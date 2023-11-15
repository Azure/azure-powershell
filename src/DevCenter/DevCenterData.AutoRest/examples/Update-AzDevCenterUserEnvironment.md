### Example 1: Update an environment by endpoint
```powershell
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

Update-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -Name "envtest" -ProjectName DevProject -ExpirationDate $dateIn8Months
```
This command updates an environment named "envtest" to the project "DevProject".

### Example 2: Update an environment by dev center
```powershell
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

Update-AzDevCenterUserEnvironment -DevCenterName Contoso -Name "envtest" -ProjectName DevProject -ExpirationDate $dateIn8Months
```
This command updates an environment named "envtest" to the project "DevProject".

### Example 3: Update an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

Update-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput -ExpirationDate $dateIn8Months

```
This command updates an environment named "envtest" to the project "DevProject".

### Example 4: Update an environment by dev center and InputObject
```powershell
$currentDate = Get-Date
$dateIn8Months = $currentDate.AddMonths(8)

$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "envtest" }

Update-AzDevCenterUserEnvironment -DevCenterName Contoso -InputObject $envInput -ExpirationDate $dateIn8Months
```
This command updates an environment named "envtest" to the project "DevProject".