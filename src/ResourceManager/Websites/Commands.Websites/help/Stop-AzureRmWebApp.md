---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: A12FFDB1-9849-4150-9716-068BE6EFC681
online version: 
schema: 2.0.0
---

# Stop-AzureRmWebApp

## SYNOPSIS
Stops an Azure Web App.

## SYNTAX

### S1
```
Stop-AzureRmWebApp [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

### S2
```
Stop-AzureRmWebApp [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmWebApp** cmdlet stops an Azure Web App.

## EXAMPLES

### Example 1: Stop a Web App
```
PS C:\>Stop-AzureRmWebApp -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp"
```

This command stops the Web App named ContosoWebApp that belongs to the resource group named Default-Web-WestUS.

## PARAMETERS

### -Name
WebApp Name

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
WebApp Object

```yaml
Type: Site
Parameter Sets: S2
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Site

Parameter 'WebApp' accepts value of type 'Site' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmWebApp](./Get-AzureRmWebApp.md)

[New-AzureRmWebApp](./New-AzureRmWebApp.md)

[Remove-AzureRmWebApp](./Remove-AzureRmWebApp.md)

[Restart-AzureRmWebApp](./Restart-AzureRmWebApp.md)

[Start-AzureRmWebApp](./Start-AzureRmWebApp.md)


