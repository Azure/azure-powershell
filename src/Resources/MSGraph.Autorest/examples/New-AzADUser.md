### Example 1: Create user
```powershell
$pp = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile" -Property @{Password=$password}
New-AzADUser -DisplayName $uname -PasswordProfile $pp -AccountEnabled -MailNickname $nickname -UserPrincipalName $upn
```

Create user