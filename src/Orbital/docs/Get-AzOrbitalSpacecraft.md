---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/get-azorbitalspacecraft
schema: 2.0.0
---

# Get-AzOrbitalSpacecraft

## SYNOPSIS
Gets the specified spacecraft in a specified resource group.

## SYNTAX

### List (Default)
```
Get-AzOrbitalSpacecraft [-SubscriptionId <String[]>] [-Skiptoken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOrbitalSpacecraft -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOrbitalSpacecraft -InputObject <IOrbitalIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOrbitalSpacecraft -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Skiptoken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified spacecraft in a specified resource group.

## EXAMPLES

### Example 1: List the specified spacecraft.
```powershell
Get-AzOrbitalSpacecraft
```

```output
Name                     Location NoradId TitleLine   ResourceGroupName
----                     -------- ------- ---------   -----------------
azpstest-test-spacecraft westus2  12345   ISS (ZARYA) azpstest-gp
AQUA                     eastus   12345   ISS (ZARYA) azpstest-gp
```

List the specified spacecraft.

### Example 2: Gets the specified spacecraft in a specified resource group.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Gets the specified spacecraft in a specified resource group.

### Example 3: Get the specified spacecraft in a specified Name.
```powershell
Get-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp -Name AQUA
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Get the specified spacecraft in a specified Name.

## PARAMETERS

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
Spacecraft ID.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SpacecraftName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.ISpacecraft

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IOrbitalIdentity>`: Identity Parameter
  - `[ContactName <String>]`: Contact name.
  - `[ContactProfileName <String>]`: Contact Profile name.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[OperationId <String>]`: The ID of an ongoing async operation.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SpacecraftName <String>]`: Spacecraft ID.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

