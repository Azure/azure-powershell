### Example 1: Create an in-memory object for LoadParameters
```powershell
$contentPath = @("/movies/amazing.mp4","/pictures/pic1.jpg")
New-AzCdnLoadParametersObject -ContentPath $contentPath
```

```output
ContentPath
-----------
{/movies/amazing.mp4, /pictures/pic1.jpg}
```

Create an in-memory object for LoadParameters