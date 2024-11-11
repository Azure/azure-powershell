---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.ContainerInstance/new-AzContainerGroupVolumeObject
schema: 2.0.0
---

# New-AzContainerGroupVolumeObject

## SYNOPSIS
Create an in-memory object for Volume.

## SYNTAX

```
New-AzContainerGroupVolumeObject -Name <String> [-AzureFileReadOnly] [-AzureFileShareName <String>]
 [-AzureFileStorageAccountKey <SecureString>] [-AzureFileStorageAccountName <String>]
 [-EmptyDir <IVolumeEmptyDir>] [-GitRepoDirectoryName <String>] [-GitRepoRepositoryUrl <String>]
 [-GitRepoRevision <String>] [-Secret <ISecretVolume>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Volume.

## EXAMPLES

### Example 1: Create a Azure File volume
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey $pwd
```

```output
Name
----
myvolume
```

This command creates a Azure File volume.

### Example 2: Create an empty directory volume
```powershell
New-AzContainerGroupVolumeObject -Name "emptyvolume" -EmptyDir @{} | Format-List
```

```output
AzureFileReadOnly           : 
AzureFileShareName          : 
AzureFileStorageAccountKey  : 
AzureFileStorageAccountName : 
EmptyDir                    : {
                              }
GitRepoDirectory            : 
GitRepoRepository           : 
GitRepoRevision             : 
Name                        : emptyvolume
Secret                      : {
                              }
```

This command creates an empty directory volume.

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

### -EmptyDir
The empty directory volume.
To construct, see NOTES section for EMPTYDIR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IVolumeEmptyDir
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

### -Secret
The secret volume.
To construct, see NOTES section for SECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.ISecretVolume
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Volume

## NOTES

## RELATED LINKS
