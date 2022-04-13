### Example 1: Create application
```powershell
New-AzADApplication -SigninAudience AzureADandPersonalMicrosoftAccount
```

Create application with signin audience 'AzureADandPersonalMicrosoftAccount', other available options are: 'AzureADMyOrg', 'AzureADMultipleOrgs', 'PersonalMicrosoftAccount'