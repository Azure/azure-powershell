---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/get-azorbitalspacecraftavailablecontact
schema: 2.0.0
---

# Get-AzOrbitalSpacecraftAvailableContact

## SYNOPSIS
Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

## SYNTAX

### ListExpanded (Default)
```
Get-AzOrbitalSpacecraftAvailableContact -ResourceGroupName <String> -SpacecraftName <String>
 -ContactProfileId <String> -EndTime <DateTime> -GroundStationName <String> -StartTime <DateTime>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### List
```
Get-AzOrbitalSpacecraftAvailableContact -ResourceGroupName <String> -SpacecraftName <String>
 -Parameter <IContactParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns list of available contacts.
A contact is available if the spacecraft is visible from the ground station for more than the minimum viable contact duration provided in the contact profile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

