---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilessubvolume
schema: 2.0.0
---

# Get-AzNetAppFilesSubvolume

## SYNOPSIS
Gets details of an Azure NetApp Files (ANF) subvolume.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesSubvolume -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 [-VolumeName <String>] [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesSubvolume [-Name <String>] -VolumeObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesSubvolume [-Name <String>] -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesSubvolume** cmdlet gets details of an ANF Subvolume.

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesSubvolume -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfSubvolume"
```

```output
ResourceGroupName : myrg
Id                : /subscriptions/69a75bda-882e-44d5-8431-63421204132a/resourceGroups/myrg/providers/Microsoft.NetApp/netAppAccounts/myanfaccount/capacityPools/myanfpool/volumes/myanfvolume/subvolumes/myanfsubvolume
Name              : myanfaccount/myanfpool/myanfvolume/myanfsubvolume
Type              : Microsoft.NetApp/netAppAccounts/capacityPools/volumes/subvolumes
Etag              :
Path              : /subvolumePath
Size              :
ParentPath        :
ProvisioningState : Succeeded
```

The **Get-AzNetAppFilesSubvolume** cmdlet gets details of an ANF Subvolume.

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

### -Name
The name of the ANF Subvolume

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SubvolumeName

Required: False
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

### -ResourceGroupName
The resource group of the ANF Subvolume

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
The resource id of the ANF Subvolume

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

### -VolumeName
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeObject
The volume object containing the Subvolume to return

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## NOTES

## RELATED LINKS

[New-AzNetAppFilesSubvolume](./New-AzNetAppFilesSubvolume.md)
[Update-AzNetAppFilesSubvolume](./Update-AzNetAppFilesSubvolume.md)
[Remove-AzNetAppFilesSubvolume](./Remove-AzNetAppFilesSubvolume.md)
[Get-AzNetAppFilesSubvolumeMetadata](./Get-AzNetAppFilesSubvolumeMetadata.md)
