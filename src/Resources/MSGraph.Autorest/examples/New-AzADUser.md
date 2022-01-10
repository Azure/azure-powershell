### Example 1: Create user
```powershell
PS C:\> $pp=New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile" -Property @{Password=$password}
PS C:\> New-MgUser -DisplayName $uname -PasswordProfile $pp -AccountEnabled -MailNickname $nickname -UserPrincipalName $upn
```

Create user