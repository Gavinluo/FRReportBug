#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM hub.360scm.com/library/aspnet-qt:3.1-font AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FR2022ReportBug.csproj", "."]
RUN dotnet restore "./FR2022ReportBug.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FR2022ReportBug.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FR2022ReportBug.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FR2022ReportBug.dll"]