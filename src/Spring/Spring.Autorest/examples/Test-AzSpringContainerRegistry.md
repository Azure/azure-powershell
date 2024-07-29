### Example 1: Check if the container registry properties are valid.
```powershell
$containerRegistryObj = New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
Test-AzSpringContainerRegistry -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -ContainerRegistryProperty $containerRegistryObj
```

```output
IsValid Message
------- -------
  False credential cannot be null.:
```

Check if the container registry properties are valid.