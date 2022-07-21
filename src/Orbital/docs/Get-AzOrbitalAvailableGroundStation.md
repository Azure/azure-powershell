---
external help file:
Module Name: Az.Orbital
online version: https://docs.microsoft.com/powershell/module/az.orbital/get-azorbitalavailablegroundstation
schema: 2.0.0
---

# Get-AzOrbitalAvailableGroundStation

## SYNOPSIS
Gets the specified available ground station.

## SYNTAX

### Get (Default)
```
Get-AzOrbitalAvailableGroundStation -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOrbitalAvailableGroundStation -InputObject <IOrbitalIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzOrbitalAvailableGroundStation -Capability <CapabilityParameter> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified available ground station.

## EXAMPLES

### Example 1: Gets the specified  available ground station.
```powershell
Get-AzOrbitalAvailableGroundStation -Capability 'EarthObservation'
```

```output
Location      Name             ProviderName City
--------      ----             ------------ ----
westus2       WESTUS2_0        Microsoft    Quincy
westus2       SVALSAT          KSAT         Svalbard
westus2       AWARUA           KSAT         Awarua
westus2       HARTEBEESTHOEK   KSAT         Hartebeesthoek
westus2       LONG_BEACH       KSAT         LongBeach
westus2       WESTUS2_1        Microsoft    Quincy-preview
westus2       ATHENS           KSAT         Athens
swedencentral MICROSOFT_SWEDEN Microsoft    Gavle
swedencentral SWEDENCENTRAL_0  Microsoft    Gavle
```

Gets the specified  available ground station.

## PARAMETERS

### -Capability
Ground Station Capability.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Orbital.Support.CapabilityParameter
Parameter Sets: List
Aliases:

Required: True
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
Ground Station name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: GroundStationName

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20220301.IAvailableGroundStation

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

