---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.vmware/get-azvmwareprivatecloud
schema: 2.0.0
---

# Get-AzVMwarePrivateCloud

## SYNOPSIS
Get a private cloud

## SYNTAX

### List1 (Default)
```
Get-AzVMwarePrivateCloud [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwarePrivateCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwarePrivateCloud -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzVMwarePrivateCloud -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a private cloud

## EXAMPLES

### Example 1: List private cloud under subscription
```powershell
Get-AzVMwarePrivateCloud
```
```output
Location      Name            Type
--------      ----            ----
australiaeast azps_test_cloud Microsoft.AVS/privateClouds
```

List private cloud under subscription

### Example 2: List private cloud under resource group
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

List private cloud under resource group

### Example 3: Get a private cloud by name
```powershell
Get-AzVMwarePrivateCloud -ResourceGroupName azps_test_group -Name azps_test_cloud
```
```output
Location      Name            Type                        ResourceGroupName
--------      ----            ----                        -----------------
australiaeast azps_test_cloud Microsoft.AVS/privateClouds azps_test_group
```

Get a private cloud by name

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
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateCloudName

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IPrivateCloud

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

