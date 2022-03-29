### Example 1: 
```powershell
Get-AzStackHciExtension -ResourceGroupName test-rg -ClusterName myCluster -ArcSettingName "default"
```

```output
Name                     ResourceGroupName
----                     -----------------
MicrosoftMonitoringAgent test-rg
```

Gets extensions in an arcSetting of a cluster. To see the details use : "Write-Host( $extension | Format-List | Out-String)"


