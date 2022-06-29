### Example 1: List AzureCDN Endpoints under the AzureCDN profile
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
WestUs   endptest002 testps-rg-da16jm
```

List AzureCDN Endpoints under the AzureCDN profile

### Example 2: Get an AzureCDN Endpoint under the AzureCDN profile
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Get an AzureCDN Endpoint under the AzureCDN profile

