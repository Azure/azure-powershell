---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
ms.assetid: 6420CBE1-BF9D-493D-BCA8-E8C6688FAF3B
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstoragefilecontent
schema: 2.0.0
---

# Get-AzStorageFileContent

## SYNOPSIS
Downloads the contents of a file.

## SYNTAX

### ShareName (Default)
```
Get-AzStorageFileContent [-ShareName] <String> [-Path] <String> [[-Destination] <String>] [-CheckMd5]
 [-PassThru] [-Force] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Share
```
Get-AzStorageFileContent [-Share] <CloudFileShare> [-Path] <String> [[-Destination] <String>] [-CheckMd5]
 [-PassThru] [-Force] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Directory
```
Get-AzStorageFileContent [-Directory] <CloudFileDirectory> [-Path] <String> [[-Destination] <String>]
 [-CheckMd5] [-PassThru] [-Force] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### File
```
Get-AzStorageFileContent [-File] <CloudFile> [[-Destination] <String>] [-CheckMd5] [-PassThru] [-Force]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageFileContent** cmdlet downloads the contents of a file, and then saves it to a destination that you specify.
This cmdlet does not return the contents of the file.

## EXAMPLES

### Example 1: Download a file from a folder
```
PS C:\>Get-AzStorageFileContent -ShareName "ContosoShare06" -Path "ContosoWorkingFolder/CurrentDataFile"
```

This command downloads a file that is named CurrentDataFile in the folder ContosoWorkingFolder from the file share ContosoShare06 to current folder.

### Example 2: Downloads the files under sample file share
```
PS C:\>Get-AzStorageFile -ShareName sample | ? {$_.GetType().Name -eq "CloudFile"} | Get-AzStorageFileContent
```

This example downloads the files under sample file share

## PARAMETERS

### -CheckMd5
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.
If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.
If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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

### -ConcurrentTaskCount
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.
If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.
If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: ShareName
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

### -Destination
Specifies the destination path.
This cmdlet downloads the file contents to the location that this parameter specifies.
If you specify the path of a file that does not exist, this cmdlet creates that file, and saves the contents in the new file.
If you specify a path of a file that already exists and you specify the *Force* parameter, the cmdlet overwrites the file.
If you specify a path of an existing file and you do not specify *Force*, the cmdlet prompts you before it continues.
If you specify the path of a folder, this cmdlet attempts to create a file that has the name of the Azure storage file.

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

### -Directory
Specifies a folder as a **CloudFileDirectory** object.
This cmdlet gets content for a file in the folder that this parameter specifies.
To obtain a directory, use the New-AzStorageDirectory cmdlet.
You can also use the Get-AzStorageFile cmdlet to obtain a directory.

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFileDirectory
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
To obtain a **CloudFile** object, use the Get-AzStorageFile cmdlet.

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFile
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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
Type: System.String
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
Type: System.Nullable`1[System.Int32]
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
To obtain a **CloudFileShare** object, use the Get-AzStorageShare cmdlet.
This object contains the storage context.
If you specify this parameter, do not specify the *Context* parameter.

```yaml
Type: Microsoft.WindowsAzure.Storage.File.CloudFileShare
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.WindowsAz.Storage.File.CloudFileShare
Parameters: Share (ByValue)

### Microsoft.WindowsAz.Storage.File.CloudFileDirectory
Parameters: Directory (ByValue)

### Microsoft.WindowsAz.Storage.File.CloudFile
Parameters: File (ByValue)

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAz.Storage.File.CloudFile

## NOTES

## RELATED LINKS

[Get-AzStorageFile](./Get-AzStorageFile.md)

[Set-AzStorageFileContent](./Set-AzStorageFileContent.md)


