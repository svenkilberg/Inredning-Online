#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /InredningOnline
COPY ["InredningOnline/InredningOnline.csproj", "InredningOnline/"]
RUN dotnet restore "InredningOnline/InredningOnline.csproj"
COPY . .
WORKDIR "InredningOnline"
RUN dotnet build "InredningOnline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InredningOnline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "InredningOnline.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet InredningOnline.dll