### Example 1: Create user with password profile
```powershell
$password = "xxxxxxxxxx"
$pp = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordProfile" -Property @{Password=$password}
New-AzADUser -DisplayName $uname -PasswordProfile $pp -AccountEnabled $true -MailNickname $nickname -UserPrincipalName $upn
```

Create user with password profile

### Example 2: Create user with password
```powershell
$password = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzADUser -DisplayName $uname -Password $password -AccountEnabled $true -MailNickname $nickname -UserPrincipalName $upn
```

Create user with password