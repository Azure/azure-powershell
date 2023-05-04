### Example 1: Delete a user entry from the static site
```powershell
Remove-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider 'all' -UserId 'xxxxxxxx'

```

This command deletes the user entry from the static site.

### Example 2: Delete all users from the static site
```powershell
$userList = Get-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider all
Remove-AzStaticWebAppUser -InputObject $userList

```

This command deletes all users from the static site.