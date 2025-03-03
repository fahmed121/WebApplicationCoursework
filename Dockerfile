From mcr.microsoft.com/dotnet/sdk;9.0 AS build

WORKDIR /src

Copy ["src/WebAplicationCoursework/WebAplicationCoursework.csproj", "WebAplicationCoursework/"]
RUN dotnet restore 'WebAplicationCoursework/WebAplicationCoursework.csproj'

COPY ["src/WebAplicationCoursework", "WebAplicationCoursework"]
WORKDIR /src/WebAplicationCoursework
RUN dotnet build 'WebAplicationCoursework.csproj' -c Release -o /app/build

From build as publish

RUN dotnet publist 'WebAplicationCoursework.csproj' -c Release -o /app/publish

From mcr.microsoft.com/dotnet/aspnet;9.0
ENV ASPNETCORE_HTTP_PORTS=5001
Expose 5001
WORKDIR /app
Copy --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "WebAplicationCoursework.dll" ]