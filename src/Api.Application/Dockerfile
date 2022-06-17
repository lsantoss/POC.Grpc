FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api.Application/Api.Application.csproj", "src/Api.Application/"]
COPY ["src/Api.Infra.Crosscuting/Api.Infra.Crosscuting.csproj", "src/Api.Infra.Crosscuting/"]
COPY ["src/Api.Infra.Data/Api.Infra.Data.csproj", "src/Api.Infra.Data/"]
COPY ["src/Api.Domain/Api.Domain.csproj", "src/Api.Domain/"]
COPY ["src/Lib.Contract/Lib.Contract.csproj", "src/Lib.Contract/"]
RUN dotnet restore "src/Api.Application/Api.Application.csproj"
COPY . .
WORKDIR "/src/src/Api.Application"
RUN dotnet build "Api.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.Api.Application.dll"]