---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/set-azpolicysetdefinition
schema: 2.0.0
---

# Set-AzPolicySetDefinition

## SYNOPSIS
Modifies a policy set definition

## SYNTAX

## DESCRIPTION
The **Set-AzPolicySetDefinition** cmdlet modifies a policy definition.

## EXAMPLES

### Example 1: Update the description of a policy set definition
```powershell
$PolicySetDefinition = Get-AzPolicySetDefinition -ResourceId '/subscriptions/mySub/Microsoft.Authorization/policySetDefinitions/myPSSetDefinition'
Set-AzPolicySetDefinition -Id $PolicySetDefinition.ResourceId -Description 'Updated policy to not allow virtual machine creation'
```

The first command gets a policy set definition by using the Get-AzPolicySetDefinition cmdlet.
The command stores that object in the $PolicySetDefinition variable.
The second command updates the description of the policy set definition identified by the **ResourceId** property of $PolicySetDefinition.

### Example 2: Update the metadata of a policy set definition
```powershell
Set-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -Metadata '{"category":"Virtual Machine"}'
```

```output
Name                  : VMPolicySetDefinition
ResourceId            : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policySetDefinitions/VMPolicySetDefinition
ResourceName          : VMPolicySetDefinition
ResourceType          : Microsoft.Authorization/policySetDefinitions
SubscriptionId        : 11111111-1111-1111-1111-111111111111
Properties            : @{displayName=VMPolicySetDefinition; policyType=Custom; metadata=; parameters=; policyDefinitions=System.Object[]}
PolicySetDefinitionId : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policySetDefinitions/VMPolicySetDefinition
```

This command updates the metadata of a policy set definition named VMPolicySetDefinition to indicate its category is "Virtual Machine".

### Example 3: Update the groups of a policy set definition
```powershell
Set-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition '[{ "name": "group1", "displayName": "Virtual Machine Security" }, { "name": "group2" }]'
```

This command updates the groups of a policy set definition named VMPolicySetDefinition.

### Example 4: Update the groups of a policy set definition using a hash table
```powershell
$groupsJson = ConvertTo-Json @{ name = "group1"; displayName = "Virtual Machine Security" }, @{ name = "group2" }
Set-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -GroupDefinition $groupsJson
```

This command updates the groups of a policy set definition named VMPolicySetDefinition using a hash table to construct the groups.

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
