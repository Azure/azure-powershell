### Example 1: Create service princial without application or display name
```powershell
PS C:\> New-AzADServicePrincipal
```

Create application with display name "azure-powershell-MM-dd-yyyy-HH-mm-ss" and new service principal associate with it

### Example 2: Create service princial with existing application
```powershell
PS C:\> New-AzADServicePrincipal -ApplicationId $appid
```

Create service princial with existing application

### Example 3: Create application with display name and associated new service pincipal with it
```powershell
PS C:\> New-AzADServicePrincipal -DisplayName $name
```

Create application with display name and associated new service pincipal with it