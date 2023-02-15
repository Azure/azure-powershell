---
external help file:
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudConfigurationServiceGitRepositoryObject
schema: 2.0.0
---

# New-AzSpringCloudConfigurationServiceGitRepositoryObject

## SYNOPSIS
Create an in-memory object for ConfigurationServiceGitRepository.

## SYNTAX

```
New-AzSpringCloudConfigurationServiceGitRepositoryObject -Label <String> -Name <String> -Pattern <String[]>
 -Uri <String> [-HostKey <String>] [-HostKeyAlgorithm <String>] [-Password <String>] [-PrivateKey <String>]
 [-SearchPath <String[]>] [-StrictHostKeyChecking <Boolean>] [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ConfigurationServiceGitRepository.

## EXAMPLES

### Example 1: Create an in-memory object for ConfigurationServiceGitRepository
```powershell
New-AzSpringCloudConfigurationServiceGitRepositoryObject -Name fake -Label master -Uri "https://github.com/fake-user/fake-repository" -Pattern "app/dev" -debug
```

```output
HostKey HostKeyAlgorithm Label  Name Password Pattern   PrivateKey SearchPath StrictHostKeyChecking Uri
------- ---------------- -----  ---- -------- -------   ---------- ---------- --------------------- ---
                         master fake          {app/dev}                                             https://github.com…
```

Create an in-memory object for ConfigurationServiceGitRepository.

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

Required: True
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
Collection of patterns of the repository.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ConfigurationServiceGitRepository

## NOTES

ALIASES

## RELATED LINKS

