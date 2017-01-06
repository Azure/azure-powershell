---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: 070DA86E-9EA4-4777-9D53-64B58B4401B8
online version: 
schema: 2.0.0
---

# Import-AzureRmSiteRecoveryVaultSettingsFile

## SYNOPSIS
Imports a Site Recovery vault settings file.

## SYNTAX

```
Import-AzureRmSiteRecoveryVaultSettingsFile [-Path] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Import-AzureRmSiteRecoveryVaultSettingsFile** cmdlet imports an Azure Site Recovery vault settings file to set the vault context for subsequent Site Recovery operations in the current session.

## EXAMPLES

## PARAMETERS

### -Path
Specifies the path of the Site Recovery vault settings file.
This file can be downloaded from the Site Recovery vault portal and stored locally.

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

[Get-AzureRmSiteRecoveryVaultSettingsFile](./Get-AzureRmSiteRecoveryVaultSettingsFile.md)
