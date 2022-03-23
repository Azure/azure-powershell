---
external help file:
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.purview/get-azpurviewsystemscanruleset
schema: 2.0.0
---

# Get-AzPurviewSystemScanRuleset

## SYNOPSIS
Get a system scan ruleset for a data source

## SYNTAX

### List (Default)
```
Get-AzPurviewSystemScanRuleset -Endpoint <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPurviewSystemScanRuleset -Endpoint <String> -DataSourceType <DataSourceType>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzPurviewSystemScanRuleset -Endpoint <String> -Version <Int32> [-DataSourceType <DataSourceType>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a system scan ruleset for a data source

## EXAMPLES

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

## PARAMETERS

### -DataSourceType
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: Get, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
.

```yaml
Type: System.Int32
Parameter Sets: Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.ISystemScanRuleset

## NOTES

ALIASES

## RELATED LINKS

