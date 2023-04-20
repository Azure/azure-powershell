---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/get-azmobilenetworkpacketcorecontrolplane
schema: 2.0.0
---

# Get-AzMobileNetworkPacketCoreControlPlane

## SYNOPSIS
Gets information about the specified packet core control plane.

## SYNTAX

### List (Default)
```
Get-AzMobileNetworkPacketCoreControlPlane [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMobileNetworkPacketCoreControlPlane -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMobileNetworkPacketCoreControlPlane -InputObject <IMobileNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzMobileNetworkPacketCoreControlPlane -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified packet core control plane.

## EXAMPLES

### Example 1: List information about the specified packet core control plane by Sub.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

List information about the specified packet core control plane by Sub.

### Example 2: Get information about the specified packet core control plane by ResourceGroup.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane -ResourceGroupName azps_test_group
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Get information about the specified packet core control plane by ResourceGroup.

### Example 3: Get information about the specified packet core control plane by Name.
```powershell
Get-AzMobileNetworkPacketCoreControlPlane -ResourceGroupName azps_test_group -Name azps-mn-pccp
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Get information about the specified packet core control plane by Name.

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the packet core control plane.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PacketCoreControlPlaneName

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPacketCoreControlPlane

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMobileNetworkIdentity>: Identity Parameter
  - `[AttachedDataNetworkName <String>]`: The name of the attached data network.
  - `[DataNetworkName <String>]`: The name of the data network.
  - `[Id <String>]`: Resource identity path
  - `[MobileNetworkName <String>]`: The name of the mobile network.
  - `[PacketCoreControlPlaneName <String>]`: The name of the packet core control plane.
  - `[PacketCoreDataPlaneName <String>]`: The name of the packet core data plane.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ServiceName <String>]`: The name of the service. You must not use any of the following reserved strings - 'default', 'requested' or 'service'
  - `[SimGroupName <String>]`: The name of the SIM Group.
  - `[SimName <String>]`: The name of the SIM.
  - `[SimPolicyName <String>]`: The name of the SIM policy.
  - `[SiteName <String>]`: The name of the mobile network site.
  - `[SliceName <String>]`: The name of the network slice.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VersionName <String>]`: The name of the packet core control plane version.

## RELATED LINKS

