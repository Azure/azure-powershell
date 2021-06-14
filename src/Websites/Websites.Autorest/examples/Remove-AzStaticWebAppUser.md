### Example 1: Delete a user entry from the static site
```powershell
PS C:\> Remove-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider 'all' -UseId 'xxxxxxxx'

```

This command deletes the user entry from the static site.

### Example 2: Delete all users from the static site
```powershell
PS C:\> $userList = Get-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider all    
PS C:\> Remove-AzStaticWebAppUser -InputObject $userList

```

This command deletes all users from the static site.

