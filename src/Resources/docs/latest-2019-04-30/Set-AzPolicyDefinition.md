---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azpolicydefinition
schema: 2.0.0
---

# Set-AzPolicyDefinition

## SYNOPSIS
This operation creates or updates a policy definition in the given subscription with the given name.

## SYNTAX

### UpdateById (Default)
```
Set-AzPolicyDefinition -Id <String> [-SubscriptionId <String>] [-Description <String>] [-DisplayName <String>]
 [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>]
 [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzPolicyDefinition -Name <String> -SubscriptionId <String> -Parameter <IPolicyDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzPolicyDefinition -ManagementGroupName <String> -Name <String> -Parameter <IPolicyDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzPolicyDefinition -Name <String> -SubscriptionId <String>
 [-DefinitionParameter <IPolicyDefinitionPropertiesParameters>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>]
 [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzPolicyDefinition -ManagementGroupName <String> -Name <String>
 [-DefinitionParameter <IPolicyDefinitionPropertiesParameters>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>]
 [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy definition in the given subscription with the given name.

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

### -DefinitionParameter
Required if a parameter is used in policy rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesParameters
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Description
The policy definition description.

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
The display name of the policy definition.

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
The ID of the policy definition.

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
The policy definition metadata.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesMetadata
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Mode
The policy definition mode.
Possible values are NotSpecified, Indexed, and All.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode
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
The name of the policy definition to create.

```yaml
Type: System.String
Parameter Sets: Update, Update1, UpdateExpanded, UpdateExpanded1
Aliases: PolicyDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
HELP MESSAGE MISSING
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition
Parameter Sets: Update, Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PolicyRule
The policy rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesPolicyRule
Parameter Sets: UpdateById, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateById, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IPolicyDefinition>: HELP MESSAGE MISSING
  - `[Description <String>]`: The policy definition description.
  - `[DisplayName <String>]`: The display name of the policy definition.
  - `[Metadata <IPolicyDefinitionPropertiesMetadata>]`: The policy definition metadata.
  - `[Mode <PolicyMode?>]`: The policy definition mode. Possible values are NotSpecified, Indexed, and All.
  - `[Parameter <IPolicyDefinitionPropertiesParameters>]`: Required if a parameter is used in policy rule.
  - `[PolicyRule <IPolicyDefinitionPropertiesPolicyRule>]`: The policy rule.
  - `[PolicyType <PolicyType?>]`: The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.

## RELATED LINKS

