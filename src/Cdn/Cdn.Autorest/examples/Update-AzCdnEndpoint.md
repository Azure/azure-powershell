### Example 1: Update an AzureCDN Endpoint under the AzureCDN profile
```powershell
$tags = @{
    Tag1 = 11
    Tag2 = 22
}
Update-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 -Tag $tags -DefaultOriginGroupId $originGroup.Id
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile


### Example 2: Update an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
$tags = @{
    Tag1 = 11
    Tag2 = 22
}
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Update-AzCdnEndpoint -Tag $tags -DefaultOriginGroupId $originGroup.Id
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile via identity


### Example 3: Update an AzureCDN Endpoint under the AzureCDN profile, enabled content compression
```powershell
Update-AzCdnEndpoint -Name cdntestcert -ProfileName classicCDNtest -ResourceGroupName yaoshitest -IsCompressionEnabled:$true
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Update an AzureCDN Endpoint under the AzureCDN profile, enabled content compression