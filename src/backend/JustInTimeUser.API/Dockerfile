#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/backend/JustInTimeUser.API/JustInTimeUser.API.csproj", "src/backend/JustInTimeUser.API/"]
COPY ["src/shared/JustInTimeUser.Communication/JustInTimeUser.Communication.csproj", "src/shared/JustInTimeUser.Communication/"]
COPY ["src/backend/JustInTimeUser.Application/JustInTimeUser.Application.csproj", "src/backend/JustInTimeUser.Application/"]
RUN dotnet restore "./src/backend/JustInTimeUser.API/./JustInTimeUser.API.csproj"
COPY . .
WORKDIR "/src/src/backend/JustInTimeUser.API"
RUN dotnet build "./JustInTimeUser.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./JustInTimeUser.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JustInTimeUser.API.dll"]