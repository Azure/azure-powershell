---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstoragefilesymboliclink
schema: 2.0.0
---

# New-AzStorageFileSymbolicLink

## SYNOPSIS
Creates a symbolic link to a specified file. Only works in NFS file share.

## SYNTAX

### ShareName (Default)
```
New-AzStorageFileSymbolicLink [-ShareName] <String> [-Path] <String> [-LinkText] <String>
 [-Metadata <Hashtable>] [-FileCreatedOn <DateTimeOffset>] [-FileLastWrittenOn <DateTimeOffset>]
 [-Owner <String>] [-Group <String>] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Share
```
New-AzStorageFileSymbolicLink [-ShareClient] <ShareClient> [-Path] <String> [-LinkText] <String>
 [-Metadata <Hashtable>] [-FileCreatedOn <DateTimeOffset>] [-FileLastWrittenOn <DateTimeOffset>]
 [-Owner <String>] [-Group <String>] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Directory
```
New-AzStorageFileSymbolicLink [-ShareDirectoryClient] <ShareDirectoryClient> [-Path] <String>
 [-LinkText] <String> [-Metadata <Hashtable>] [-FileCreatedOn <DateTimeOffset>]
 [-FileLastWrittenOn <DateTimeOffset>] [-Owner <String>] [-Group <String>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageFileSymbolicLink** cmdlet creates a symbolic link to a file in an Azure File share. This cmdlet only works with NFS file shares. A symbolic link is a file that points to another file or directory. The symbolic link can point to files in the same file share or even outside the file share using relative or absolute paths.

## EXAMPLES

### Example 1: Create a symbolic link with all optional parameters
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
New-AzStorageFileSymbolicLink -ShareName "nfsshare" -Path "links/testlink" -LinkText "config/app.conf" -Metadata @{ "meta1"="value1";"meta2"="value2"} -FileCreatedOn "2025-09-01T00:00:00Z" -FileLastWrittenOn "2025-09-15T12:00:00Z" -Owner "1000" -Group "1000" -Context $ctx
```

This command creates a symbolic link with all available optional parametersThe symbolic link points to a relative path "config/app.conf".

### Example 2: Create a symbolic link using ShareClient object
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
$shareClient = Get-AzStorageShare -Name "nfsshare" -Context $ctx
$shareClient | New-AzStorageFileSymbolicLink -Path "dir1/app-link" -LinkText "config/app.conf"
```

This command creates a symbolic link using a ShareClient object obtained from Get-AzStorageShare.

### Example 3: Create a symbolic link using directory client
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
$dirClient = Get-AzStorageFile -ShareName "nfsshare" -Path "testdir" -Context $ctx
$dirClient | New-AzStorageFileSymbolicLink -Path "testlink" -LinkText "app/main.exe"
```

This command creates a symbolic link within a specific directory using a ShareDirectoryClient object.

## PARAMETERS

### -ClientTimeoutPerRequest
The client side maximum execution time for each request in seconds.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases: ClientTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConcurrentTaskCount
The total amount of concurrent async tasks.
The default value is 10.

```yaml
Type: System.Nullable`1[System.Int32]
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

### -FileCreatedOn
The creation time of the symbolic link.

```yaml
Type: System.Nullable`1[System.DateTimeOffset]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileLastWrittenOn
The last write time of the symbolic link.

```yaml
Type: System.Nullable`1[System.DateTimeOffset]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Optional.
The owner group identifier (GID) to be set on the symbolic link.
The default value is 0 (root group).

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

### -LinkText
The absolute or relative path to the file to be linked to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Optional custom metadata to set for the symbolic link.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Owner
Optional.
The owner user identifier (UID) to be set on the symbolic link.
The default value is 0 (root).

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

### -Path
Path of the symbolic link to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ServerTimeoutPerRequest
The server time out for each request in seconds.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases: ServerTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShareClient
ShareClient object indicated the share where the symbolic link would be created.

```yaml
Type: Azure.Storage.Files.Shares.ShareClient
Parameter Sets: Share
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareDirectoryClient
ShareDirectoryClient object indicated the base folder where the symbolic link would be created.

```yaml
Type: Azure.Storage.Files.Shares.ShareDirectoryClient
Parameter Sets: Directory
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareName
Name of the file share where the symbolic link would be created.

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

### Azure.Storage.Files.Shares.ShareClient

### Azure.Storage.Files.Shares.ShareDirectoryClient

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile

## NOTES
- This cmdlet only works with NFS file shares
- Symbolic links can point to files within the same share or external locations
- The symbolic link will appear as a regular file in directory listings but contains a reference to the target path

## RELATED LINKS

[Get-AzStorageFileSymbolicLink](./Get-AzStorageFileSymbolicLink.md)

[New-AzStorageFileHardLink](./New-AzStorageFileHardLink.md)

[Get-AzStorageFile](./Get-AzStorageFile.md)
