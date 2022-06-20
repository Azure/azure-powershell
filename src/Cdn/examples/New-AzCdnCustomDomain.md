### Example 1: Create an AzureCDN custom domain under the AzureCDN endpoint
```powershell
New-AzCdnCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name customdomain001 -HostName 'testcm.dev.cdn.azure.cn'
```

```output
Name            ResourceGroupName
----            -----------------
customdomain001 testps-rg-da16jm
```

Create an AzureCDN custom domain under the AzureCDN endpoint
