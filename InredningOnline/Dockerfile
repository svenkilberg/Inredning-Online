#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# First stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /App
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY /src/InredningOnline/*.csproj ./src/InredningOnline/
COPY test/InredningOnline.Tests/*.csproj ./test/InredningOnline.Tests/
RUN dotnet restore

# Copy everything else and build website
COPY /src/InredningOnline/. ./src/InredningOnline/
WORKDIR /App/src/InredningOnline/
RUN dotnet publish -c release -o /AppOutput/InredningOnline --no-restore

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /AppOutput/InredningOnline/
COPY --from=build /AppOutput/InredningOnline ./
#ENTRYPOINT ["dotnet", "InredningOnline.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet InredningOnline.dll