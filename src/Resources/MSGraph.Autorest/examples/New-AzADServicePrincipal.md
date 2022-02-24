### Example 1: Create service principal without application or display name
```powershell
PS C:\> New-AzADServicePrincipal
```

Create application with display name "azure-powershell-MM-dd-yyyy-HH-mm-ss" and new service principal associate with it

### Example 2: Create service principal with existing application
```powershell
PS C:\> New-AzADServicePrincipal -ApplicationId $appid
```

Create service principal with existing application

### Example 3: Create application with display name and associated new service principal with it
```powershell
PS C:\> New-AzADServicePrincipal -DisplayName $name
```

Create application with display name and associated new service pincipal with it
