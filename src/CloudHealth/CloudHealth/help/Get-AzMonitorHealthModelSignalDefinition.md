---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelsignaldefinition
Module Name: Az.CloudHealth
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzMonitorHealthModelSignalDefinition

## SYNOPSIS

Get a SignalDefinition

## SYNTAX

### List (Default)

```
Get-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Timestamp <DateTime>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get

```
Get-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity

```
Get-AzMonitorHealthModelSignalDefinition -InputObject <ICloudHealthIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityHealthmodel

```
Get-AzMonitorHealthModelSignalDefinition -Name <string>
 -HealthmodelInputObject <ICloudHealthIdentity> [-DefaultProfile <psobject>]
```

## ALIASES

## DESCRIPTION

Get a SignalDefinition

## EXAMPLES

### Example 1: Get a signal definition by name

```powershell
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-signal
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/signaldefinitions/cpu-signal
Name                         : cpu-signal
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/signaldefinitions
```

Gets a single signal definition under a health model by name.

### Example 2: List every signal definition in a health model

```powershell
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
cpu-signal Succeeded         azpwsh-test-rg
cpu-signal-2         Succeeded         azpwsh-test-rg
```

Lists all signal definition resources defined on the specified health model.

## PARAMETERS

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
- Name: List
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

### -Name

Name of the signal definition.
Must be unique within a health model.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- SignalDefinitionName
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

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
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

### -SubscriptionId

The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
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

### -Timestamp

Timestamp to use for the operation.
When specified, the version of the resource at this point in time is retrieved.
If not specified, the latest version is used.

```yaml
Type: System.DateTime
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinition

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

