---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version:
schema: 2.0.0
---

# Get-AzNetAppFilesSubvolumeMetadata

## SYNOPSIS
Gets metadata details of an Azure NetApp Files (ANF) subvolume.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesSubvolumeMetadata -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 [-VolumeName <String>] -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesSubvolumeMetadata -Name <String> -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesSubvolumeMetadata -Name <String> -VolumeObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesSubvolumeMetadata** cmdlet gets metadata details of an ANF Subvolume.

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesSubvolumeMetadata -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfSubvolume"
```

```output
ResourceGroupName : myrg
Id                : /subscriptions/69a75bda-882e-44d5-8431-63421204132a/resourceGroups/myrg/providers/Microsoft.NetApp/netAppAccounts/myanfaccount/capacityPools/myanfpool/volumes/myanfvolume/subvolumes/myanfsubvolume
Name              : myanfaccount/myanfpool/myanfvolume/myanfsubvolume
Type              : Microsoft.NetApp/netAppAccounts/capacityPools/volumes/subvolumes
Path              : /subvolumePath
ParentPath        :
Size              : 5
BytesUsed         : 0
Permissions       : 644
CreationTimeStamp : 28/04/2022 15:49:24
AccessedTimeStamp : 28/04/2022 15:49:23
ModifiedTimeStamp : 28/04/2022 15:49:24
ChangedTimeStamp  : 28/04/2022 15:49:24
ProvisioningState : Succeeded
```

The gets details of the MyAnfSubvolume Subvolume metadata.

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
The volume object containing the Subvolume Metadata to return

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
[Get-AzNetAppFilesSubvolume](./Get-AzNetAppFilesSubvolume.md)