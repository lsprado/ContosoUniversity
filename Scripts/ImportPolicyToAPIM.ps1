Write-Host "Import XML Policy"

$agentDirectory = $env:Agent_ReleaseDirectory
Write-Host "Agent directory = " $agentDirectory

$pathXml = $agentDirectory + "\PoliciesAPIM.xml"
Write-Host "Path Swagger = " $pathSwagger

$apimContext = New-AzApiManagementContext -ResourceGroupName "RG_ContosoUniversity" -ServiceName "ContosoUniversity"
Set-AzApiManagementPolicy -Context $apimContext -ApiId "ff86ccbd70a1488ab7fea0ce255a420b" -PolicyFilePath $pathXml

Write-Host "Import successful"