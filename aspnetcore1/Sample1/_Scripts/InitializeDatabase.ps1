#docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux

Write-Host "Delete container/Image if exists"
docker image rm -f sql-demo-sample
docker rm -f sql-demo-sample

Write-Host "Creating Docker image"
docker build -t sql-demo-sample ./DockerSqlServer

Write-Host "Running Docker container"
docker run --name sql-demo-sample -p 1433:1433 -d sql-demo-sample
Write-Host "Waiting 20s for SQL Server to Start"
Start-Sleep -s 20

Write-Host "Creating Database and objects"
docker exec sql-demo-sample /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Qwerty12 -i /dbscript.sql