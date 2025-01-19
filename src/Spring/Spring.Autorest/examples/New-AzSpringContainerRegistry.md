### Example 1: Create container registry resource.
```powershell
$containerRegistryObj = New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
New-AzSpringContainerRegistry -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Credentials $containerRegistryObj
```

Create container registry resource.

### Example 2: Create container registry resource.
```powershell
$jsonStr = '
{
  "properties": {
    "credentials": {
      "type": "BasicAuth",
      "server": "containerregistry.azurecr.io",
      "username": "containerregistry",
      "password": "an+Z******XRJX"
    }
  }
}'
New-AzSpringContainerRegistry -Name default -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -JsonString $jsonStr
```

Create container registry resource.