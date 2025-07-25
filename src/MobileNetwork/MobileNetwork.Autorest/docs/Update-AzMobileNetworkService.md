---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworkservice
schema: 2.0.0
---

# Update-AzMobileNetworkService

## SYNOPSIS
Updates service.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMobileNetworkService -MobileNetworkName <String> -Name <String> -ResourceGroupName <String>
 -ServicePrecedence <Int32> [-SubscriptionId <String>] [-MaximumBitRateDownlink <String>]
 [-MaximumBitRateUplink <String>] [-PccRule <IPccRuleConfiguration[]>]
 [-ServiceQoPolicyAllocationAndRetentionPriorityLevel <Int32>] [-ServiceQoPolicyFiveQi <Int32>]
 [-ServiceQoPolicyPreemptionCapability <String>] [-ServiceQoPolicyPreemptionVulnerability <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMobileNetworkService -InputObject <IMobileNetworkIdentity> -ServicePrecedence <Int32>
 [-MaximumBitRateDownlink <String>] [-MaximumBitRateUplink <String>] [-PccRule <IPccRuleConfiguration[]>]
 [-ServiceQoPolicyAllocationAndRetentionPriorityLevel <Int32>] [-ServiceQoPolicyFiveQi <Int32>]
 [-ServiceQoPolicyPreemptionCapability <String>] [-ServiceQoPolicyPreemptionVulnerability <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMobileNetworkExpanded
```
Update-AzMobileNetworkService -MobileNetworkInputObject <IMobileNetworkIdentity> -Name <String>
 -ServicePrecedence <Int32> [-MaximumBitRateDownlink <String>] [-MaximumBitRateUplink <String>]
 [-PccRule <IPccRuleConfiguration[]>] [-ServiceQoPolicyAllocationAndRetentionPriorityLevel <Int32>]
 [-ServiceQoPolicyFiveQi <Int32>] [-ServiceQoPolicyPreemptionCapability <String>]
 [-ServiceQoPolicyPreemptionVulnerability <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates service.

## EXAMPLES

### Example 1: Updates service.
```powershell
Update-AzMobileNetworkService -MobileNetworkName azps-mn -ServiceName azps-mn-service -ResourceGroupName azps_test_group -Tag @{"abc"="123"} -ServicePrecedence 0
```

```output
Location Name            ResourceGroupName ProvisioningState Precedence MaximumBitRateDownlink MaximumBitRateUplink QoPolicyAllocationAndRetentionPriorityLevel QoPolicyFiveQi
-------- ----            ----------------- ----------------- ---------- ---------------------- -------------------- ------------------------------------------- --------------
eastus   azps-mn-service azps_test_group   Succeeded         0          1 Gbps                 500 Mbps             9                                           9
```

Updates service.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaximumBitRateDownlink
Downlink bit rate.

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

### -MaximumBitRateUplink
Uplink bit rate.

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

### -MobileNetworkInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: UpdateViaIdentityMobileNetworkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MobileNetworkName
The name of the mobile network.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the service.
You must not use any of the following reserved strings - 'default', 'requested' or 'service'

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMobileNetworkExpanded
Aliases: ServiceName

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

### -PccRule
The set of data flow policy rules that make up this service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IPccRuleConfiguration[]
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrecedence
A precedence value that is used to decide between services when identifying the QoS values to use for a particular SIM.
A lower value means a higher priority.
This value should be unique among all services configured in the mobile network.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceQoPolicyAllocationAndRetentionPriorityLevel
QoS Flow allocation and retention priority (ARP) level.
Flows with higher priority preempt flows with lower priority, if the settings of `preemptionCapability` and `preemptionVulnerability` allow it.
1 is the highest level of priority.
If this field is not specified then `5qi` is used to derive the ARP value.
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

### -ServiceQoPolicyFiveQi
5G QoS Flow Indicator value.
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

### -ServiceQoPolicyPreemptionCapability
QoS Flow preemption capability.
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

### -ServiceQoPolicyPreemptionVulnerability
QoS Flow preemption vulnerability.
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IService

## NOTES

## RELATED LINKS

