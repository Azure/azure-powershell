---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/get-azorbitalspacecraftcontact
schema: 2.0.0
---

# Get-AzOrbitalSpacecraftContact

## SYNOPSIS
Gets the specified contact in a specified resource group.

## SYNTAX

### List (Default)
```
Get-AzOrbitalSpacecraftContact -ResourceGroupName <String> -SpacecraftName <String>
 [-SubscriptionId <String[]>] [-Skiptoken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOrbitalSpacecraftContact -Name <String> -ResourceGroupName <String> -SpacecraftName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOrbitalSpacecraftContact -InputObject <IOrbitalIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified contact in a specified resource group.

## EXAMPLES

### Example 1: Get the specified contact.
```powershell
Get-AzOrbitalSpacecraftContact -Name azps-orbital-contact -ResourceGroupName azpstest-gp -SpacecraftName AQUA
```

```output
Name                 GroundStationName Status    ReservationStartTime     ReservationEndTime     ResourceGroupName
----                 ----------------- ------    --------------------     ------------------     -----------------
azps-orbital-contact KSAT_SVALBARD     scheduled 2022-06-23 09:13:05 AM   2022-06-24 09:13:10 AM azpstest-gp
```

Get the specified contact.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.IOrbitalIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Contact name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ContactName

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skiptoken
An opaque string that the resource provider uses to skip over previously-returned results.
This is used when a previous list operation call returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpacecraftName
Spacecraft ID.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.IOrbitalIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IContact

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IOrbitalIdentity>`: Identity Parameter
  - `[ContactName <String>]`: Contact name.
  - `[ContactProfileName <String>]`: Contact Profile name.
  - `[GroundStationName <String>]`: Ground Station name.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OperationId <String>]`: The ID of an ongoing async operation.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SpacecraftName <String>]`: Spacecraft ID.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

