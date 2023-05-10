---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/get-azorbitalavailablespacecraftcontact
schema: 2.0.0
---

# Get-AzOrbitalAvailableSpacecraftContact

## SYNOPSIS
Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

## SYNTAX

### ListExpanded (Default)
```
Get-AzOrbitalAvailableSpacecraftContact -Name <String> -ResourceGroupName <String> -ContactProfileId <String>
 -EndTime <DateTime> -GroundStationName <String> -StartTime <DateTime> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzOrbitalAvailableSpacecraftContact -Name <String> -ResourceGroupName <String>
 -Parameter <IContactParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

## EXAMPLES

### Example 1: Returns list of available contacts.
```powershell
$dateS = Get-Date -Day 9 -Month 5 -AsUTC
$dateE = Get-Date -Day 10 -Month 5 -AsUTC

Get-AzOrbitalAvailableSpacecraftContact -Name SwedenAQUASpacecraft -ResourceGroupName azpstest-gp -EndTime $dateE -StartTime $dateS -GroundStationName Microsoft_Gavle -ContactProfileId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/Sweden-contactprofile
```

```output
GroundStationName StartAzimuthDegree EndAzimuthDegree StartElevationDegree EndElevationDegree MaximumElevationDegree RxStartTime          RxEndTime
----------------- ------------------ ---------------- -------------------- ------------------ ---------------------- -----------          ---------
Microsoft_Gavle   13.77217           225.1679         4.999997             5.005328           44.586                 5/9/2023 2:24:07 AM  5/9/2023 2:35:15 AM
Microsoft_Gavle   8.178263           275.0042         4.999985             5.018794           14.834                 5/9/2023 4:02:13 AM  5/9/2023 4:10:34 AM
Microsoft_Gavle   4.437663           325.7795         4.999995             5.013724           6.46                   5/9/2023 5:40:23 AM  5/9/2023 5:44:10 AM
Microsoft_Gavle   22.93799           355.8058         5.000004             5.007165           5.71                   5/9/2023 7:16:26 AM  5/9/2023 7:19:06 AM
Microsoft_Gavle   73.33928           352.9607         5.000013             5.031366           11.955                 5/9/2023 8:49:49 AM  5/9/2023 8:57:12 AM
Microsoft_Gavle   123.3645           347.7329         4.999993             5.041272           33.262                 5/9/2023 10:24:39 AM 5/9/2023 10:35:21 AM
Microsoft_Gavle   173.6422           340.1027         4.999974             5.024394           61.188                 5/9/2023 12:01:46 PM 5/9/2023 12:13:15 PM
Microsoft_Gavle   231.5447           325.2475         4.999982             5.020995           14.006                 5/9/2023 1:42:01 PM  5/9/2023 1:50:22 PM
Microsoft_Gavle   30.4992            141.2818         5.000002             5.04285            18.785                 5/9/2023 11:50:46 PM 5/10/2023 12:00:14 AM
Microsoft_Gavle   18.08898           196.4807         4.999971             5.052687           82.019                 5/10/2023 1:28:09 AM 5/10/2023 1:39:43 AM
```

Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

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

### -ContactProfileId
Resource ID.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: True
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

### -EndTime
End time of a contact (ISO 8601 UTC standard).

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroundStationName
Name of Azure Ground Station.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Spacecraft ID.

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

### -Parameter
Parameters that define the contact resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IContactParameters
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -StartTime
Start time of a contact (ISO 8601 UTC standard).

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IContactParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IAvailableContacts

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IContactParameters>`: Parameters that define the contact resource.
  - `ContactProfileId <String>`: Resource ID.
  - `EndTime <DateTime>`: End time of a contact (ISO 8601 UTC standard).
  - `GroundStationName <String>`: Name of Azure Ground Station.
  - `StartTime <DateTime>`: Start time of a contact (ISO 8601 UTC standard).

## RELATED LINKS

