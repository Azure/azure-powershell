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
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AccountObject
```
Get-AzStorageLocalUser -StorageAccount <PSStorageAccount> [-UserName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes
----      ---                                          ------------- ------------ --------- -------------- ----------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...]

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

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes SshAuthorizedKeys
----      ---                                          ------------- ------------ --------- -------------- ---------------- -----------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...]      
testuser2 S-1-2-0-0000000000-000000000-0000000000-0002 /dir          True         True      False
```

This command lists all local users in a storage account.

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
