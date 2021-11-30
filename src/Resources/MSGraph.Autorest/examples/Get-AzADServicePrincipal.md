### Example 1: Get service principal by display name
```powershell
PS C:\> Get-AzADServicePrincipal -DisplayName $name
```

Get service principal by display name

### Example 2: Search for service principal display name starts with
```powershell
PS C:\> Get-AzADServicePrincipal -DisplayNameStartsWith $prefix
```

Search for service principal display name starts with

### Example 3: List service principals
```powershell
PS C:\> Get-AzADServicePrincipal -First 10 -Select Tags -AppendSelected
```

List first 10 service principals and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'ServicePrincipalNames', 'AppId'

### Example 4: Get service principal by application Id
```powershell
PS C:\> Get-AzADServicePrincipal -ApplicationId $appId
```

Get service principal by application Id

### Example 5: Get service principal by pipeline input
```powershell
PS C:\> Get-AzADApplication -DisplayName $name | Get-AzADServicePrincipal
```

Get service principal by pipeline input