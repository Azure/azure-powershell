### Example 1: Get group by display name
```powershell
Get-AzADGroup -DisplayName $gname
```

Get group by display name

### Example 2: List groups
```powershell
Get-AzADGroup -First 10
```

List first 10 groups

### Example 3: Get group by object id
```powershell
Get-AzADGroup -ObjectId $id -Select groupTypes -AppendSelected
```

Get group by object id and append property 'groupTypes' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'SecurityEnabled', 'MailEnabled', 'MailNickname', 'Description'

### Example 4: Get group with filter
```powershell
Get-AzADGroup -Filter "startsWith(DisplayName,'some-name')"
```

Get group with filter

### Example 5: Assign OdataCount to a variable
```powershell
Get-AzADGroup -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
$result
```

Assign OdataCount to a variable