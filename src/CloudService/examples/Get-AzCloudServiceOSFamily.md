### Example 1: Get all OS families in a location
```powershell
PS C:\> Get-AzCloudServiceOSFamily -location 'westus2'

Name Label
---- -----
5    Windows Server 2016
4    Windows Server 2012 R2
6    Windows Server 2019
3    Windows Server 2012
2    Windows Server 2008 R2
```

This command gets all OS families in location westus2

### Example 2: Get OS family
```powershell
PS C:\> Get-AzCloudServiceOSFamily -location 'westus2' -OSFamilyName 5

Name Label
---- -----
5    Windows Server 2016
```

This command gets OS family named 5 that is located in westus2.
