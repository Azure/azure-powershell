---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 86D8965D-D999-48A4-A4EE-9E054E5486EE
online version: 
schema: 2.0.0
---

# New-AzureRmADUser

## SYNOPSIS
Creates a new active directory user.

## SYNTAX

```
New-AzureRmADUser -DisplayName <String> -UserPrincipalName <String> -Password <String> [-ImmutableId <String>]
 [-ForceChangePasswordNextLogin] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new active directory user (work/school account also popularly known as org-id).
For more information: https://msdn.microsoft.com/en-us/library/azure/ad/graph/api/users-operations#CreateUser

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DisplayName
The name to display in the address book for the user.
example 'Alex Wu'.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ForceChangePasswordNextLogin
It must be specified if the user must change the password on the next successful login (true).
Default behavior is (false) to not change the password on the next successful login.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ImmutableId
It needs to be specified only if you are using a federated domain for the user's user principal name (upn) property.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Password
Password for the user.
It must meet the tenant's password complexity requirements.
It is recommended to set a strong password.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserPrincipalName
The user principal name.
Example-'someuser@contoso.com'.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmADUser](./Get-AzureRmADUser.md)

[Set-AzureRmADUser](./Set-AzureRmADUser.md)

[Remove-AzureRmADUser](./Remove-AzureRmADUser.md)
