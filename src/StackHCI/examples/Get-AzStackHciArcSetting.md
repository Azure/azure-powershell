### Example 1:
```powershell
Get-AzStackHciArcSetting -ResourceGroupName test-rg -ClusterName myCluster
```

```output
Resource Group AggregateState
-------------- --------------
test-rg        Connected
```

Gets arcSettings in a cluster. To see the details use : "Write-Host( $arcSettings | Format-List | Out-String)"