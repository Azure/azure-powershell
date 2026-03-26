---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefilesymboliclink
schema: 2.0.0
---

# Get-AzStorageFileSymbolicLink

## SYNOPSIS
Gets the properties of a symbolic link. Only works in NFS file share.

## SYNTAX

### ShareName (Default)
```
Get-AzStorageFileSymbolicLink [-ShareName] <String> [-Path] <String> [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [<CommonParameters>]
```

### Share
```
Get-AzStorageFileSymbolicLink [-ShareClient] <ShareClient> [-Path] <String> [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [<CommonParameters>]
```

### Directory
```
Get-AzStorageFileSymbolicLink [-ShareDirectoryClient] <ShareDirectoryClient> [-Path] <String>
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageFileSymbolicLink** cmdlet retrieves the properties and target path of a symbolic link in an Azure File share. This cmdlet only works with NFS file shares.

## EXAMPLES

### Example 1: Get symbolic link properties using share name
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
$link = Get-AzStorageFileSymbolicLink -ShareName "nfsshare" -Path "linkdir/mylink" -Context $ctx
$link
$link.FileProperties
$link.FileProperties.PosixProperties
$link.ShareFileSymbolicLinkInfo
```

```output
AccountName: myaccount, ShareName: nfsshare

Type Length Name   Path        
---- ------ ----   ----        
File      0 mylink linkdir/mylink

LastModified          : 9/17/2025 8:36:43 AM +00:00
Metadata              : {}
ContentLength         : 13
ContentType           : application/octet-stream
ETag                  : "0x8DDF5C554DCC708"
ContentHash           : 
ContentEncoding       : 
CacheControl          : 
ContentDisposition    : 
ContentLanguage       : 
CopyCompletedOn       : 1/1/0001 12:00:00 AM +00:00
CopyStatusDescription : 
CopyId                : 
CopyProgress          : 
CopySource            : 
CopyStatus            : Pending
IsServerEncrypted     : True
SmbProperties         : Azure.Storage.Files.Shares.Models.FileSmbProperties
LeaseDuration         : Infinite
LeaseState            : Available
LeaseStatus           : Unlocked
PosixProperties       : Azure.Storage.Files.Shares.Models.FilePosixProperties


FileMode  : rwxrwxrwx
Owner     : 0
Group     : 0
FileType  : SymLink
LinkCount : 1


ETag         : "0x8DDF5C554DCC708"
LastModified : 9/17/2025 8:36:43 AM +00:00
LinkText     : app%2Fmain.exe
```

This command gets the properties of a symbolic link named "mylink" in the "links" directory of the NFS file share "nfsshare".

### Example 2: Get multiple symbolic links in a directory
```powershell
$files = Get-AzStorageFile -ShareName "nfsshare" -Path "linkdir" -Context $ctx | Get-AzStorageFile -ExcludeExtendedInfo
$symLinkFiles = $files | Where-Object {$_.FileProperties.PosixProperties.FileType.ToString() -eq "SymLink"}
foreach ($file in $symLinkFiles) {
    $symlink = Get-AzStorageFileSymbolicLink -ShareName "nfsshare"  -Path "linkdir/$($file.Name)" -Context $ctx
    Write-Output "$($file.Name) -> $([System.Web.HttpUtility]::UrlDecode($symlink.ShareFileSymbolicLinkInfo.LinkText))"
}
```

This command first lists all files in "linkdir" directory , then filter out all files which are symbolic link, finally gets symbolic link properties for each file.

### Example 3: Get symbolic link using ShareClient pipeline
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
$shareClient = Get-AzStorageShare -Name "nfsshare" -Context $ctx
$link = $shareClient | Get-AzStorageFileSymbolicLink -Path "linkdir/mylink"
```

This command gets a symbolic link using a ShareClient object obtained from Get-AzStorageShare, demonstrating the pipeline usage with the Share parameter set.

### Example 4: Get symbolic link using ShareDirectoryClient pipeline
```powershell
$ctx = New-AzStorageContext -StorageAccountName "myaccount" -EnableFileBackupRequestIntent
$dirClient = Get-AzStorageFile -ShareName "nfsshare" -Path "linkdir" -Context $ctx
$link = $dirClient | Get-AzStorageFileSymbolicLink -Path "mylink"
```

This command gets a symbolic link within a specific directory using a ShareDirectoryClient object, demonstrating the pipeline usage with the Directory parameter set.

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

### -Path
Path of the symbolic link file to retrieve.

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
ShareClient object indicating the share containing the symbolic link.

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
ShareDirectoryClient object indicating the base folder containing the symbolic link.

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
Name of the file share containing the symbolic link.

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
- The returned object contains the symbolic link properties including the target path (LinkText)
- Use the FileProperties.LinkText property to access the target path of the symbolic link
- The FileProperties.IsSymbolicLink property can be used to verify the file is indeed a symbolic link

## RELATED LINKS

[New-AzStorageFileSymbolicLink](./New-AzStorageFileSymbolicLink.md)

[Get-AzStorageFile](./Get-AzStorageFile.md)

[New-AzStorageFileHardLink](./New-AzStorageFileHardLink.md)
