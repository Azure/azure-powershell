---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azpolicyassignment
schema: 2.0.0
---

# New-AzPolicyAssignment

## SYNOPSIS
Policy assignments are inherited by child resources.
For example, when you apply a policy to a resource group that policy is assigned to all resources in the group.

## SYNTAX

### Create2 (Default)
```
New-AzPolicyAssignment [-Name <String>] [-Scope <String>] [-Parameter <IPolicyAssignment>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded2
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> [-Name <String>] [-Scope <String>]
 [-Parameter <IPolicyAssignment>] [-Description <String>] [-DisplayName <String>]
 [-PolicyDefinitionId <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded2
```
New-AzPolicyAssignment -PolicyAssignmentName <String> [-Name <String>] [-Scope <String>]
 [-Parameter <IPolicyAssignment>] [-Description <String>] [-DisplayName <String>]
 [-PolicyDefinitionId <String>] [-PropertiesScope <String>] [-Type <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity2
```
New-AzPolicyAssignment -InputObject <IResourcesIdentity> [-Parameter <IPolicyAssignment>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Policy assignments are inherited by child resources.
For example, when you apply a policy to a resource group that policy is assigned to all resources in the group.

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
Parameter Sets: CreateViaIdentityExpanded2, CreateExpanded2
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
Parameter Sets: CreateViaIdentityExpanded2, CreateExpanded2
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
Parameter Sets: CreateViaIdentityExpanded2, CreateViaIdentity2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: Create2, CreateViaIdentityExpanded2, CreateExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The policy assignment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyAssignment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PolicyAssignmentName
The name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PolicyDefinitionId
The ID of the policy definition or policy set definition being assigned.

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded2, CreateExpanded2
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
Parameter Sets: CreateExpanded2
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
Parameter Sets: Create2, CreateViaIdentityExpanded2, CreateExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
The type of the policy assignment.

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded2, CreateExpanded2
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyAssignment

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyAssignment

## ALIASES

## RELATED LINKS

