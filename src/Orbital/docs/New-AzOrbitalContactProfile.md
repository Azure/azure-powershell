---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/new-azorbitalcontactprofile
schema: 2.0.0
---

# New-AzOrbitalContactProfile

## SYNOPSIS
Creates or updates a contact profile

## SYNTAX

```
New-AzOrbitalContactProfile -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AutoTrackingConfiguration <AutoTrackingConfiguration>] [-EventHubUri <String>]
 [-Link <IContactProfileLink[]>] [-MinimumElevationDegree <Single>] [-MinimumViableContactDuration <String>]
 [-NetworkConfigurationSubnetId <String>] [-ProvisioningState <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a contact profile

## EXAMPLES

### Example 1: Creates or updates a contact profile.
```powershell
$linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 0.036 -CenterFrequencyMHz 2106.4063 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 4000 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK

$profileLink = New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction uplink -Name RHCP_UL -Polarization RHCP -EirpdBw 45 -GainOverTemperature 0

New-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest_gp -Location eastus -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f -AutoTrackingConfiguration xBand -EventHubUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest_gp/providers/Microsoft.EventHub/namespaces/orbital-eventhub/eventhub-test-0617 -Link $profileLink -MinimumElevationDegree 10 -MinimumViableContactDuration PT1M -NetworkConfigurationSubnetId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest_gp/providers/Microsoft.Network/virtualNetworks/orbital-virtualnetwork/subnets/default
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
Auto track configuration.

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
The URI of the Event Hub used for telemetry

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
Links of the Contact Profile
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
Contact Profile Name

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
Customer subnet ARM resource identifier.

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

### -ProvisioningState
The current state of the resource's creation, deletion, or modification

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


LINK <IContactProfileLink[]>: Links of the Contact Profile
  - `Channel <IContactProfileLinkChannel[]>`: Contact Profile Link Channel
    - `BandwidthMHz <Single>`: Bandwidth in MHz
    - `CenterFrequencyMHz <Single>`: Center Frequency in MHz
    - `EndPointIPAddress <String>`: IP Address.
    - `EndPointName <String>`: Name of an end point.
    - `EndPointPort <String>`: TCP port to listen on to receive data.
    - `EndPointProtocol <Protocol>`: Protocol either UDP or TCP.
    - `Name <String>`: Channel name
    - `[DecodingConfiguration <String>]`: Configuration for decoding
    - `[DemodulationConfiguration <String>]`: Configuration for demodulation
    - `[EncodingConfiguration <String>]`: Configuration for encoding
    - `[ModulationConfiguration <String>]`: Configuration for modulation
  - `Direction <Direction>`: Direction (uplink or downlink)
  - `Name <String>`: Link name
  - `Polarization <Polarization>`: polarization. eg (RHCP, LHCP)
  - `[EirpdBw <Single?>]`: Effective Isotropic Radiated Power (EIRP) in dBW.
  - `[GainOverTemperature <Single?>]`: Gain To Noise Temperature in db/K.

## RELATED LINKS

