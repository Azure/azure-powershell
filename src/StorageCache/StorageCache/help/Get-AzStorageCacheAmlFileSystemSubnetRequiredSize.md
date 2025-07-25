---
external help file: Az.StorageCache-help.xml
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecacheamlfilesystemsubnetrequiredsize
schema: 2.0.0
---

# Get-AzStorageCacheAmlFileSystemSubnetRequiredSize

## SYNOPSIS
Get the number of available IP addresses needed for the AML file system information provided.

## SYNTAX

```
Get-AzStorageCacheAmlFileSystemSubnetRequiredSize [-SubscriptionId <String[]>] [-SkuName <String>]
 [-StorageCapacityTiB <Single>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get the number of available IP addresses needed for the AML file system information provided.

## EXAMPLES

### Example 1: Get the number of available IP addresses needed for the AML file system information provided.
```powershell
Get-AzStorageCacheAmlFileSystemSubnetRequiredSize -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16
```

```output
8
```

Get the number of available IP addresses needed for the AML file system information provided.

## PARAMETERS

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

### -SkuName
SKU name for this resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageCapacityTiB
The size of the AML file system, in TiB.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IRequiredAmlFilesystemSubnetsSize

## NOTES

## RELATED LINKS
