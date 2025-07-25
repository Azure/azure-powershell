### Example 1: Create key credentials for application
```powershell
# ObjectId is the string representation of a GUID for directory object, application, in Azure AD.
$Id = "00000000-0000-0000-0000-000000000000"
# $cert is Base64 encoded content of certificate
$credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                 -Property @{'Key' = $cert;
                                 'Usage'       = 'Verify';
                                 'Type'        = 'AsymmetricX509Cert'
                                 }
New-AzADAppCredential -ObjectId $Id -KeyCredentials $credential
```

Create key credentials for application with object Id $Id

### Example 2: Create password credentials for application
```powershell
# ApplicationId is AppId of Application object which is different from directory id in Azure AD.
Get-AzADApplication -ApplicationId $appId | New-AzADAppCredential -StartDate $startDate -EndDate $endDate
```

Create password credentials for application