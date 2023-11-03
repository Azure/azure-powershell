### Example 1: Stop an AzureCDN Endpoint under the AzureCDN profile
```powershell
Stop-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Stop an AzureCDN Endpoint under the AzureCDN profile


### Example 2: Stop an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Stop-AzCdnEndpoint
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Stop an AzureCDN Endpoint under the AzureCDN profile via identity