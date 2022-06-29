---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.vmware/get-azvmwarevirtualmachine
schema: 2.0.0
---

# Get-AzVMwareVirtualMachine

## SYNOPSIS
Get a virtual machine by id in a private cloud cluster

## SYNTAX

### List (Default)
```
Get-AzVMwareVirtualMachine -ClusterName <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareVirtualMachine -ClusterName <String> -Id <String> -PrivateCloudName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareVirtualMachine -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a virtual machine by id in a private cloud cluster

## EXAMPLES

### Example 1: List virtual machine in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
vm-128 group1
```

List virtual machine in a private cloud cluster

### Example 2: Get a virtual machine by id in a private cloud cluster
```powershell
Get-AzVMwareVirtualMachine -Id vm-209 -ClusterName cluster1 -PrivateCloudName cloud1 -ResourceGroupName group1
```
```output
Name   ResourceGroupName
----   -----------------
vm-209 group1
```

Get a virtual machine by id in a private cloud cluster

## PARAMETERS

### -ClusterName
Name of the cluster in the private cloud

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -Id
Virtual Machine identifier

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualMachineId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IVirtualMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IVMwareIdentity>`: Identity Parameter
  - `[AddonName <String>]`: Name of the addon for the private cloud
  - `[AuthorizationName <String>]`: Name of the ExpressRoute Circuit Authorization in the private cloud
  - `[CloudLinkName <String>]`: Name of the cloud link resource
  - `[ClusterName <String>]`: Name of the cluster in the private cloud
  - `[DatastoreName <String>]`: Name of the datastore in the private cloud cluster
  - `[DhcpId <String>]`: NSX DHCP identifier. Generally the same as the DHCP display name
  - `[DnsServiceId <String>]`: NSX DNS Service identifier. Generally the same as the DNS Service's display name
  - `[DnsZoneId <String>]`: NSX DNS Zone identifier. Generally the same as the DNS Zone's display name
  - `[GatewayId <String>]`: NSX Gateway identifier. Generally the same as the Gateway's display name
  - `[GlobalReachConnectionName <String>]`: Name of the global reach connection in the private cloud
  - `[HcxEnterpriseSiteName <String>]`: Name of the HCX Enterprise Site in the private cloud
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Azure region
  - `[PlacementPolicyName <String>]`: Name of the VMware vSphere Distributed Resource Scheduler (DRS) placement policy
  - `[PortMirroringId <String>]`: NSX Port Mirroring identifier. Generally the same as the Port Mirroring display name
  - `[PrivateCloudName <String>]`: Name of the private cloud
  - `[PublicIPId <String>]`: NSX Public IP Block identifier. Generally the same as the Public IP Block's display name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScriptCmdletName <String>]`: Name of the script cmdlet resource in the script package in the private cloud
  - `[ScriptExecutionName <String>]`: Name of the user-invoked script execution resource
  - `[ScriptPackageName <String>]`: Name of the script package in the private cloud
  - `[SegmentId <String>]`: NSX Segment identifier. Generally the same as the Segment's display name
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VMGroupId <String>]`: NSX VM Group identifier. Generally the same as the VM Group's display name
  - `[VirtualMachineId <String>]`: Virtual Machine identifier

## RELATED LINKS

