#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HardWaxReborn/HardWaxReborn.csproj", "HardWaxReborn/"]
COPY ["HardWaxReborn.Domain/HardWaxReborn.Domain.csproj", "HardWaxReborn.Domain/"]
COPY ["HardWaxReborn.DAL/HardWaxReborn.DAL.csproj", "HardWaxReborn.DAL/"]
RUN dotnet restore "HardWaxReborn/HardWaxReborn.csproj"
COPY . .
WORKDIR "/src/HardWaxReborn"
RUN dotnet build "HardWaxReborn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HardWaxReborn.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HardWaxReborn.dll"]