---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/start-azstorageblobcopy
schema: 2.0.0
---

# Start-AzStorageBlobCopy

## SYNOPSIS


## SYNTAX

### ContainerName (Default)
```
Start-AzStorageBlobCopy [-SrcBlob] <String> -DestContainer <String> -SrcContainer <String>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force]
 [-PremiumPageBlobTier <PremiumPageBlobTier>] [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BlobInstance
```
Start-AzStorageBlobCopy -CloudBlob <CloudBlob> -DestContainer <String> [-ClientTimeoutPerRequest <Int32?>]
 [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force] [-PremiumPageBlobTier <PremiumPageBlobTier>]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BlobInstanceToBlobInstance
```
Start-AzStorageBlobCopy -CloudBlob <CloudBlob> -DestCloudBlob <CloudBlob> [-ClientTimeoutPerRequest <Int32?>]
 [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-DestContext <IStorageContext>] [-Force] [-PremiumPageBlobTier <PremiumPageBlobTier>]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ContainerInstance
```
Start-AzStorageBlobCopy [-SrcBlob] <String> -CloudBlobContainer <CloudBlobContainer> -DestContainer <String>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force]
 [-PremiumPageBlobTier <PremiumPageBlobTier>] [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DirInstance
```
Start-AzStorageBlobCopy -DestContainer <String> -SrcDir <CloudFileDirectory> -SrcFilePath <String>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FileInstance
```
Start-AzStorageBlobCopy -DestContainer <String> -SrcFile <CloudFile> [-ClientTimeoutPerRequest <Int32?>]
 [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### FileInstanceToBlobInstance
```
Start-AzStorageBlobCopy -DestCloudBlob <CloudBlob> -SrcFile <CloudFile> [-ClientTimeoutPerRequest <Int32?>]
 [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-DestContext <IStorageContext>] [-Force] [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ShareInstance
```
Start-AzStorageBlobCopy -DestContainer <String> -SrcFilePath <String> -SrcShare <CloudFileShare>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ShareName
```
Start-AzStorageBlobCopy -DestContainer <String> -SrcFilePath <String> -SrcShareName <String>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestBlob <String>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UriPipeline
```
Start-AzStorageBlobCopy -AbsoluteUri <String> -DestBlob <String> -DestContainer <String>
 [-ClientTimeoutPerRequest <Int32?>] [-ConcurrentTaskCount <Int32?>] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-DestContext <IStorageContext>] [-Force]
 [-ServerTimeoutPerRequest <Int32?>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Source blob uri

```yaml
Type: System.String
Parameter Sets: UriPipeline
Aliases: SrcUri, SourceUri

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -CloudBlob
CloudBlob Object

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlob
Parameter Sets: BlobInstance, BlobInstanceToBlobInstance
Aliases: SrcICloudBlob, SrcCloudBlob, ICloudBlob, SourceICloudBlob, SourceCloudBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
Dynamic: False
```

### -CloudBlobContainer
CloudBlobContainer Object

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer
Parameter Sets: ContainerInstance
Aliases: SourceCloudBlobContainer

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: (All)
Aliases: SrcContext, SourceContext

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

### -DestBlob
Destination blob name

```yaml
Type: System.String
Parameter Sets: BlobInstance, ContainerInstance, ContainerName, DirInstance, FileInstance, ShareInstance, ShareName, UriPipeline
Aliases: DestinationBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestCloudBlob
Destination CloudBlob object

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.CloudBlob
Parameter Sets: BlobInstanceToBlobInstance, FileInstanceToBlobInstance
Aliases: DestICloudBlob, DestinationCloudBlob, DestinationICloudBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestContainer
Destination container name

```yaml
Type: System.String
Parameter Sets: BlobInstance, ContainerInstance, ContainerName, DirInstance, FileInstance, ShareInstance, ShareName, UriPipeline
Aliases: DestinationContainer

Required: True
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
Parameter Sets: (All)
Aliases: DestinationContext

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Force
Force to overwrite the existing blob or file

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

### -PremiumPageBlobTier
Premium Page Blob Tier

```yaml
Type: Microsoft.WindowsAzure.Storage.Blob.PremiumPageBlobTier
Parameter Sets: BlobInstance, BlobInstanceToBlobInstance, ContainerInstance, ContainerName
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
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcBlob
Blob name

```yaml
Type: System.String
Parameter Sets: ContainerInstance, ContainerName
Aliases: SourceBlob

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcContainer
Source Container name

```yaml
Type: System.String
Parameter Sets: ContainerName
Aliases: SourceContainer

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcDir
Source file directory

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFileDirectory
Parameter Sets: DirInstance
Aliases: SourceDir

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcFile
Source file

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFile
Parameter Sets: FileInstance, FileInstanceToBlobInstance
Aliases: SourceFile

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
Parameter Sets: DirInstance, ShareInstance, ShareName
Aliases: SourceFilePath

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SrcShare
Source share

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFileShare
Parameter Sets: ShareInstance
Aliases: SourceShare

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
Aliases: SourceShareName

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

### Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer

### Microsoft.WindowsAzure.Storage.File.CloudFile

### System.String

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## ALIASES

### Start-CopyAzureStorageBlob

## NOTES

## RELATED LINKS

