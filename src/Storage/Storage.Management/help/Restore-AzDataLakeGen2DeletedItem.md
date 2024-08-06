---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/restore-azdatalakegen2deleteditem
schema: 2.0.0
---

# Restore-AzDataLakeGen2DeletedItem

## SYNOPSIS
Restores a deleted file or directory in a filesystem.

## SYNTAX

### ReceiveManual (Default)
```
Restore-AzDataLakeGen2DeletedItem [-FileSystem] <String> [-Path] <String> [-DeletionId] <String> [-AsJob]
 [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ItemPipeline
```
Restore-AzDataLakeGen2DeletedItem -InputObject <AzureDataLakeGen2DeletedItem> [-AsJob]
 [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzDataLakeGen2DeletedItem** cmdlet restores a deleted file or directory in a filesystem in an Azure storage account.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account. This kind of account can be created by run "New-AzStorageAccount" cmdlet with "-EnableHierarchicalNamespace $true".

## EXAMPLES

### Example 1: List all deleted files or directories from a Filesystem, and restore them by pipeline
<!-- Skip: Output cannot be splitted from code -->


```
$items = Get-AzDataLakeGen2DeletedItem -FileSystem "filesystem1" 
$items

   FileSystem Name: filesystem1

Path                 DeletionId           DeletedOn            RemainingRetentionDays
----                 ----------           ---------            ----------------------
dir0/dir1/file1      132658816156507617   2021-05-19 07:06:55Z 3                     
dir0/dir2            132658834541610122   2021-05-19 07:37:34Z 3                    
dir0/dir2/file3      132658834534174806   2021-05-19 07:37:33Z 3   

$items | Restore-AzDataLakeGen2DeletedItem 

   FileSystem Name: filesystem1

Path                 IsDirectory  Length          LastModified         Permissions  Owner                Group               
----                 -----------  ------          ------------         -----------  -----                -----               
dir0/dir1/file1      False        1024            2021-05-19 07:06:39Z rw-r-----    $superuser           $superuser          
dir0/dir2            True                         2021-05-19 07:06:37Z rwxr-x---    $superuser           $superuser          
dir0/dir2/file3      False        1024            2021-05-19 07:06:42Z rw-r-----    $superuser           $superuser
```

This command lists all deleted files or directories from a Filesystem, the restore all of them by pipeline.

### Example 2: Restore an single file with path and DeletionId
```powershell
Restore-AzDataLakeGen2DeletedItem -FileSystem "filesystem1"  -Path dir0/dir1/file1 -DeletionId 132658838415219780
```

```output
FileSystem Name: filesystem1

Path                 IsDirectory  Length          LastModified         Permissions  Owner                Group               
----                 -----------  ------          ------------         -----------  -----                -----               
dir0/dir1/file1      False        1024            2021-05-19 07:06:39Z rw-r-----    $superuser           $superuser
```

This command restores an single file with path and DeletionId. The DeletionId can be get with 'Get-AzDataLakeGen2DeletedItem' cmdlet.

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

### -Context
Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeletionId
The deletion ID associated with the soft deleted path.
You can get soft deleted paths and their assocaited deletion IDs with cmdlet 'Get-AzDataLakeGen2DeletedItem'.

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FileSystem
FileSystem name

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Azure Datalake Gen2 Deleted Item Object to restore.

```yaml
Type: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2DeletedItem
Parameter Sets: ItemPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Path
The deleted item path in the specified FileSystem that should be restore.
In the format 'directory/file.txt' or 'directory1/directory2/'

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 1
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

### System.String

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2DeletedItem

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

## NOTES

## RELATED LINKS
