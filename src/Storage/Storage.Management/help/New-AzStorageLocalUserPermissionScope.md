---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstoragelocaluserpermissionscope
schema: 2.0.0
---

# New-AzStorageLocalUserPermissionScope

## SYNOPSIS
Creates a permission scope object, which can be used in Set-AzStorageLocalUser.

## SYNTAX

```
New-AzStorageLocalUserPermissionScope -Permission <String> -Service <String> -ResourceName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageLocalUserPermissionScope** cmdlet creates a permission scope object, which can be used in Set-AzStorageLocalUser.

## EXAMPLES

### Example 1: Create permission scope objects, then create or update local user with the permission scope objects.
<!-- Skip: Output cannot be splitted from code -->


```
$permissionScope1 = New-AzStorageLocalUserPermissionScope -Permission rw -Service blob -ResourceName container1 

$permissionScope2 = New-AzStorageLocalUserPermissionScope -Permission rwd -Service file -ResourceName share2

$localuser = Set-AzStorageLocalUser -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -UserName testuser1 -HomeDirectory "/" -PermissionScope $permissionScope1,$permissionScope2

$localuser

   ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name      Sid                                          HomeDirectory HasSharedKey HasSshKey HasSshPassword PermissionScopes SshAuthorizedKeys
----      ---                                          ------------- ------------ --------- -------------- ---------------- -----------------
testuser1 S-1-2-0-0000000000-000000000-0000000000-0000 /                                                   [container1,...]                  

$localuser.PermissionScopes

Permissions Service ResourceName
----------- ------- ------------
rw          blob    container1  
rwd         file    share2
```

This first 2 commands create 2 permission scope objects. 
The following commands create or update a local user with the permission scope objects, then show the updated local user properties.

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

### -Permission
Specify the permissions for the local user. Possible values include: Read(r), Write (w), Delete (d), List (l), and Create (c).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -ResourceName
Specify the name of resource, normally the container name or the file share name, used by the local user.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Service
Specify the service used by the local user, e.g.
blob, file.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSPermissionScope

## NOTES

## RELATED LINKS
