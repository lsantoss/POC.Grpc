FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/POC.Grpc.Api.Application/POC.Grpc.Api.Application.csproj", "src/POC.Grpc.Api.Application/"]
COPY ["src/POC.Grpc.Api.Infra.Crosscuting/POC.Grpc.Api.Infra.Crosscuting.csproj", "src/POC.Grpc.Api.Infra.Crosscuting/"]
COPY ["src/POC.Grpc.Api.Infra.Data/POC.Grpc.Api.Infra.Data.csproj", "src/POC.Grpc.Api.Infra.Data/"]
COPY ["src/POC.Grpc.Api.Infra/POC.Grpc.Api.Infra.csproj", "src/POC.Grpc.Api.Infra/"]
COPY ["src/POC.Grpc.Api.Domain/POC.Grpc.Api.Domain.csproj", "src/POC.Grpc.Api.Domain/"]
COPY ["src/POC.Grpc.Lib.Contract/POC.Grpc.Lib.Contract.csproj", "src/POC.Grpc.Lib.Contract/"]
RUN dotnet restore "src/POC.Grpc.Api.Application/POC.Grpc.Api.Application.csproj"
COPY . .
WORKDIR "/src/src/POC.Grpc.Api.Application"
RUN dotnet build "POC.Grpc.Api.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Grpc.Api.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.Api.Application.dll"]