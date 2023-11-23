### Example 1: Start an AzureCDN Endpoint under the AzureCDN profile
```powershell
Start-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Start an AzureCDN Endpoint under the AzureCDN profile


### Example 2: Start an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Start-AzCdnEndpoint
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Start an AzureCDN Endpoint under the AzureCDN profile via identity