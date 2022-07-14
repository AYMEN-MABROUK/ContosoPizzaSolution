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
FROM build AS test
ARG BuildId
LABEL test=${BuildId}
RUN dotnet test -c Release --results-directory testresults --logger "trx;LogFileName=test_results.trx" contoso_pizza_backend.Tests/contoso_pizza_backend.Tests.csproj


# publish the API
FROM build AS publish
RUN dotnet publish "contoso_pizza_backend/contoso_pizza_backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "contoso_pizza_backend.dll"]