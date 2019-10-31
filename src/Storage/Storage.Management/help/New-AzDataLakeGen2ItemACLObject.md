---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azdatalakegen2itemaclobject
schema: 2.0.0
---

# New-AzDataLakeGen2ItemAclObject

## SYNOPSIS
Creates a DataLake gen2 item ACL object, which can be used in Update-AzDataLakeGen2Item cmdlet.

## SYNTAX

```
New-AzDataLakeGen2ItemAclObject [-EntityId <String>] [-DefaultScope] -Permission <String>
 [-InputObject <PSPathAccessControlEntry[]>] -AccessControlType <AccessControlType> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDataLakeGen2ItemAclObject** cmdlet creates a DataLake gen2 item ACL object, which can be used in Update-AzDataLakeGen2Item cmdlet.

## EXAMPLES

### Example 1: Create an ACL object with 3 ACL entry, and update ACL on a Folder
```
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rwx -DefaultScope
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission rw- -InputObject $acl 
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "rw-" -InputObject $acl
PS C:\>Update-AzDataLakeGen2Item -FileSystem "testfilesystem" -Path "dir1/dir2" -ACL $acl

   FileSystem Uri: https://testaccount.blob.core.windows.net/testfilesystem

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/dir2            True                         application/octet-stream       2019-10-30 02:43:09Z rw-rw--wx    $superuser $superuser
```

This command creates an ACL object with 3 acl entry (use -InputObject parameter to add acl entry to existing acl object), and updates ACL on a Folder.

## PARAMETERS

### -AccessControlType
There are four types: "user" grants rights to the owner or a named user, "group" grants rights to the owning group or a named group, "mask" restricts rights granted to named users and the members of groups, and "other" grants rights to all users not found in any of the other entries.

```yaml
Type: Microsoft.Azure.Storage.Blob.AccessControlType
Parameter Sets: (All)
Aliases:
Accepted values: User, Group, Mask, Other

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultScope
Set this parameter to indicate the ACE belongs to the default ACL for a directory; otherwise scope is implicit and the ACE belongs to the access ACL.

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

### -EntityId
The user or group identifier.
It is omitted for entries of AccessControlType "mask" and "other".
The user or group identifier is also omitted for the owner and owning group.

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

### -InputObject
If input the PSPathAccessControlEntry\[\] object, will add the new ACL as a new element of the input PSPathAccessControlEntry\[\] object.

```yaml
Type: Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel.PSPathAccessControlEntry[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Permission
The permission field is a 3-character sequence where the first character is 'r' to grant read access, the second character is 'w' to grant write access, and the third character is 'x' to grant execute permission.
If access is not granted, the '-' character is used to denote that the permission is denied.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel.PSPathAccessControlEntry

## NOTES

## RELATED LINKS
