---
external help file: Az.NetworkSecurity-help.xml
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/new-aznetworksecurityneuroshieldprotectedresource
schema: 2.0.0
---

# New-AzNetworkSecurityNeuroShieldProtectedResource

## SYNOPSIS
Create a protected resource under a NeuroShield resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityNeuroShieldProtectedResource -NeuroShieldName <String> -ProtectedResourceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] -TargetResourceId <String>
 [-TargetIdentityPrincipalId <String>] [-TargetIdentityTenantId <String>] [-TargetIdentityType <String>]
 [-TargetIdentityUserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityNeuroShieldProtectedResource -NeuroShieldName <String> -ProtectedResourceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityNeuroShieldProtectedResource -NeuroShieldName <String> -ProtectedResourceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityNeuroShieldProtectedResource -NeuroShieldName <String> -ProtectedResourceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-IfMatch <String>]
 -Resource <INeuroShieldProtectedResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNeuroShieldExpanded
```
New-AzNetworkSecurityNeuroShieldProtectedResource -ProtectedResourceName <String>
 -NeuroShieldInputObject <INetworkSecurityIdentity> [-IfMatch <String>] -TargetResourceId <String>
 [-TargetIdentityPrincipalId <String>] [-TargetIdentityTenantId <String>] [-TargetIdentityType <String>]
 [-TargetIdentityUserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNeuroShield
```
New-AzNetworkSecurityNeuroShieldProtectedResource -ProtectedResourceName <String>
 -NeuroShieldInputObject <INetworkSecurityIdentity> [-IfMatch <String>]
 -Resource <INeuroShieldProtectedResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityNeuroShieldProtectedResource -InputObject <INetworkSecurityIdentity> [-IfMatch <String>]
 -TargetResourceId <String> [-TargetIdentityPrincipalId <String>] [-TargetIdentityTenantId <String>]
 [-TargetIdentityType <String>] [-TargetIdentityUserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzNetworkSecurityNeuroShieldProtectedResource -InputObject <INetworkSecurityIdentity> [-IfMatch <String>]
 -Resource <INeuroShieldProtectedResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a protected resource under a NeuroShield resource.

## EXAMPLES

### Example 1: Register a virtual machine as a protected resource
```powershell
$targetResourceId = '/subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVM'
New-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -TargetResourceId $targetResourceId
```

Registers the target resource and waits for the asynchronous operation to complete.

Inventory assessments and remediation also require the `Microsoft.Azure.Networking/Neuron` VM extension, installed separately using the service-provided settings.
Its managed identity must be attached to the VM and match the protected-resource registration.
This cmdlet does not install the VM extension, and installing the VM extension alone does not register the protected resource.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -IfMatch
The entity tag that makes the request conditional.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NeuroShieldInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityNeuroShield
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NeuroShieldName
The name of the NeuroShield resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ProtectedResourceName
The name of the protected resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityNeuroShield
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Azure Resource Manager proxy child resource representing a protected resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldProtectedResource
Parameter Sets: Create, CreateViaIdentityNeuroShield, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetIdentityPrincipalId
Microsoft Entra service principal ID of the target's system-assigned identity.A nonzero value is required for SystemAssigned; omit for UserAssigned.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetIdentityTenantId
Microsoft Entra tenant ID of the target's system-assigned identity.A nonzero value is required for SystemAssigned; omit for UserAssigned.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetIdentityType
Type of the target identity.
None, SystemAssigned, and UserAssigned are supported.The declared combined system/user-assigned value is rejected by the operation.There is no default when an identity object is supplied.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetIdentityUserAssignedIdentity
User-assigned identities keyed by Azure Resource Manager resource ID.For UserAssigned, supply exactly one non-null entry with a nonblank key andnonzero principalId and clientId.
Other identity kinds reject a nonempty map.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
Azure Resource Manager resource ID of the target virtual machine or virtual machine scale set.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNeuroShieldExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldProtectedResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldProtectedResource

## NOTES

## RELATED LINKS
