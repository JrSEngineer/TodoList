FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3000
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TodoList/TodoList.csproj", "TodoList/"]
COPY ["TodoList.Domain/TodoList.Domain.csproj", "TodoList.Domain/"]
COPY ["TodoList.Infra/TodoList.Infra.csproj", "TodoList.Infra/"]
RUN dotnet restore "./TodoList/TodoList.csproj"
COPY . .
WORKDIR "/src/TodoList"
RUN dotnet build "./TodoList.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TodoList.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoList.dll"]