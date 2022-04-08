### Example 1: Remove credentials from application by key id
```powershell
Remove-AzADAppCredential -DisplayName $name -KeyId $keyid
```

Remove credentials from application by key id

### Example 2: Remove all credentials from application
```powershell
Get-AzADApplication -DisplayName $name | Remove-AzADAppCredential
```

Remove all credentials from application