---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.vmware/update-azvmwareglobalreachconnection
schema: 2.0.0
---

# Update-AzVMwareGlobalReachConnection

## SYNOPSIS
Create a global reach connection in a private cloud

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzVMwareGlobalReachConnection -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AuthorizationKey <String>] [-ExpressRouteId <String>]
 [-PeerExpressRouteCircuit <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityPrivateCloudExpanded
```
Update-AzVMwareGlobalReachConnection -Name <String> -PrivateCloudInputObject <IVMwareIdentity>
 [-AuthorizationKey <String>] [-ExpressRouteId <String>] [-PeerExpressRouteCircuit <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVMwareGlobalReachConnection -InputObject <IVMwareIdentity> [-AuthorizationKey <String>]
 [-ExpressRouteId <String>] [-PeerExpressRouteCircuit <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a global reach connection in a private cloud

## EXAMPLES

### EXAMPLE 1
```
Update-AzVMwareGlobalReachConnection -Name azps_test_grc -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationKey
Authorization key from the peer express route used for the global reach connection

```yaml
Type: String
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteId
The ID of the Private Cloud's ExpressRoute Circuit that is participating in the global reach connection

```yaml
Type: String
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IVMwareIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the global reach connection in the private cloud

```yaml
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateCloudExpanded
Aliases: GlobalReachConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerExpressRouteCircuit
Identifier of the ExpressRoute Circuit to peer with in the global reach connection

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateCloudInputObject
Identity Parameter
To construct, see NOTES section for PRIVATECLOUDINPUTOBJECT properties and create a hash table.

```yaml
Type: IVMwareIdentity
Parameter Sets: UpdateViaIdentityPrivateCloudExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateCloudName
The name of the private cloud.

```yaml
Type: String
Parameter Sets: UpdateExpanded
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
Type: String
Parameter Sets: UpdateExpanded
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
Type: String
Parameter Sets: UpdateExpanded
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IGlobalReachConnection
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IVMwareIdentity\>: Identity Parameter
  \[AddonName \<String\>\]: Name of the addon for the private cloud
  \[AuthorizationName \<String\>\]: Name of the ExpressRoute Circuit Authorization in the private cloud
  \[CloudLinkName \<String\>\]: Name of the cloud link resource
  \[ClusterName \<String\>\]: Name of the cluster in the private cloud
  \[DatastoreName \<String\>\]: Name of the datastore in the private cloud cluster
  \[DhcpId \<String\>\]: NSX DHCP identifier.
Generally the same as the DHCP display name
  \[DnsServiceId \<String\>\]: NSX DNS Service identifier.
Generally the same as the DNS Service's display name
  \[DnsZoneId \<String\>\]: NSX DNS Zone identifier.
Generally the same as the DNS Zone's display name
  \[GatewayId \<String\>\]: NSX Gateway identifier.
Generally the same as the Gateway's display name
  \[GlobalReachConnectionName \<String\>\]: Name of the global reach connection in the private cloud
  \[HcxEnterpriseSiteName \<String\>\]: Name of the HCX Enterprise Site in the private cloud
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Azure region
  \[PlacementPolicyName \<String\>\]: Name of the VMware vSphere Distributed Resource Scheduler (DRS) placement policy
  \[PortMirroringId \<String\>\]: NSX Port Mirroring identifier.
Generally the same as the Port Mirroring display name
  \[PrivateCloudName \<String\>\]: Name of the private cloud
  \[PublicIPId \<String\>\]: NSX Public IP Block identifier.
Generally the same as the Public IP Block's display name
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScriptCmdletName \<String\>\]: Name of the script cmdlet resource in the script package in the private cloud
  \[ScriptExecutionName \<String\>\]: Name of the user-invoked script execution resource
  \[ScriptPackageName \<String\>\]: Name of the script package in the private cloud
  \[SegmentId \<String\>\]: NSX Segment identifier.
Generally the same as the Segment's display name
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[VMGroupId \<String\>\]: NSX VM Group identifier.
Generally the same as the VM Group's display name
  \[VirtualMachineId \<String\>\]: Virtual Machine identifier
  \[WorkloadNetworkName \<String\>\]: Name for the workload network in the private cloud

PRIVATECLOUDINPUTOBJECT \<IVMwareIdentity\>: Identity Parameter
  \[AddonName \<String\>\]: Name of the addon for the private cloud
  \[AuthorizationName \<String\>\]: Name of the ExpressRoute Circuit Authorization in the private cloud
  \[CloudLinkName \<String\>\]: Name of the cloud link resource
  \[ClusterName \<String\>\]: Name of the cluster in the private cloud
  \[DatastoreName \<String\>\]: Name of the datastore in the private cloud cluster
  \[DhcpId \<String\>\]: NSX DHCP identifier.
Generally the same as the DHCP display name
  \[DnsServiceId \<String\>\]: NSX DNS Service identifier.
Generally the same as the DNS Service's display name
  \[DnsZoneId \<String\>\]: NSX DNS Zone identifier.
Generally the same as the DNS Zone's display name
  \[GatewayId \<String\>\]: NSX Gateway identifier.
Generally the same as the Gateway's display name
  \[GlobalReachConnectionName \<String\>\]: Name of the global reach connection in the private cloud
  \[HcxEnterpriseSiteName \<String\>\]: Name of the HCX Enterprise Site in the private cloud
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Azure region
  \[PlacementPolicyName \<String\>\]: Name of the VMware vSphere Distributed Resource Scheduler (DRS) placement policy
  \[PortMirroringId \<String\>\]: NSX Port Mirroring identifier.
Generally the same as the Port Mirroring display name
  \[PrivateCloudName \<String\>\]: Name of the private cloud
  \[PublicIPId \<String\>\]: NSX Public IP Block identifier.
Generally the same as the Public IP Block's display name
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScriptCmdletName \<String\>\]: Name of the script cmdlet resource in the script package in the private cloud
  \[ScriptExecutionName \<String\>\]: Name of the user-invoked script execution resource
  \[ScriptPackageName \<String\>\]: Name of the script package in the private cloud
  \[SegmentId \<String\>\]: NSX Segment identifier.
Generally the same as the Segment's display name
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[VMGroupId \<String\>\]: NSX VM Group identifier.
Generally the same as the VM Group's display name
  \[VirtualMachineId \<String\>\]: Virtual Machine identifier
  \[WorkloadNetworkName \<String\>\]: Name for the workload network in the private cloud

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.vmware/update-azvmwareglobalreachconnection](https://learn.microsoft.com/powershell/module/az.vmware/update-azvmwareglobalreachconnection)

