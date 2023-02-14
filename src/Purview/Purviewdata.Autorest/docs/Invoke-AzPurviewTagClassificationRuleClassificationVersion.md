---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/invoke-azpurviewtagclassificationruleclassificationversion
schema: 2.0.0
---

# Invoke-AzPurviewTagClassificationRuleClassificationVersion

## SYNOPSIS
Sets Classification Action on a specific classification rule version.

## SYNTAX

<<<<<<< HEAD
### Tag (Default)
=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```
Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint <String> -ClassificationRuleName <String>
 -ClassificationRuleVersion <Int32> -Action <ClassificationAction> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

<<<<<<< HEAD
### TagViaIdentity
```
Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint <String>
 -InputObject <IPurviewdataIdentity> -Action <ClassificationAction> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
## DESCRIPTION
Sets Classification Action on a specific classification rule version.

## EXAMPLES

### Example 1: Set Classification Action on specific rule version
```powershell
<<<<<<< HEAD
Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint 'https://parv-brs-2.purview.azure.com/' -ClassificationRuleName 'ClassificationRule2' -ClassificationRuleVersion 1 -Action 'Delete'
```

```output
=======
PS C:\> Invoke-AzPurviewTagClassificationRuleClassificationVersion -Endpoint 'https://parv-brs-2.purview.azure.com/' -ClassificationRuleName 'ClassificationRule2' -ClassificationRuleVersion 1 -Action 'Delete'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
EndTime ScanResultId StartTime Status
------- ------------ --------- ------
                               Accepted
```

Set Classification Action on specific rule version

## PARAMETERS

### -Action
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ClassificationAction
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationRuleName
.

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: Tag
=======
Parameter Sets: (All)
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationRuleVersion
.

```yaml
Type: System.Int32
<<<<<<< HEAD
Parameter Sets: Tag
=======
Parameter Sets: (All)
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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

<<<<<<< HEAD
### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IPurviewdataIdentity
Parameter Sets: TagViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

=======
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IOperationResponse

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

