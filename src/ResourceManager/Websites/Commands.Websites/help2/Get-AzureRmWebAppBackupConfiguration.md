---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 8337BEA9-4927-4718-83B9-F3F567BE0FBD
online version: 
schema: 2.0.0
---

# Get-AzureRmWebAppBackupConfiguration

## SYNOPSIS

## SYNTAX

### FromResourceName
```
Get-AzureRmWebAppBackupConfiguration [-ResourceGroupName] <String> [-Name] <String> [[-Slot] <String>]
 [<CommonParameters>]
```

### FromWebApp
```
Get-AzureRmWebAppBackupConfiguration [-WebApp] <Site> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmWebAppBackupConfiguration** cmdlet gets the backup configuration of an Azure Web App.

## EXAMPLES

### 1:
```
PS C:\>Get-AzureRmWebAppBackupConfiguration -ResourceGroupName "Default-Web-WestUS" -Name "WebAppStandard"
```

This command gets the backup configuration from the Web App named WebAppStandard that belongs to the resource group Default-Web-WestUS.

## PARAMETERS

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
WebApp Name

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Slot
Slot Name

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WebApp
WebApp Name

```yaml
Type: Site
Parameter Sets: FromWebApp
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

