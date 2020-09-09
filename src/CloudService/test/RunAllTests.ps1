$envFile = 'env.json'
$env = Get-Content (Join-Path $PSScriptRoot $envFile) | ConvertFrom-Json

Write-Host -ForegroundColor Cyan "Running all Az.CloudService module tests"
& "$PSScriptRoot\New-AzCloudService.Tests.ps1"

# Loop until timeout for Cloud Service to start
$timeout = (Get-Date).AddMinutes($env.TimeoutInMinutes)
Do {
  Start-Sleep -Seconds 10
  $cloudServiceInstanceView = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -InstanceView -ErrorAction SilentlyContinue
} while (((Get-Date) -le $timeout) -and (($cloudServiceInstanceView -eq $NULL) -or ($cloudServiceInstanceView.Statuses[1].Code -ne $env.PowerStateStartedCode)))

if (($cloudServiceInstanceView -eq $NULL) -or ($cloudServiceInstanceView.Statuses[1].Code -ne $env.PowerStateStartedCode)) {
  Write-Error ("Creation of CloudService does not succeed in " +  $env.TimeoutInMinutes + " minutes.") -ErrorAction Stop
}

& "$PSScriptRoot\Get-AzCloudService.Tests.ps1"
& "$PSScriptRoot\Get-AzCloudServiceRoleInstance.Tests.ps1"
& "$PSScriptRoot\Update-AzCloudService.Tests.ps1"
& "$PSScriptRoot\Reset-AzCloudServiceRoleInstance.Tests.ps1"
& "$PSScriptRoot\Reset-AzCloudService.Tests.ps1"
& "$PSScriptRoot\Stop-AzCloudService.Tests.ps1"
& "$PSScriptRoot\Start-AzCloudService.Tests.ps1"
& "$PSScriptRoot\Remove-AzCloudServiceRoleInstance.Tests.ps1"
& "$PSScriptRoot\Remove-AzCloudService.Tests.ps1"

# Delete the Resource Group
Remove-AzResourceGroup -ResourceGroupName $env.ResourceGroupName -Force
