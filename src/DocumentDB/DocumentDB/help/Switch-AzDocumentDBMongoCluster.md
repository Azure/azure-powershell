---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/switch-azdocumentdbmongocluster
schema: 2.0.0
---

# Switch-AzDocumentDBMongoCluster

## SYNOPSIS
Promote a replica mongo cluster to a primary role.

## SYNTAX

```
Switch-AzDocumentDBMongoCluster -MongoClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -SourceCluster <String> -PromoteOption <String> [-Mode <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Promote a replica mongo cluster to a primary role.
As a safety check, the expected source
(primary) cluster must be provided and is validated against the replica's actual source
cluster; promotion only proceeds when they match.
Use Planned to wait for replication to catch up before promotion.
Forced promotes
without waiting for replication and may result in data loss; use it only for disaster recovery.

## EXAMPLES

### Example 1: Perform a planned switchover to a read replica
```powershell
Switch-AzDocumentDBMongoCluster -Name myReplica -ResourceGroupName myResourceGroup `
    -SourceCluster myCluster -Mode Switchover -PromoteOption Planned -Confirm
```

Promote a read replica to the primary role using `Planned`, which waits for the replica
to catch up with the primary before promotion to avoid data loss.
`Switchover` changes
the original primary to a replica and maintains the replication link.

The required `-SourceCluster` value is checked against the replica's actual source;
promotion fails if they do not match.
A source name uses the target subscription and
resource group.
Use the source cluster's full resource ID if either is different.
`-Confirm` prompts for confirmation before promotion.

### Example 2: Force a switchover during disaster recovery
```powershell
Switch-AzDocumentDBMongoCluster -Name myReplica -ResourceGroupName myResourceGroup `
    -SourceCluster myCluster -Mode Switchover -PromoteOption Forced -Confirm
```

Force the replica to become the primary without waiting for it to catch up.
Forced
promotion can lose data and should only be used for disaster recovery when that risk
is acceptable.
The same source-cluster validation applies.

## PARAMETERS

### -AsJob
Run the command as a job.

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

### -Mode
The mode to apply to the promote operation.
Value is optional and default value is 'Switchover'.

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

### -MongoClusterName
The name of the replica mongo cluster to promote.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously.

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

### -PassThru
Returns true when the command succeeds.

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

### -PromoteOption
The promote option to apply to the operation.
Planned waits for replication to catch up; Forced may result in data loss.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SourceCluster
Name or resource ID of the expected source (primary) cluster of this replica.
Promotion only proceeds if it matches the replica's actual source cluster; otherwise the operation fails.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### System.Boolean

By default, this cmdlet returns no output. With `-PassThru`, it returns `true` on success.

## NOTES

## RELATED LINKS
