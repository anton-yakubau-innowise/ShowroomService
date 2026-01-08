FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
EXPOSE 8080

COPY ["ShowroomService.sln", "ShowroomService.sln"]
COPY ["ShowroomService.API/ShowroomService.API.csproj", "ShowroomService.API/"]
COPY ["ShowroomService.Application/ShowroomService.Application.csproj", "ShowroomService.Application/"]
COPY ["ShowroomService.Domain/ShowroomService.Domain.csproj", "ShowroomService.Domain/"]
COPY ["ShowroomService.Infrastructure/ShowroomService.Infrastructure.csproj", "ShowroomService.Infrastructure/"]

RUN dotnet restore "ShowroomService.sln"

COPY . .

WORKDIR "/src/ShowroomService.API"
RUN dotnet publish "ShowroomService.API.csproj" -c Release -o /app/publish





FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "ShowroomService.API.dll"]