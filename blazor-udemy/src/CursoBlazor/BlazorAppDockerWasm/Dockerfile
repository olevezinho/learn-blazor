FROM mcr.microsoft.com/dotnet/sdk:10.0.100-alpine3.22-amd64 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

ENV PYTHONUNBUFFERED=1
RUN apk add --update --no-cache python3 && ln -sf python3 /usr/bin/python

RUN dotnet workload config --update-mode manifests
RUN dotnet workload update --version 10.0.100

COPY BlazorAppDockerWasm.csproj .
RUN dotnet restore BlazorAppDockerWasm.csproj

COPY . .
RUN dotnet build BlazorAppDockerWasm.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish BlazorAppDockerWasm.csproj -c $BUILD_CONFIGURATION -o /app/publish

FROM docker.io/library/nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
