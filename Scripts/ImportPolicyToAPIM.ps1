Write-Host "Import XML Policy"

$agentDirectory = $env:Agent_ReleaseDirectory
Write-Host "Agent directory = " $agentDirectory

$pathXml = $agentDirectory + "\PoliciesAPIM.xml"
Write-Host "Path Swagger = " $pathSwagger

$apimContext = New-AzApiManagementContext -ResourceGroupName "RG_ContosoUniversity" -ServiceName "ContosoUniversity"
Set-AzApiManagementPolicy -Context $apimContext -ApiId "ContosoUniversityAPI" -PolicyFilePath $pathXml

Write-Host "Import successful"