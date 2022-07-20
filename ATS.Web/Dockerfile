#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ATS.Web/ATS.Web.csproj", "ATS.Web/"]
COPY ["ATS.Domain/ATS.Domain.csproj", "ATS.Domain/"]
COPY ["ATS.Application/ATS.Application.csproj", "ATS.Application/"]
COPY ["ATS.Infra/ATS.Infra.csproj", "ATS.Infra/"]
RUN dotnet restore "ATS.Web/ATS.Web.csproj"
COPY . .
WORKDIR "/src/ATS.Web"
RUN dotnet build "ATS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATS.Web.dll"]