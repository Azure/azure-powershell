---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/Az.storage/add-Azstorageaccountmanagementpolicyaction
schema: 2.0.0
---

# Add-AzStorageAccountManagementPolicyAction

## SYNOPSIS
Adds an action to the input ManagementPolicy Action Group object, or creates a ManagementPolicy Action Group object with the action. The object can be used in New-AzStorageAccountManagementPolicyRule.

## SYNTAX

### BaseBlob (Default)
```
Add-AzStorageAccountManagementPolicyAction -BaseBlobAction <String> -DaysAfterModificationGreaterThan <Int32>
 [-InputObject <PSManagementPolicyActionGroup>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Snapshot
```
Add-AzStorageAccountManagementPolicyAction -SnapshotAction <String> -DaysAfterCreationGreaterThan <Int32>
 [-InputObject <PSManagementPolicyActionGroup>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### BlobVersion
```
Add-AzStorageAccountManagementPolicyAction -BlobVersionAction <String> -DaysAfterCreationGreaterThan <Int32>
 [-InputObject <PSManagementPolicyActionGroup>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzStorageAccountManagementPolicyAction** cmdlet adds an action to the input ManagementPolicy Action Group object, or creates a ManagementPolicy Action Group object with the action.

## EXAMPLES

### Example 1: Creates a ManagementPolicy Action Group object with 4 actions, then add it to a management policy rule and set to a Storage account
```
PS C:\>$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction Delete -daysAfterModificationGreaterThan 100
PS C:\>$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToArchive -daysAfterModificationGreaterThan 50  -InputObject $action
PS C:\>$action = Add-AzStorageAccountManagementPolicyAction -BaseBlobAction TierToCool -daysAfterModificationGreaterThan 30 -InputObject $action
PS C:\>$action = Add-AzStorageAccountManagementPolicyAction -SnapshotAction Delete -daysAfterCreationGreaterThan 100 -InputObject $action
PS C:\>$action 

BaseBlob.TierToCool.DaysAfterModificationGreaterThan    : 30
BaseBlob.TierToArchive.DaysAfterModificationGreaterThan : 50
BaseBlob.Delete.DaysAfterModificationGreaterThan        : 100
Snapshot.TierToCool.DaysAfterCreationGreaterThan        : 
Snapshot.TierToArchive.DaysAfterCreationGreaterThan     : 
Snapshot.Delete.DaysAfterCreationGreaterThan            : 100
Version.TierToCool.DaysAfterCreationGreaterThan         : 
Version.TierToArchive.DaysAfterCreationGreaterThan      : 
Version.Delete.DaysAfterCreationGreaterThan             : 

PS C:\>$filter = New-AzStorageAccountManagementPolicyFilter
PS C:\>$rule = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action -Filter $filter
PS C:\>$policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Rule $rule
```

The first command create a ManagementPolicy Action Group object, the following 3 commands add 3 actions to the object. Then add it to a management policy rule and set to a Storage account.

### Example 2: Creates a ManagementPolicy Action Group object with 6 actions on snapshot and blob version, then add it to a management policy rule and set to a Storage account
```
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction  -SnapshotAction Delete -daysAfterCreationGreaterThan 40
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -SnapshotAction TierToArchive -daysAfterCreationGreaterThan 50
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -SnapshotAction TierToCool -daysAfterCreationGreaterThan 60
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction Delete -daysAfterCreationGreaterThan 70
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction TierToArchive -daysAfterCreationGreaterThan 80
PS C:\> $action = Add-AzStorageAccountManagementPolicyAction -InputObject $action -BlobVersionAction TierToCool -daysAfterCreationGreaterThan 90
PS C:\> $action

BaseBlob.TierToCool.DaysAfterModificationGreaterThan    : 
BaseBlob.TierToArchive.DaysAfterModificationGreaterThan : 
BaseBlob.Delete.DaysAfterModificationGreaterThan        : 
Snapshot.TierToCool.DaysAfterCreationGreaterThan        : 60
Snapshot.TierToArchive.DaysAfterCreationGreaterThan     : 50
Snapshot.Delete.DaysAfterCreationGreaterThan            : 40
Version.TierToCool.DaysAfterCreationGreaterThan         : 90
Version.TierToArchive.DaysAfterCreationGreaterThan      : 80
Version.Delete.DaysAfterCreationGreaterThan             : 70

PS C:\>$filter = New-AzStorageAccountManagementPolicyFilter
PS C:\>$rule = New-AzStorageAccountManagementPolicyRule -Name Test -Action $action -Filter $filter
PS C:\>$policy = Set-AzStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Rule $rule
```

The first command create a ManagementPolicy Action Group object, the following 5 commands add 5 actions on snapshot and blob version to the object. Then add it to a management policy rule and set to a Storage account.

## PARAMETERS

### -BaseBlobAction
The management policy action for baseblob.

```yaml
Type: System.String
Parameter Sets: BaseBlob
Aliases:
Accepted values: Delete, TierToArchive, TierToCool

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
Accepted values: Delete, TierToArchive, TierToCool

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
Parameter Sets: Snapshot, BlobVersion
Aliases:

Required: True
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

### -SnapshotAction
The management policy action for snapshot.

```yaml
Type: System.String
Parameter Sets: Snapshot
Aliases:
Accepted values: Delete, TierToArchive, TierToCool

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicyActionGroup

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicyActionGroup

## NOTES

## RELATED LINKS
