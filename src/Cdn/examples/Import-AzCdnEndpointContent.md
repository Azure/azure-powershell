### Example 1: Import content of an AzureCDN Endpoint under the AzureCDN profile
```powershell
Import-AzCdnEndpointContent -ResourceGroupName testps-rg-verzion -ProfileName verzioncdn001 -EndpointName verzionendptest001 -ContentPath @("/movies/hello","/pictures/pic1.jpg") 
```

Import content of an AzureCDN Endpoint under the AzureCDN profile, only some skus support this action


