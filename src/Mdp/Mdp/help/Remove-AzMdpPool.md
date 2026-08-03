---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.mdp/remove-azmdppool
Module Name: Az.Mdp
ms.date: 08-03-2026
PlatyPS schema version: 2024-05-01
---

# Remove-AzMdpPool

## SYNOPSIS

Delete a Pool

## SYNTAX

### Delete (Default)

```
Remove-AzMdpPool -Name <string> -ResourceGroupName <string> [-SubscriptionId <string>]
 [-DefaultProfile <psobject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm]
```

### DeleteViaIdentity

```
Remove-AzMdpPool -InputObject <IMdpIdentity> [-DefaultProfile <psobject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm]
```

## ALIASES

## DESCRIPTION

Delete a Pool

## EXAMPLES

### Example 1: Delete a Managed DevOps Pool

```powershell
Remove-AzMdpPool -Name Contoso -ResourceGroupName testRg
```

This command deletes the Managed DevOps Pool named "Contoso" in the resource group "testRg".

### Example 2: Delete a Managed DevOps Pool using InputObject

```powershell
$pool = Get-AzMdpPool -ResourceGroupName testRg -Name Contoso

Remove-AzMdpPool -InputObject $pool
```

This command deletes the Managed DevOps Pool named "Contoso" in the resource group "testRg".

## PARAMETERS

### -AsJob

Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- cf
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DefaultProfile

The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
DefaultValue: None
SupportsWildcards: false
Aliases:
- AzureRMContext
- AzureCredential
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: DeleteViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Name of the pool.
It needs to be globally unique.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- PoolName
ParameterSets:
- Name: Delete
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -NoWait

Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PassThru

Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -SubscriptionId

The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Delete
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WhatIf

Shows what would happen if the cmdlet runs.
The cmdlet is not run.
Runs the command in a mode that only reports what would happen without performing the actions.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- wi
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

