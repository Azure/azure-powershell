---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/start-azstoragefilecopy
schema: 2.0.0
---

# Start-AzStorageFileCopy

## SYNOPSIS


## SYNTAX

### UriToFilePath (Default)
```
Start-AzStorageFileCopy -DestShareName <String> -DestFilePath <String> -AbsoluteUri <String>
 [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>]
 [-ClientTimeoutPerRequest <Int32?>] [-DefaultProfile <IAzureContextContainer>]
 [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ContainerInstance
```
Start-AzStorageFileCopy -SrcBlobName <String> -DestShareName <String> -DestFilePath <String>
 -SrcContainer <CloudBlobContainer> [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ContainerName
```
Start-AzStorageFileCopy -SrcBlobName <String> -SrcContainerName <String> -DestShareName <String>
 -DestFilePath <String> [-Context <IStorageContext>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### FileInstanceToFilePath
```
Start-AzStorageFileCopy -DestShareName <String> -DestFilePath <String> -SrcFile <CloudFile>
 [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>]
 [-ClientTimeoutPerRequest <Int32?>] [-DefaultProfile <IAzureContextContainer>]
 [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ShareInstance
```
Start-AzStorageFileCopy -DestShareName <String> -DestFilePath <String> -SrcFilePath <String>
 -SrcShare <CloudFileShare> [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>]
 [-ClientTimeoutPerRequest <Int32?>] [-DefaultProfile <IAzureContextContainer>]
 [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ShareName
```
Start-AzStorageFileCopy -DestShareName <String> -DestFilePath <String> -SrcFilePath <String>
 -SrcShareName <String> [-Context <IStorageContext>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BlobInstanceFilePath
```
Start-AzStorageFileCopy -DestShareName <String> -DestFilePath <String> -SrcBlob <CloudBlob>
 [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>]
 [-ClientTimeoutPerRequest <Int32?>] [-DefaultProfile <IAzureContextContainer>]
 [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BlobInstanceFileInstance
```
Start-AzStorageFileCopy -SrcBlob <CloudBlob> -DestFile <CloudFile> [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UriToFileInstance
```
Start-AzStorageFileCopy -DestFile <CloudFile> -AbsoluteUri <String> [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### FileInstanceToFileInstance
```
Start-AzStorageFileCopy -DestFile <CloudFile> -SrcFile <CloudFile> [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-ClientTimeoutPerRequest <Int32?>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
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

### -AbsoluteUri
Source Uri

```yaml
Type: System.String
Parameter Sets: UriToFilePath, UriToFileInstance
Aliases:

Required: True
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
Aliases:

Required: False
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
Source Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: ContainerName, ShareName
Aliases: SrcContext

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -DestContext
Destination Storage context object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: UriToFilePath, ContainerInstance, ContainerName, FileInstanceToFilePath, ShareInstance, ShareName, BlobInstanceFilePath
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestFile
Dest file instance

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFile
Parameter Sets: BlobInstanceFileInstance, UriToFileInstance, FileInstanceToFileInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestFilePath
Dest file path

```yaml
Type: System.String
Parameter Sets: UriToFilePath, ContainerInstance, ContainerName, FileInstanceToFilePath, ShareInstance, ShareName, BlobInstanceFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestShareName
Dest share name

```yaml
Type: System.String
Parameter Sets: UriToFilePath, ContainerInstance, ContainerName, FileInstanceToFilePath, ShareInstance, ShareName, BlobInstanceFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Force
Force to overwrite the existing file.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServerTimeoutPerRequest
The server time out for each request in seconds.

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

### -SrcBlob
Source blob instance

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlob
Parameter Sets: BlobInstanceFilePath, BlobInstanceFileInstance
Aliases: ICloudBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
Dynamic: False
```

### -SrcBlobName
Source blob name

```yaml
Type: System.String
Parameter Sets: ContainerInstance, ContainerName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcContainer
Source container instance

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer
Parameter Sets: ContainerInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcContainerName
Source container name

```yaml
Type: System.String
Parameter Sets: ContainerName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcFile
Source file instance

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFile
Parameter Sets: FileInstanceToFilePath, FileInstanceToFileInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SrcFilePath
Source file path

```yaml
Type: System.String
Parameter Sets: ShareInstance, ShareName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcShare
Source share instance

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFileShare
Parameter Sets: ShareInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcShareName
Source share name

```yaml
Type: System.String
Parameter Sets: ShareName
Aliases:

Required: True
Position: Named
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

### Microsoft.WindowsAzure.Storage.Blob.CloudBlob

### Microsoft.WindowsAzure.Storage.File.CloudFile

## OUTPUTS

### System.Void

## ALIASES

## NOTES

## RELATED LINKS

