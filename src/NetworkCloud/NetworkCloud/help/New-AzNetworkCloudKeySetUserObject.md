---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudKeySetUserObject
schema: 2.0.0
---

# New-AzNetworkCloudKeySetUserObject

## SYNOPSIS
Create an in-memory object for KeySetUser.

## SYNTAX

```
New-AzNetworkCloudKeySetUserObject -AzureUserName <String> -SshPublicKeyData <String> [-Description <String>]
 [-UserPrincipalName <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeySetUser.

## EXAMPLES

### Example 1: Create an in-memory object for KeySetUser.
```powershell
New-AzNetworkCloudKeySetUserObject -AzureUserName azureUserName -SshPublicKeyData "ssh-rsa-key" -Description "userDescription"
```

```output
AzureUserName Description
------------- -----------
azureUserName userDescription
```

Create an in-memory object for KeySetUser.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.KeySetUser

## NOTES

## RELATED LINKS
