---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodel
Module Name: Az.CloudHealth
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzMonitorHealthModel

## SYNOPSIS

Get a HealthModel

## SYNTAX

### List (Default)

```
Get-AzMonitorHealthModel [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get

```
Get-AzMonitorHealthModel -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity

```
Get-AzMonitorHealthModel -InputObject <ICloudHealthIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1

```
Get-AzMonitorHealthModel -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Get a HealthModel

## EXAMPLES

### Example 1: Get a health model by name

```powershell
Get-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1
Location                     : eastus2
Name                         : azpwsh-healthmodel1
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels
```

Gets a single health model by its name and the resource group it belongs to.

### Example 2: List all health models in a resource group

```powershell
Get-AzMonitorHealthModel -ResourceGroupName azpwsh-test-rg
```

```output
Location Name                 SystemDataCreatedAt   SystemDataCreatedByType ResourceGroupName
-------- ----                 -------------------   ----------------------- -----------------
eastus2  azpwsh-healthmodel1 5/1/2026 12:00:35 AM  User                    azpwsh-test-rg
eastus2  azpwsh-healthmodel2  5/1/2026 12:01:06 AM  User                    azpwsh-test-rg
```

Lists all health models in the specified resource group.

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

Name of health model resource

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- HealthModelName
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

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
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
- Name: List1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IHealthModel

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

