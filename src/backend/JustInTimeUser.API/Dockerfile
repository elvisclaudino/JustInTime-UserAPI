# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["JustInTimeUserAPI/src/backend/JustInTimeUser.API/JustInTimeUser.API.csproj", "JustInTimeUser.API/"]
COPY ["JustInTimeUserAPI/src/shared/JustInTimeUser.Communication/JustInTimeUser.Communication.csproj", "JustInTimeUser.Communication/"]
COPY ["JustInTimeUserAPI/src/backend/JustInTimeUser.Application/JustInTimeUser.Application.csproj", "JustInTimeUser.Application/"]

# Restaura as dependências
RUN dotnet restore "JustInTimeUserAPI/src/backend/JustInTimeUser.API.csproj"

# Copie o restante do código
COPY JustInTimeUserAPI/src/ ./

# Build the application
WORKDIR "/src/JustInTimeUser.API"
RUN dotnet build "JustInTimeUser.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "JustInTimeUser.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image with the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JustInTimeUser.API.dll"]
