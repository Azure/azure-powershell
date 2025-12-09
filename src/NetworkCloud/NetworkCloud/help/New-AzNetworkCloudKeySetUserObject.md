---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudkeysetuserobject
schema: 2.0.0
---

# New-AzNetworkCloudKeySetUserObject

## SYNOPSIS
Create an in-memory object for KeySetUser.

## SYNTAX

```
New-AzNetworkCloudKeySetUserObject -AzureUserName <String> -SshPublicKeyData <String> [-Description <String>]
 [-UserPrincipalName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeySetUser.

## EXAMPLES

### Example 1: Create keyset user with SSH public key
```powershell
New-AzNetworkCloudKeySetUserObject -AzureUserName "user1" -SshPublicKeyData "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC..." -Description "User for cluster access"
```

```output
AzureUserName      : user1
Description        : User for cluster access
SshPublicKeyData   : ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC...
UserPrincipalName  : 
```

This example creates a keyset user with SSH public key authentication and a description.

### Example 2: Create keyset user with user principal name
```powershell
New-AzNetworkCloudKeySetUserObject -AzureUserName "user2" -SshPublicKeyData "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC..." -UserPrincipalName "user2@contoso.com"
```

```output
AzureUserName      : user2
Description        : 
SshPublicKeyData   : ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC...
UserPrincipalName  : user2@contoso.com
```

This example creates a keyset user with Azure user name and associated user principal name for group membership validation.

## PARAMETERS

### -AzureUserName
The user name that will be used for access.

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

### -Description
The free-form description for this user.

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

### -SshPublicKeyData
The SSH public key data.

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

### -UserPrincipalName
The user principal name (email format) used to validate this user's group membership.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.KeySetUser

## NOTES

## RELATED LINKS
