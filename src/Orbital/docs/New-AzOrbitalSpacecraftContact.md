---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/new-azorbitalspacecraftcontact
schema: 2.0.0
---

# New-AzOrbitalSpacecraftContact

## SYNOPSIS
Creates a contact.

## SYNTAX

```
New-AzOrbitalSpacecraftContact -Name <String> -ResourceGroupName <String> -SpacecraftName <String>
 [-SubscriptionId <String>] [-ContactProfileId <String>] [-GroundStationName <String>]
 [-ReservationEndTime <DateTime>] [-ReservationStartTime <DateTime>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a contact.

## EXAMPLES

### Example 1: Creates a contact.
```powershell
$dateS = Get-Date -Day 22
$dateE = Get-Date -Day 23

New-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName AQUA -ContactProfileId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Orbital/contactProfiles/azps-orbital-contactprofile" -GroundStationName "WESTUS2_1" -ReservationStartTime $dateS -ReservationEndTime $dateE
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact WESTUS2_1         scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

Creates a contact.

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

### -GroundStationName
Azure Ground Station name.

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
Contact name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ContactName

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

### -ReservationEndTime
Reservation end time of a contact (ISO 8601 UTC standard).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationStartTime
Reservation start time of a contact (ISO 8601 UTC standard).

```yaml
Type: System.DateTime
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

### -SpacecraftName
Spacecraft ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContact

## NOTES

ALIASES

## RELATED LINKS

