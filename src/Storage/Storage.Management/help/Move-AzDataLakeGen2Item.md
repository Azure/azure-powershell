---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/move-azdatalakegen2item
schema: 2.0.0
---

# Move-AzDataLakeGen2Item

## SYNOPSIS
Move a file or directory to another a file or directory in same Storage account.

## SYNTAX

### ReceiveManual (Default)
```
Move-AzDataLakeGen2Item [-FileSystem] <String> [-Path] <String> -DestFileSystem <String> -DestPath <String>
 [-Force] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ItemPipeline
```
Move-AzDataLakeGen2Item -InputObject <AzureDataLakeGen2Item> -DestFileSystem <String> -DestPath <String>
 [-Force] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzDataLakeGen2Item** cmdlet moves a a file or directory to another a file or directory in same Storage account.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account. This kind of account can be created by run "New-AzStorageAccount" cmdlet with "-EnableHierarchicalNamespace $true".

## EXAMPLES

### Example 1: Move a fold in same Filesystem
```powershell
Move-AzDataLakeGen2Item -FileSystem "filesystem1" -Path "dir1/" -DestFileSystem "filesystem1" -DestPath "dir3/"
```

```output
FileSystem Name: filesystem1

Path                 IsDirectory  Length          LastModified         Permissions  Owner                Group               
----                 -----------  ------          ------------         -----------  -----                -----               
dir3                 True                         2020-03-13 13:07:34Z rwxrw-rw-    $superuser           $superuser
```

This command move directory 'dir1' to directory 'dir3' in the same Filesystem.

### Example 2: Move a file by pipeline, to another Filesystem in the same Storage account without prompt
```powershell
Get-AzDataLakeGen2Item -FileSystem "filesystem1" -Path "dir1/file1" | Move-AzDataLakeGen2Item -DestFileSystem "filesystem2" -DestPath "dir2/file2" -Force
```

```output
FileSystem Name: filesystem2

Path                 IsDirectory  Length          LastModified         Permissions  Owner                Group               
----                 -----------  ------          ------------         -----------  -----                -----               
dir2/file2           False        1024            2020-03-23 09:57:33Z rwxrw-rw-    $superuser           $superuser
```

This command move file 'dir1/file1' in 'filesystem1' to file 'dir2/file2' in 'filesystem2' in the same Storage account without prompt.

### Example 3: Move an item with Sas token
```powershell
$sas = New-AzStorageContainerSASToken -Name $filesystemName -Permission rdw -Context $ctx

$sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas

Move-AzDataLakeGen2Item -FileSystem $filesystemName -Path $itempath1 -DestFileSystem $filesystemName -DestPath "$($itempath2)$($sas)" -Context $sasctx
```

```output
FileSystem Name: filesystem1

Path                 IsDirectory  Length          LastModified         Permissions  Owner                Group               
----                 -----------  ------          ------------         -----------  -----                -----               
dir2/file1           False        1024            2021-03-23 09:57:33Z rwxrw-rw-    $superuser           $superuser
```

This first command creates a Sas token with rdw permission, the second command creates a Storage context from the Sas token, the 3rd command moves an item with the Sas token.
This example use same Sastoken with rdw permission on both source and destication, if use 2 SAS token for source and destication, source need permission rd, destication need permission w.

## PARAMETERS

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

### -DestFileSystem
Dest FileSystem name

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

### -DestPath
Dest Blob path

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

### -Force
Force to over write the destination.

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

### -InputObject
Azure Datalake Gen2 Item Object to move from.

```yaml
Type: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item
Parameter Sets: ItemPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Path
The path in the specified Filesystem that should be move from.
Can be a file or directory In the format 'directory/file.txt' or 'directory1/directory2/'

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

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

## NOTES

## RELATED LINKS
