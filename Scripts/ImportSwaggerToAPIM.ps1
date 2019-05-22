Write-Host "Import swagger.json files to APIM"

$agentDirectory = $env:Agent_ReleaseDirectory
Write-Host "Agent directory = " $agentDirectory

$pathSwagger = $agentDirectory + "\swagger.json"
Write-Host "Path Swagger = " $pathSwagger

$ApiMgmtContext = New-AzApiManagementContext -ResourceGroupName "RG_ContosoUniversity" -ServiceName "ContosoUniversity"
Import-AzApiManagementApi -Context $ApiMgmtContext -SpecificationFormat "Swagger" -SpecificationPath $pathSwagger -Path "apis" -ApiId "ContosoUniversityAPI"

Write-Host "Import successful"