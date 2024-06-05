---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratehcinicmappingobject
schema: 2.0.0
---

# New-AzMigrateHCINicMappingObject

## SYNOPSIS
Creates an object to update NIC properties of a replicating server.

## SYNTAX

```
New-AzMigrateHCINicMappingObject -NicID <String> [-TargetVirtualSwitchId <String>]
 [-TargetTestVirtualSwitchId <String>] [-CreateAtTarget <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateHCINicMappingObject cmdlet creates a mapping of the source NIC attached to the server to be migrated.
This object is provided as an input to the Set-AzMigrateServerReplication cmdlet to update the NIC and its properties for a replicating server.

## EXAMPLES

### Example 1: Create NIC to migrate
```powershell
New-AzMigrateHCINicMappingObject -NicID a -TargetVirtualSwitchId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external"
```

```output
NicId                    : a
TargetNetworkId          : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
TestNetworkId            : /subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/external
SelectionTypeForFailover : SelectedByUser
```

Get NIC object to provide input for New-AzMigrateHCIServerReplication and Set-AzMigrateHCIServerReplication

## PARAMETERS

### -CreateAtTarget
Specifies whether the this Nic should be created at target.

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

### -NicID
Specifies the ID of the NIC to be updated.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTestVirtualSwitchId
Specifies the test logical network ARM ID that the VMs will use.

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

### -TargetVirtualSwitchId
Specifies the logical network ARM ID that the VMs will use.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.AzStackHCINicInput

## NOTES

## RELATED LINKS
