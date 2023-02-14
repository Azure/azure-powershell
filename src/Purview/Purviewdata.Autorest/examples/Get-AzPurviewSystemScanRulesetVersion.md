### Example 1: Get all versions of system scanruleset available for a data source
```powershell
<<<<<<< HEAD
Get-AzPurviewSystemScanRulesetVersion -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'
```

```output
=======
PS C:\> Get-AzPurviewSystemScanRulesetVersion -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 4

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 3

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2

Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 1
```

Get all versions of system scanruleset available for a data source

