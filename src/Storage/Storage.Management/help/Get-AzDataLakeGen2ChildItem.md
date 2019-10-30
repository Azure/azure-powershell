---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azdatalakegen2childitem
schema: 2.0.0
---

# Get-AzDataLakeGen2ChildItem

## SYNOPSIS
Lists sub folders and files from a folder or container.

## SYNTAX

```
Get-AzDataLakeGen2ChildItem [-Container] <String> [[-Path] <String>] [-FetchPermission] [-Recurse]
 [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>] [-AsJob] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataLakeGen2ChildItem** cmdlet lists sub folders and files in a folder or container in an Azure storage account.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account. This kind of account can be created by run "New-AzStorageAccount" cmdlet with "-EnableHierarchicalNamespace $true".

## EXAMPLES

### Example 1: List the direct sub items from a container
```
PS C:\>Get-AzDataLakeGen2ChildItem -Container "container1" 


   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/                True                                                                                                                         
dir2/                True
```

This command lists the direct sub items from a container

### Example 2: List recursively from a folder, and fetch permission/owner/ACL
```
PS C:\>Get-AzDataLakeGen2ChildItem -Container "container1" -Path "dir1/" -Recurse -FetchPermission


   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/dir1/           True                         application/octet-stream       2019-10-29 04:13:22Z rwxr-x---    $superuser $superuser          
dir1/dir1/testfile1  False        14400000        application/octet-stream       2019-10-29 04:14:36Z rw-r-----    $superuser $superuser
```

This command lists the direct sub items from a container

### Example 3: List items recursively from a container in multiple batches
```
PS C:\> $MaxReturn = 10000
PS C:\> $ContainerName = "container1"
PS C:\> $Total = 0
PS C:\> $Token = $Null
PS C:\> do
 {
     $items = Get-AzDataLakeGen2ChildItem -Container $ContainerName -Recurse -MaxCount $MaxReturn  -ContinuationToken $Token
     $Total += $items.Count
     if($items.Length -le 0) { Break;}
     $Token = $items[$items.Count -1].ContinuationToken;
 }
 While ($Token -ne $Null)
PS C:\> Echo "Total $Total items in container $ContainerName"
```

This example uses the *MaxCount* and *ContinuationToken* parameters to list items recursively from a container in multiple batches.
The first four commands assign values to variables to use in the example.
The fifth command specifies a **Do-While** statement that uses the **Get-AzDataLakeGen2ChildItem** cmdlet to list items.
The statement includes the continuation token stored in the $Token variable.
$Token changes value as the loop runs.
The final command uses the **Echo** command to display the total.

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

### -Container
Container name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -ContinuationToken
Continuation Token.

```yaml
Type: Microsoft.Azure.Storage.Blob.BlobContinuationToken
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -FetchPermission
Fetch Blob Permission.

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

### -MaxCount
The max count of the blobs that can return.

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

### -Path
The path in the specified container that should be retrieved.
Should be a folder, in the format 'folder1/folder2/'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Recurse
Indicates if will recursively get the Child Item.
The default is false.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

## NOTES

## RELATED LINKS
