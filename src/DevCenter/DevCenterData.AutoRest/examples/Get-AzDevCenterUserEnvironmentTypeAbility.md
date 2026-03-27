### Example 1: Get the signed-in user's abilities for an environment type by endpoint
```powershell
Get-AzDevCenterUserEnvironmentTypeAbility `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -EnvironmentTypeName "DevTest"
```
This command gets the permitted abilities for the signed-in user in the "DevTest" environment type for the project "DevProject" using the endpoint.

### Example 2: Get a specific user's abilities for an environment type by dev center name
```powershell
Get-AzDevCenterUserEnvironmentTypeAbility `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -EnvironmentTypeName "DevTest" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```
This command gets the permitted abilities for user "786a823c-8037-48ab-89b8-8599901e67d0" in the "DevTest" environment type for the project "DevProject" using the dev center name.

### Example 3: Get the signed-in user's abilities for an environment type using InputObject and endpoint
```powershell
$envTypeInput = @{
    ProjectName = "DevProject"
    EnvironmentTypeName = "DevTest"
}
Get-AzDevCenterUserEnvironmentTypeAbility `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $envTypeInput
```
This command gets the permitted abilities for the signed-in user in the "DevTest" environment type using the endpoint and an identity object.

### Example 4: Get the signed-in user's abilities for an environment type using InputObject and dev center name
```powershell
$envTypeInput = @{
    ProjectName = "DevProject"
    EnvironmentTypeName = "DevTest"
}
Get-AzDevCenterUserEnvironmentTypeAbility `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $envTypeInput
```
This command gets the permitted abilities for the signed-in user in the "DevTest" environment type using the dev center name and an identity object.