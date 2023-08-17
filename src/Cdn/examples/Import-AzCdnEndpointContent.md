### Example 1: Import content of an AzureCDN Endpoint under the AzureCDN profile
```powershell
Import-AzCdnEndpointContent -ResourceGroupName testps-rg-verizon -ProfileName verzioncdn001 -EndpointName verzionendptest001 -ContentPath @("/movies/hello","/pictures/pic1.jpg") 
```

Import content of an AzureCDN Endpoint under the AzureCDN profile, only some skus support this action


### Example 2: Import content of an AzureCDN Endpoint under the AzureCDN profile using contentFilePath parameter
```powershell
$contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg")
$contentFilePath = New-AzCdnLoadParametersObject -ContentPath $contentPath
Import-AzCdnEndpointContent -ResourceGroupName testps-rg-verizon -ProfileName verzioncdn001 -EndpointName verzionendptest001 -ContentFilePath $contentFilePath
```

Import content of an AzureCDN Endpoint under the AzureCDN profile, only some skus support this action using contentFilePath parameter


