---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
ms.assetid: E1AC7139-786C-4DD6-A898-242723E0D159
online version: https://learn.microsoft.com/powershell/module/az.resources/set-azpolicydefinition
schema: 2.0.0
---

# Set-AzPolicyDefinition

## SYNOPSIS
Modifies a policy definition.

## SYNTAX

## DESCRIPTION
The **Set-AzPolicyDefinition** cmdlet modifies a policy definition.

## EXAMPLES

### Example 1: Update the description of a policy definition
```powershell
$PolicyDefinition = Get-AzPolicyDefinition -Name 'VMPolicyDefinition'
Set-AzPolicyDefinition -Id $PolicyDefinition.ResourceId -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy definition named VMPolicyDefinition by using the Get-AzPolicyDefinition cmdlet.
The command stores that object in the $PolicyDefinition variable.
The second command updates the description of the policy definition identified by the **ResourceId** property of $PolicyDefinition.

### Example 2: Update the mode of a policy definition
```powershell
Set-AzPolicyDefinition -Name 'VMPolicyDefinition' -Mode 'All'
```

This command updates the policy definition named VMPolicyDefinition by using the Set-AzPolicyDefinition cmdlet to 
set its mode property to 'All'.

### Example 3: Update the metadata of a policy definition
```powershell
Set-AzPolicyDefinition -Name 'VMPolicyDefinition' -Metadata '{"category":"Virtual Machine"}'
```

```output
Name               : VMPolicyDefinition
ResourceId         : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policyDefinitions/VMPolicyDefinition
ResourceName       : VMPolicyDefinition
ResourceType       : Microsoft.Authorization/policyDefinitions
SubscriptionId     : 11111111-1111-1111-1111-111111111111
Properties         : @{displayName=VMPolicyDefinition; policyType=Custom; mode=All; metadata=; policyRule=}
PolicyDefinitionId : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policyDefinitions/VMPolicyDefinition
```

This command updates the metadata of a policy definition named VMPolicyDefinition to indicate its category is "Virtual Machine".

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Nullable`1[[System.Guid, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

[Get-AzPolicyDefinition](./Get-AzPolicyDefinition.md)

[New-AzPolicyDefinition](./New-AzPolicyDefinition.md)

[Remove-AzPolicyDefinition](./Remove-AzPolicyDefinition.md)


