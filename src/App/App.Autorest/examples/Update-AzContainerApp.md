### Example 1: Update container app.
```powershell
$newSecretObject = New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"
$configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $newSecretObject 

Update-AzContainerApp -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"}
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Update container app.

### Example 2: Update container app.
```powershell
$secretObject = Get-AzContainerAppSecret -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
$newSecretObject1 = New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"
$newSecretObject2 = New-AzContainerAppSecretObject -Name $secretObject.Name -Value $secretObject.Value -Identity $secretObject.Identity -KeyVaultUrl $secretObject.KeyVaultUrl
$configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $newSecretObject1,$newSecretObject2

Update-AzContainerApp -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"}
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Update container app.