---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicydefinition
schema: 2.0.0
---

# Update-AzPolicyDefinition

## SYNOPSIS
This operation updates an existing policy definition in the given subscription or management group with the given name.

## SYNTAX

### Name (Default)
```
Update-AzPolicyDefinition -Name <String> [-DisplayName <String>] [-Description <String>] [-Policy <String>]
 [-Metadata <String>] [-Parameter <String>] [-Mode <String>] [-Version <String>]
 [-ExternalEvaluationEnforcementSettingMissingTokenAction <String>]
 [-ExternalEvaluationEnforcementSettingResultLifespan <String>]
 [-ExternalEvaluationEnforcementSettingRoleDefinitionId <String[]>] [-EndpointSettingKind <String>]
 [-EndpointSettingDetail <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SubscriptionId
```
Update-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-DisplayName <String>]
 [-Description <String>] [-Policy <String>] [-Metadata <String>] [-Parameter <String>] [-Mode <String>]
 [-Version <String>] [-ExternalEvaluationEnforcementSettingMissingTokenAction <String>]
 [-ExternalEvaluationEnforcementSettingResultLifespan <String>]
 [-ExternalEvaluationEnforcementSettingRoleDefinitionId <String[]>] [-EndpointSettingKind <String>]
 [-EndpointSettingDetail <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ManagementGroupName
```
Update-AzPolicyDefinition -Name <String> -ManagementGroupName <String> [-DisplayName <String>]
 [-Description <String>] [-Policy <String>] [-Metadata <String>] [-Parameter <String>] [-Mode <String>]
 [-Version <String>] [-ExternalEvaluationEnforcementSettingMissingTokenAction <String>]
 [-ExternalEvaluationEnforcementSettingResultLifespan <String>]
 [-ExternalEvaluationEnforcementSettingRoleDefinitionId <String[]>] [-EndpointSettingKind <String>]
 [-EndpointSettingDetail <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Id
```
Update-AzPolicyDefinition -Id <String> [-DisplayName <String>] [-Description <String>] [-Policy <String>]
 [-Metadata <String>] [-Parameter <String>] [-Mode <String>] [-Version <String>]
 [-ExternalEvaluationEnforcementSettingMissingTokenAction <String>]
 [-ExternalEvaluationEnforcementSettingResultLifespan <String>]
 [-ExternalEvaluationEnforcementSettingRoleDefinitionId <String[]>] [-EndpointSettingKind <String>]
 [-EndpointSettingDetail <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### InputObject
```
Update-AzPolicyDefinition [-DisplayName <String>] [-Description <String>] [-Policy <String>]
 [-Metadata <String>] [-Parameter <String>] [-Mode <String>] [-Version <String>]
 [-ExternalEvaluationEnforcementSettingMissingTokenAction <String>]
 [-ExternalEvaluationEnforcementSettingResultLifespan <String>]
 [-ExternalEvaluationEnforcementSettingRoleDefinitionId <String[]>] [-EndpointSettingKind <String>]
 [-EndpointSettingDetail <String>] -InputObject <IPolicyDefinition> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This operation updates an existing policy definition in the given subscription or management group with the given name.

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

### -EndpointSettingDetail
The details of the endpoint.

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

### -EndpointSettingKind
The kind of the endpoint.

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

### -ExternalEvaluationEnforcementSettingMissingTokenAction
What to do when evaluating an enforcement policy that requires an external evaluation and the token is missing.
Possible values are Audit and Deny and language expressions are supported.

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

### -ExternalEvaluationEnforcementSettingResultLifespan
The lifespan of the endpoint invocation result after which it's no longer valid.

Value is expected to follow the ISO 8601 duration format and language expressions are supported.

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

### -ExternalEvaluationEnforcementSettingRoleDefinitionId
An array of the role definition Ids the assignment's MSI will need in order to invoke the endpoint.

```yaml
Type: System.String[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinition
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Parameter Sets: Name, SubscriptionId, ManagementGroupName
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
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinition

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinition

## NOTES

ALIASES

Set-AzPolicyDefinition

## RELATED LINKS
