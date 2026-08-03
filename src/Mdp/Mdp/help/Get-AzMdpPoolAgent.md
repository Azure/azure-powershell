---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.mdp/get-azmdppoolagent
Module Name: Az.Mdp
ms.date: 08-03-2026
PlatyPS schema version: 2024-05-01
---

# Get-AzMdpPoolAgent

## SYNOPSIS

List ResourceDetailsObject resources by Pool

## SYNTAX

### Default (Default)

```
Get-AzMdpPoolAgent -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List (Default)

```
Get-AzMdpPoolAgent -PoolName <string> -ResourceGroupName <string> [-SubscriptionId <string[]>]
 [-DefaultProfile <psobject>]
```

## ALIASES

## DESCRIPTION

List ResourceDetailsObject resources by Pool

## EXAMPLES

### Example 1: List agents for a pool in a resource group

```powershell
Get-AzMdpPoolAgent -ResourceGroupName testRg -PoolName Contoso
```

This command gets the agents for Managed DevOps Pool named "Contoso" under the resource group "testRg".

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

### -PoolName

Name of the pool.
It needs to be globally unique.

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

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IResourceDetailsObject

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

