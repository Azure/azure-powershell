---
external help file: Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml
ms.assetid: 6420CBE1-BF9D-493D-BCA8-E8C6688FAF3B
online version: https://docs.microsoft.com/en-us/powershell/module/azure.storage/get-azurestoragefilecontent
schema: 2.0.0
---

# Get-AzureStorageFileContent

## SYNOPSIS
Downloads the contents of a file.

## SYNTAX

### ShareName (Default)
```
Get-AzureStorageFileContent [-ShareName] <String> [-Path] <String> [[-Destination] <String>] [-CheckMd5]
 [-PassThru] [-Force] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Share
```
Get-AzureStorageFileContent [-Share] <CloudFileShare> [-Path] <String> [[-Destination] <String>] [-CheckMd5]
 [-PassThru] [-Force] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Directory
```
Get-AzureStorageFileContent [-Directory] <CloudFileDirectory> [-Path] <String> [[-Destination] <String>]
 [-CheckMd5] [-PassThru] [-Force] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### File
```
Get-AzureStorageFileContent [-File] <CloudFile> [[-Destination] <String>] [-CheckMd5] [-PassThru] [-Force]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>] [-ConcurrentTaskCount <Int32>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureStorageFileContent** cmdlet downloads the contents of a file, and then saves it to a destination that you specify.
This cmdlet does not return the contents of the file.

## EXAMPLES

### Example 1: Download a file from a folder
```
PS C:\>Get-AzureStorageFileContent -ShareName "ContosoShare06" -Path "ContosoWorkingFolder/CurrentDataFile"
```

This command downloads a file that is named CurrentDataFile in the folder ContosoWorkingFolder from the file share ContosoShare06 to current folder.

### Example 2: Downloads the files under sample file share
```
PS C:\>Get-AzureStorageFile -ShareName sample | ? {$_.GetType().Name -eq "CloudFile"} | Get-AzureStorageFileContent
```

This example downloads the files under sample file share

## PARAMETERS

### -CheckMd5
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientTimeoutPerRequest
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: IStorageContext
Parameter Sets: ShareName
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Destination
Specifies the destination path.
This cmdlet downloads the file contents to the location that this parameter specifies.

If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Directory
Specifies a folder as a **CloudFileDirectory** object.
This cmdlet gets content for a file in the folder that this parameter specifies.
To obtain a directory, use the New-AzureStorageDirectory cmdlet.
You can also use the Get-AzureStorageFile cmdlet to obtain a directory.

```yaml
Type: CloudFileDirectory
Parameter Sets: Directory
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -File
Specifies a file as a **CloudFile** object.
This cmdlet gets the file that this parameter specifies.
To obtain a **CloudFile** object, use the Get-AzureStorageFile cmdlet.

```yaml
Type: CloudFile
Parameter Sets: File
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Force
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specifies the path of a file.
This cmdlet gets the contents the file that this parameter specifies.
If the file does not exist, this cmdlet returns an error.

```yaml
Type: String
Parameter Sets: ShareName, Share, Directory
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerTimeoutPerRequest
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.

If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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

### -Share
Specifies a **CloudFileShare** object.
This cmdlet downloads the contents of the file in the share this parameter specifies.
To obtain a **CloudFileShare** object, use the Get-AzureStorageShare cmdlet.
This object contains the storage context.
If you specify this parameter, do not specify the *Context* parameter.

```yaml
Type: CloudFileShare
Parameter Sets: Share
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ShareName
Specifies the name of the file share.
This cmdlet downloads the contents of the file in the share this parameter specifies.

```yaml
Type: String
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### IStorageContext

Parameter 'Context' accepts value of type 'IStorageContext' from the pipeline

### CloudFileDirectory

Parameter 'Directory' accepts value of type 'CloudFileDirectory' from the pipeline

### CloudFile

Parameter 'File' accepts value of type 'CloudFile' from the pipeline

### CloudFileShare

Parameter 'Share' accepts value of type 'CloudFileShare' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureStorageFile](./Get-AzureStorageFile.md)

[Set-AzureStorageFileContent](./Set-AzureStorageFileContent.md)


