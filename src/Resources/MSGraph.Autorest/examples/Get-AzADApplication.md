### Example 1: Get application by display name
```powershell
Get-AzADApplication -DisplayName $appname
```

Get application by display name

### Example 2: List applications
```powershell
Get-AzADApplication -First 10
```

List first 10 applications

### Example 3: Search for application display name starts with
```powershell
Get-AzADApplication -DisplayNameStartsWith $prefix
```

Search for application display name starts with

### Example 4: Get application by object Id
```powershell
Get-AzADApplication -ObjectId $id -Select Tags -AppendSelected
```

Get application by object Id and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'IdentifierUris', 'Web', 'AppId', 'SignInAudience'

### Example 5: Get applications owned by current user
```powershell
Get-AzADApplication -OwnedApplication
```

Get applications owned by current user

### Example 6: Get applications with filter
```powershell
Get-AzADApplication -Filter "startsWith(DisplayName,'some-name')"
```

Get applications with filter

### Example 7: Assign OdataCount to a variable
```powershell
Get-AzADApplication -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
$result
```

Assign OdataCount to a variable
