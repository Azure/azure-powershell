### Example 1: List AzureCDN custom domains under the AzureCDN endpoint
```powershell
Get-AzCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001
```

```output
Name            ResourceGroupName
----            -----------------
customdomain001 testps-rg-da16jm
customdomain002 testps-rg-da16jm
```

List AzureCDN custom domains under the AzureCDN endpoint

### Example 2: Get an AzureCDN custom domain under the AzureCDN endpoint
```powershell
Get-AzCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name customdomain001
```

```output
Name            ResourceGroupName
----            -----------------
customdomain001 testps-rg-da16jm
```

Get an AzureCDN custom domain under the AzureCDN endpoint

