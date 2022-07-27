---
external help file:
Module Name: Az.Maps
online version: https://docs.microsoft.com/powershell/module/az.maps/update-azmapscreator
schema: 2.0.0
---

# Update-AzMapsCreator

## SYNOPSIS
Updates the Maps Creator resource.
Only a subset of the parameters may be updated after creation, such as Tags.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMapsCreator -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-StorageUnit <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMapsCreator -InputObject <IMapsIdentity> [-StorageUnit <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the Maps Creator resource.
Only a subset of the parameters may be updated after creation, such as Tags.

## EXAMPLES

### Example 1: Updates the Maps Creator resource
```powershell
Update-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01 -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command updates the Maps Creator resource.
Only a subset of the parameters may be updated after creation, such as Tags.

### Example 2: Updates the Maps Creator resource by pipeline
```powershell
Get-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount03 -Name creator-01 | Update-AzMapsCreator -Tag @{'key1'='value1'; 'key2'='value2'}
```

```output
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command updates the Maps Creator resource by pipeline.
Only a subset of the parameters may be updated after creation, such as Tags.

## PARAMETERS

### -AccountName
The name of the Maps Account.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Maps Creator instance.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: CreatorName

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageUnit
The storage units to be allocated.
Integer values from 1 to 100, inclusive.

```yaml
Type: System.Int32
Parameter Sets: (All)
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
Gets or sets a list of key value pairs that describe the resource.
These tags can be used in viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key no greater than 128 characters and value no greater than 256 characters.

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

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IMapsIdentity>`: Identity Parameter
  - `[AccountName <String>]`: The name of the Maps Account.
  - `[CreatorName <String>]`: The name of the Maps Creator instance.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

