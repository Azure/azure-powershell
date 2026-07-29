---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelentitysignalrecommendation
Module Name: Az.CloudHealth
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzMonitorHealthModelEntitySignalRecommendation

## SYNOPSIS

Get recommended signal configurations for a given Entity (only applicable for Entities representing Azure resources)

## SYNTAX

### Get (Default)

```
Get-AzMonitorHealthModelEntitySignalRecommendation -EntityName <string> -HealthModelName <string>
 -ResourceGroupName <string> [-SubscriptionId <string[]>] [-DefaultProfile <psobject>] [-WhatIf]
 [-Confirm]
```

### GetViaIdentity

```
Get-AzMonitorHealthModelEntitySignalRecommendation -InputObject <ICloudHealthIdentity>
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### GetViaIdentityHealthmodel

```
Get-AzMonitorHealthModelEntitySignalRecommendation -EntityName <string>
 -HealthmodelInputObject <ICloudHealthIdentity> [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

## ALIASES

## DESCRIPTION

Get recommended signal configurations for a given Entity (only applicable for Entities representing Azure resources)

## EXAMPLES

### Example 1: {{ Add title here }}

```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}

```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

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

### -EntityName

Name of the entity.
Must be unique within a health model.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: GetViaIdentityHealthmodel
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -HealthmodelInputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: GetViaIdentityHealthmodel
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -HealthModelName

Name of health model resource

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Get
  Position: Named
  IsRequired: true
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
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: GetViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
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
- Name: Get
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
Type: System.String[]
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IGetSignalRecommendationsResponse

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

