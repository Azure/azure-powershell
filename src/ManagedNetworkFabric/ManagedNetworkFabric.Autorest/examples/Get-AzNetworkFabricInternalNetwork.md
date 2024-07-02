### Example 1: List Internal Networks
```powershell
Get-AzNetworkFabricInternalNetwork -L3IsolationDomainName $l3name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation BgpConfiguration
------------------- ---------- ----------------
Enabled                        
```

This command lists all the Internal Networks.

### Example 2: Get Internal Network
```powershell
Get-AzNetworkFabricInternalNetwork -L3IsolationDomainName $l3name -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation BgpConfiguration
------------------- ---------- ----------------
Enabled                        
```

This command gets details of the given Internal Network.

