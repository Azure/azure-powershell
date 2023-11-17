### Example 1: Get service principal by display name
```powershell
Get-AzADServicePrincipal -DisplayName $name
```

Get service principal by display name

### Example 2: Search for service principal display name starts with
```powershell
Get-AzADServicePrincipal -DisplayNameStartsWith $prefix
```

Search for service principal display name starts with

### Example 3: List service principals
```powershell
Get-AzADServicePrincipal -First 10 -Select Tags -AppendSelected
```

List first 10 service principals and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'ServicePrincipalNames', 'AppId'

### Example 4: Get service principal by application Id
```powershell
Get-AzADServicePrincipal -ApplicationId $appId
```

Get service principal by application Id

### Example 5: Get service principal by pipeline input
```powershell
Get-AzADApplication -DisplayName $name | Get-AzADServicePrincipal
```

Get service principal by pipeline input

### Example 6: Get service principal with filter
```powershell
Get-AzADServicePrincipal -Filter "startsWith(DisplayName,'some-name')"
```

Get service principal with filter

### Example 7: Assign OdataCount to a variable
```powershell
Get-AzADServicePrincipal -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
$result
```

Assign OdataCount to a variable