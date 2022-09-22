---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/new-azorbitalcontactprofile
schema: 2.0.0
---

# New-AzOrbitalContactProfile

## SYNOPSIS
Creates or updates a contact profile.

## SYNTAX

```
New-AzOrbitalContactProfile -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AutoTrackingConfiguration <AutoTrackingConfiguration>] [-EventHubUri <String>]
 [-Link <IContactProfileLink[]>] [-MinimumElevationDegree <Single>] [-MinimumViableContactDuration <String>]
 [-NetworkConfigurationSubnetId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a contact profile.

## EXAMPLES

### Example 1: Creates or updates a contact profile.
```powershell
$linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 55555 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK

$profileLink = New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction Downlink -Name RHCP_UL -Polarization RHCP -EirpdBw 45 -GainOverTemperature 0

New-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest-gp -Location westus2 -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f -AutoTrackingConfiguration xBand -EventHubUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.EventHub/namespaces/eventhub-test -Link $profileLink -MinimumElevationDegree 10 -MinimumViableContactDuration PT1M -NetworkConfigurationSubnetId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Network/virtualNetworks/orbital-virtualnetwork/subnets/orbital-vn
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Creates or updates a contact profile.

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

### -AutoTrackingConfiguration
Auto-tracking configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Support.AutoTrackingConfiguration
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

### -EventHubUri
ARM resource identifier of the Event Hub used for telemetry.
Requires granting Orbital Resource Provider the rights to send telemetry into the hub.

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

### -Link
Links of the Contact Profile.
Describes RF links, modem processing, and IP endpoints.
To construct, see NOTES section for LINK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContactProfileLink[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -MinimumElevationDegree
Minimum viable elevation for the contact in decimal degrees.
Used for listing the available contacts with a spacecraft at a given ground station.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumViableContactDuration
Minimum viable contact duration in ISO 8601 format.
Used for listing the available contacts with a spacecraft at a given ground station.

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

### -Name
Contact Profile name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ContactProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationSubnetId
ARM resource identifier of the subnet delegated to the Microsoft.Orbital/orbitalGateways.
Needs to be at least a class C subnet, and should not have any IP created in it.

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContactProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`LINK <IContactProfileLink[]>`: Links of the Contact Profile. Describes RF links, modem processing, and IP endpoints.
  - `Channel <IContactProfileLinkChannel[]>`: Contact Profile Link Channel.
    - `BandwidthMHz <Single>`: Bandwidth in MHz.
    - `CenterFrequencyMHz <Single>`: Center Frequency in MHz.
    - `EndPointIPAddress <String>`: IP Address.
    - `EndPointName <String>`: Name of an end point.
    - `EndPointPort <String>`: TCP port to listen on to receive data.
    - `EndPointProtocol <Protocol>`: Protocol either UDP or TCP.
    - `Name <String>`: Channel name.
    - `[DecodingConfiguration <String>]`: Currently unused.
    - `[DemodulationConfiguration <String>]`: Copy of the modem configuration file such as Kratos QRadio or Kratos QuantumRx. Only valid for downlink directions. If provided, the modem connects to the customer endpoint and sends demodulated data instead of a VITA.49 stream.
    - `[EncodingConfiguration <String>]`: Currently unused.
    - `[ModulationConfiguration <String>]`: Copy of the modem configuration file such as Kratos QRadio. Only valid for uplink directions. If provided, the modem connects to the customer endpoint and accepts commands from the customer instead of a VITA.49 stream.
  - `Direction <Direction>`: Direction (uplink or downlink).
  - `Name <String>`: Link name.
  - `Polarization <Polarization>`: Polarization. e.g. (RHCP, LHCP).
  - `[EirpdBw <Single?>]`: Effective Isotropic Radiated Power (EIRP) in dBW. It is the required EIRP by the customer. Not used yet.
  - `[GainOverTemperature <Single?>]`: Gain To Noise Temperature in db/K. It is the required G/T by the customer. Not used yet.

## RELATED LINKS

