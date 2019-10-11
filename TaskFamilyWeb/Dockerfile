#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["TaskFamilyWeb/TaskFamilyWeb.csproj", "TaskFamilyWeb/"]
COPY ["ClassLibModel/TaskFamilyModels.csproj", "ClassLibModel/"]
COPY ["TaskFamilyDbContext/TaskFamilyDbContext.csproj", "TaskFamilyDbContext/"]
RUN dotnet restore "TaskFamilyWeb/TaskFamilyWeb.csproj"
COPY . .
WORKDIR "/src/TaskFamilyWeb"
RUN dotnet build "TaskFamilyWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskFamilyWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskFamilyWeb.dll"]