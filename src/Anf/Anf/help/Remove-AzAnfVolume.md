---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Anf.dll-Help.xml
Module Name: Az.anf
online version:
schema: 2.0.0
---

# Remove-AzAnfVolume

## SYNOPSIS
Deletes an Azure NetApp Files (ANF) volume.

## SYNTAX

### ByFieldsParameterSet
```
Remove-AzAnfVolume -ResourceGroupName <String> -AccountName <String> -PoolName <String> -VolumeName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResouceIdParameterSet
```
Remove-AzAnfVolume -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzAnfVolume** cmdlet deletes an ANF volume.

## EXAMPLES

### Example 1: Delete an ANF volume
```
PS C:\>Remove-AzAnfVolume -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume"
```

This command deletes the ANF volume "MyAnfVolume".

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF pool

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF volume

```yaml
Type: String
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
Type: String
Parameter Sets: ByResouceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeName
The name of the ANF volume

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Anf.Models.PSAnfVolume

## NOTES

## RELATED LINKS
