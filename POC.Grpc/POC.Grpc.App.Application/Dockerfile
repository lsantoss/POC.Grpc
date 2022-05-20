FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["POC.Grpc.App.Application/POC.Grpc.App.Application.csproj", "POC.Grpc.App.Application/"]
COPY ["POC.Grpc.App.Infra.Crosscuting/POC.Grpc.App.Infra.Crosscuting.csproj", "POC.Grpc.App.Infra.Crosscuting/"]
COPY ["POC.Grpc.App.Infra.Service/POC.Grpc.App.Infra.Service.csproj", "POC.Grpc.App.Infra.Service/"]
COPY ["POC.Grpc.App.Domain/POC.Grpc.App.Domain.csproj", "POC.Grpc.App.Domain/"]
COPY ["POC.Grpc.Lib/POC.Grpc.Lib.csproj", "POC.Grpc.Lib/"]
RUN dotnet restore "POC.Grpc.App.Application/POC.Grpc.App.Application.csproj"
COPY . .
WORKDIR "/src/POC.Grpc.App.Application"
RUN dotnet build "POC.Grpc.App.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Grpc.App.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.App.Application.dll"]