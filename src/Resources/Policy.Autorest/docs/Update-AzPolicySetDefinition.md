---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicysetdefinition
schema: 2.0.0
---

# Update-AzPolicySetDefinition

## SYNOPSIS
This operation updates an existing policy set definition in the given subscription or management group with the given name.

## SYNTAX

### Name (Default)
```
Update-AzPolicySetDefinition -Name <String> [-Description <String>] [-DisplayName <String>]
 [-Metadata <String>] [-Parameter <String>] [-PolicyDefinition <String>] [-PolicyDefinitionGroup <String>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Id
```
Update-AzPolicySetDefinition -Id <String> [-Description <String>] [-DisplayName <String>] [-Metadata <String>]
 [-Parameter <String>] [-PolicyDefinition <String>] [-PolicyDefinitionGroup <String>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InputObject
```
Update-AzPolicySetDefinition -InputObject <IPolicySetDefinition> [-Description <String>]
 [-DisplayName <String>] [-Metadata <String>] [-Parameter <String>] [-PolicyDefinition <String>]
 [-PolicyDefinitionGroup <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ManagementGroupName
```
Update-AzPolicySetDefinition -ManagementGroupName <String> -Name <String> [-Description <String>]
 [-DisplayName <String>] [-Metadata <String>] [-Parameter <String>] [-PolicyDefinition <String>]
 [-PolicyDefinitionGroup <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SubscriptionId
```
Update-AzPolicySetDefinition -Name <String> -SubscriptionId <String> [-Description <String>]
 [-DisplayName <String>] [-Metadata <String>] [-Parameter <String>] [-PolicyDefinition <String>]
 [-PolicyDefinitionGroup <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This operation updates an existing policy set definition in the given subscription or management group with the given name.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Description
The policy set definition description.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
The display name of the policy set definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
The resource Id of the policy definition to update.

```yaml
Type: System.String
Parameter Sets: Id
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupName
The ID of the management group.

```yaml
Type: System.String
Parameter Sets: ManagementGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Metadata
The policy set definition metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy set definition to update.

```yaml
Type: System.String
Parameter Sets: ManagementGroupName, Name, SubscriptionId
Aliases: PolicySetDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Parameter
The parameter definitions for parameters used in the policy set.
The keys are the parameter names.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyDefinition
The policy definition array in JSON string form.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinitionGroup
The metadata describing groups of policy definition references within the policy set definition.
To construct, see NOTES section for POLICYDEFINITIONGROUP properties and create a hash table.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GroupDefinition

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
The policy definition version in #.#.# format.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyDefinitionVersion

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition

## NOTES

ALIASES

Set-AzPolicySetDefinition

## RELATED LINKS

