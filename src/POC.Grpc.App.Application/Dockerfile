FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/POC.Grpc.App.Application/POC.Grpc.App.Application.csproj", "src/POC.Grpc.App.Application/"]
COPY ["src/POC.Grpc.App.Domain/POC.Grpc.App.Domain.csproj", "src/POC.Grpc.App.Domain/"]
COPY ["src/POC.Grpc.Lib.Contract/POC.Grpc.Lib.Contract.csproj", "src/POC.Grpc.Lib.Contract/"]
COPY ["src/POC.Grpc.App.Infra.Service/POC.Grpc.App.Infra.Service.csproj", "src/POC.Grpc.App.Infra.Service/"]
COPY ["src/POC.Grpc.App.Infra/POC.Grpc.App.Infra.csproj", "src/POC.Grpc.App.Infra/"]
RUN dotnet restore "src/POC.Grpc.App.Application/POC.Grpc.App.Application.csproj"
COPY . .
WORKDIR "/src/src/POC.Grpc.App.Application"
RUN dotnet build "POC.Grpc.App.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Grpc.App.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.App.Application.dll"]