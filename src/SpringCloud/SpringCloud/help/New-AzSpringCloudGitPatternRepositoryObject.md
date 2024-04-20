---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/Az.SpringCloud/new-AzSpringCloudGitPatternRepositoryObject
schema: 2.0.0
---

# New-AzSpringCloudGitPatternRepositoryObject

## SYNOPSIS
Create an in-memory object for GitPatternRepository.

## SYNTAX

```
New-AzSpringCloudGitPatternRepositoryObject -Name <String> -Uri <String> [-HostKey <String>]
 [-HostKeyAlgorithm <String>] [-Label <String>] [-Password <String>] [-Pattern <String[]>]
 [-PrivateKey <String>] [-SearchPath <String[]>] [-StrictHostKeyChecking <Boolean>] [-Username <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for GitPatternRepository.

## EXAMPLES

### Example 1: Create an in-memory object for GitPatternRepository
```powershell
New-AzSpringCloudGitPatternRepositoryObject -Name fake -Uri "https://github.com/fake-user/fake-repository"
```

```output
HostKey HostKeyAlgorithm Label Name Password Pattern PrivateKey SearchPath StrictHostKeyChecking Uri
------- ---------------- ----- ---- -------- ------- ---------- ---------- --------------------- ---
                               fake                                                              https://github.com/fa…
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.GitPatternRepository

## NOTES

## RELATED LINKS
