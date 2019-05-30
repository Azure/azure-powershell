---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azpolicydefinition
schema: 2.0.0
---

# New-AzPolicyDefinition

## SYNOPSIS
Creates or updates a policy definition.

## SYNTAX

### Create2 (Default)
```
New-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded3
```
New-AzPolicyDefinition -Name <String> -ManagementGroupId <String> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded2
```
New-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create3
```
New-AzPolicyDefinition -Name <String> -ManagementGroupId <String> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded3
```
New-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded2
```
New-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <IPolicyDefinitionPropertiesMetadata>]
 [-Mode <PolicyMode>] [-PolicyRule <IPolicyDefinitionPropertiesPolicyRule>] [-PolicyType <PolicyType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity3
```
New-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity2
```
New-AzPolicyDefinition -InputObject <IResourcesIdentity> [-Parameter <IPolicyDefinition>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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

### -Description
The policy definition description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: CreateViaIdentityExpanded3, CreateViaIdentityExpanded2, CreateViaIdentity3, CreateViaIdentity2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ManagementGroupId
The ID of the management group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded3, Create3
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
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: Create2, CreateExpanded3, CreateExpanded2, Create3
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition
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
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: CreateExpanded3, CreateExpanded2, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
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
Parameter Sets: Create2, CreateExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinition

## ALIASES

## RELATED LINKS

