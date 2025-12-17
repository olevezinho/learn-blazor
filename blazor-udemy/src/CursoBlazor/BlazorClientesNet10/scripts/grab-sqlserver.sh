#!/bin/bash
alias docker=podman
docker image pull mcr.microsoft.com/mssql/server:2025-latest
docker volume create --name sql-data
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=DockerSql2025!' -e 'MSSQL_PID=Evaluation' -p 1433:1433 --name sqlserver -v sql-data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2025-latest