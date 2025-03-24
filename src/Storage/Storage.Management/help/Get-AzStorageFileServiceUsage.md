---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefileserviceusage
schema: 2.0.0
---

# Get-AzStorageFileServiceUsage

## SYNOPSIS
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

## SYNTAX

### Get (Default)
```
Get-AzStorageFileServiceUsage -ResourceGroupName <String> -StorageAccountName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzStorageFileServiceUsage -ResourceGroupName <String> -StorageAccountName <String>
 [-SubscriptionId <String[]>] [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageFileServiceUsage -InputObject <IStorageIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

## EXAMPLES

### Example 1: Get a Storage account file service usage data
```powershell
Get-AzStorageFileServiceUsage -StorageAccountName myaccount -ResourceGroupName myresroucegroup
```

```output
BurstingConstantBurstFloorIops                      : 10000
BurstingConstantBurstIoScalar                       : 3
BurstingConstantBurstTimeframeSecond                : 3600
FileShareLimitMaxProvisionedBandwidthMiBPerSec      : 10340
FileShareLimitMaxProvisionedIops                    : 102400
FileShareLimitMaxProvisionedStorageGiB              : 262144
FileShareLimitMinProvisionedBandwidthMiBPerSec      : 125
FileShareLimitMinProvisionedIops                    : 3000
FileShareLimitMinProvisionedStorageGiB              : 32
FileShareRecommendationBandwidthScalar              : 0.1
FileShareRecommendationBaseBandwidthMiBPerSec       : 125
FileShareRecommendationBaseIops                     : 3000
FileShareRecommendationIoScalar                     : 1
Id                                                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresroucegroup/providers/Microsoft.Storage/storageAccounts/myaccount/fileServices/default/usages/default
LiveShareFileShareCount                             : 1
LiveShareProvisionedBandwidthMiBPerSec              : 129
LiveShareProvisionedIops                            : 3032
LiveShareProvisionedStorageGiB                      : 32
Name                                                : default
ResourceGroupName                                   : myresroucegroup
SoftDeletedShareFileShareCount                      : 0
SoftDeletedShareProvisionedBandwidthMiBPerSec       : 0
SoftDeletedShareProvisionedIops                     : 0
SoftDeletedShareProvisionedStorageGiB               : 0
StorageAccountLimitMaxFileShare                     : 50
StorageAccountLimitMaxProvisionedBandwidthMiBPerSec : 10340
StorageAccountLimitMaxProvisionedIops               : 102400
StorageAccountLimitMaxProvisionedStorageGiB         : 262144
Type                                                : Microsoft.Storage/storageAccounts/fileServices/usages
```

This command gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
Optional, specifies the maximum number of file service usages to be included in the list response.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
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

### -StorageAccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceUsage

## NOTES

## RELATED LINKS
