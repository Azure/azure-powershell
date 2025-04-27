---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/Az.storage/add-Azstorageaccountmanagementpolicyaction
schema: 2.0.0
---

# Add-AzStorageAccountManagementPolicyAction

## SYNOPSIS
Adds an action to the input ManagementPolicy Action Group object, or creates a ManagementPolicy Action Group object with the action. The object can be used in New-AzStorageAccountManagementPolicyRule.

## SYNTAX

### BaseBlob (Default)
```
Add-AzStorageAccountManagementPolicyAction -BaseBlobAction <String> -DaysAfterModificationGreaterThan <Int32>
 [-DaysAfterLastTierChangeGreaterThan <Int32>] [-InputObject <PSManagementPolicyActionGroup>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### BaseBlobLastAccessTime
```
Add-AzStorageAccountManagementPolicyAction -BaseBlobAction <String> -DaysAfterLastAccessTimeGreaterThan <Int32>
 [-EnableAutoTierToHotFromCool] [-InputObject <PSManagementPolicyActionGroup>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### BaseBlobCreationTime
```
Add-AzStorageAccountManagementPolicyAction -BaseBlobAction <String> -DaysAfterCreationGreaterThan <Int32>
 [-InputObject <PSManagementPolicyActionGroup>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Snapshot
```
Add-AzStorageAccountManagementPolicyAction -SnapshotAction <String> -DaysAfterCreationGreaterThan <Int32>
 [-DaysAfterLastTierChangeGreaterThan <Int32>] [-InputObject <PSManagementPolicyActionGroup>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### BlobVersion
```
Add-AzStorageAccountManagementPolicyAction -BlobVersionAction <String> -DaysAfterCreationGreaterThan <Int32>
 [-DaysAfterLastTierChangeGreaterThan <Int32>] [-InputObject <PSManagementPolicyActionGroup>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzStorageAccountManagementPolicyAction** cmdlet adds an action to the input ManagementPolicy Action Group object, or creates a ManagementPolicy Action Group object with the action.

## EXAMPLES

### Example 1: Creates a ManagementPolicy Action Group object with 4 actions, then add it to a management policy rule and set to a Storage account
<!-- Skip: Output cannot be splitted from code -->


```
$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -DaysAfterCreationGreaterThan 100
$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToArchive -daysAfterModificationGreaterThan 50  -DaysAfterLastTierChangeGreaterThan 40 -InputObject $action
$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToCool -DaysAfterLastAccessTimeGreaterThan 30  -EnableAutoTierToHotFromCool -InputObject $action
$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToHot -DaysAfterCreationGreaterThan 100 -InputObject $action
$action = Add-AzStorageAccountManagementPolicyAction -SnapshotAction Delete -daysAfterCreationGreaterThan 100 -InputObject $action
$action 

BaseBlob.TierToCool.DaysAfterModificationGreaterThan      : 
BaseBlob.TierToCool.DaysAfterLastAccessTimeGreaterThan    : 30
BaseBlob.TierToCool.DaysAfterCreationGreaterThan          : 
BaseBlob.EnableAutoTierToHotFromCool                      : True
BaseBlob.TierToArchive.DaysAfterModificationGreaterThan   : 50
BaseBlob.TierToArchive.DaysAfterLastAccessTimeGreaterThan : 
BaseBlob.TierToArchive.DaysAfterCreationGreaterThan       : 
BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan : 40
BaseBlob.Delete.DaysAfterModificationGreaterThan          : 
BaseBlob.Delete.DaysAfterLastAccessTimeGreaterThan        : 
BaseBlob.Delete.DaysAfterCreationGreaterThan              : 100
BaseBlob.TierToCold.DaysAfterModificationGreaterThan      : 
BaseBlob.TierToCold.DaysAfterLastAccessTimeGreaterThan    : 
BaseBlob.TierToCold.DaysAfterCreationGreaterThan          : 
BaseBlob.TierToHot.DaysAfterModificationGreaterThan       : 
BaseBlob.TierToHot.DaysAfterLastAccessTimeGreaterThan     : 
BaseBlob.TierToHot.DaysAfterCreationGreaterThan           : 100
Snapshot.TierToCool.DaysAfterCreationGreaterThan          : 
Snapshot.TierToArchive.DaysAfterCreationGreaterThan       : 
Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan : 
Snapshot.Delete.DaysAfterCreationGreaterThan              : 100
Snapshot.TierToCold.DaysAfterCreationGreaterThan          : 
Snapshot.TierToHot.DaysAfterCreationGreaterThan           : 
Version.TierToCool.DaysAfterCreationGreaterThan           : 
Version.TierToArchive.DaysAfterCreationGreaterThan        : 
Version.TierToArchive.DaysAfterLastTierChangeGreaterThan  : 
Version.Delete.DaysAfterCreationGreaterThan               : 
Version.TierToCold.DaysAfterCreationGreaterThan           : 
Version.TierToHot.DaysAfterCreationGreaterThan            : 

$filter = New-AzStorageAccountManagementPolicyFilter
$rule = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action -Filter $filter
$policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Rule $rule
```

The first command create a ManagementPolicy Action Group object, the following 3 commands add 3 actions to the object. Then add it to a management policy rule and set to a Storage account.

### Example 2: Creates a ManagementPolicy Action Group object with 7 actions on snapshot and blob version, then add it to a management policy rule and set to a Storage account
<!-- Skip: Output cannot be splitted from code -->


```
$action = Add-AzStorageAccountManagementPolicyAction  -SnapshotAction Delete -daysAfterCreationGreaterThan 40
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -SnapshotAction TierToArchive -daysAfterCreationGreaterThan 50
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -SnapshotAction TierToCool -daysAfterCreationGreaterThan 60
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction Delete -daysAfterCreationGreaterThan 70
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction TierToArchive -daysAfterCreationGreaterThan 80
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction TierToCool -daysAfterCreationGreaterThan 90
$action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction TierToCold -daysAfterCreationGreaterThan 100
$action

BaseBlob.TierToCool.DaysAfterModificationGreaterThan      : 
BaseBlob.TierToCool.DaysAfterLastAccessTimeGreaterThan    : 
BaseBlob.TierToCool.DaysAfterCreationGreaterThan          : 
BaseBlob.EnableAutoTierToHotFromCool                      : 
BaseBlob.TierToArchive.DaysAfterModificationGreaterThan   : 
BaseBlob.TierToArchive.DaysAfterLastAccessTimeGreaterThan : 
BaseBlob.TierToArchive.DaysAfterCreationGreaterThan       : 
BaseBlob.TierToArchive.DaysAfterLastTierChangeGreaterThan : 
BaseBlob.Delete.DaysAfterModificationGreaterThan          : 
BaseBlob.Delete.DaysAfterLastAccessTimeGreaterThan        : 
BaseBlob.Delete.DaysAfterCreationGreaterThan              : 
BaseBlob.TierToCold.DaysAfterModificationGreaterThan      : 
BaseBlob.TierToCold.DaysAfterLastAccessTimeGreaterThan    : 
BaseBlob.TierToCold.DaysAfterCreationGreaterThan          : 
BaseBlob.TierToHot.DaysAfterModificationGreaterThan       : 
BaseBlob.TierToHot.DaysAfterLastAccessTimeGreaterThan     : 
BaseBlob.TierToHot.DaysAfterCreationGreaterThan           : 
Snapshot.TierToCool.DaysAfterCreationGreaterThan          : 60
Snapshot.TierToArchive.DaysAfterCreationGreaterThan       : 50
Snapshot.TierToArchive.DaysAfterLastTierChangeGreaterThan : 
Snapshot.Delete.DaysAfterCreationGreaterThan              : 40
Snapshot.TierToCold.DaysAfterCreationGreaterThan          : 
Snapshot.TierToHot.DaysAfterCreationGreaterThan           : 
Version.TierToCool.DaysAfterCreationGreaterThan           : 90
Version.TierToArchive.DaysAfterCreationGreaterThan        : 80
Version.TierToArchive.DaysAfterLastTierChangeGreaterThan  : 
Version.Delete.DaysAfterCreationGreaterThan               : 70
Version.TierToCold.DaysAfterCreationGreaterThan           : 100
Version.TierToHot.DaysAfterCreationGreaterThan            : 

$filter = New-AzStorageAccountManagementPolicyFilter
$rule = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action -Filter $filter
$policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Rule $rule
```

The first command create a ManagementPolicy Action Group object, the following 5 commands add 5 actions on snapshot and blob version to the object. Then add it to a management policy rule and set to a Storage account.

## PARAMETERS

### -BaseBlobAction
The management policy action for baseblob.

```yaml
Type: System.String
Parameter Sets: BaseBlob, BaseBlobLastAccessTime, BaseBlobCreationTime
Aliases:
Accepted values: Delete, TierToArchive, TierToCool, TierToCold, TierToHot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobVersionAction
The management policy action for blob version.

```yaml
Type: System.String
Parameter Sets: BlobVersion
Aliases:
Accepted values: Delete, TierToArchive, TierToCool, TierToCold, TierToHot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysAfterCreationGreaterThan
Integer value indicating the age in days after creation.

```yaml
Type: System.Int32
Parameter Sets: BaseBlobCreationTime, Snapshot, BlobVersion
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysAfterLastAccessTimeGreaterThan
Integer value indicating the age in days after last blob access. This property can only be used in conjuction with last access time tracking policy.

```yaml
Type: System.Int32
Parameter Sets: BaseBlobLastAccessTime
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysAfterLastTierChangeGreaterThan
Integer value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions. It requires daysAfterModificationGreaterThan to be set for baseBlobs based actions, or daysAfterModificationGreaterThan to be set for snapshots and blob version based actions.

```yaml
Type: System.Int32
Parameter Sets: BaseBlob, Snapshot, BlobVersion
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaysAfterModificationGreaterThan
Integer value indicating the age in days after last modification.

```yaml
Type: System.Int32
Parameter Sets: BaseBlob
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -EnableAutoTierToHotFromCool
Enables auto tiering of a blob from cool to hot on a blob access. It only works with TierToCool action and DaysAfterLastAccessTimeGreaterThan.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BaseBlobLastAccessTime
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
If input the ManagementPolicy Action object, will set the action to the input action object.
If not input, will create a new action object.

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicyActionGroup
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnapshotAction
The management policy action for snapshot.

```yaml
Type: System.String
Parameter Sets: Snapshot
Aliases:
Accepted values: Delete, TierToArchive, TierToCool, TierToCold, TierToHot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicyActionGroup

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicyActionGroup

## NOTES

## RELATED LINKS
