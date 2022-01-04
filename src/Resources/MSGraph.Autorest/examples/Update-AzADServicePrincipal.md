### Example 1: Update service principal and associated application by display name
```powershell
PS C:\> Update-AzADServicePrincipal -DisplayName $name -IdentifierUri $uri
```

Update service principal and associated application by display name, 'IdentifierUri', 'PasswordCredential', 'KeyCredential' will be assigned to application

### Example 2: Update service principal by pipeline input
```powershell
PS C:\> Get-AzADServicePrincipal -ObjectId $id | Update-AzADServicePrincipal -Note $note
```

Update service principal and associated application by display name, 'IdentifierUri', 'PasswordCredential', 'KeyCredential' will be assigned to application