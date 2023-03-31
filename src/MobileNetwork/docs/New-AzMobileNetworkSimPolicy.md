---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/new-azmobilenetworksimpolicy
schema: 2.0.0
---

# New-AzMobileNetworkSimPolicy

## SYNOPSIS
Creates or updates a SIM policy.
Must be created in the same location as its parent mobile network.

## SYNTAX

```
New-AzMobileNetworkSimPolicy -MobileNetworkName <String> -Name <String> -ResourceGroupName <String>
 -DefaultSliceId <String> -Location <String> -SliceConfiguration <ISliceConfiguration[]>
 -UeAmbrDownlink <String> -UeAmbrUplink <String> [-SubscriptionId <String>] [-RegistrationTimer <Int32>]
 [-RfspIndex <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a SIM policy.
Must be created in the same location as its parent mobile network.

## EXAMPLES

### Example 1: Creates or updates a SIM policy.
```powershell
$ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"

$DataNetworkConfiguration = New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'

$SliceConfiguration = New-AzMobileNetworkSliceConfigurationObject -DataNetworkConfiguration $DataNetworkConfiguration -DefaultDataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SliceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/slices/azps-mn-slice"

New-AzMobileNetworkSimPolicy -MobileNetworkName azps-mn -Name azps-mn-simpolicy -ResourceGroupName azps_test_group -Location eastus -DefaultSliceId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/slices/azps-mn-slice" -SliceConfiguration $SliceConfiguration -UeAmbrDownlink "1 Gbps" -UeAmbrUplink "500 Mbps" -RegistrationTimer 3240
```

```output
Location Name              ResourceGroupName ProvisioningState RegistrationTimer UeAmbrDownlink UeAmbrUplink
-------- ----              ----------------- ----------------- ----------------- -------------- ------------
eastus   azps-mn-simpolicy azps_test_group   Succeeded         3240              1 Gbps         500 Mbps
```

Creates or updates a SIM policy.
Must be created in the same location as its parent mobile network.

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

### -DefaultSliceId
Slice resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileNetworkName
The name of the mobile network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the SIM policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SimPolicyName

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

### -RegistrationTimer
Interval for the UE periodic registration update procedure, in seconds.

```yaml
Type: System.Int32
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RfspIndex
RAT/Frequency Selection Priority Index, defined in 3GPP TS 36.413.
This is an optional setting and by default is unspecified.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SliceConfiguration
The allowed slices and the settings to use for them.
The list must not contain duplicate items and must contain at least one item.
To construct, see NOTES section for SLICECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISliceConfiguration[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UeAmbrDownlink
Downlink bit rate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UeAmbrUplink
Uplink bit rate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISimPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SLICECONFIGURATION <ISliceConfiguration[]>: The allowed slices and the settings to use for them. The list must not contain duplicate items and must contain at least one item.
  - `DataNetworkConfiguration <IDataNetworkConfiguration[]>`: The allowed data networks and the settings to use for them. The list must not contain duplicate items and must contain at least one item.
    - `AllowedService <IServiceResourceId[]>`: List of services that can be used as part of this SIM policy. The list must not contain duplicate items and must contain at least one item. The services must be in the same location as the SIM policy.
      - `Id <String>`: Service resource ID.
    - `DataNetworkId <String>`: Data network resource ID.
    - `SessionAmbrDownlink <String>`: Downlink bit rate.
    - `SessionAmbrUplink <String>`: Uplink bit rate.
    - `[AdditionalAllowedSessionType <PduSessionType[]>]`: Allowed session types in addition to the default session type. Must not duplicate the default session type.
    - `[AllocationAndRetentionPriorityLevel <Int32?>]`: Default QoS Flow allocation and retention priority (ARP) level. Flows with higher priority preempt flows with lower priority, if the settings of `preemptionCapability` and `preemptionVulnerability` allow it. 1 is the highest level of priority. If this field is not specified then `5qi` is used to derive the ARP value. See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.
    - `[DefaultSessionType <PduSessionType?>]`: The default PDU session type, which is used if the UE does not request a specific session type.
    - `[FiveQi <Int32?>]`: Default 5G QoS Flow Indicator value. The 5QI identifies a specific QoS forwarding treatment to be provided to a flow. See 3GPP TS23.501 section 5.7.2.1 for a full description of the 5QI parameter, and table 5.7.4-1 for the definition the 5QI values.
    - `[MaximumNumberOfBufferedPacket <Int32?>]`: The maximum number of downlink packets to buffer at the user plane for High Latency Communication - Extended Buffering. See 3GPP TS29.272 v15.10.0 section 7.3.188 for a full description. This maximum is not guaranteed because there is a internal limit on buffered packets across all PDU sessions.
    - `[PreemptionCapability <PreemptionCapability?>]`: Default QoS Flow preemption capability. The preemption capability of a QoS Flow controls whether it can preempt another QoS Flow with a lower priority level. See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.
    - `[PreemptionVulnerability <PreemptionVulnerability?>]`: Default QoS Flow preemption vulnerability. The preemption vulnerability of a QoS Flow controls whether it can be preempted by a QoS Flow with a higher priority level. See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.
  - `DefaultDataNetworkId <String>`: Data network resource ID.
  - `SlouseId <String>`: Slice resource ID.

## RELATED LINKS

