#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 2230
EXPOSE 2231

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NSI.WebApi/NSI.WebApi.csproj", "NSI.WebApi/"]
COPY ["NSI.BusinessLayer/NSI.BusinessLayer.csproj", "NSI.BusinessLayer/"]
COPY ["NSI.DataTransferObject/NSI.DataTransferObject.csproj", "NSI.DataTransferObject/"]
COPY ["NSI.Shared/NSI.Shared.csproj", "NSI.Shared/"]
COPY ["NSI.UnitOfWork/NSI.UnitOfWork.csproj", "NSI.UnitOfWork/"]
COPY ["NSI.DataAccessLayer/NSI.DataAccessLayer.csproj", "NSI.DataAccessLayer/"]
COPY ["NSI.Entity/NSI.Entity.csproj", "NSI.Entity/"]
COPY ["NSI.Repository/NSI.Repository.csproj", "NSI.Repository/"]
COPY ["NSI.Service/NSI.Service.csproj", "NSI.Service/"]
COPY ["NSI.Validation/NSI.Validation.csproj", "NSI.Validation/"]
RUN dotnet restore "./NSI.WebApi/./NSI.WebApi.csproj"
COPY . .
WORKDIR "/src/NSI.WebApi"
RUN dotnet build "./NSI.WebApi.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NSI.WebApi.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSI.WebApi.dll"]