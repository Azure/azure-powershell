---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: EF2D377C-C000-4BCA-8EB9-58C805FA5C31
online version: 
schema: 2.0.0
---

# Get-AzureRmWebAppSlotConfigName

## SYNOPSIS
Get the list of Web App Slot Config names

## SYNTAX

### S1
```
Get-AzureRmWebAppSlotConfigName [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

### S2
```
Get-AzureRmWebAppSlotConfigName [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmWebAppSlotConfigName** cmdlet retrieves the list of App Setting and Connection String names that are currently marked as slot settings

## EXAMPLES

### 1:
```
PS C:\>Get-AzureRmWebAppSlotConfigName -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite"
```

This command gets App Settings and Connection strings pertaining to the Web App named ContosoSite associated with the resource group Default-Web-WestUS

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

