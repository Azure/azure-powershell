---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewAzureKeyVaultObject
schema: 2.0.0
---

# New-AzPurviewAzureKeyVaultObject

## SYNOPSIS
Create an in-memory object for AzureKeyVault.

## SYNTAX

```
New-AzPurviewAzureKeyVaultObject [-BaseUrl <String>] [-Description <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureKeyVault.

## EXAMPLES

### Example 1: Create a key vault connection object
```powershell
New-AzPurviewAzureKeyVaultObject -BaseUrl 'https://datascankv.vault.azure.net/' -Description 'This is a key vault'
```

```output
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                :
Name              :
```

Create a key vault connection object.

## PARAMETERS

### -BaseUrl

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureKeyVault

## NOTES

## RELATED LINKS
