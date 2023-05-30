### Example 1: Removes a content from CDN endpoint using Parameter "ContentPath"
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentPath @("/movies/*","/pictures/pic1.jpg") 
```

```output
```

Removes a content from CDN endpoint using Parameter "ContentPath"

### Example 2: Removes a content from CDN endpoint using Parameter "ContentFilePath"
```powershell
$contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg")
$contentFilePath = New-AzCdnPurgeParametersObject -ContentPath $contentPath
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentFilePath $contentFilePath
```

```output
```

Removes a content from CDN endpoint using Parameter "ContentFilePath"
