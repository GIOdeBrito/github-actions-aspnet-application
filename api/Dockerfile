# Dotnet 8 project build image
FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY Api.csproj .

RUN dotnet restore

EXPOSE 8080