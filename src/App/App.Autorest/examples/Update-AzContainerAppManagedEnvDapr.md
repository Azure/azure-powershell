### Example 1: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

Update-AzContainerAppManagedEnvDapr -Name azps-dapr -EnvName azps-env -ResourceGroupName azps_test_group_app -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.

### Example 2: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$managedenvdapr = Get-AzContainerAppManagedEnvDapr -Name azps-dapr -EnvName 4azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvDapr -InputObject $managedenvdapr -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.

### Example 3: Update a managed environment dapr component.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvDapr -Name azps-dapr -ManagedEnvironmentInputObject $managedenv -componentType state.azure.cosmosdb -Version v2 -IgnoreError:$false -InitTimeout 60s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----      -------------        ----------- ----------- -----------------   -------
azps-dapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Update a managed environment dapr component.