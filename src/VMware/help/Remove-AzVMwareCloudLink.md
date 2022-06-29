---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.vmware/remove-azvmwarecloudlink
schema: 2.0.0
---

# Remove-AzVMwareCloudLink

## SYNOPSIS
Delete a cloud link in a private cloud

## SYNTAX

### Delete (Default)
```
Remove-AzVMwareCloudLink -Name <String> -PrivateCloudName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzVMwareCloudLink -InputObject <IVMwareIdentity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete a cloud link in a private cloud

## EXAMPLES

### Example 1: Delete a cloud link
```powershell
Remove-AzVMwareCloudLink -Name azps_test_cloudlink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group

```

Delete a cloud link

### Example 2: Delete a cloud link
```powershell
Get-AzVMwareCloudLink -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -Name azps_test_cloudlink | Remove-AzVMwareCloudLink

```

Delete a cloud link

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
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the cloud link resource

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: CloudLinkName

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

### -PrivateCloudName
Name of the private cloud

```yaml
Type: System.String
Parameter Sets: Delete
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
Parameter Sets: Delete
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
Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity

## OUTPUTS

### System.Boolean

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

