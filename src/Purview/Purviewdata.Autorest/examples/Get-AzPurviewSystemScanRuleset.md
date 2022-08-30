### Example 1: Get all system scanrulesets
```powershell
PS C:\> Get-AzPurviewSystemScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/

Id                : systemscanrulesets/AmazonMySql
Kind              : AmazonMySql
Name              : AmazonMySql
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2

Id                : systemscanrulesets/AzureMySql
Kind              : AzureMySql
Name              : AzureMySql
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2

Id                : systemscanrulesets/AmazonPostgreSql
Kind              : AmazonPostgreSql
Name              : AmazonPostgreSql
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2

Id                : systemscanrulesets/Teradata
Kind              : Teradata
Name              : Teradata
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 1
```

Get all system scanrulesets

### Example 2: Get system scanruleset for a data source type
```powershell
PS C:\> Get-AzPurviewSystemScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/  -DataSourceType 'AdlsGen2'

Id                : systemscanrulesets/AdlsGen2
Kind              : AdlsGen2
Name              : AdlsGen2
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 3
```

Get system scanruleset for a data source type

### Example 2: Get system scanruleset for a data source type and specific version
```powershell
PS C:\>  Get-AzPurviewSystemScanRuleset -Endpoint https://parv-brs-2.purview.azure.com/  -DataSourceType 'AdlsGen2' -Version 2

Id                : systemscanrulesets/AdlsGen2
Kind              : AdlsGen2
Name              : AdlsGen2
ResourceGroupName :
Status            : Enabled
Type              : System
Version           : 2
```

Get system scanruleset for a data source type and specific version

