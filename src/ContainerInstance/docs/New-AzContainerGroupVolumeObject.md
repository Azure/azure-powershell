---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerGroupVolumeObject
schema: 2.0.0
---

# New-AzContainerGroupVolumeObject

## SYNOPSIS
Create a in-memory object for Volume

## SYNTAX

```
New-AzContainerGroupVolumeObject -Name <String> [-AzureFileReadOnly] [-AzureFileShareName <String>]
 [-AzureFileStorageAccountKey <SecureString>] [-AzureFileStorageAccountName <String>]
 [-GitRepoDirectoryName <String>] [-GitRepoRepositoryUrl <String>] [-GitRepoRevision <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Volume

## EXAMPLES

### Example 1: Create a Azure File volume
```powershell
PS C:\> New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "******" -AsPlainText -Force)

******

Name
----
myvolume
```

This command creates a Azure File volume.

## PARAMETERS

### -AzureFileReadOnly
The flag indicating whether the Azure File shared mounted as a volume is read-only.

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

### -AzureFileShareName
The name of the Azure File share to be mounted as a volume.

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

### -AzureFileStorageAccountKey
The storage account access key used to access the Azure File share.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileStorageAccountName
The name of the storage account that contains the Azure File share.

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

### -GitRepoDirectoryName
Target directory name.
Must not contain or start with '..'.
If '.' is supplied, the volume directory will be the git repository.
Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.

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

### -GitRepoRepositoryUrl
Repository URL.

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

### -GitRepoRevision
Commit hash for the specified revision.

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
The name of the volume.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Volume

## NOTES

ALIASES

## RELATED LINKS

