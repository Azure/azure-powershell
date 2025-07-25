---
external help file: Az.Maps-help.xml
Module Name: Az.Maps
online version: https://learn.microsoft.com/powershell/module/az.maps/new-azmapscreator
schema: 2.0.0
---

# New-AzMapsCreator

## SYNOPSIS
create a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.

## SYNTAX

### CreateExpanded (Default)
```
New-AzMapsCreator -Name <String> -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -StorageUnit <Int32> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMapsCreator -Name <String> -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMapsCreator -Name <String> -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityAccountExpanded
```
New-AzMapsCreator -Name <String> -AccountInputObject <IMapsIdentity> -Location <String> -StorageUnit <Int32>
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
create a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.

## EXAMPLES

### Example 1: Create a Maps Creator resource
```powershell
New-AzMapsCreator -ResourceGroupName azure-rg-test -AccountName pwsh-mapsAccount02 -Name creator-01 -Location eastus2 -StorageUnit 3
```

```output
Location Name       Type
-------- ----       ----
eastus2  creator-01 Microsoft.Maps/accounts/creators
```

This command creates a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.

## PARAMETERS

### -AccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.IMapsIdentity
Parameter Sets: CreateViaIdentityAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AccountName
The name of the Maps Account.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Maps Creator instance.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityAccountExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.ICreator

## NOTES

## RELATED LINKS
