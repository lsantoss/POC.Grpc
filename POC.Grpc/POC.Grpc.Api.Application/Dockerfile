FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["POC.Grpc.Api.Application/POC.Grpc.Api.Application.csproj", "POC.Grpc.Api.Application/"]
COPY ["POC.Grpc.Api.Infra.Crosscuting/POC.Grpc.Api.Infra.Crosscuting.csproj", "POC.Grpc.Api.Infra.Crosscuting/"]
COPY ["POC.Grpc.Api.Infra.Data/POC.Grpc.Api.Infra.Data.csproj", "POC.Grpc.Api.Infra.Data/"]
COPY ["POC.Grpc.Api.Domain/POC.Grpc.Api.Domain.csproj", "POC.Grpc.Api.Domain/"]
COPY ["POC.Grpc.Lib/POC.Grpc.Lib.csproj", "POC.Grpc.Lib/"]
RUN dotnet restore "POC.Grpc.Api.Application/POC.Grpc.Api.Application.csproj"
COPY . .
WORKDIR "/src/POC.Grpc.Api.Application"
RUN dotnet build "POC.Grpc.Api.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Grpc.Api.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.Api.Application.dll"]