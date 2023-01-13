### Example 1: Get content of an AzureCDN Endpoint under the AzureCDN profile
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentPath @("/movies/*","/pictures/pic1.jpg") 
```

Get content of an AzureCDN Endpoint under the AzureCDN profile

