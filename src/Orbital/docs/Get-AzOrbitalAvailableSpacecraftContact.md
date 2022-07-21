---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/get-azorbitalavailablespacecraftcontact
schema: 2.0.0
---

# Get-AzOrbitalAvailableSpacecraftContact

## SYNOPSIS
Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

## SYNTAX

### ListExpanded (Default)
```
Get-AzOrbitalAvailableSpacecraftContact -Name <String> -ResourceGroupName <String> -EndTime <DateTime>
 -GroundStationName <String> -StartTime <DateTime> [-SubscriptionId <String[]>] [-ContactProfileId <String>]
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
$dateS = Get-Date -Day 22 -Month 7
$dateE = Get-Date -Day 23 -Month 7

Get-AzOrbitalAvailableSpacecraftContact -Name AQUA -ResourceGroupName azpstest-gp -EndTime $dateE -StartTime $dateS -GroundStationName WESTUS2_1 -ContactProfileId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/azps-orbital-contactprofile
```

```output
GroundStationName StartAzimuthDegree EndAzimuthDegree StartElevationDegree EndElevationDegree MaximumElevationDegree RxStartTime            RxEndTime
----------------- ------------------ ---------------- -------------------- ------------------ ---------------------- -----------            ---------
WESTUS2_1         33.65817           156.5579         10                   10                 29.905                 2022-07-22 09:14:48 AM 2022-07-22 09:23:09 AM
WESTUS2_1         358.0121           228.2359         10                   10                 35.335                 2022-07-22 10:52:26 AM 2022-07-22 11:01:04 AM
WESTUS2_1         141.8587           357.0999         10                   10                 46.502                 2022-07-22 08:23:26 AM 2022-07-22 08:32:32 AM
WESTUS2_1         215.2225           319.5766         10                   10                 22.735                 2022-07-22 10:02:11 AM 2022-07-22 10:09:42 AM
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContactParameters
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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContactParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IAvailableContacts

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IContactParameters>`: Parameters that define the contact resource.
  - `EndTime <DateTime>`: End time of a contact (ISO 8601 UTC standard).
  - `GroundStationName <String>`: Name of Azure Ground Station.
  - `StartTime <DateTime>`: Start time of a contact (ISO 8601 UTC standard).
  - `[ContactProfileId <String>]`: Resource ID.

## RELATED LINKS

