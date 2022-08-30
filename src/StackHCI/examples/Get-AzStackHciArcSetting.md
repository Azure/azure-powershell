### Example 1:
```powershell
Get-AzStackHciArcSetting -ResourceGroupName test-rg -ClusterName myCluster
```

```output
Name    ResourceGroupName
----    -----------------
default test-rg
```

Gets arcSettings in a cluster. To see the details use : "Write-Host( $arcSettings | Format-List | Out-String)"