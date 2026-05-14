---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/invoke-azredisenterprisecachedatabaseflush
schema: 2.0.0
---

# Invoke-AzRedisEnterpriseCacheDatabaseFlush

## SYNOPSIS
Flushes all the keys in this database and also from its linked databases.

## SYNTAX

### FlushExpanded (Default)
```
Invoke-AzRedisEnterpriseCacheDatabaseFlush -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Id <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FlushViaJsonString
```
Invoke-AzRedisEnterpriseCacheDatabaseFlush -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FlushViaJsonFilePath
```
Invoke-AzRedisEnterpriseCacheDatabaseFlush -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FlushViaIdentityExpanded
```
Invoke-AzRedisEnterpriseCacheDatabaseFlush -InputObject <IRedisEnterpriseCacheIdentity> [-Id <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### FlushViaIdentityRedisEnterpriseExpanded
```
Invoke-AzRedisEnterpriseCacheDatabaseFlush -RedisEnterpriseInputObject <IRedisEnterpriseCacheIdentity>
 [-Id <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Flushes all the keys in this database and also from its linked databases.

## EXAMPLES

### Example 1: Flush Cache
```powershell
Invoke-AzRedisEnterpriseCacheDatabaseFlush -ClusterName "MyCache" -ResourceGroupName "MyResourceGroup" -Id @("Mydatabase1") , @("MyLinkedDatabase1")
```

Flushes all the keys in this database and also from its linked databases.

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
Name must be 1-60 characters long.
Allowed characters(A-Z, a-z, 0-9) and hyphen(-).
There can be no leading nor trailing nor consecutive hyphens

```yaml
Type: System.String
Parameter Sets: FlushExpanded, FlushViaJsonString, FlushViaJsonFilePath
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

### -Id
The identifiers of all the other database resources in the georeplication group to be flushed.

```yaml
Type: System.String[]
Parameter Sets: FlushExpanded, FlushViaIdentityExpanded, FlushViaIdentityRedisEnterpriseExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: FlushViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Flush operation

```yaml
Type: System.String
Parameter Sets: FlushViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Flush operation

```yaml
Type: System.String
Parameter Sets: FlushViaJsonString
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

### -PassThru
Returns true when the command succeeds

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

### -RedisEnterpriseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: FlushViaIdentityRedisEnterpriseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: FlushExpanded, FlushViaJsonString, FlushViaJsonFilePath
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
Parameter Sets: FlushExpanded, FlushViaJsonString, FlushViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
