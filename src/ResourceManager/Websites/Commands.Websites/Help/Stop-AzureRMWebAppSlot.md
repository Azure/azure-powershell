---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 86E0D477-DD32-49BD-82E7-1CF191E4F612
online version: 
schema: 2.0.0
---

# Stop-AzureRmWebAppSlot

## SYNOPSIS
Stops an Azure Web App slot.

## SYNTAX

### S1
```
Stop-AzureRmWebAppSlot [-ResourceGroupName] <String> [-Name] <String> [-Slot] <String> [<CommonParameters>]
```

### S2
```
Stop-AzureRmWebAppSlot [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmWebAppSlot** cmdlet stops an Azure Web App slot.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -ResourceGroupName
Specifies the name of the resource group that the slot is assigned to.

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
Specifies the name of the Web App slot.

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

### -Slot
Specifies the Web App slot.
To get a Web App slot, use the Get-AzureRMWebAppSlot cmdlet.

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
Specifies a Web App.
To get a Web App, use the Get-AzureRmWebApp cmdlet.

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

[Get-AzureRMWebAppSlot](./Get-AzureRMWebAppSlot.md)

[New-AzureRMWebAppSlot](./New-AzureRMWebAppSlot.md)

[Remove-AzureRMWebAppSlot](./Remove-AzureRMWebAppSlot.md)

[Restart-AzureRMWebAppSlot](./Restart-AzureRMWebAppSlot.md)

[Set-AzureRMWebAppSlot](./Set-AzureRMWebAppSlot.md)

[Start-AzureRMWebAppSlot](./Start-AzureRMWebAppSlot.md)

[Get-AzureRmWebApp](./Get-AzureRmWebApp.md)


