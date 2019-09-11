---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azpolicysetdefinition
schema: 2.0.0
---

# Set-AzPolicySetDefinition

## SYNOPSIS
This operation creates or updates a policy set definition in the given subscription with the given name.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzPolicySetDefinition -Name <String> [-SubscriptionId <String>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicySetDefinitionPropertiesMetadata>]
 [-PolicyDefinition <IPolicyDefinitionReference[]>] [-PolicyType <PolicyType>]
 [-SetDefinitionParameter <IPolicySetDefinitionPropertiesParameters>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzPolicySetDefinition -Name <String> -Parameter <IPolicySetDefinition> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzPolicySetDefinition -ManagementGroupName <String> -Name <String> -Parameter <IPolicySetDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateById
```
Set-AzPolicySetDefinition -Id <String> -PolicyDefinition <IPolicyDefinitionReference[]>
 [-SubscriptionId <String>] [-Description <String>] [-DisplayName <String>]
 [-Metadata <IPolicySetDefinitionPropertiesMetadata>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzPolicySetDefinition -ManagementGroupName <String> -Name <String> [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicySetDefinitionPropertiesMetadata>]
 [-PolicyDefinition <IPolicyDefinitionReference[]>] [-PolicyType <PolicyType>]
 [-SetDefinitionParameter <IPolicySetDefinitionPropertiesParameters>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy set definition in the given subscription with the given name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Description
The policy set definition description.

```yaml
Type: System.String
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayName
The display name of the policy set definition.

```yaml
Type: System.String
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The ID of the policy set definition.

```yaml
Type: System.String
Parameter Sets: UpdateById
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagementGroupName
The ID of the management group.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metadata
The policy set definition metadata.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicySetDefinitionPropertiesMetadata
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the policy set definition to create.

```yaml
Type: System.String
Parameter Sets: Update, Update1, UpdateExpanded, UpdateExpanded1
Aliases: PolicySetDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The policy set definition.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicySetDefinition
Parameter Sets: Update, Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PolicyDefinition
An array of policy definition references.
To construct, see NOTES section for POLICYDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinitionReference[]
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PolicyType
The type of policy definition.
Possible values are NotSpecified, BuiltIn, and Custom.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SetDefinitionParameter
The policy set definition parameters that can be used in policy definition references.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicySetDefinitionPropertiesParameters
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateById, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicySetDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicySetDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IPolicySetDefinition>: The policy set definition.
  - `PolicyDefinition <IPolicyDefinitionReference[]>`: An array of policy definition references.
    - `[Parameter <IPolicyDefinitionReferenceParameters>]`: Required if a parameter is used in policy rule.
    - `[PolicyDefinitionId <String>]`: The ID of the policy definition or policy set definition.
  - `[Description <String>]`: The policy set definition description.
  - `[DisplayName <String>]`: The display name of the policy set definition.
  - `[Metadata <IPolicySetDefinitionPropertiesMetadata>]`: The policy set definition metadata.
  - `[Parameter <IPolicySetDefinitionPropertiesParameters>]`: The policy set definition parameters that can be used in policy definition references.
  - `[PolicyType <PolicyType?>]`: The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.

#### POLICYDEFINITION <IPolicyDefinitionReference[]>: An array of policy definition references.
  - `[Parameter <IPolicyDefinitionReferenceParameters>]`: Required if a parameter is used in policy rule.
  - `[PolicyDefinitionId <String>]`: The ID of the policy definition or policy set definition.

## RELATED LINKS

