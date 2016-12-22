---
external help file: Microsoft.Azure.Commands.RedisCache.dll-Help.xml
ms.assetid: FA99C137-68E3-47D3-A0AC-FE33A481BE66
online version: 
schema: 2.0.0
---

# Set-AzureRmRedisCacheDiagnostics

## SYNOPSIS
Enables diagnostics on an Azure Redis Cache.

## SYNTAX

```
Set-AzureRmRedisCacheDiagnostics -ResourceGroupName <String> -Name <String> -StorageAccountId <String>
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmRedisCacheDiagnostics** cmdlet enables diagnostics for an Azure Redis Cache.

## EXAMPLES

### Example 1: Enable diagnostics
```
PS C:\>Set-AzureRmRedisCacheDiagnostics -ResourceGroupName "ContosoResourceGroup" -Name "PeakCache" -StorageAccountId "/subscriptions/fffff139-aaaa-bbbb-cccc-21f21f35806e/resourcegroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount"
```

This command enables diagnostics for an Azure Redis cache.

This command will enable diagnostics or update the storage account for all Azure Redis Caches in the same region for the subscription.

## PARAMETERS

### -Name
Specifies the name of the cache.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the cache.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountId
Specifies the resource ID of the storage account used to store the diagnostics data.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Void

## NOTES
* Keywords: azure, azurerm, arm, resource, management, manager, redis, cache, web, webapp, website

## RELATED LINKS

[Remove-AzureRmRedisCacheDiagnostics](./Remove-AzureRmRedisCacheDiagnostics.md)


