### Example 1: Update an AzureCDN profile under the resource group
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Update-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -Tag $tags
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Update an AzureCDN profile under the resource group


### Example 2: Update an AzureCDN profile under the resource group via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2  = 22
}
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 | Update-AzCdnProfile -Tag $tags
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Update an AzureCDN profile under the resource group via identity

