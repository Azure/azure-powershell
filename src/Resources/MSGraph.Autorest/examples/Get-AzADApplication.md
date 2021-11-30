### Example 1: Get application by display name
```powershell
PS C:\> Get-AzADApplication -DisplayName $appname
```

Get application by display name

### Example 2: List applications
```powershell
PS C:\> Get-AzADApplication -First 10
```

List first 10 applications

### Example 3: Search for application display name starts with
```powershell
PS C:\> Get-AzADApplication -DisplayNameStartsWith $prefix
```

Search for application display name starts with

### Example 4: Get application by object Id
```powershell
PS C:\> Get-AzADapplication -ObjectId $id -Select Tags -AppendSelected
```

Get application by object Id and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'IdentifierUris', 'Web', 'AppId', 'SignInAudience'