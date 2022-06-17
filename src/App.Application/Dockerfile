FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/App.Application/App.Application.csproj", "src/App.Application/"]
COPY ["src/App.Infra.Crosscuting/App.Infra.Crosscuting.csproj", "src/App.Infra.Crosscuting/"]
COPY ["src/App.Domain/App.Domain.csproj", "src/App.Domain/"]
COPY ["src/Lib.Contract/Lib.Contract.csproj", "src/Lib.Contract/"]
COPY ["src/App.Infra.Service/App.Infra.Service.csproj", "src/App.Infra.Service/"]
RUN dotnet restore "src/App.Application/App.Application.csproj"
COPY . .
WORKDIR "/src/src/App.Application"
RUN dotnet build "App.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Grpc.App.Application.dll"]