### Example 1: Create key credentials for application
```powershell
PS C:\> $credential = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential" `
                                 -Property @{'Key' = $cert;
                                 'Usage'       = 'Verify'; 
                                 'Type'        = 'AsymmetricX509Cert'
                                 }
PS C:\> New-AzADAppCredential -ObjectId $Id -KeyCredentials $credential
```

Create key credentials for application with object Id $Id

### Example 2: Create password credentials for application
```powershell
PS C:\> Get-AzADApplication -ApplicationId $appId | New-AzADAppCredential -StartDate $startDate -EndDate $endDate
```

Create password credentials for application