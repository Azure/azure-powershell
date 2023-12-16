---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/get-azorbitalcontactprofile
schema: 2.0.0
---

# Get-AzOrbitalContactProfile

## SYNOPSIS
Gets the specified contact Profile in a specified resource group.

## SYNTAX

### List (Default)
```
Get-AzOrbitalContactProfile [-SubscriptionId <String[]>] [-Skiptoken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOrbitalContactProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOrbitalContactProfile -InputObject <IOrbitalIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOrbitalContactProfile -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Skiptoken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified contact Profile in a specified resource group.

## EXAMPLES

### Example 1: List the specified contact Profile.
```powershell
Get-AzOrbitalContactProfile
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

List the specified contact Profile.

### Example 2: Gets the specified contact Profile in a specified resource group.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp
```

```output
Name                        Location      ProvisioningState ResourceGroupName
----                        --------      ----------------- -----------------
azps-orbital-contactprofile westus2       succeeded         azpstest-gp
Sweden-contactprofile       swedencentral succeeded         azpstest-gp
```

Gets the specified contact Profile in a specified resource group.

### Example 2: Get the specified contact Profile in a specified.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp -Name azps-orbital-contactprofile
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Get the specified contact Profile in a specified.

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
Contact Profile name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ContactProfileName

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

### Microsoft.Azure.PowerShell.Cmdlets.Orbital.Models.Api20221101.IContactProfile

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

