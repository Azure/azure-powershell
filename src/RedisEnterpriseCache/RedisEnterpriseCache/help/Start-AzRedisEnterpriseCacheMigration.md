---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/start-azredisenterprisecachemigration
schema: 2.0.0
---

# Start-AzRedisEnterpriseCacheMigration

## SYNOPSIS
Starts a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis.

## SYNTAX

```
Start-AzRedisEnterpriseCacheMigration -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -SourceResourceId <String> [-SwitchDns] [-SkipDataMigration] [-ForceMigrate]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Starts a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis.
This custom cmdlet provides friendly parameters instead of requiring raw JSON input.
It constructs the discriminated union request body internally and calls the generated cmdlet underneath.

## EXAMPLES

### Example 1: Start a migration from Azure Cache for Redis
```powershell
$sourceResourceId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1"
Start-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId $sourceResourceId -ForceMigrate -SwitchDns -SkipDataMigration |
    Format-List Name, ProvisioningState, SourceType, TargetResourceId, CreationTime, LastModifiedTime, RollbackEligibleUntil
```

```output
Name                  : cache1/default
ProvisioningState     : Succeeded
SourceType            : AzureCacheForRedis
TargetResourceId      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Cache/redisEnterprise/cache1
CreationTime          : 30-10-2026 11:09:22
LastModifiedTime      : 30-10-2026 11:14:35
RollbackEligibleUntil : 29-11-2026 11:14:35
```

Starts a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis, switches the source DNS endpoint, and skips data migration.

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

### -ClusterName
The name of the Redis Enterprise cluster.

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

### -ForceMigrate
Sets whether to force the migration even if validation warnings exist.

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

### -SkipDataMigration
Sets whether to skip data migration and only migrate the endpoint.
This property is required by the service.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
The resource ID of the source Azure Cache for Redis Basic, Standard, or Premium cache to migrate from.

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

### -SwitchDns
Sets whether to switch DNS to point to the target cache after migration completes.
This property is required by the service.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigration

## NOTES

## RELATED LINKS
