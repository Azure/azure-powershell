### Example 1: 
```powershell
New-AzStackHciExtension -ArcSettingName "default" -ClusterName "myCluster" -Name "MicrosoftMonitoringAgent" -ResourceGroupName test-rg
```

```output
Name                     ResourceGroupName
----                     -----------------
MicrosoftMonitoringAgent test-rg
```

Creates a new arc extension. 

### Example 2:
```powershell
$Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
New-AzStackHciExtension -ArcSettingName "default" -ClusterName "myCluster" -Name "MicrosoftMonitoringAgent" -ResourceGroupName test-rg -ExtensionParameterPublisher "Microsoft.Compute" -ExtensionParameterType "MicrosoftMonitoringAgent" -ExtensionParameterProtectedSetting $Settings
```

```output
Name                     ResourceGroupName
----                     -----------------
MicrosoftMonitoringAgent test-rg
```

Creates new arc extension with the given parameters 
