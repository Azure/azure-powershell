---
external help file: Microsoft.Azure.Commands.ServerManagement.dll-Help.xml
ms.assetid: 06081209-BBE5-4F76-86F8-9CF6197938F8
online version: 
schema: 2.0.0
---

# Install-AzureRmServerManagementGatewayProfile

## SYNOPSIS
Installs a Server Management Gateway profile.

## SYNTAX

```
Install-AzureRmServerManagementGatewayProfile [[-InputFile] <FileInfo>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Install-AzureRmServerManagementGatewayProfile** cmdlet installs an Azure Server Management Gateway profile into the correct location.
The file that this cmdlet installs is named profile.json.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -InputFile
Specifies the name of the local file that contains the gateway profile to install.

The file that this cmdlet installs should have been previously saved with the Save-AzureRmServerManagementGatewayProfile cmdlet.

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Reset-AzureRmServerManagementGatewayProfile](./Reset-AzureRmServerManagementGatewayProfile.md)

[Save-AzureRmServerManagementGatewayProfile](./Save-AzureRmServerManagementGatewayProfile.md)


