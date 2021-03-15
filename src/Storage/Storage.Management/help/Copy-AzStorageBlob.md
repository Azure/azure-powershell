---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/copy-azstorageblob
schema: 2.0.0
---

# Copy-AzStorageBlob

## SYNOPSIS
Copy a blob synchronously.

## SYNTAX

### ContainerName (Default)
```
Copy-AzStorageBlob [-SrcBlob] <String> -SrcContainer <String> -DestContainer <String> [-DestBlob <String>]
 [-StandardBlobTier <String>] [-RehydratePriority <RehydratePriority>] [-EncryptionScope <String>]
 [-Context <IStorageContext>] [-DestContext <IStorageContext>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BlobInstance
```
Copy-AzStorageBlob [-BlobBaseClient <BlobBaseClient>] -DestContainer <String> [-DestBlob <String>]
 [-StandardBlobTier <String>] [-RehydratePriority <RehydratePriority>] [-EncryptionScope <String>]
 [-Context <IStorageContext>] [-DestContext <IStorageContext>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UriPipeline
```
Copy-AzStorageBlob -AbsoluteUri <String> -DestContainer <String> -DestBlob <String>
 [-StandardBlobTier <String>] [-RehydratePriority <RehydratePriority>] [-EncryptionScope <String>]
 [-Context <IStorageContext>] [-DestContext <IStorageContext>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Copy-AzStorageBlob** cmdlet copies a blob synchronously, currently only support block blob.

## EXAMPLES

### Example 1: Copy a named blob to another
```
C:\PS> $destBlob = Copy-AzStorageBlob -SrcContainer "sourcecontainername" -SrcBlob "srcblobname" -DestContainer "destcontainername" -DestBlob "destblobname"
```

This command copies a blob from source container to the destination container with a new blob name. 

### Example 2: Copy blob from a blob object
```
C:\PS> $srcBlob = Get-AzStorageBlob -Container $containerName -Blob $blobName  -Context $ctx 
C:\PS> $destBlob =  $srcBlob | Copy-AzStorageBlob  -DestContainer "destcontainername" -DestBlob "destblobname"
```

This command copies a blob from source blob object to the destination container with a new blob name.

### Example 3: Copy blob from a blob Uri
```
C:\PS> $srcBlobUri = New-AzStorageBlobSASToken -Container $srcContainerName -Blob $srcBlobName -Permission rt -ExpiryTime (Get-Date).AddDays(7) -FullUri 
C:\PS> $destBlob = Copy-AzStorageBlob -AbsoluteUri $srcBlobUri -DestContainer "destcontainername" -DestBlob "destblobname"
```

The first command creates a blob Uri of the source blob, with sas token of permission "rt". The second command copies from source blob Uri to the destination blob.

### Example 4: Update a block blob encryption scope
```
C:\PS> $blob = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob $blobname -DestContainer $containername -EncryptionScope $newScopeName -Force
```

This command update a block blob encryption scope by copy it to itself with a new encryption scope.

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
```

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

### -BlobBaseClient
BlobBaseClient Object

```yaml
Type: Azure.Storage.Blobs.Specialized.BlobBaseClient
Parameter Sets: BlobInstance
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Context
Source Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: ContainerName, BlobInstance
Aliases: SrcContext, SourceContext

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: UriPipeline
Aliases: SrcContext, SourceContext

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

### -DestBlob
Destination blob name

```yaml
Type: System.String
Parameter Sets: ContainerName, BlobInstance
Aliases: DestinationBlob

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UriPipeline
Aliases: DestinationBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestContainer
Destination container name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DestinationContainer

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -EncryptionScope
Encryption scope to be used when making requests to the dest blob.

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
```

### -RehydratePriority
Block Blob RehydratePriority.
Indicates the priority with which to rehydrate an archived blob.
Valid values are High/Standard.

```yaml
Type: Microsoft.Azure.Storage.Blob.RehydratePriority
Parameter Sets: (All)
Aliases:
Accepted values: Standard, High

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SrcBlob
Blob name

```yaml
Type: System.String
Parameter Sets: ContainerName
Aliases: SourceBlob

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -StandardBlobTier
Block Blob Tier, valid values are Hot/Cool/Archive.
See detail in https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Hot, Cool, Archive

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Azure.Storage.Blobs.Specialized.BlobBaseClient

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS
