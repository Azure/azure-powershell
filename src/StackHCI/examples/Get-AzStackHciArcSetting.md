### Example 1: {{ Add title here }}
```powershell
Get-AzStackHciArcSetting -ResourceGroupName test-rg -ClusterName myCluster
```

```output
Name
----
default
```

Gets arcSettings in a cluster. To see the details use :
```powershell
Write-Host( $arcSettings | Format-List | Out-String)
```