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

### Update (Default)
```
Set-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzPolicyDefinition -Name <String> -ManagementGroupName <String> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzPolicyDefinition -Name <String> -ManagementGroupName <String> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Set-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity1
```
Set-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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

### -Description
The policy definition description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentity1, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ManagementGroupName
The ID of the management group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, Update1
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
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded1, UpdateExpanded, Update1
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded1, UpdateExpanded, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition

## ALIASES

## RELATED LINKS

