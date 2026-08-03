---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.mdp/get-azmdpsku
Module Name: Az.Mdp
ms.date: 08-03-2026
PlatyPS schema version: 2024-05-01
---

# Get-AzMdpSku

## SYNOPSIS

List ResourceSku resources by subscription ID

## SYNTAX

### Default (Default)

```
Get-AzMdpSku -Location <String> -SubscriptionId <String[]> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List (Default)

```
Get-AzMdpSku -Location <string> -SubscriptionId <string[]> [-DefaultProfile <psobject>]
```

## ALIASES

## DESCRIPTION

List ResourceSku resources by subscription ID

## EXAMPLES

### Example 1: List skus in location

```powershell
Get-AzMdpSku -Location westus
```

List all skus in the location "westus" in the current subscription

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

### -Location

Name of the location.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
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
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IResourceSku

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

