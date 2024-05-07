---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RedisCache.dll-Help.xml
Module Name: Az.RedisCache
online version: https://learn.microsoft.com/powershell/module/az.rediscache/get-azrediscacheaccesspolicyassignment
schema: 2.0.0
---

# Get-AzRedisCacheAccessPolicyAssignment

## SYNOPSIS
Get the detailed information about Access Policy Assignment(s) (Redis User(s)) of the Redis Cache

## SYNTAX

### NormalParameterSet
```
Get-AzRedisCacheAccessPolicyAssignment [-ResourceGroupName <String>] -Name <String>
 [-AccessPolicyAssignmentName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzRedisCacheAccessPolicyAssignment -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CacheObjectParameterSet
```
Get-AzRedisCacheAccessPolicyAssignment -TopLevelResourceObject <RedisCacheAttributes>
 [-AccessPolicyAssignmentName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
If **AccessPolicyAssignmentName** parameter provided, **Get-AzRedisCacheAccessPolicyAssignment** cmdlet gets details about the specified access policy assignment (redis user). If only **Name** is specified this operation gets all access policy assignments (Redis Users) of the Redis Cache.

## EXAMPLES

### Example 1: Get information of an access policy assignment (redis user)
```powershell
Get-AzRedisCacheAccessPolicyAssignment -Name "testCache" -AccessPolicyAssignmentName "testAccessPolicyAssignment"
```

This command gets information on access policy assignment (redis user) named testAccessPolicyAssignment from Redis Cache named testCache

### Example 2: Get information of all access policy assignments (redis users)
```powershell
Get-AzRedisCacheAccessPolicyAssignment -Name "testCache"
```

This command gets information on all access policy assignments from Redis Cache named testCache.

## PARAMETERS

### -AccessPolicyAssignmentName
Name of Access Policy Assignment.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet, CacheObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Redis Cache.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group in which cache exists.

```yaml
Type: System.String
Parameter Sets: NormalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
ARM Id of Redis Cache Access Policy Assignment

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TopLevelResourceObject
Object of type RedisCacheAttributes

```yaml
Type: Microsoft.Azure.Commands.RedisCache.Models.RedisCacheAttributes
Parameter Sets: CacheObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RedisCache.Models.PSRedisAccessPolicyAssignment

## NOTES

## RELATED LINKS
