---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HPCCache.dll-Help.xml
Module Name: Az.HPCCache
online version: https://docs.microsoft.com/powershell/module/az.hpccache/get-azhpccachestoragetarget
schema: 2.0.0
---

# Get-AzHpcCacheStorageTarget

## SYNOPSIS
Get HPC cache storage target(s).

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzHpcCacheStorageTarget -ResourceGroupName <String> -CacheName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzHpcCacheStorageTarget -CacheId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzHpcCacheStorageTarget -CacheObject <PSHPCCache> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzHpcCacheStorageTarget** cmdlet gets storage target(s) that exist on cache.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzHpcCacheStorageTarget -ResourceGroupName rgTest -CacheName cacheTest
```

### Example 2
```powershell
PS C:\> Get-AzHpcCacheStorageTarget -ResourceGroupName rgTest -CacheName cacheTest -StorageTargetName stTest
```

## PARAMETERS

### -CacheId
The resource id of the Cache

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CacheName
Name of cache.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CacheObject
The cache object to start.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models.PSHPCCache
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Name of storage target.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: StorageTargetName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group cache is in.


```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models.PSHpcStorageTarget

## NOTES

## RELATED LINKS
