FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PropertyManagement/PropertyManagement.csproj", "PropertyManagement/"]
RUN dotnet restore "PropertyManagement/PropertyManagement.csproj"
COPY . .
WORKDIR "/src/PropertyManagement"
RUN dotnet build "PropertyManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PropertyManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PropertyManagement.dll"]
