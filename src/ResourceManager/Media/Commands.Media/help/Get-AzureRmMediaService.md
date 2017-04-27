---
external help file: Microsoft.Azure.Commands.Media.dll-Help.xml
ms.assetid: 9843D191-CBC4-481A-BD36-D7B2D7917BD9
online version: 
schema: 2.0.0
---

# Get-AzureRmMediaService

## SYNOPSIS
Gets information about a media service.

## SYNTAX

### ResourceGroupParameterSet
```
Get-AzureRmMediaService [-ResourceGroupName] <String> [<CommonParameters>]
```

### AccountNameParameterSet
```
Get-AzureRmMediaService [-ResourceGroupName] <String> [-AccountName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmMediaService** cmdlet gets information about a media service.

## EXAMPLES

### Example 1: Get all media services in a resource group
```
PS C:\>Get-AzureRmMediaService -ResourceGroupName "ResourceGroup001"
```

This command gets properties for all media services in the resource group named ResourceGroup001.

### Example 2: Get media service properties
```
PS C:\>Get-AzureRmMediaService -ResourceGroupName "ResourceGroup002" -AccountName "MediaService1"
```

This command gets the properties of the media service named MediaService1 that belongs to the resource group named ResourceGroup002.

## PARAMETERS

### -AccountName
Specifies the name of the media service that this cmdlet gets.

```yaml
Type: String
Parameter Sets: AccountNameParameterSet
Aliases: Name, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the media service.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[New-AzureRmMediaService](./New-AzureRmMediaService.md)

[Remove-AzureRmMediaService](./Remove-AzureRmMediaService.md)

[Set-AzureRmMediaService](./Set-AzureRmMediaService.md)


