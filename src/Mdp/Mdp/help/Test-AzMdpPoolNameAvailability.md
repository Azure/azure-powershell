---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.mdp/test-azmdppoolnameavailability
Module Name: Az.Mdp
ms.date: 08-03-2026
PlatyPS schema version: 2024-05-01
---

# Test-AzMdpPoolNameAvailability

## SYNOPSIS

Checks that the pool name is valid and is not already in use.

## SYNTAX

### CheckExpanded (Default)

```
Test-AzMdpPoolNameAvailability -Name <string> [-SubscriptionId <string>]
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### Check

```
Test-AzMdpPoolNameAvailability -Body <ICheckNameAvailability> [-SubscriptionId <string>]
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### CheckViaJsonFilePath

```
Test-AzMdpPoolNameAvailability -JsonFilePath <string> [-SubscriptionId <string>]
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### CheckViaJsonString

```
Test-AzMdpPoolNameAvailability -JsonString <string> [-SubscriptionId <string>]
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

## ALIASES

## DESCRIPTION

Checks that the pool name is valid and is not already in use.

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

### -Body

The parameters used to check the availability of a resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.ICheckNameAvailability
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: Check
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
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

### -JsonFilePath

Path of Json file supplied to the Check operation

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CheckViaJsonFilePath
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -JsonString

Json string supplied to the Check operation

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CheckViaJsonString
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

The name of the resource.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CheckExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.ICheckNameAvailability

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.ICheckNameAvailabilityResult

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

