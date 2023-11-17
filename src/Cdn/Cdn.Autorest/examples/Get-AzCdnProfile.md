### Example 1: List AzureCDN profiles under the subscription
```powershell
Get-AzCdnProfile
```

```output
Location Name             Kind ResourceGroupName
-------- ----             ---- -----------------
Global   p-oln142         cdn  testps-rg-godj4q
Global   cdn001           cdn  testps-rg-da16jm
Global   cdn002           cdn  testps-rg-da16jm
```

List AzureCDN profiles under the subscription


### Example 2: List AzureCDN profiles under the resource group
```powershell
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
Global   cdn002 cdn  testps-rg-da16jm
```

List AzureCDN profiles under the resource group


### Example 3: Get an AzureCDN profile under the resource group
```powershell
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Get an AzureCDN profile under the resource group


### Example 4: Get an AzureCDN profile under the resource group via identity
```powershell
New-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -SkuName Standard_Microsoft -Location Global | Get-AzCdnProfile
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Get an AzureCDN profile under the resource group via identity