### Example 1: Create a Web PubSub resource with minimal required parameters.
```powershell
New-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps -Location eastus -SkuName Standard_S1
```

```output
Name                Location      SkuName
----                --------      -------
psdemo-wps          eastus        Standard_S1
```



### Example 2: Create a Web PubSub resource with more parameters and show the result
```powershell
$wps = New-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps `
-Location eastus -SkuName Standard_S1 -IdentityType SystemAssigned -LiveTraceEnabled true `
-LiveTraceCategory @{ Name='ConnectivityLogs' ; Enabled = 'true' }, @{ Name='MessageLogs' ; Enabled = 'true' }
```

```output
Name                Location      SkuName
----                --------      -------
psdemo-wps          eastus        Standard_S1
```


