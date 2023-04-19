---
external help file:
Module Name: Az.ContainerService
online version: https://learn.microsoft.com/powershell/module/az.containerservice/reset-azcontainerservicemanagedclusteraadprofile
schema: 2.0.0
---

# Reset-AzContainerServiceManagedClusterAadProfile

## SYNOPSIS
**WARNING**: This API will be deprecated.
Please see [AKS-managed Azure Active Directory integration](https://aka.ms/aks-managed-aad) to update your cluster with AKS-managed Azure AD.

## SYNTAX

### ResetExpanded (Default)
```
Reset-AzContainerServiceManagedClusterAadProfile -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AdminGroupObjectID <String[]>] [-ClientAppId <String>] [-EnableAzureRbac]
 [-Managed] [-ServerAppId <String>] [-ServerAppSecret <String>] [-TenantId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reset
```
Reset-AzContainerServiceManagedClusterAadProfile -ResourceGroupName <String> -ResourceName <String>
 -Parameter <IManagedClusterAadProfile> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentity
```
Reset-AzContainerServiceManagedClusterAadProfile -InputObject <IContainerServiceIdentity>
 -Parameter <IManagedClusterAadProfile> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentityExpanded
```
Reset-AzContainerServiceManagedClusterAadProfile -InputObject <IContainerServiceIdentity>
 [-AdminGroupObjectID <String[]>] [-ClientAppId <String>] [-EnableAzureRbac] [-Managed]
 [-ServerAppId <String>] [-ServerAppSecret <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
**WARNING**: This API will be deprecated.
Please see [AKS-managed Azure Active Directory integration](https://aka.ms/aks-managed-aad) to update your cluster with AKS-managed Azure AD.

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

### -AdminGroupObjectID
The list of AAD group object IDs that will have admin role of the cluster.

```yaml
Type: System.String[]
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ClientAppId
(DEPRECATED) The client AAD application ID.
Learn more at https://aka.ms/aks/aad-legacy.

```yaml
Type: System.String
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
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

### -EnableAzureRbac
Whether to enable Azure RBAC for Kubernetes authorization.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity
Parameter Sets: ResetViaIdentity, ResetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Managed
Whether to enable managed AAD.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
Aliases:

Required: False
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

### -Parameter
For more details see [managed AAD on AKS](https://docs.microsoft.com/azure/aks/managed-aad).
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedClusterAadProfile
Parameter Sets: Reset, ResetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Reset, ResetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: Reset, ResetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerAppId
(DEPRECATED) The server AAD application ID.
Learn more at https://aka.ms/aks/aad-legacy.

```yaml
Type: System.String
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerAppSecret
(DEPRECATED) The server AAD application secret.
Learn more at https://aka.ms/aks/aad-legacy.

```yaml
Type: System.String
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Reset, ResetExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The AAD tenant ID to use for authentication.
If not specified, will use the tenant of the deployment subscription.

```yaml
Type: System.String
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedClusterAadProfile

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerServiceIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[CommandId <String>]`: Id of the command.
  - `[ConfigName <String>]`: The name of the maintenance configuration.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`PARAMETER <IManagedClusterAadProfile>`: For more details see [managed AAD on AKS](https://docs.microsoft.com/azure/aks/managed-aad).
  - `[AdminGroupObjectID <String[]>]`: The list of AAD group object IDs that will have admin role of the cluster.
  - `[ClientAppId <String>]`: (DEPRECATED) The client AAD application ID. Learn more at https://aka.ms/aks/aad-legacy.
  - `[EnableAzureRbac <Boolean?>]`: Whether to enable Azure RBAC for Kubernetes authorization.
  - `[Managed <Boolean?>]`: Whether to enable managed AAD.
  - `[ServerAppId <String>]`: (DEPRECATED) The server AAD application ID. Learn more at https://aka.ms/aks/aad-legacy.
  - `[ServerAppSecret <String>]`: (DEPRECATED) The server AAD application secret. Learn more at https://aka.ms/aks/aad-legacy.
  - `[TenantId <String>]`: The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.

## RELATED LINKS

