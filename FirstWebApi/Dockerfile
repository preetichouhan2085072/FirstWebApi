#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FirstWebApi/FirstWebApi.csproj", "FirstWebApi/"]
RUN dotnet restore "FirstWebApi/FirstWebApi.csproj"
COPY . .
WORKDIR "/src/FirstWebApi"
RUN dotnet build "FirstWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FirstWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstWebApi.dll"]



FROM mcr.microsoft.com/dotnet/core/sdk:3.1AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
# Build runtime image
FROMmcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FirstWebApi.dll"]
