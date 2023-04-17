### Example 1: Removes a content from CDN endpoint
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentPath @("/movies/*","/pictures/pic1.jpg") 
```

```output
```

Removes a content from CDN using Parameter "ContentPath"

### Example 2: Removes a content from CDN endpoint
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentFilePath @("/movies/*","/pictures/pic1.jpg") 
```

```output
```

Removes a content from CDN using Parameter "ContentFilePath"

### Example 3: Removes a content from CDN endpoint via identity
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentPath @("/movies/*","/pictures/pic1.jpg") 
```

```output
```

Removes a content from CDN using Parameter "ContentPath" via identity

### Example 4: Removes a content from CDN endpoint via identity
```powershell
Clear-AzCdnEndpointContent -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -ContentFilePath @("/movies/*","/pictures/pic1.jpg") 
```

```output
```

Removes a content from CDN using Parameter "ContenContentFilePathtPath" via identity