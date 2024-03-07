---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/set-azmigratehciserverreplication
schema: 2.0.0
---

# Set-AzMigrateHCIServerReplication

## SYNOPSIS
Updates the target properties for the replicating server.

## SYNTAX

```
Set-AzMigrateHCIServerReplication -TargetObjectID <String> [-TargetVMName <String>] [-TargetVMCPUCore <Int32>]
 [-IsDynamicMemoryEnabled <String>] [-DynamicMemoryConfig <ProtectedItemDynamicMemoryConfig>]
 [-TargetVMRam <Int64>] [-NicToInclude <AzStackHCINicInput[]>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzMigrateHCIServerReplication cmdlet updates the target properties for the replicating server.

## EXAMPLES

### EXAMPLE 1
```
Set-AzMigrateHCIServerReplication -TargetObjectID  '/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5' -TargetVMName "targetName1"
```

### EXAMPLE 2
```
$memoryConfig = [PSCustomObject]@{
	MinimumMemoryInMegaByte = 1024
	MaximumMemoryInMegaByte = 34816
	TargetMemoryBufferPercentage = 20
}
```

Set-AzMigrateHCIServerReplication -TargetObjectID  '/subscriptions/xxx-xxx-xxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/proj62434replicationvault/protectedItems/503a4f02-916c-d6b0-8d14-222bbd4767e5' -DynamicMemoryConfig $memoryConfig

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMemoryConfig
Specifies the dynamic memory configration of RAM.
To construct, see NOTES section for DYNAMICMEMORYCONFIG properties and create a hash table.

```yaml
Type: ProtectedItemDynamicMemoryConfig
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDynamicMemoryEnabled
Specifies if RAM is dynamic or not.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicToInclude
Specifies the nics on the source server to be included for replication.

```yaml
Type: AzStackHCINicInput[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetObjectID
Specifies the replicating server for which the properties need to be updated.
The ID should be retrieved using the Get-AzMigrateHCIServerReplication cmdlet.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMCPUCore
Specifies the number of CPU cores.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMName
Specifies the target VM name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVMRam
Specifies the target RAM size in MB.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.IWorkflowModel
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

DYNAMICMEMORYCONFIG \<ProtectedItemDynamicMemoryConfig\>: Specifies the dynamic memory configration of RAM.
  MaximumMemoryInMegaByte \<Int64\>: Gets or sets maximum memory in MB.
  MinimumMemoryInMegaByte \<Int64\>: Gets or sets minimum memory in MB.
  TargetMemoryBufferPercentage \<Int32\>: Gets or sets target memory buffer in %.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.migrate/set-azmigratehciserverreplication](https://learn.microsoft.com/powershell/module/az.migrate/set-azmigratehciserverreplication)

