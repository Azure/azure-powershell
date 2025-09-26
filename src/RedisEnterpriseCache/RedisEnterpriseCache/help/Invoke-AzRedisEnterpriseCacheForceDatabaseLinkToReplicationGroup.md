---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/invoke-azredisenterprisecacheforcedatabaselinktoreplicationgroup
schema: 2.0.0
---

# Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup

## SYNOPSIS
Forcibly reforce an existing database on the specified cluster, and rejoins it to an existing replication group.
**IMPORTANT NOTE:** All data in this database will be discarded, and the database will temporarily be unavailable while rejoining the replication group.

## SYNTAX

### ForceViaIdentityExpanded (Default)
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -InputObject <IRedisEnterpriseCacheIdentity>
 -GroupNickname <String> -LinkedDatabase <ILinkedDatabase[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ForceViaJsonString
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ForceViaJsonFilePath
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ForceExpanded
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -GroupNickname <String>
 -LinkedDatabase <ILinkedDatabase[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ForceViaIdentityRedisEnterpriseExpanded
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -DatabaseName <String>
 -RedisEnterpriseInputObject <IRedisEnterpriseCacheIdentity> -GroupNickname <String>
 -LinkedDatabase <ILinkedDatabase[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Forcibly reforce an existing database on the specified cluster, and rejoins it to an existing replication group.
**IMPORTANT NOTE:** All data in this database will be discarded, and the database will temporarily be unavailable while rejoining the replication group.

## EXAMPLES

### Example 1: How to relink a database after a regional outage
```powershell
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName "MyCache" -ResourceGroupName "MyResourceGroup" -DatabaseName "default" -GroupNickname "MyExistingGroup" -LinkedDatabase @(@{ResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Cache/RedisEnterprise/mycache/databases/default"},@{ResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Cache/RedisEnterprise/mycache/databases/MyLinkedDatabase2"})
```

Forcibly recreates the database given, and rejoins it to an existing replication group.

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
Parameter Sets: ForceViaJsonString, ForceViaJsonFilePath, ForceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the Redis Enterprise database.

```yaml
Type: System.String
Parameter Sets: ForceViaJsonString, ForceViaJsonFilePath, ForceExpanded, ForceViaIdentityRedisEnterpriseExpanded
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

### -GroupNickname
The name of the group of linked database resources.
This should match the existing replication group name.

```yaml
Type: System.String
Parameter Sets: ForceViaIdentityExpanded, ForceExpanded, ForceViaIdentityRedisEnterpriseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: ForceViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Force operation

```yaml
Type: System.String
Parameter Sets: ForceViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Force operation

```yaml
Type: System.String
Parameter Sets: ForceViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkedDatabase
The resource IDs of the databases that are expected to be linked and included in the replication group.
This parameter is used to validate that the linking is to the expected (unlinked) part of the replication group, if it is splintered.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.ILinkedDatabase[]
Parameter Sets: ForceViaIdentityExpanded, ForceExpanded, ForceViaIdentityRedisEnterpriseExpanded
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
Parameter Sets: ForceViaIdentityRedisEnterpriseExpanded
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
Parameter Sets: ForceViaJsonString, ForceViaJsonFilePath, ForceExpanded
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
Parameter Sets: ForceViaJsonString, ForceViaJsonFilePath, ForceExpanded
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
