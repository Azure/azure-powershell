---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/set-azstorageaccountlocaluser
schema: 2.0.0
---

# Set-AzStorageAccountLocalUser

## SYNOPSIS
Creates or updates a specified local user in a storage account.

## SYNTAX

### AccountName (Default)
```
Set-AzStorageAccountLocalUser [-ResourceGroupName] <String> [-StorageAccountName] <String> -UserName <String>
 [-HomeDirectory <String>] [-SshAuthorizedKey <PSSshPublicKey[]>] [-PermissionScope <PSPermissionScope[]>]
 [-HasSharedKey <Boolean>] [-HasSshKey <Boolean>] [-HasSshPassword <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountObject
```
Set-AzStorageAccountLocalUser -StorageAccount <PSStorageAccount> -UserName <String> [-HomeDirectory <String>]
 [-SshAuthorizedKey <PSSshPublicKey[]>] [-PermissionScope <PSPermissionScope[]>] [-HasSharedKey <Boolean>]
 [-HasSshKey <Boolean>] [-HasSshPassword <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzStorageAccountLocalUser** cmdlet creates or updates a specified local user in a storage account.
To run this cmdlet, the storage account must has already set EnableLocalUser as true.

## EXAMPLES

### Example 1: Create or update a local user
```
PS C:\> $sshkey1 = New-AzStorageAccountLocalUserSshPublicKey -Key "ssh-rsa keykeykeykeykey=" -Description "sshpulickey name1"

PS C:\> $permissionScope1 = New-AzStorageAccountLocalUserPermissionScope -Permission rw -Service blob -ResourceName container1 

PS C:\> $localuser = Set-AzStorageAccountLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -UserName testuser1 -HomeDirectory "/" -SshAuthorizedKey $sshkey1 -PermissionScope $permissionScope1 -HasSharedKey $true -HasSshKey $true -HasSshPassword $true

PS C:\> $localuser

   ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes SshAuthorizedKeys             
----      ---                                          ------------- ------------ --------- -------------- ---------------- -----------------             
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1]     [ssh-rsa keykeykeykeykey=]

PS C:\> $localuser.SshAuthorizedKeys 

Description       Key                     
-----------       ---                     
sshpulickey name1 ssh-rsa keykeykeykeykey=

PS C:\> $localuser.PermissionScopes 

Permissions Service ResourceName
----------- ------- ------------
rw          blob    container1
```

The first 2 commands create 2 local objects that will be used in create or update local user. 
The third command creates or updates the local user. 
The following commands show the local user properties.

### Example 2: Create or update a local user by input permission scope and ssh key with json
```
PS C:\> Set-AzStorageAccountLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -UserName testuser1 -HomeDirectory "/" -HasSharedKey $true -HasSshKey $true -HasSshPassword $true `
            -SshAuthorizedKey (@{
                Description="sshpulickey name1";
                Key="ssh-rsa keykeykeykeykey=";                
            },
            @{
                Description="sshpulickey name2";
                Key="ssh-rsa keykeykeykeykew="; 
            }) `
            -PermissionScope (@{
                Permissions="rw";
                Service="blob"; 
                ResourceName="container1";                
            },
            @{
                Permissions="rwd";
                Service="share"; 
                ResourceName="share1";
            })


   ResourceGroupName: weitry, StorageAccountName: weisftp3

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes SshAuthorizedKeys             
----      ---                                          ------------- ------------ --------- -------------- ---------------- -----------------             
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /             True         True      True           [container1,...] [ssh-rsa keykeykeykeykey=,...]
```

This command creates or updates a local user by input permission scope and ssh key with json.

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

### -HasSharedKey
Whether shared key exists.
Set it to false to remove existing shared key.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasSshKey
Whether SSH key exists.
Set it to false to remove existing SSH key.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HasSshPassword
Whether SSH password exists.
Set it to false to remove existing SSH password.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HomeDirectory
Local user home directory

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

### -PermissionScope
The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSPermissionScope[]
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

### -SshAuthorizedKey
The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSSshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSLocalUser

## NOTES

## RELATED LINKS
