---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicydefinition
schema: 2.0.0
---

# Update-AzPolicyDefinition

## SYNOPSIS
This operation updates an existing policy definition in the given subscription or management group with the given name.

## SYNTAX

### SubscriptionId (Default)
```
Update-AzPolicyDefinition -Name <String> [-SubscriptionId <String>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <String>] [-Mode <String>] [-Parameter <String>] [-Policy <String>]
 [-UsePropertyBag] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Id
```
Update-AzPolicyDefinition -Id <String> -Name <String> [-Description <String>] [-DisplayName <String>]
 [-Metadata <String>] [-Mode <String>] [-Parameter <String>] [-Policy <String>] [-UsePropertyBag]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManagementGroupName
```
Update-AzPolicyDefinition -ManagementGroupName <String> -Name <String> [-Description <String>]
 [-DisplayName <String>] [-Metadata <String>] [-Mode <String>] [-Parameter <String>] [-Policy <String>]
 [-UsePropertyBag] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation updates an existing policy definition in the given subscription or management group with the given name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
${UsePropertyBag} = $false,
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
The policy definition description.

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
The display name of the policy definition.

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
[System.Collections.Hashtable]
 The policy definition metadata.
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

### -Mode
The policy definition mode.
Some examples are All, Indexed, Microsoft.KeyVault.Data.

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
The name of the policy definition to update.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Parameter
The parameter definitions for parameters used in the policy rule.
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

### -Policy
The policy rule.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SubscriptionId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UsePropertyBag
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20210601.IPolicyDefinition

## NOTES

ALIASES

Set-AzPolicyDefinition

## RELATED LINKS

