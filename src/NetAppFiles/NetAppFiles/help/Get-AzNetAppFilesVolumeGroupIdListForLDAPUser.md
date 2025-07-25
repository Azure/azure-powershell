---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesvolumegroupidlistforldapuser
schema: 2.0.0
---

# Get-AzNetAppFilesVolumeGroupIdListForLDAPUser

## SYNOPSIS
Get Group Id List for LDAP User

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -ResourceGroupName <String> -AccountName <String>
 -PoolName <String> -Name <String> -Username <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -Name <String> -PoolObject <PSNetAppFilesPool>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -InputObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Returns the list of group Ids for a specific LDAP User

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesVolumeGroupIdListForLDAPUser -ResourceGroupName "MyRG" -AccountName "MyAccount" -PoolName "MyPool" -VolumeName "MyVolume" -Username "UserName"
```

This command returns the resets the GroupIds for the volume MyVolume and user UserName

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The volume object to get to return LDAPUser GroupIdList for

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: VolumeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF pool

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolObject
The pool object containing the volume to return LDAPUser GroupIdList for

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Username
Username is required to fetch the group to which user is part of

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeBackupStatus

## NOTES

## RELATED LINKS
