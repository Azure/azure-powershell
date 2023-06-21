---
external help file:
Module Name: Az.Orbital
online version: https://learn.microsoft.com/powershell/module/az.orbital/update-azorbitalcontactprofile
schema: 2.0.0
---

# Update-AzOrbitalContactProfile

## SYNOPSIS
Updates the specified contact profile tags.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOrbitalContactProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOrbitalContactProfile -InputObject <IOrbitalIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified contact profile tags.

## EXAMPLES

### Example 1: Updates the specified contact profile tags.
```powershell
Update-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest-gp -Tag @{"123"="abc"}
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Updates the specified contact profile tags.

### Example 2: Updates the specified contact profile tags.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp -Name azps-orbital-contactprofile | Update-AzOrbitalContactProfile -Tag @{"123"="abc"}
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Updates the specified contact profile tags.

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
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

