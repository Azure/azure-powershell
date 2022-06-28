### Example 1: Update application by display name
```powershell
Update-AzADApplication -DisplayName $name -HomePage $homepage
```

Update application by display name

### Example 2: Update application by pipeline input
```powershell
Get-AzADApplication -ObjectId $id | Update-AzADApplication -ReplyUrl $replyurl
```

Update application by pipeline input