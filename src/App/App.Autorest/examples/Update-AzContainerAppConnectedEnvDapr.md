### Example 1: Create a Dapr Component in a connected environment.
```powershell
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"

Update-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr -ComponentType "state.azure.cosmosdb" -Version v2 -IgnoreError:$false -InitTimeout 60s -Secret $secretObject -Metadata $daprMetaData
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Create a Dapr Component in a connected environment.

### Example 2: Create a Dapr Component in a connected environment.
```powershell
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Update-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvdapr -ComponentType "state.azure.cosmosdb" -Version v2 -IgnoreError:$false -InitTimeout 60s -Secret $secretObject -Metadata $daprMetaData
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Create a Dapr Component in a connected environment.

### Example 3: Create a Dapr Component in a connected environment.
```powershell
$secretObject = New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
$daprMetaData = New-AzContainerAppDaprMetadataObject -Name "masterkey" -Value "masterkey"
$connectedenvdapr = Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr

Update-AzContainerAppConnectedEnvDapr -InputObject $connectedenvdapr -ComponentType "state.azure.cosmosdb" -Version v2 -IgnoreError:$false -InitTimeout 60s -Secret $secretObject -Metadata $daprMetaData
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       60s         azps_test_group_app v2
```

Create a Dapr Component in a connected environment.