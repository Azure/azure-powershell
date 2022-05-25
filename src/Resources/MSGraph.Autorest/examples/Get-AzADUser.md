### Example 1: Get signin user
```powershell
Get-AzADUser -SignedIn
```

Get signin user

### Example 2: List users
```powershell
Get-AzADUser -First 10 -Select 'City' -AppendSelected
```

List first 10 users and append property 'City' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'UserPrincipalName', 'UsageLocation', 'GivenName', 'SurName', 'AccountEnabled', 'MailNickName', 'Mail'

### Example 3: Get user by display name
```powershell
Get-AzADUser -DisplayName $name
```

Get user by display name