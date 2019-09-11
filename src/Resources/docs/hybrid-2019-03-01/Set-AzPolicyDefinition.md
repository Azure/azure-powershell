---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azpolicydefinition
schema: 2.0.0
---

# Set-AzPolicyDefinition

## SYNOPSIS
Creates or updates a policy definition.

## SYNTAX

### UpdateExpanded2 (Default)
```
Set-AzPolicyDefinition -Name <String> [-SubscriptionId <String>]
 [-DefinitionPropertiesParameter <IPolicyDefinitionPropertiesParameters>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>]
 [-PolicyRule <Hashtable>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update2
```
Set-AzPolicyDefinition -Name <String> -Parameter <IPolicyDefinition> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update3
```
Set-AzPolicyDefinition -ManagementGroupName <String> -Name <String> -Parameter <IPolicyDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateById
```
Set-AzPolicyDefinition -Id <String> [-SubscriptionId <String>] [-Description <String>] [-DisplayName <String>]
 [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>] [-PolicyRule <Hashtable>]
 [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded3
```
Set-AzPolicyDefinition -ManagementGroupName <String> -Name <String>
 [-DefinitionPropertiesParameter <IPolicyDefinitionPropertiesParameters>] [-Description <String>]
 [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>] [-Mode <PolicyMode>]
 [-PolicyRule <Hashtable>] [-PolicyType <PolicyType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a policy definition.

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

### -DefinitionPropertiesParameter
Required if a parameter is used in policy rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesParameters
Parameter Sets: UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: Update3, UpdateExpanded3
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
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: Update2, Update3, UpdateExpanded2, UpdateExpanded3
Aliases: PolicyDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The policy definition.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition
Parameter Sets: Update2, Update3
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
Type: System.Collections.Hashtable
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: UpdateById, UpdateExpanded2, UpdateExpanded3
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
Parameter Sets: Update2, UpdateById, UpdateExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IPolicyDefinition>: The policy definition.
  - `[Description <String>]`: The policy definition description.
  - `[DisplayName <String>]`: The display name of the policy definition.
  - `[Metadata <IPolicyDefinitionPropertiesMetadata>]`: The policy definition metadata.
  - `[Mode <PolicyMode?>]`: The policy definition mode. Possible values are NotSpecified, Indexed, and All.
  - `[Parameter <IPolicyDefinitionPropertiesParameters>]`: Required if a parameter is used in policy rule.
  - `[PolicyRule <IPolicyDefinitionPropertiesPolicyRule>]`: The policy rule.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyType <PolicyType?>]`: The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.

## RELATED LINKS

