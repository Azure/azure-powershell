---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/rename-azstoragedirectory
schema: 2.0.0
---

# Rename-AzStorageDirectory

## SYNOPSIS
Renames a directory.

## SYNTAX

### ShareName (Default)
```
Rename-AzStorageDirectory [-ShareName] <String> [-SourcePath] <String> [[-DestinationPath] <String>]
 [-Permission <String>] [-DisAllowSourceTrailingDot] [-DisAllowDestTrailingDot] [-Force] [-AsJob]
 [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ShareObject
```
Rename-AzStorageDirectory [-ShareClient] <ShareClient> [-SourcePath] <String> [[-DestinationPath] <String>]
 [-Permission <String>] [-Force] [-AsJob] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DirecotryObject
```
Rename-AzStorageDirectory [-ShareDirectoryClient] <ShareDirectoryClient> [[-DestinationPath] <String>]
 [-Permission <String>] [-Force] [-AsJob] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-IgnoreReadonly] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Rename-AzStorageDirectory** cmdlet renames a directory from a file share.

## EXAMPLES

### Example 1 : Rename a directory
```powershell
Rename-AzStorageDirectory -ShareName myshare -SourcePath testdir1 -DestinationPath testdir2
```

```output
AccountName: myaccount, ShareName: myshare

Type                Length Name
----                ------ ----
Directory                1 testdir2
```

This command renames a directory from testdir1 to testdir2.

### Example 2 : Rename a directory using pipeline
```powershell
Get-AzStorageFile -ShareName myshare -Path testdir1 | Rename-AzStorageDirectory -DestinationPath testdir2
```

```output
AccountName: myaccount, ShareName: myshare

Type                Length Name
----                ------ ----
Directory                1 testdir2
```

This command gets a directory from a file share first, and then rename the directory from testdir1 to testdir2 using pipeline.

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

### -DestinationPath
The destination path to rename the directory to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
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

### -ShareClient
ShareClienr indicated the share where the directory would be listed.

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
Source directory instance

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

### -ShareName
Name of the file share where the directory would be listed.

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
Path to an existing directory.

```yaml
Type: System.String
Parameter Sets: ShareName, ShareObject
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

### Azure.Storage.Files.Shares.ShareClient

### Azure.Storage.Files.Shares.ShareDirectoryClient

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFileDirectory

## NOTES

## RELATED LINKS
