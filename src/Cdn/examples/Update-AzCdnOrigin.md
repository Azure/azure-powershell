### Example 1: Update an AzureCDN origin under the AzureCDN endpoint
```powershell
Update-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1 -HttpPort 456 -HttpsPort 789
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
```

Update an AzureCDN origin under the AzureCDN endpoint


### Example 2: Update an AzureCDN origin under the AzureCDN endpoint via identity
```powershell
Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1 | Update-AzCdnOrigin -HttpPort 456 -HttpsPort 789
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
```

Update an AzureCDN origin under the AzureCDN endpoint via identity

