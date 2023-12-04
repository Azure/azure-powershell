---
external help file:
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratetestnicmapping
schema: 2.0.0
---

# New-AzMigrateTestNicMapping

## SYNOPSIS
Creates an object to update NIC properties of a test migrating server.

## SYNTAX

```
New-AzMigrateTestNicMapping -NicID <String> -TestNicSubnet <String> [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateTestNicMapping cmdlet creates a mapping of the source NIC attached to the server to be test migrated.
This object is provided as an input to the Start-AzMigrateTestMigration cmdlet to update the NIC and its properties for a test migrating server.

## EXAMPLES

### Example 1: Create a NIC object for test migration.
```powershell
New-AzMigrateTestNicMapping -NicID a2399354-653a-464e-a567-d30ef5467a31 -TestNicSubnet subnet1
```

```output
IsPrimaryNic IsSelectedForMigration NicId                                TargetNicName TargetStaticIPAddress TargetSubnetName TestStaticIPAddress TestSubnetName
------------ ---------------------- -----                                ------------- --------------------- ---------------- ------------------- --------------
                                    a2399354-653a-464e-a567-d30ef5467a31                                                                          subnet1
```

Creates a NIC object for test migration.

## PARAMETERS

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

### -TestNicSubnet
Specifies the Subnet name for the NIC in the destination Virtual Network to which the server needs to be test migrated.

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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IVMwareCbtNicInput

## NOTES

ALIASES

## RELATED LINKS

