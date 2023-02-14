### Example 1: Get latest system scan ruleset available for a data source
```powershell
<<<<<<< HEAD
Get-AzPurviewSystemScanRulesetLatest -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'
```

```output
=======
PS C:\> Get-AzPurviewSystemScanRulesetLatest -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 4
```

Get latest system scan ruleset available for a data source

