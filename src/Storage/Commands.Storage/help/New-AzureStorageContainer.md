---
external help file: Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml
ms.assetid: 2B12BC19-EF8F-43F5-AF04-C570FEEA1AE6
online version: https://docs.microsoft.com/en-us/powershell/module/azure.storage/new-azurestoragecontainer
schema: 2.0.0
---

# New-AzureStorageContainer

## SYNOPSIS
Creates an Azure storage container.

## SYNTAX

```
New-AzureStorageContainer [-Name] <String> [[-Permission] <BlobContainerPublicAccessType>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-ConcurrentTaskCount <Int32>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureStorageContainer** cmdlet creates an Azure storage container.

## EXAMPLES

### Example 1: Create an Azure storage container
```
PS C:\>New-AzureStorageContainer -Name "ContainerName" -Permission Off
```

This command creates a storage container.

### Example 2: Create multiple Azure storage containers
```
PS C:\>"container1 container2 container3".split() | New-AzureStorageContainer -Permission Container
```

This example creates multiple storage containers.
It uses the **Split** method of the .NET **String** class and then passes the names on the pipeline.

## PARAMETERS

### -ClientTimeoutPerRequest
Specifies the client-side time-out interval, in seconds, for one service request.
If the previous call fails in the specified interval, this cmdlet retries the request.
If this cmdlet does not receive a successful response before the interval elapses, this cmdlet returns an error.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConcurrentTaskCount
Specifies the maximum concurrent network calls.
You can use this parameter to limit the concurrency to throttle local CPU and bandwidth usage by specifying the maximum number of concurrent network calls.
The specified value is an absolute count and is not multiplied by the core count.
This parameter can help reduce network connection problems in low bandwidth environments, such as 100 kilobits per second.
The default value is 10.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Context
Specifies a context for the new container.

```yaml
Type: IStorageContext
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Specifies a name for the new container.

```yaml
Type: String
Parameter Sets: (All)
Aliases: N, Container

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Permission
Specifies the level of public access to this container.
By default, the container and any blobs in it can be accessed only by the owner of the storage account.
To grant anonymous users read permissions to a container and its blobs, you can set the container permissions to enable public access.
Anonymous users can read blobs in a publicly available container without authenticating the request.
The acceptable values for this parameter are:

- Container.
Provides full read access to a container and its blobs.
Clients can enumerate blobs in the container through anonymous request, but cannot enumerate containers in the storage account. 
- Blob.
Provides read access to blob data throughout a container through anonymous request, but does not provide access to container data.
Clients cannot enumerate blobs in the container by using anonymous request. 
- Off.
Which restricts access to only the storage account owner.

```yaml
Type: BlobContainerPublicAccessType
Parameter Sets: (All)
Aliases: PublicAccess
Accepted values: Off, Container, Blob

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerTimeoutPerRequest
Specifies the service side time-out interval, in seconds, for a request.
If the specified interval elapses before the service processes the request, the storage service returns an error.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### IStorageContext

Parameter 'Context' accepts value of type 'IStorageContext' from the pipeline

### String

Parameter 'Name' accepts value of type 'String' from the pipeline

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageContainer

## NOTES

## RELATED LINKS

[Get-AzureStorageContainer](./Get-AzureStorageContainer.md)

[Remove-AzureStorageContainer](./Remove-AzureStorageContainer.md)

[Set-AzureStorageContainerAcl](./Set-AzureStorageContainerAcl.md)


