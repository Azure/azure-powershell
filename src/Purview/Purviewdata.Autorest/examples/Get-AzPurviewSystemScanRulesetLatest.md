### Example 1: Get latest system scan ruleset available for a data source
```powershell
Get-AzPurviewSystemScanRulesetLatest -Endpoint https://parv-brs-2.purview.azure.com/ -DataSourceType 'AzureStorage'
```

```output
Id                : systemscanrulesets/AzureStorage
Kind              : AzureStorage
Name              : AzureStorage
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 4
```

Get latest system scan ruleset available for a data source

