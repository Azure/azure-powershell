---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/new-azorbitalspacecraft
schema: 2.0.0
---

# New-AzOrbitalSpacecraft

## SYNOPSIS
Creates or updates a spacecraft resource

## SYNTAX

```
New-AzOrbitalSpacecraft -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Link <ISpacecraftLink[]>] [-NoradId <String>] [-ProvisioningState <String>]
 [-Tag <Hashtable>] [-TitleLine <String>] [-TleLine1 <String>] [-TleLine2 <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a spacecraft resource

## EXAMPLES

### Example 1: Creates or updates a spacecraft resource.
```powershell
$linkObject = New-AzOrbitalSpacecraftLinkObject -BandwidthMHz 50 -CenterFrequencyMHz 50 -Direction 'uplink' -Name spacecraftlink -Polarization 'LHCP'

New-AzOrbitalSpacecraft -Name azps-orbitalspacecraft -ResourceGroupName azpstest_gp -Location eastus -Link $linkObject -NoradId 12345 -TitleLine "ISS (ZARYA)" -TleLine1 "1 25544U 98067A   08264.51782528 -.00002182  00000-0 -11606-4 0  2927" -TleLine2 "2 25544  51.6416 247.4627 0006703 130.5360 325.0288 15.72125391563537"
```

```output
Name                   Location NoradId TitleLine   ResourceGroupName
----                   -------- ------- ---------   -----------------
azps-orbitalspacecraft eastus   12345   ISS (ZARYA) azpstest_gp
```

Creates or updates a spacecraft resource.

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

### -Link
Links of the Spacecraft
To construct, see NOTES section for LINK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.ISpacecraftLink[]
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

### -Name
Spacecraft ID

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SpacecraftName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoradId
NORAD ID of the spacecraft.

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

### -TitleLine
Title line of Two Line Element (TLE).

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

### -TleLine1
Line 1 of Two Line Element (TLE).

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

### -TleLine2
Line 2 of Two Line Element (TLE).

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.ISpacecraft

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


LINK <ISpacecraftLink[]>: Links of the Spacecraft
  - `BandwidthMHz <Single>`: Bandwidth in MHz
  - `CenterFrequencyMHz <Single>`: Center Frequency in MHz
  - `Direction <Direction>`: Direction (uplink or downlink)
  - `Name <String>`: Link name
  - `Polarization <Polarization>`: polarization. eg (RHCP, LHCP)

## RELATED LINKS

