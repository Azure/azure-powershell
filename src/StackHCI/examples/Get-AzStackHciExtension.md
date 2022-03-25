### Example 1: 
```powershell
Get-AzStackHciExtension -ResourceGroupName test-rg -ClusterName myCluster -ArcSettingName "default"
```

```output
Name
----
MicrosoftMonitoringAgent
```

Gets extensions in an arcSetting of a cluster. To see the details use :
```powershell
Write-Host( $extension | Format-List | Out-String)
```


