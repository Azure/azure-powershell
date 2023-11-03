---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecachesku
schema: 2.0.0
---

# Get-AzStorageCacheSku

## SYNOPSIS
Get the list of StorageCache.Cache SKUs available to this subscription.

## SYNTAX

```
Get-AzStorageCacheSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the list of StorageCache.Cache SKUs available to this subscription.

## EXAMPLES

### Example 1: Get the list of StorageCache.Cache SKUs available to this subscription.
```powershell
Get-AzStorageCacheSku
```

```output
Location             Name                      ResourceType
--------             ----                      ------------
{australiaeast}      AMLFS-Durable-Premium-125 amlFilesystems
{brazilsouth}        AMLFS-Durable-Premium-125 amlFilesystems
...                  ...                       ...
```

Get the list of StorageCache.Cache SKUs available to this subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.Api20230501.IResourceSku

## NOTES

ALIASES

## RELATED LINKS

