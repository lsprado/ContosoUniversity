Write-Host "Create Header"
$headers = @{
    'Ocp-Apim-Subscription-Key' = '5c0927ce4e1749f584cc8e6750599e61'
}

Write-Host "Courses"
for ($i = 0; $i -lt 100; $i++) {
    Write-Host $i
    Invoke-RestMethod -Uri 'https://apim-contosouniversityarmtemplateapim.azure-api.net/ContosoUniversity/api/Courses' -Headers $headers
}

Write-Host "Courses By Id"
Invoke-RestMethod -Uri 'https://apim-contosouniversityarmtemplateapim.azure-api.net/ContosoUniversity/api/Courses/10' -Headers $headers

Write-Host "Departments"
Invoke-RestMethod -Uri 'https://apim-contosouniversityarmtemplateapim.azure-api.net/ContosoUniversity/api/Departments' -Headers $headers

Write-Host "Instructors"
Invoke-RestMethod -Uri 'https://apim-contosouniversityarmtemplateapim.azure-api.net/ContosoUniversity/api/Instructors' -Headers $headers

Write-Host "Students"
Invoke-RestMethod -Uri 'https://apim-contosouniversityarmtemplateapim.azure-api.net/ContosoUniversity/api/Students' -Headers $headers