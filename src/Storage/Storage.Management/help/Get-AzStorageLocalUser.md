---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragelocaluser
schema: 2.0.0
---

# Get-AzStorageLocalUser

## SYNOPSIS
Gets a specified local user or lists all local users in a storage account.

## SYNTAX

### AccountName (Default)
```
Get-AzStorageLocalUser [-ResourceGroupName] <String> [-StorageAccountName] <String> [-UserName <String>]
 [-MaxPageSize <Int32>] [-Filter <String>] [-IncludeNFSv3] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### AccountObject
```
Get-AzStorageLocalUser -StorageAccount <PSStorageAccount> [-UserName <String>] [-MaxPageSize <Int32>]
 [-Filter <String>] [-IncludeNFSv3] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageLocalUser** cmdlet gets a specified local user or lists all local users in a storage account.

## EXAMPLES

### Example 1: Get a specified local user
<!-- Skip: Output cannot be splitted from code -->


```
$localUser = Get-AzStorageLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -UserName testuser1

$localUser 

   ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes UserId GroupId AllowAclAuthorization
----      ---                                          ------------- ------------ --------- -------------- ---------------- ------ ------- ---------------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...] 1000    

$localUser.PermissionScopes
  
Permissions Service ResourceName
----------- ------- ------------
rw          blob    container1  
rw          file    share2
```

This command gets a specified local user, and show the properties of it.

### Example 2: List all local users in a storage account
```powershell
Get-AzStorageLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes UserId GroupId AllowAclAuthorization
----      ---                                          ------------- ------------ --------- -------------- ---------------- ------ ------- ---------------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...] 1000     
testuser2 S-1-2-0-0000000000-000000000-0000000000-0002 /dir          True         True      False                           1001
```

This command lists all local users in a storage account.

### Example 3: List local users with a max page size and filter
```powershell
Get-AzStorageLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -MaxPageSize 3 -Filter "startswith(name, test)"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes UserId GroupId AllowAclAuthorization
----      ---                                          ------------- ------------ --------- -------------- ---------------- ------ ------- ---------------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...] 1000     
testuser2 S-1-2-0-0000000000-000000000-0000000000-0002 /dir          True         True      False                           1001
testuser3 S-1-2-0-0000000000-000000000-0000000000-0003 /             True         True      False                           1001   100     True
```

This command lists local users that names start with "test", with a max page size of 3 included in the list response.

### Example 4: List all nfsv3 local users in a storage account
```powershell
Get-AzStorageLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -IncludeNFSv3
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name        Sid                                           HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes UserId GroupId AllowAclAuthorization
----        ---                                           ------------- ------------ --------- -------------- ---------------- ------ ------- ---------------------
nfsv3_100   S-1-2-0-3080345243-855858100-3794096380-1001  /test         False        False     False                           1001                                
nfsv3_70005 S-1-2-0-1439193041-1066083860-1154209853-1000 /test         False        False     False                           1000
```

This command lists all nfsv3 local users in a storage account.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter of username. When specified, only usernames starting with the filter will be listed. The filter must be in format: startswith(name, <prefix>)

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

### -IncludeNFSv3
Specify to include NFSv3 enabled Local Users in list Local Users.

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

### -MaxPageSize
The maximum number of local users that will be included in the list response

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

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccount
Storage account object

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount
Parameter Sets: AccountObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserName
The name of local user.
The username must contain lowercase letters and numbers only.
It must be unique only within the storage account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSLocalUser

## NOTES

## RELATED LINKS
