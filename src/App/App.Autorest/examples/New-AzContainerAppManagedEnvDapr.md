### Example 1: Creates or updates a Dapr Component in a Managed Environment.
```powershell
$scope = @("container-app-1","container-app-2")
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

New-AzContainerAppManagedEnvDapr -DaprName azps-dapr -EnvName azps-env -ResourceGroupName azpstest_gp -componentType state.azure.cosmosdb -Version v1 -IgnoreError:$false -InitTimeout 50s -Scope $scope -Secret $secretObject -Metadata $daprMetaData
```

```output
Name      ComponentType        IgnoreError InitTimeout ResourceGroupName Version
----      -------------        ----------- ----------- ----------------- -------
azps-dapr state.azure.cosmosdb False       50s         azpstest_gp       v1
```

Creates or updates a Dapr Component in a Managed Environment.