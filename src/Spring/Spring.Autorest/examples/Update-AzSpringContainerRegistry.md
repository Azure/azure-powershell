### Example 1: Update container registry resource.
```powershell
$containerRegistryObj = New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
Update-AzSpringContainerRegistry -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Credentials $containerRegistryObj
```

Update container registry resource.