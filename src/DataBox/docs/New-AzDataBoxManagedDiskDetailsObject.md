---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-AzDataBoxManagedDiskDetailsObject
schema: 2.0.0
---

# New-AzDataBoxManagedDiskDetailsObject

## SYNOPSIS
Create an in-memory object for ManagedDiskDetails.

## SYNTAX

```
New-AzDataBoxManagedDiskDetailsObject -DataAccountType <DataAccountType> -ResourceGroupId <String>
 -StagingStorageAccountId <String> [-SharePassword <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedDiskDetails.

## EXAMPLES

### Example 1: ManagedDisk object 
```powershell
New-AzDataBoxManagedDiskDetailsObject -ResourceGroupId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName" -StagingStorageAccountId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName" -DataAccountType "ManagedDisk"
```

```output
DataAccountType SharePassword ResourceGroupId                                                StagingStorageAccountId                                                                                                      
--------------- ------------- ---------------                                                -----------------------                                                                                                      
ManagedDisk                   /subscriptions/SubscriptionId/resourceGroups/resourceGroupName /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.Storage/storageAccounts/stagingAccountName
```

Creates a in-memory managed disk object

## PARAMETERS

### -DataAccountType
Account Type of the data to be transferred.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.DataAccountType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupId
Resource Group Id of the compute disks.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePassword
Password for all the shares to be created on the device.
Should not be passed for TransferType:ExportFromAzure jobs.
If this is not passed, the service will generate password itself.
This will not be returned in Get Call.
Password Requirements :  Password must be minimum of 12 and maximum of 64 characters.
Password must have at least one uppercase alphabet, one number and one special character.
Password cannot have the following characters : IilLoO0 Password can have only alphabets, numbers and these characters : @#\-$%^!+=;:_()]+.

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

### -StagingStorageAccountId
Resource Id of the storage account that can be used to copy the vhd for staging.

```yaml
Type: System.String
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.ManagedDiskDetails

## NOTES

ALIASES

## RELATED LINKS

