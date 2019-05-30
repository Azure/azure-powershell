---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azpolicyassignment
schema: 2.0.0
---

# New-AzPolicyAssignment

## SYNOPSIS
This operation creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

## SYNTAX

### Create1 (Default)
```
New-AzPolicyAssignment -Id <String> [-Parameter <IPolicyAssignment>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzPolicyAssignment -Name <String> -SkuName <String> [-Scope <String>] [-Parameter <IPolicyAssignment>]
 [-Description <String>] [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-Location <String>]
 [-Metadata <IPolicyAssignmentPropertiesMetadata>] [-NotScope <String[]>] [-PolicyDefinitionId <String>]
 [-PropertiesScope <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzPolicyAssignment -Name <String> [-Scope <String>] [-Parameter <IPolicyAssignment>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> -SkuName <String> [-Scope <String>]
 [-Parameter <IPolicyAssignment>] [-Description <String>] [-DisplayName <String>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-Metadata <IPolicyAssignmentPropertiesMetadata>]
 [-NotScope <String[]>] [-PolicyDefinitionId <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> -SkuName <String> [-Scope <String>]
 [-Parameter <IPolicyAssignment>] [-Description <String>] [-DisplayName <String>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-Metadata <IPolicyAssignmentPropertiesMetadata>]
 [-NotScope <String[]>] [-PolicyDefinitionId <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzPolicyAssignment -Id <String> -SkuName <String> [-Scope <String>] [-Parameter <IPolicyAssignment>]
 [-Description <String>] [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-Location <String>]
 [-Metadata <IPolicyAssignmentPropertiesMetadata>] [-NotScope <String[]>] [-PolicyDefinitionId <String>]
 [-SkuTier <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> [-Parameter <IPolicyAssignment>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> [-Parameter <IPolicyAssignment>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

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
This message will be part of response in case of policy violation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayName
The display name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The ID of the policy assignment to create.
Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: PolicyAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
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
Parameter Sets: CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateViaIdentity1, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
The location of the policy assignment.
Only required when utilizing managed identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metadata
The policy assignment metadata.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignmentPropertiesMetadata
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NotScope
The policy's excluded scopes.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The policy assignment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PolicyDefinitionId
The ID of the policy definition or policy set definition being assigned.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesScope
The scope for the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope for the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The name of the policy sku.
Possible values are A0 and A1.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
The policy sku tier.
Possible values are Free and Standard.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded1, CreateViaIdentityExpanded, CreateExpanded1
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment

## ALIASES

## RELATED LINKS

