---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/invoke-azredisenterprisecacheforcedatabaselinktoreplicationgroup
schema: 2.0.0
---

# Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup

## SYNOPSIS
Forcibly recreates an existing database on the specified cluster, and rejoins it to an existing replication group.
**IMPORTANT NOTE:** All data in this database will be discarded, and the database will temporarily be unavailable while rejoining the replication group.

## SYNTAX

### ForceViaIdentity (Default)
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -InputObject <IRedisEnterpriseCacheIdentity>
 -Parameter <IForceLinkParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ForceExpanded
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -GroupNickname <String>
 -LinkedDatabase <ILinkedDatabase[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Force
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Parameter <IForceLinkParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ForceViaIdentityExpanded
```
Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup -InputObject <IRedisEnterpriseCacheIdentity>
 -GroupNickname <String> -LinkedDatabase <ILinkedDatabase[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Forcibly recreates an existing database on the specified cluster, and rejoins it to an existing replication group.
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

```yaml
Type: System.String
Parameter Sets: ForceExpanded, Force
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
Parameter Sets: ForceExpanded, Force
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
Parameter Sets: ForceExpanded, ForceViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: ForceViaIdentity, ForceViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinkedDatabase
The resource IDs of the databases that are expected to be linked and included in the replication group.
This parameter is used to validate that the linking is to the expected (unlinked) part of the replication group, if it is splintered.
To construct, see NOTES section for LINKEDDATABASE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20240901Preview.ILinkedDatabase[]
Parameter Sets: ForceExpanded, ForceViaIdentityExpanded
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

### -Parameter
Parameters for reconfiguring active geo-replication, of an existing database that was previously unlinked from a replication group.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20240901Preview.IForceLinkParameters
Parameter Sets: ForceViaIdentity, Force
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
Parameter Sets: ForceExpanded, Force
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
Parameter Sets: ForceExpanded, Force
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20240901Preview.IForceLinkParameters

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
