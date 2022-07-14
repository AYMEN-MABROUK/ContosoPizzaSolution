FROM library/postgres:alpine

EXPOSE 5433

ENV POSTGRES_USER=postgres
ENV POSTGRES_DB=Training_DB
ENV POSTGRES_PASSWORD=admin

RUN mkdir -p /docker-entrypoint-initdb.d/
COPY ./init.sql ./docker-entrypoint-initdb.d/