---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: AzureRM.RecoveryServices.SiteRecovery
online version: 
schema: 2.0.0
---

# Start-AzureRmRecoveryServicesAsrSwitchProcessServer

## SYNOPSIS
Switch replication from one Process server to another.

## SYNTAX

### Default (Default)
```
Start-AzureRmRecoveryServicesAsrSwitchProcessServer -Fabric <ASRFabric> -SourceProcessServer <ASRProcessServer>
 -TargetProcessServer <ASRProcessServer> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByRPIObject
```
Start-AzureRmRecoveryServicesAsrSwitchProcessServer -Fabric <ASRFabric> -SourceProcessServer <ASRProcessServer>
 -TargetProcessServer <ASRProcessServer> -ReplicationProtectedItem <ASRReplicationProtectedItem[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureRmRecoveryServicesAsrSwitchProcessServer** switches replication data movement for the specified virtual machines or a specified Process server to the specified target Process server. Used for load balancing or switching replication between Process servers.

## EXAMPLES

### Example 1
```
PS C:\> Start-AzureRmRecoveryServicesAsrSwitchProcessServer -Fabric $fabric -SourceProcessServer $sourceProcessServer  -TargetProcessServer $TargetProcessServer
```

Job to track switching process server for all replication protected item from source to target process server.

### Example 2
```
PS C:\> Start-AzureRmRecoveryServicesAsrSwitchProcessServer -Fabric $fabric -SourceProcessServer $sourceProcessServer  -TargetProcessServer $TargetProcessServer -ReplicatedItem $rpList
```

Job to track switching process server for passed replication protected item from source to target process server.

## PARAMETERS

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

### -Fabric
ASR fabric corresponding to the Configuration Server.

```yaml
Type: ASRFabric
Parameter Sets: (All)
Aliases: ConfigServer

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceProcessServer
The Process server to switch replication out from.

```yaml
Type: ASRProcessServer
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetProcessServer
The Process server to switch replication to.

```yaml
Type: ASRProcessServer
Parameter Sets: (All)
Aliases: 

Required: True
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

### -ReplicationProtectedItem
List of replication protected item whose process server to be switched.

```yaml
Type: ASRReplicationProtectedItem[]
Parameter Sets: ByRPIObject
Aliases: ReplicatedItem

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

