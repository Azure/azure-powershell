---
external help file: Az.Aks-help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azaksmachine
schema: 2.0.0
---

# Get-AzAksMachine

## SYNOPSIS
Get a specific machine in the specified agent pool.

## SYNTAX

### List (Default)
```
Get-AzAksMachine -AgentPoolName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityManagedCluster
```
Get-AzAksMachine -AgentPoolName <String> -Name <String> -ManagedClusterInputObject <IAksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAksMachine -AgentPoolName <String> -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAgentPool
```
Get-AzAksMachine -Name <String> -AgentPoolInputObject <IAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksMachine -InputObject <IAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a specific machine in the specified agent pool.

## EXAMPLES

### Example 1: Get a specific machine in the specified agent pool.
```powershell
Get-AzAksMachine -AgentPoolName 'default' -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster
```

```output
Id                : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/agentPools/default/machines/aks-default-12988240-vmss000000
Name              : aks-default-12988240-vmss000000
NetworkIPAddress  : {{
                      "family": "IPv4",
                      "ip": "10.224.0.4"
                    }}
ResourceGroupName : AKS_TEST_RG
ResourceId        : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/MC_AKS_TEST_RG_AKS_Test_Cluster_eastus/providers/Microsoft.Compute/virtualMachineScaleSets/aks-default-12988240-vmss/virtualMachines/0
Type              : Microsoft.ContainerService/managedClusters/agentPools/machines
Zone              :
```

Get a specific machine in the specified agent pool.

## PARAMETERS

### -AgentPoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentityAgentPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AgentPoolName
The name of the agent pool.

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityManagedCluster, Get
Aliases:

Required: True
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

### -InputObject
Identity Parameter

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

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
host name of the machine

```yaml
Type: System.String
Parameter Sets: GetViaIdentityManagedCluster, Get, GetViaIdentityAgentPool
Aliases: MachineName

Required: True
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMachine

## NOTES

## RELATED LINKS
