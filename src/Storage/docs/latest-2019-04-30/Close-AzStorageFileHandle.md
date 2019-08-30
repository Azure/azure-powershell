---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/close-azstoragefilehandle
schema: 2.0.0
---

# Close-AzStorageFileHandle

## SYNOPSIS


## SYNTAX

### ShareNameCloseAll (Default)
```
Close-AzStorageFileHandle [-ShareName] <String> -CloseAll [[-Path] <String>] [-AsJob]
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-PassThru] [-Recursive] [-ServerTimeoutPerRequest <Int32?>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DirectoryCloseAll
```
Close-AzStorageFileHandle [-Directory] <CloudFileDirectory> -CloseAll [[-Path] <String>] [-AsJob]
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-PassThru] [-Recursive] [-ServerTimeoutPerRequest <Int32?>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FileCloseAll
```
Close-AzStorageFileHandle [-File] <CloudFile> -CloseAll [-AsJob] [-ClientTimeoutPerRequest <Int32?>]
 [-ConcurrentTaskCount <Int32?>] [-DefaultProfile <IAzureContextContainer>] [-PassThru]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ShareCloseAll
```
Close-AzStorageFileHandle [-Share] <CloudFileShare> -CloseAll [[-Path] <String>] [-AsJob]
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-PassThru] [-Recursive] [-ServerTimeoutPerRequest <Int32?>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ShareCloseSingle
```
Close-AzStorageFileHandle [-Share] <CloudFileShare> -FileHandle <PSFileHandle> [-AsJob]
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-PassThru] [-ServerTimeoutPerRequest <Int32?>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ShareNameCloseSingle
```
Close-AzStorageFileHandle [-ShareName] <String> -FileHandle <PSFileHandle> [-AsJob]
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-PassThru] [-ServerTimeoutPerRequest <Int32?>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -ClientTimeoutPerRequest
The client side maximum execution time for each request in seconds.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases: ClientTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloseAll
Force close all File handles.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DirectoryCloseAll, FileCloseAll, ShareCloseAll, ShareNameCloseAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConcurrentTaskCount
The total amount of concurrent async tasks.
The default value is 10.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Context
Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: ShareNameCloseAll, ShareNameCloseSingle
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Directory
CloudFileDirectory object indicated the base folder which contains the files/directories to closed handle.

```yaml
Type: Microsoft.Azure.Storage.File.CloudFileDirectory
Parameter Sets: DirectoryCloseAll
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -File
CloudFile object indicated the file to close handle.

```yaml
Type: Microsoft.Azure.Storage.File.CloudFile
Parameter Sets: FileCloseAll
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -FileHandle
The File Handle to close.

```yaml
Type: Microsoft.Azure.Commands.Storage.Model.ResourceModel.PSFileHandle
Parameter Sets: ShareCloseSingle, ShareNameCloseSingle
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Return whether the specified blob is successfully removed

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Path
Path to an existing file/directory.

```yaml
Type: System.String
Parameter Sets: DirectoryCloseAll, ShareCloseAll, ShareNameCloseAll
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Recursive
Closed handles Recursively.
Only works on File Directory.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DirectoryCloseAll, ShareCloseAll, ShareNameCloseAll
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServerTimeoutPerRequest
The server time out for each request in seconds.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases: ServerTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Share
CloudFileShare object indicated the share which contains the files/directories to closed handle.

```yaml
Type: Microsoft.Azure.Storage.File.CloudFileShare
Parameter Sets: ShareCloseAll, ShareCloseSingle
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ShareName
Name of the file share which contains the files/directories to closed handle.

```yaml
Type: System.String
Parameter Sets: ShareNameCloseAll, ShareNameCloseSingle
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

### Microsoft.Azure.Commands.Storage.Model.ResourceModel.PSFileHandle

### Microsoft.Azure.Storage.File.CloudFile

### Microsoft.Azure.Storage.File.CloudFileDirectory

### Microsoft.Azure.Storage.File.CloudFileShare

## OUTPUTS

### System.Int32

## ALIASES

## NOTES

## RELATED LINKS

