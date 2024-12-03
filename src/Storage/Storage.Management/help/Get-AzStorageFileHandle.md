---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefilehandle
schema: 2.0.0
---

# Get-AzStorageFileHandle

## SYNOPSIS
Lists file handles of a file share, a file directory or a file.

## SYNTAX

### ShareName (Default)
```
Get-AzStorageFileHandle [-ShareName] <String> [[-Path] <String>] [-Recursive] [-DisAllowTrailingDot]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### Share
```
Get-AzStorageFileHandle [-ShareClient] <ShareClient> [[-Path] <String>] [-Recursive]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### Directory
```
Get-AzStorageFileHandle [-ShareDirectoryClient] <ShareDirectoryClient> [[-Path] <String>] [-Recursive]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

### File
```
Get-AzStorageFileHandle [-ShareFileClient <ShareFileClient>] [-Recursive] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [-IncludeTotalCount] [-Skip <UInt64>] [-First <UInt64>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageFileHandle** cmdlet lists file handles of a  file share, or file directory or a file.

## EXAMPLES

### Example 1: List all file handles on a file share recursively, and sort by ClientIp and OpenTime
```powershell
Get-AzStorageFileHandle -ShareName "mysharename" -Recursive | Sort-Object ClientIP,OpenTime
```

```output
HandleId    Path                  ClientIp       ClientPort OpenTime             LastReconnectTime FileId               ParentId SessionId           ClientName        
--------    ----                  --------       ---------- --------             ----------------- ------               -------- ---------           ----------
28506980357                       104.46.105.229 49805      2019-07-29 08:37:36Z                   0                    0        9297571480349046273 myclientvm
28506980537 dir1                  104.46.105.229 49805      2019-07-30 09:28:48Z                   10376363910205800448 0        9297571480349046273 myclientvm
28506980538 dir1                  104.46.105.229 49805      2019-07-30 09:28:48Z                   10376363910205800448 0        9297571480349046273 myclientvm
28582543365                       104.46.119.170 51675      2019-07-30 09:29:32Z                   0                    0        9477733061320772929 myclientvm
28582543375 dir1                  104.46.119.170 51675      2019-07-30 09:29:38Z                   10376363910205800448 0        9477733061320772929 myclientvm
28582543376 dir1                  104.46.119.170 51675      2019-07-30 09:29:38Z                   10376363910205800448 0        9477733061320772929 myclientvm
```

This command lists file handles on a file share, and sort the output by ClientIp, then by OpenTime.

### Example 2: List first 2 file handles on a file directory recursively
```powershell
Get-AzStorageFileHandle -ShareName "mysharename" -Path 'dir1/dir2'  -Recursive -First 2
```

```output
HandleId    Path      ClientIp       ClientPort OpenTime             LastReconnectTime FileId               ParentId             SessionId           ClientName 
--------    ----      --------       ---------- --------             ----------------- ------               --------             ---------           ----------
24057151779 dir1/dir2 104.46.105.229 50861      2019-06-18 07:39:23Z                   16140971433240035328 11529285414812647424 9549812641162070049 myclientvm
24057151780 dir1/dir2 104.46.105.229 50861      2019-06-18 07:39:23Z                   16140971433240035328 11529285414812647424 9549812641162070049 myclientvm
```

This command lists first 2 file handles on a file directory recursively .

### Example 3: List the 3rd to the 6th file handles on a file
```powershell
Get-AzStorageFileHandle -ShareName "mysharename" -Path 'dir1/dir2/test.txt' -skip 2 -First 4
```

```output
HandleId    Path               ClientIp       ClientPort OpenTime             LastReconnectTime FileId              ParentId             SessionId           ClientName
--------    ----               --------       ---------- --------             ----------------- ------              --------             ---------           ---------- 
24055513248 dir1/dir2/test.txt 104.46.105.229 49817      2019-06-18 08:21:59Z                   9223407221226864640 16140971433240035328 9338416139169958321 myclientvm
24055513249 dir1/dir2/test.txt 104.46.105.229 49817      2019-06-18 08:21:59Z                   9223407221226864640 16140971433240035328 9338416139169958321 myclientvm
24055513252 dir1/dir2/test.txt 104.46.105.229 49964      2019-06-18 08:22:54Z                   9223407221226864640 16140971433240035328 9338416138431762125 myclientvm
24055513253 dir1/dir2/test.txt 104.46.105.229 49964      2019-06-18 08:22:54Z                   9223407221226864640 16140971433240035328 9338416138431762125 myclientvm
```

This command lists the 3rd to the 6th file handles on a file.

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

### -DisAllowTrailingDot
Disallow trailing dot (.) to suffix directory and file names.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ShareName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Path to an existing file/directory.

```yaml
Type: System.String
Parameter Sets: ShareName, Share, Directory
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Recursive
List handles Recursively.
Only works on File Directory.

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

### -ShareClient
ShareClient object indicated the share where the files/directories would list File Handles

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
ShareDirectoryClient object indicated the base folder where the files/directories would list File Handles

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

### -ShareFileClient
ShareFileClient object indicated the file to list File Handles.

```yaml
Type: Azure.Storage.Files.Shares.ShareFileClient
Parameter Sets: File
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ShareName
Name of the file share where the files/directories would be listed.

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

### -IncludeTotalCount
Reports the number of objects in the data set (an integer) followed by the objects. If the cmdlet cannot determine the total count, it returns 'Unknown total count'.
Currently, this parameter does nothing.

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

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

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

### Azure.Storage.Files.Shares.ShareFileClient

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel.PSFileHandle

## NOTES

## RELATED LINKS
