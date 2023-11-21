### Example 1: Clear the content of an AzureFrontDoor endpoint using Parameter "ContentPath"
```powershell
Clear-AzFrontDoorCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -ContentPath /a
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "ContentPath"


### Example 2: Clear the content of an AzureFrontDoor endpoint using Parameter "Content"
```powershell
$contentPath = "/a"
$content = New-AzFrontDoorCdnPurgeParametersObject -ContentPath $contentPath
Clear-AzFrontDoorCdnEndpointContent -ResourceGroupName testps-rg-afdx -ProfileName cdn001 -EndpointName endpointTest001 -Content $content
```

```output
```

Clear the content of an AzureFrontDoor endpoint using Parameter "Content"

