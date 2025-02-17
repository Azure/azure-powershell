---
external help file: Az.RedisEnterpriseCache-help.xml
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/get-azredisenterprisecacheaccesspolicyassignment
schema: 2.0.0
---

# Get-AzRedisEnterpriseCacheAccessPolicyAssignment

## SYNOPSIS
Gets information about access policy assignment for database.

## SYNTAX

### List (Default)
```
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName <String> -DatabaseName <String>
 -ResourceGroupName <String> -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about access policy assignment for database.

## EXAMPLES

### Example 1: Get access policy assignment information.
```powershell
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -AccessPolicyAssignmentName "testAccessPolicyAssignmentName" -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup"
```

```output
Name
----
testAccessPolicyAssignmentName
```

This command gets information on access policy assignment (redis user) named testAccessPolicyAssignment from Redis enterprise cache named testCache

### Example 2: List access policy assignment information.
```powershell
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName "MyCache" -DatabaseName "default" -ResourceGroupName "MyGroup"
```

```output
Name
----
testAccessPolicyAssignmentName
```

This command gets information on all access policy assignments from Redis enterprise cache named MyCache.

## PARAMETERS

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

### -DatabaseName
The name of the Redis Enterprise database.

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

### -Name
The name of the Redis Enterprise database access policy assignment.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AccessPolicyAssignmentName

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20240901Preview.IAccessPolicyAssignment

## NOTES

## RELATED LINKS
