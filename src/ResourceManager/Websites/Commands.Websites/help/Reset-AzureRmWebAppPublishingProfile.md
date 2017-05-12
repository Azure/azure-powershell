---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 84C861B2-DCB3-47F0-8589-BB3172C6E1EC
online version: 
schema: 2.0.0
---

# Reset-AzureRmWebAppPublishingProfile

## SYNOPSIS

## SYNTAX

### S1
```
Reset-AzureRmWebAppPublishingProfile [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

### S2
```
Reset-AzureRmWebAppPublishingProfile [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Reset-AzureRmWebAppPublishingProfile** cmdlet resets the publishing profile for the specified Web App.

## EXAMPLES

### 1:
```
PS C:\> Reset-AzureRmWebAppSlotPublishingProfile -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp"
```

This command resets the publishing profile for the Web App ContosoWebApp associated with the resource group Default-Web-WestUS.

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

## OUTPUTS

## NOTES

## RELATED LINKS

