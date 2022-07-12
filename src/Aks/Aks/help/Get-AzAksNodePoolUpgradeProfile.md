---
external help file:
Module Name: Az.Aks
online version: https://docs.microsoft.com/powershell/module/az.aks/get-azaksnodepoolupgradeprofile
schema: 2.0.0
---

# Get-AzAksNodePoolUpgradeProfile

## SYNOPSIS
Gets the details of the upgrade profile for an agent pool with a specified resource group and managed cluster name.

## SYNTAX

### Get (Default)
```
Get-AzAksNodePoolUpgradeProfile -ClusterName <String> -NodePoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksNodePoolUpgradeProfile -InputObject <IAksIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the upgrade profile for an agent pool with a specified resource group and managed cluster name.

## EXAMPLES

### Example 1: Get Aks node pool upgrade profile with resource group name and cluster name
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```

```output
Name    Type
----    ----
default Microsoft.ContainerService/managedClusters/agentPools/upgradeProfiles
```

Get Aks node pool upgrade profile with resource group name and cluster name.

## PARAMETERS

### -ClusterName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NodePoolName
The name of the agent pool.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AgentPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IAksIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of a supported Azure region.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

