---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://learn.microsoft.com/powershell/module/az.cosmosdb/new-azcosmosdbthroughputbucketobject
schema: 2.0.0
---

# New-AzCosmosDBThroughputBucketObject

## SYNOPSIS
Creates a new CosmosDB Throughput Bucket Object (PSThroughputBucket).

## SYNTAX

```
New-AzCosmosDBThroughputBucketObject -Id <Int32> -MaxThroughputPercentage <Int32> [-IsDefaultBucket <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new CosmosDB Throughput Bucket Object (PSThroughputBucket).

## EXAMPLES

### Example 1
```powershell
New-AzCosmosDBThroughputBucketObject -Id 1 -MaxThroughputPercentage 20
```

Creates a throughput bucket with Id 1 and maximum throughput percentage of 20. This bucket is not marked as default.

### Example 2
```powershell
New-AzCosmosDBThroughputBucketObject -Id 2 -MaxThroughputPercentage 30 -IsDefaultBucket $true
```

Creates a throughput bucket with Id 2 and maximum throughput percentage of 30, explicitly marked as the default bucket.

### Example 3
```powershell
New-AzCosmosDBThroughputBucketObject -Id 3 -MaxThroughputPercentage 50 -IsDefaultBucket $false
```

Creates a throughput bucket with Id 3 and maximum throughput percentage of 50, explicitly marked as not default.

## PARAMETERS

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

### -Id
The ID of the throughput bucket.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDefaultBucket
Boolean to indicate whether this is the default throughput bucket. If not specified, the bucket is not marked as default.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxThroughputPercentage
The maximum throughput of the throughput bucket.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSThroughputBucket

## NOTES

## RELATED LINKS
