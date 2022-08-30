### Example 1: Remove service principal credentials by key id
```powershell
Remove-AzADSpCredential -DisplayName $name -KeyId $keyid
```

Remove service principal credentials by key id

### Example 2: Remove all credentials from service principal
```powershell
Get-AzADServicePrincipal -DisplayName $name | Remove-AzADSpCredential
```

Remove all credentials from service principal