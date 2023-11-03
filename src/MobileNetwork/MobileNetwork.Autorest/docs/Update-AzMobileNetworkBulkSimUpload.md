---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworkbulksimupload
schema: 2.0.0
---

# Update-AzMobileNetworkBulkSimUpload

## SYNOPSIS
Bulk upload SIMs to a SIM group.

## SYNTAX

### BulkViaIdentityExpanded (Default)
```
Update-AzMobileNetworkBulkSimUpload -InputObject <IMobileNetworkIdentity> -Sim <ISimNameAndProperties[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BulkExpanded
```
Update-AzMobileNetworkBulkSimUpload -ResourceGroupName <String> -SimGroupName <String>
 -Sim <ISimNameAndProperties[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Bulk upload SIMs to a SIM group.

## EXAMPLES

### Example 1: Bulk uploading Sims
```powershell
$sim1 = @{Name = "BulkSim01"; InternationalMobileSubscriberIdentity = "0000000001"; AuthenticationKey = "00000000000000000000000000000001"; OperatorKeyCode = "00000000000000000000000000000001"}
$sim2 = @{Name = "BulkSim02"; InternationalMobileSubscriberIdentity = "0000000002"; AuthenticationKey = "00000000000000000000000000000002"; OperatorKeyCode = "00000000000000000000000000000002"}
$sims = @($sim1,$sim2)
Update-AzMobileNetworkBulkSimUpload -ResourceGroupName azps_test_group -SimGroupName SimGroup01 -Sim $sims
```

Bulks uploads multiple sims into a SimGroup.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: BulkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: BulkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sim
A list of SIMs to upload.
To construct, see NOTES section for SIM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISimNameAndProperties[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SimGroupName
The name of the SIM Group.

```yaml
Type: System.String
Parameter Sets: BulkExpanded
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
Parameter Sets: BulkExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IAsyncOperationStatus

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMobileNetworkIdentity>`: Identity Parameter
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

`SIM <ISimNameAndProperties[]>`: A list of SIMs to upload.
  - `InternationalMobileSubscriberIdentity <String>`: The international mobile subscriber identity (IMSI) for the SIM.
  - `Name <String>`: The name of the SIM.
  - `[AuthenticationKey <String>]`: The Ki value for the SIM.
  - `[DeviceType <String>]`: An optional free-form text field that can be used to record the device type this SIM is associated with, for example 'Video camera'. The Azure portal allows SIMs to be grouped and filtered based on this value.
  - `[IntegratedCircuitCardIdentifier <String>]`: The integrated circuit card ID (ICCID) for the SIM.
  - `[OperatorKeyCode <String>]`: The Opc value for the SIM.
  - `[SimPolicyId <String>]`: SIM policy resource ID.
  - `[StaticIPConfiguration <ISimStaticIPProperties[]>]`: A list of static IP addresses assigned to this SIM. Each address is assigned at a defined network scope, made up of {attached data network, slice}.
    - `[AttachedDataNetworkId <String>]`: Attached data network resource ID.
    - `[SlouseId <String>]`: Slice resource ID.
    - `[StaticIPIpv4Address <String>]`: The IPv4 address assigned to the SIM at this network scope. This address must be in the userEquipmentStaticAddressPoolPrefix defined in the attached data network.

## RELATED LINKS

