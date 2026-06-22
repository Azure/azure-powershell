---
external help file:
Module Name: Az.RedisEnterpriseCache
online version: https://learn.microsoft.com/powershell/module/az.redisenterprisecache/test-azredisenterprisecachemigration
schema: 2.0.0
---

# Test-AzRedisEnterpriseCacheMigration

## SYNOPSIS
Validates if a source Azure Cache for Redis resource can be migrated to a target Azure Managed Redis resource.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzRedisEnterpriseCacheMigration -ClusterName <String> -ResourceGroupName <String>
 -SourceResourceId <String> [-SubscriptionId <String>] [-ForceMigrate] [-SkipDataMigration]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzRedisEnterpriseCacheMigration -ClusterName <String> -ResourceGroupName <String>
 -Body <IMigrationValidationRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzRedisEnterpriseCacheMigration -InputObject <IRedisEnterpriseCacheIdentity>
 -Body <IMigrationValidationRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzRedisEnterpriseCacheMigration -InputObject <IRedisEnterpriseCacheIdentity> -SourceResourceId <String>
 [-ForceMigrate] [-SkipDataMigration] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzRedisEnterpriseCacheMigration -ClusterName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzRedisEnterpriseCacheMigration -ClusterName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates if a source Azure Cache for Redis resource can be migrated to a target Azure Managed Redis resource.

## EXAMPLES

### Example 1: Validate a migration before starting
```powershell
Test-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1" -SkipDataMigration
```

Validates whether a migration from the source Azure Cache for Redis to the target Redis Enterprise cache is possible.

## PARAMETERS

### -Body
Properties for validating migration from Azure Cache for Redis to Redis Enterprise.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigrationValidationRequest
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the Redis Enterprise cluster.
Name must be 1-60 characters long.
Allowed characters(A-Z, a-z, 0-9) and hyphen(-).
There can be no leading nor trailing nor consecutive hyphens

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
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

### -ForceMigrate
Sets whether to ignore warnings when validating if the source cache can be migrated to the target cache.
If this property is true, the isValid property in the response will ignore warning-level disparities between the source and target resource.
The default value is false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString
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
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipDataMigration
Sets whether the data is migrated from source to target or not.
The default value is true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
The source resource ID to validate migration from.
This is the resource ID of the Azure Cache for Redis.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigrationValidationRequest

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigrationValidationResponse

## NOTES

## RELATED LINKS

