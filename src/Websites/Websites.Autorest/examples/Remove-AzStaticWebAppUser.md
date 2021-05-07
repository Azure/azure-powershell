### Example 1: Deletes a user entry from the static site
```powershell
PS C:\> Remove-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider 'all' -Userid UserId

```

This command deletes the user entry from the static site.

### Example 2: Deletes all users from the static site
```powershell
PS C:\> $userList = Get-AzStaticWebAppUser -ResourceGroupName resourceGroup -Name staticweb01 -Authprovider all    
PS C:\> Remove-AzStaticWebAppUser -InputObject $userList

```

This command deletes all users from the static site.

