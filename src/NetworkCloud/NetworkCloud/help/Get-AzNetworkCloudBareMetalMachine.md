---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudbaremetalmachine
schema: 2.0.0
---

# Get-AzNetworkCloudBareMetalMachine

## SYNOPSIS
Get properties of the provided bare metal machine.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudBareMetalMachine [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudBareMetalMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudBareMetalMachine -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudBareMetalMachine -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided bare metal machine.

## EXAMPLES

### Example 1: List bare metal machines by subscription
```powershell
Get-AzNetworkCloudBareMetalMachine -SubscriptionId subscriptionId
```

```output
Location  Name             SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt      SystemDataLastModifiedBy
--------  ----             -------------------   -------------------  ----------------------- ------------------------      ------------
westus3  rack1compute01    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1compute02    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1compute03    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1control01    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>
westus3  rack1control02    07/19/2023 15:44:02   <identity>           User                    07/19/2023 15:46:45           <identity>

```

This command lists bare metal machines by subscription.

### Example 2: Get bare metal machine
```powershell
 Get-AzNetworkCloudBareMetalMachine -Name rack1control02 -ResourceGroupName resourceGroupName
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType ResourceGroupName
-------- ----           ------------------- -------------------    ----------------------- ------------------------ ------------------------    ---------------------------- -----------------
eastus   rack1control02 08/12/2023 23:14:00  <identity>            User                     08/17/2023 13:36:42      <identity>                  User                         resourceGroupName
```

This command gets details of a bare metal machine.

### Example 3: List bare metal machines by resource group
```powershell
Get-AzNetworkCloudBareMetalMachine -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location  Name                    SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                         -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  rack1compute01 07/19/2023 15:44:02   <identity>                         User                                          07/19/2023 15:46:45           <identity>
```

This command lists bare metal machines by resource group.

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the bare metal machine.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BareMetalMachineName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IBareMetalMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <INetworkCloudIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the Kubernetes cluster agent pool.
  - `[BareMetalMachineKeySetName <String>]`: The name of the bare metal machine key set.
  - `[BareMetalMachineName <String>]`: The name of the bare metal machine.
  - `[BmcKeySetName <String>]`: The name of the baseboard management controller key set.
  - `[CloudServicesNetworkName <String>]`: The name of the cloud services network.
  - `[ClusterManagerName <String>]`: The name of the cluster manager.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConsoleName <String>]`: The name of the virtual machine console.
  - `[Id <String>]`: Resource identity path
  - `[KubernetesClusterName <String>]`: The name of the Kubernetes cluster.
  - `[L2NetworkName <String>]`: The name of the L2 network.
  - `[L3NetworkName <String>]`: The name of the L3 network.
  - `[MetricsConfigurationName <String>]`: The name of the metrics configuration for the cluster.
  - `[RackName <String>]`: The name of the rack.
  - `[RackSkuName <String>]`: The name of the rack SKU.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageApplianceName <String>]`: The name of the storage appliance.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[TrunkedNetworkName <String>]`: The name of the trunked network.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.
  - `[VolumeName <String>]`: The name of the volume.

## RELATED LINKS

