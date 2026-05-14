---
external help file:
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
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -ClusterName <String> -DatabaseName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDatabase
```
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -DatabaseInputObject <IRedisEnterpriseCacheIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityRedisEnterprise
```
Get-AzRedisEnterpriseCacheAccessPolicyAssignment -DatabaseName <String> -Name <String>
 -RedisEnterpriseInputObject <IRedisEnterpriseCacheIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
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
Name must be 1-60 characters long.
Allowed characters(A-Z, a-z, 0-9) and hyphen(-).
There can be no leading nor trailing nor consecutive hyphens

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: GetViaIdentityDatabase
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseName
The name of the Redis Enterprise database.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityRedisEnterprise, List
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
Parameter Sets: Get, GetViaIdentityDatabase, GetViaIdentityRedisEnterprise
Aliases: AccessPolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedisEnterpriseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
Parameter Sets: GetViaIdentityRedisEnterprise
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IAccessPolicyAssignment

## NOTES

## RELATED LINKS

