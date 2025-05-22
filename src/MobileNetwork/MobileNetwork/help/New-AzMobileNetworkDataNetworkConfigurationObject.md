---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/Az.MobileNetwork/new-azmobilenetworkdatanetworkconfigurationobject
schema: 2.0.0
---

# New-AzMobileNetworkDataNetworkConfigurationObject

## SYNOPSIS
Create an in-memory object for DataNetworkConfiguration.

## SYNTAX

```
New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService <IServiceResourceId[]>
 -DataNetworkId <String> -SessionAmbrDownlink <String> -SessionAmbrUplink <String>
 [-AdditionalAllowedSessionType <String[]>] [-AllocationAndRetentionPriorityLevel <Int32>]
 [-DefaultSessionType <String>] [-FiveQi <Int32>] [-MaximumNumberOfBufferedPacket <Int32>]
 [-PreemptionCapability <String>] [-PreemptionVulnerability <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataNetworkConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for DataNetworkConfiguration.
```powershell
$ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"

New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/dataNetworks/azps-mn-datanetwork" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'
```

```output
AdditionalAllowedSessionType AllocationAndRetentionPriorityLevel DefaultSessionType FiveQi MaximumNumberOfBufferedPacket PreemptionCapability PreemptionVulnerability
---------------------------- ----------------------------------- ------------------ ------ ----------------------------- -------------------- -----------------------
                             9                                   IPv4               9      200                           NotPreempt           Preemptable
```

Create an in-memory object for DataNetworkConfiguration.

## PARAMETERS

### -AdditionalAllowedSessionType
Allowed session types in addition to the default session type.
Must not duplicate the default session type.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllocationAndRetentionPriorityLevel
Default QoS Flow allocation and retention priority (ARP) level.
Flows with higher priority preempt flows with lower priority, if the settings of preemptionCapability and preemptionVulnerability allow it.
1 is the highest level of priority.
If this field is not specified then 5qi is used to derive the ARP value.
See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.

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

### -AllowedService
List of services that can be used as part of this SIM policy.
The list must not contain duplicate items and must contain at least one item.
The services must be in the same location as the SIM policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IServiceResourceId[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataNetworkId
Data network resource ID.

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

### -DefaultSessionType
The default PDU session type, which is used if the UE does not request a specific session type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FiveQi
Default 5G QoS Flow Indicator value.
The 5QI identifies a specific QoS forwarding treatment to be provided to a flow.
See 3GPP TS23.501 section 5.7.2.1 for a full description of the 5QI parameter, and table 5.7.4-1 for the definition the 5QI values.

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

### -MaximumNumberOfBufferedPacket
The maximum number of downlink packets to buffer at the user plane for High Latency Communication - Extended Buffering.
See 3GPP TS29.272 v15.10.0 section 7.3.188 for a full description.
This maximum is not guaranteed because there is a internal limit on buffered packets across all PDU sessions.

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

### -PreemptionCapability
Default QoS Flow preemption capability.
The preemption capability of a QoS Flow controls whether it can preempt another QoS Flow with a lower priority level.
See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreemptionVulnerability
Default QoS Flow preemption vulnerability.
The preemption vulnerability of a QoS Flow controls whether it can be preempted by a QoS Flow with a higher priority level.
See 3GPP TS23.501 section 5.7.2.2 for a full description of the ARP parameters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionAmbrDownlink
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

### -SessionAmbrUplink
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.DataNetworkConfiguration

## NOTES

## RELATED LINKS
