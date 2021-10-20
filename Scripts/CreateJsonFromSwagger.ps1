Write-Host "Create swagger.json files"

$agentDirectory = $env:Agent_ReleaseDirectory

Write-Host "Agent directory = " $agentDirectory

$pathSwagger = $agentDirectory + "\swagger.json"

Write-Host "Path Swagger = " $pathSwagger

Invoke-WebRequest -Uri "https://contosouniversityexampleapi-dev.azurewebsites.net/swagger/v1/swagger.json" | Set-Content -Path $pathSwagger

Write-Host "Swagger.json files generated"