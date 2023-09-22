### Example 1: Create a Dapr Component in a connected environment.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

New-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr -ComponentType "state.azure.cosmosdb" -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName    Version
----                  -------------        ----------- ----------- -----------------    -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Create a Dapr Component in a connected environment.