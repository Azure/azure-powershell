### Example 1: Update application by display name
```powershell
PS C:\> Update-AzADApplication -DisplayName $name -HomePage $homepage
```

Update application by display name

### Example 2: Update application by pipeline input
```powershell
PS C:\> Get-AzADApplication -ObjectId $id | Update-AzADApplication -ReplyUrl $replyurl
```

Update application by pipeline input