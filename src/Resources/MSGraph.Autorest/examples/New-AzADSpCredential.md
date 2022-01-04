### Example 1: Create key credentials for service principal
```powershell
PS C:\> $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                 -Property @{'Key' = $cert;
                                 'Usage'       = 'Verify'; 
                                 'Type'        = 'AsymmetricX509Cert'
                                 }
PS C:\> New-AzADSpCredential -ObjectId $Id -KeyCredentials $credential
```

Create key credentials for service principal

### Example 2: Create password credentials for service principal
```powershell
PS C:\> Get-AzADServicePrincipal -ApplicationId $appId | New-AzADSpCredential -StartDate $startDate -EndDate $endDate
```

Create password credentials for service principal