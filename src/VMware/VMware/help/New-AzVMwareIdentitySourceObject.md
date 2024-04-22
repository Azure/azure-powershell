---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwareidentitysourceobject
schema: 2.0.0
---

# New-AzVMwareIdentitySourceObject

## SYNOPSIS
Create an in-memory object for IdentitySource.

## SYNTAX

```
New-AzVMwareIdentitySourceObject [-Alias <String>] [-BaseGroupDn <String>] [-BaseUserDn <String>]
 [-Domain <String>] [-Name <String>] [-Password <String>] [-PrimaryServer <String>] [-SecondaryServer <String>]
 [-Ssl <String>] [-Username <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IdentitySource.

## EXAMPLES

### Example 1: Create an in-memory object for IdentitySource
```powershell
New-AzVMwareIdentitySourceObject -Alias test
```

```output
Alias           : test
BaseGroupDn     : 
BaseUserDn      : 
Domain          : 
Name            : 
Password        : 
PrimaryServer   : 
SecondaryServer : 
Ssl             : 
Username        :
```

Create an in-memory object for IdentitySource

## PARAMETERS

### -Alias
The domain's NetBIOS name.

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

### -BaseGroupDn
The base distinguished name for groups.

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

### -BaseUserDn
The base distinguished name for users.

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

### -Domain
The domain's dns name.

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

### -Name
The name of the identity source.

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

### -Password
The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.

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

### -PrimaryServer
Primary server URL.

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

### -SecondaryServer
Secondary server URL.

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

### -Ssl
Protect LDAP communication using SSL certificate (LDAPS).

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

### -Username
The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IdentitySource

## NOTES

## RELATED LINKS
