---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewclassificationrule
schema: 2.0.0
---

# Get-AzPurviewClassificationRule

## SYNOPSIS
Get a classification rule

## SYNTAX

### List (Default)
```
Get-AzPurviewClassificationRule -Endpoint <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPurviewClassificationRule -Endpoint <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

<<<<<<< HEAD
### GetViaIdentity
```
Get-AzPurviewClassificationRule -Endpoint <String> -InputObject <IPurviewdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## DESCRIPTION
Get a classification rule

## EXAMPLES

### Example 1: Get custom classification rule by name
```powershell
<<<<<<< HEAD
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/ -Name ClassificationRule1
```

```output
=======
PS C:\> Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/ -Name ClassificationRule1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1
```

Get classification rule named Classification1

### Example 2: Get all custom classification rules
```powershell
<<<<<<< HEAD
Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/
```

```output
=======
PS C:\> Get-AzPurviewClassificationRule -Endpoint https://parv-brs-2.purview.azure.com/

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ClassificationAction   : Keep
ClassificationName     : ClassificationName1
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column1"
                         }}
CreatedAt              : 1/27/2022 4:36:25 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{5}$"
                         }}
Description            : This is a description
Id                     : classificationrules/ClassificationRule1
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:36:25 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule1
RuleStatus             : Enabled
Version                : 1

ClassificationAction   : Keep
ClassificationName     : ClassificationName2
ColumnPattern          : {{
                           "kind": "Regex",
                           "pattern": "column2"
                         }}
CreatedAt              : 1/27/2022 4:37:09 AM
DataPattern            : {{
                           "kind": "Regex",
                           "pattern": "^\\d{6}$"
                         }}
Description            : This is description
Id                     : classificationrules/ClassificationRule2
Kind                   : Custom
LastModifiedAt         : 1/27/2022 4:37:09 AM
MinimumPercentageMatch : 60
Name                   : ClassificationRule2
RuleStatus             : Enabled
Version                : 1
```

Get all custom classification rules

## PARAMETERS

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

<<<<<<< HEAD
### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
### -Name
.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClassificationRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

<<<<<<< HEAD
### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IClassificationRule

## NOTES

ALIASES

<<<<<<< HEAD
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IPurviewdataIdentity>: Identity Parameter
  - `[ClassificationRuleName <String>]`: 
  - `[ClassificationRuleVersion <Int32?>]`: 
  - `[DataSourceName <String>]`: 
  - `[DataSourceType <DataSourceType?>]`: 
  - `[Id <String>]`: Resource identity path
  - `[KeyVaultName <String>]`: 
  - `[RunId <String>]`: 
  - `[ScanName <String>]`: 
  - `[ScanRulesetName <String>]`: 
  - `[Version <Int32?>]`: 

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## RELATED LINKS

