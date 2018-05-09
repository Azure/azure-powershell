---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/remove-item-for-keyvaultprovider
schema: 2.0.0
---

# Remove-Item for KeyVault Provider

## SYNOPSIS
Deletes KeyVault Vaults, Secrets, Certificates, and Keys.

## SYNTAX

### Path (Default)
```
Remove-Item [-Path] <String[]> [-Recurse] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LiteralPath
```
Remove-Item -LiteralPath <String[]> [-Recurse] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Remove-Item** cmdlet deletes KeyVault types specified by the path.  These types are: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

Note: This custom cmdlet help file explains how the Remove-Item cmdlet works in a KeyVault drive. For information about the Remove-Item cmdlet in all drives, type "Get-Help Remove-Item -Path $null" or see Remove-Item at http://go.microsoft.com/fwlink/?LinkID=113373.

## EXAMPLES

### Example 1: Remove KeyVault Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1 -Force
```

### Example 2: Remove Secret from Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1/Secrets/secret1 -Force
```

### Example 3: Remove all Secrets from Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1/Secrets/ -Force -Recurse
```

### Example 4: Remove Certificate from Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1/Certificates/cert1 -Force
```

### Example 5: Remove Key from Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1/Keys/key1 -Force
```

### Example 5: Remove AccessPolicy from Vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Remove-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111 -Force
```

## PARAMETERS

### -Force
Bypasses the confirmation prompt for deleting a KeyVault resource.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiteralPath
Specifies a path to the item.
Unlike the *Path* parameter, the value of *LiteralPath* is used exactly as it is typed.
No characters are interpreted as wildcards.
If the path includes escape characters, enclose it in single quotation marks.
Single quotation marks tell Windows PowerShell not to interpret any characters as escape sequences.

```yaml
Type: String[]
Parameter Sets: LiteralPath
Aliases: PSPath

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Path
Specifies the path to an item.
This cmdlet gets the item at the specified location.
Wildcards are permitted.
This parameter is required, but the parameter name ("Path") is optional.

Use a dot (.) to specify the current location.
Use the wildcard character (*) to specify all the items in the current location.

```yaml
Type: String[]
Parameter Sets: Path
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: True
```

### -Recurse
Indicates that this cmdlet deletes the items in the specified locations and in all child items of the locations.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### None

## NOTES

## RELATED LINKS
