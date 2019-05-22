Write-Host "Create swagger.json files"

$agentDirectory = $env:Agent_ReleaseDirectory
Write-Host $agentDirectory

$pathSwagger = $agentDirectory + "\swagger.json"
Write-Host $pathSwagger

Invoke-WebRequest -Uri "https://contosouniversityexampleapi-dev.azurewebsites.net/swagger/v1/swagger.json" | Set-Content -Path $pathSwagger