---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 297071E5-FC06-4493-BCC2-37D4929E4025
online version: 
schema: 2.0.0
---

# Restart-AzureRmWebApp

## SYNOPSIS
Restarts an Azure Web App.

## SYNTAX

### S1
```
Restart-AzureRmWebApp [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

### S2
```
Restart-AzureRmWebApp [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Restart-AzureRmWebApp** cmdlet stops and then starts an Azure Web App.
If the Web App is in a stopped state, use the Start-AzureRmWebApp cmdlet.

## EXAMPLES

### Example 1: Restart a Web App
```
PS C:\>Restart-AzureRmWebApp -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite"
```

This command stops the Azure Web App named ContosoSite that belongs to the resource group named Default-Web-WestUS and then restarts it.

## PARAMETERS

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

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmWebApp](./Get-AzureRmWebApp.md)

[New-AzureRmWebApp](./New-AzureRmWebApp.md)

[Remove-AzureRmWebApp](./Remove-AzureRmWebApp.md)

[Start-AzureRmWebApp](./Start-AzureRmWebApp.md)

[Stop-AzureRmWebApp](./Stop-AzureRmWebApp.md)


