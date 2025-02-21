# Base image for .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use .NET SDK to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Install Node.js (required for frontend build)
RUN apt-get update && apt-get install -y curl
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash -
RUN apt-get install -y nodejs

# Copy only project files for caching
COPY FullStackDemo.Server/FullStackDemo.Server.csproj FullStackDemo.Server/
COPY fullstackdemo.client/fullstackdemo.client.esproj fullstackdemo.client/
RUN dotnet restore FullStackDemo.Server/FullStackDemo.Server.csproj

# Copy the rest of the source code
COPY FullStackDemo.Server/ FullStackDemo.Server/
COPY fullstackdemo.client/ fullstackdemo.client/

# Move to backend project directory
WORKDIR /source/FullStackDemo.Server

# Debugging: Check if Node.js is installed
RUN node --version

# Build the backend
RUN dotnet build -c Release -o /app/build

# Publish the backend
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FullStackDemo.Server.dll"]
