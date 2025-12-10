#!/bin/bash

docker cp sqlserver:/var/opt/mssql ~/Documents/Backups/
docker stop --time=120 sqlserver