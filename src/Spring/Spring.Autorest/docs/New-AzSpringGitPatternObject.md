---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringgitpatternobject
schema: 2.0.0
---

# New-AzSpringGitPatternObject

## SYNOPSIS
Create an in-memory object for GitPatternRepository.

## SYNTAX

```
New-AzSpringGitPatternObject -Name <String> -Uri <String> [-HostKey <String>] [-HostKeyAlgorithm <String>]
 [-Label <String>] [-Password <String>] [-Pattern <String[]>] [-PrivateKey <String>] [-SearchPath <String[]>]
 [-StrictHostKeyChecking <Boolean>] [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GitPatternRepository.

## EXAMPLES

### Example 1: Create an in-memory object for GitPatternRepository.
```powershell
New-AzSpringGitPatternObject -Name "gitPatternName" -Uri "uriString" -HostKey "hostKeyString" -HostKeyAlgorithm "hostKeyAlgorithmString" -Label "labelString" -Password "password" -Pattern "patternString" -PrivateKey "privateKeyString" -SearchPath "searchPathString" -StrictHostKeyChecking:$true -Username "xxx"
```

```output
HostKey               : hostKeyString
HostKeyAlgorithm      : hostKeyAlgorithmString
Label                 : labelString
Name                  : gitPatternName
Password              : password
Pattern               : {patternString}
PrivateKey            : privateKeyString
SearchPath            : {searchPathString}
StrictHostKeyChecking : True
Uri                   : uriString
Username              : xxx
```

Create an in-memory object for GitPatternRepository.

## PARAMETERS

### -HostKey
Public sshKey of git repository.

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

### -HostKeyAlgorithm
SshKey algorithm of git repository.

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

### -Label
Label of the repository.

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
Name of the repository.

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

### -Password
Password of git repository basic auth.

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

### -Pattern
Collection of pattern of the repository.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateKey
Private sshKey algorithm of git repository.

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

### -SearchPath
Searching path of the repository.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StrictHostKeyChecking
Strict host key checking or not.

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

### -Uri
URI of the repository.

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

### -Username
Username of git repository basic auth.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.GitPatternRepository

## NOTES

## RELATED LINKS

