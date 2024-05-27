### Example 1: Create container registry resource.
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