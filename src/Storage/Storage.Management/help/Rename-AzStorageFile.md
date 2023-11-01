---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/rename-azstoragefile
schema: 2.0.0
---

# Rename-AzStorageFile

## SYNOPSIS
Renames a file.

## SYNTAX

### ShareName (Default)
```
Rename-AzStorageFile [-ShareName] <String> [-SourcePath] <String> [[-DestinationPath] <String>]
 [-ContentType <String>] [-Permission <String>] [-DisAllowSourceTrailingDot] [-DisAllowDestTrailingDot]
 [-Force] [-AsJob] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FileObject
```
Rename-AzStorageFile [-ShareFileClient] <ShareFileClient> [[-DestinationPath] <String>] [-ContentType <String>]
 [-Permission <String>] [-Force] [-AsJob] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ShareObject
```
Rename-AzStorageFile [-ShareClient] <ShareClient> [-SourcePath] <String> [[-DestinationPath] <String>]
 [-ContentType <String>] [-Permission <String>] [-Force] [-AsJob] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DirecotryObject
```
Rename-AzStorageFile [-ShareDirectoryClient] <ShareDirectoryClient> [-SourcePath] <String>
 [[-DestinationPath] <String>] [-ContentType <String>] [-Permission <String>] [-Force] [-AsJob]
 [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Rename-AzStorageFile** cmdlet renames a directory from a file share.

## EXAMPLES

### Example 1 : Rename a file from a file share
```powershell
Rename-AzStorageFile -SourcePath testfile1 -DestinationPath testfile2 -ShareName myshare
```

```output
Directory: https://myaccount.file.core.windows.net/myshare

Type                Length Name
----                ------ ----
File                   512 testfile2
```

This command renames a file from testfile1 to testfile2 under file share myshare. 

### Example 2 : Rename a file from a file share using pipeline
```powershell
Get-AzStorageFile -ShareName myshare -Path testfile1 | Rename-AzStorageFile -DestinationPath testfile2
```

```output
Directory: https://myaccount.file.core.windows.net/myshare

Type                Length Name
----                ------ ----
File                   512 testfile2
```

This command gets a file client object first, and the rename the file from testfile1 to testfile2 using pipeline. 

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

### -ContentType
Sets the MIME content type of the file.
The default type is 'application/octet-stream'.

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

### -DestinationPath
The destination path to rename the file to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisAllowDestTrailingDot
Disallow trailing dot (.) to suffix destination directory and destination file names.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ShareName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisAllowSourceTrailingDot
Disallow trailing dot (.) to suffix source directory and source file names.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ShareName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Force to overwrite the existing file.

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

### -IgnoreReadonly
Optional.
Specifies whether the ReadOnly attribute on a preexisting destination file should be respected.
If true, the rename will succeed, otherwise, a previous file at the destination with the ReadOnly attribute set will cause the rename to fail.

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

### -Permission
If specified the permission (security descriptor) shall be set for the directory/file.
Default value: Inherit.
If SDDL is specified as input, it must have owner, group and dacl.

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

### -ShareClient
ShareClient indicated the share where the file would be listed.

```yaml
Type: Azure.Storage.Files.Shares.ShareClient
Parameter Sets: ShareObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareDirectoryClient
ShareDirectoryClient indicated the share where the file would be listed.

```yaml
Type: Azure.Storage.Files.Shares.ShareDirectoryClient
Parameter Sets: DirecotryObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareFileClient
Source file instance

```yaml
Type: Azure.Storage.Files.Shares.ShareFileClient
Parameter Sets: FileObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareName
Name of the file share where the file would be listed.

```yaml
Type: System.String
Parameter Sets: ShareName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePath
Path to an existing file.

```yaml
Type: System.String
Parameter Sets: ShareName, ShareObject, DirecotryObject
Aliases:

Required: True
Position: 1
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Azure.Storage.Files.Shares.ShareFileClient

### Azure.Storage.Files.Shares.ShareClient

### Azure.Storage.Files.Shares.ShareDirectoryClient

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile

## NOTES

## RELATED LINKS
