---
external help file:
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/new-azredisenterprisecachekey
schema: 2.0.0
---

# New-AzRedisEnterpriseCacheKey

## SYNOPSIS
Regenerates an access key for a Redis Enterprise database.

## SYNTAX

```
New-AzRedisEnterpriseCacheKey -ClusterName <String> -ResourceGroupName <String> -KeyType <AccessKeyType>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Regenerates an access key for a Redis Enterprise database.

## EXAMPLES

### Example 1: Regenerate primary access key
```powershell
New-AzRedisEnterpriseCacheKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Primary"
```

```output
PrimaryKey                                   SecondaryKey
----------                                   ------------
new-primary-key                              secondary-key

```

This command regenerates the primary secret access key used for authenticating connections to the database of the Redis Enterprise cache named MyCache.

### Example 2: Regenerate secondary access key
```powershell
New-AzRedisEnterpriseCacheKey -Name "MyCache" -ResourceGroupName "MyGroup" -KeyType "Secondary"
```

```output
PrimaryKey                                   SecondaryKey
----------                                   ------------
primary-key                                  new-secondary-key

```

This command regenerates the secondary secret access key used for authenticating connections to the database of the Redis Enterprise cache named MyCache.

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

### -ClusterName
The name of the Redis Enterprise cluster.

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

### -KeyType
Which access key to regenerate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AccessKeyType
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IAccessKeys

## NOTES

ALIASES

### New-AzRedisEnterpriseCacheDatabaseKey

### New-AzRedisEnterpriseCacheAccessKey

## RELATED LINKS

