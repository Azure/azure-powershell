---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
ms.assetid: E53D5040-C1E8-4DC1-8371-F41C00B666E3
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstorageaccount
schema: 2.0.0
---

# Get-AzStorageAccount

## SYNOPSIS
Gets a Storage account.

## SYNTAX

### ResourceGroupParameterSet
```
Get-AzStorageAccount [[-ResourceGroupName] <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AccountNameParameterSet
```
Get-AzStorageAccount [-ResourceGroupName] <String> [-Name] <String> [-IncludeGeoReplicationStats] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### BlobRestoreStatusParameterSet
```
Get-AzStorageAccount [-ResourceGroupName] <String> [-Name] <String> [-IncludeBlobRestoreStatus] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageAccount** cmdlet gets a specified Storage account or all of the Storage accounts in a resource group or the subscription.

## EXAMPLES

### Example 1: Get a specified Storage account
```powershell
Get-AzStorageAccount -ResourceGroupName "RG01" -Name "mystorageaccount"
```

This command gets the specified Storage account.

### Example 2: Get all Storage accounts in a resource group
```powershell
Get-AzStorageAccount -ResourceGroupName "RG01"
```

This command gets all of the Storage accounts in a resource group.

### Example 3:  Get all Storage accounts in the subscription
```powershell
Get-AzStorageAccount
```

This command gets all of the Storage accounts in the subscription.

### Example 4:  Get a Storage accounts with its blob restore status
```powershell
$account = Get-AzStorageAccount -ResourceGroupName "myresourcegoup" -Name "mystorageaccount" -IncludeBlobRestoreStatus

$account.BlobRestoreStatus
```

```output
Status     RestoreId                            FailureReason Parameters.TimeToRestore     Parameters.BlobRanges                 
------     ---------                            ------------- ------------------------     ---------------------                 
InProgress a70cd4a1-f223-4c86-959f-cc13eb4795a8               2020-02-10T13:45:04.7155962Z [container1/blob1 -> container2/blob2]
```

This command gets a Storage accounts with its blob restore status, and show the blob restore status.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -IncludeBlobRestoreStatus
Get the BlobRestoreStatus of the Storage account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlobRestoreStatusParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeGeoReplicationStats
Get the GeoReplicationStats of the Storage account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccountNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Storage account to get.

```yaml
Type: System.String
Parameter Sets: AccountNameParameterSet, BlobRestoreStatusParameterSet
Aliases: StorageAccountName, AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ResourceGroupName
Specifies the name of the resource group that contains the Storage account to get.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AccountNameParameterSet, BlobRestoreStatusParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

## NOTES

## RELATED LINKS

[New-AzStorageAccount](./New-AzStorageAccount.md)

[Remove-AzStorageAccount](./Remove-AzStorageAccount.md)

[Set-AzStorageAccount](./Set-AzStorageAccount.md)
