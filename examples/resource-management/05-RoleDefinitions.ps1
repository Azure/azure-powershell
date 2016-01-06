Param(
  [string]$groupName,
  [string]$location
)

Write-Host "=== Managing Role Definitions in Azure ==="

Write-Host "1. Create a new resource group"
New-AzureRmResourceGroup -Name $groupName -Location $location

Write-Host "2. Creating a new Role Definition."
$rd = New-AzureRmRoleDefinition -InputFile roleDefinition.json

Write-Host "3. Get information about Role Definitions."
Get-AzureRmRoleDefinition -Name $rd.Name

Write-Host "4. Update Role Definition."
$rd.Actions.Add('Microsoft.Authorization/*/write')
$updatedRd = Set-AzureRmRoleDefinition -Role $rd
Assert-NotNull $updatedRd

Write-Host "5. Delete Role Definition."
Remove-AzureRmRoleDefinition -Id $rd.Id -Force -PassThru
$readRd = Get-AzureRmRoleDefinition -Name $rd.Name
Assert-Null $readRd