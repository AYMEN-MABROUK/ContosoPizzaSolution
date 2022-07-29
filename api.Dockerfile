#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["ContosoPizzaSolution.sln", "."]
COPY ["contoso_pizza_backend/contoso_pizza_backend.csproj", "contoso_pizza_backend/"]
COPY ["contoso_pizza_backend.Tests/contoso_pizza_backend.Tests.csproj", "contoso_pizza_backend.Tests/"]
RUN dotnet restore "contoso_pizza_backend/contoso_pizza_backend.csproj"
RUN dotnet restore "contoso_pizza_backend.Tests/contoso_pizza_backend.Tests.csproj"

# copy full solution over
COPY . .
RUN dotnet build "contoso_pizza_backend/contoso_pizza_backend.csproj" -c Release -o /app/build
RUN dotnet build "contoso_pizza_backend.Tests/contoso_pizza_backend.Tests.csproj" -c Release -o /app/build


# run the unit tests
FROM build as testrunner
WORKDIR /src/contoso_pizza_backend.Tests/

RUN dotnet tool install dotnet-reportgenerator-globaltool --tool-path /dotnetglobaltools
LABEL unittestlayer=true
RUN dotnet test --logger "trx;LogFileName=dockerunittestspiketestresults.xml" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/out/testresults/coverage/ /p:Exclude="[xunit.*]*" --results-directory /out/testresults
RUN /dotnetglobaltools/reportgenerator "-reports:/out/testresults/coverage/coverage.cobertura.xml" "-targetdir:/out/testresults/coverage/reports" "-reporttypes:HTMLInline;HTMLChart"
 


# publish the API
FROM build AS publish
RUN dotnet publish "contoso_pizza_backend/contoso_pizza_backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "contoso_pizza_backend.dll"]