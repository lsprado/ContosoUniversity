Write-Host "Import XML Policy"

$agentDirectory = $env:Agent_ReleaseDirectory
Write-Host "Agent directory = " $agentDirectory

$primaryArtifact = $env:RELEASE_PRIMARYARTIFACTSOURCEALIAS
Write-Host "Primary Artifact" + $primaryArtifact

$pathXml = $agentDirectory + "\" + $primaryArtifact + "\Scripts\PoliciesAPIM.xml"
Write-Host "Path XML Policy = " $pathXml

$ApiMgmtContext = New-AzApiManagementContext -ResourceGroupName "RG_ContosoUniversity" -ServiceName "ContosoUniversity"
Set-AzApiManagementPolicy -Context $ApiMgmtContext -ApiId "ContosoUniversityAPI" -PolicyFilePath $pathXml

Write-Host "Import XML successful"