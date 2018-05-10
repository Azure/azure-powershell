---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/set-content-for-keyvaultprovider
schema: 2.0.0
---

# Set-Content for KeyVault Provider

## SYNOPSIS
Sets the secret value of a KeyVault Secret.

## SYNTAX

### Path (Default)

```
Set-Content [-Value] <Object[]> [-PassThru] [-Path] <String[]> [<CommonParameters>]
```

### LiteralPath

```
Set-Content [-Value] <Object[]> [-PassThru] -LiteralPath <String[]> [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Set-Content** cmdlet takes a SecureString to set the SecretValue of a KeyVault Secret.

Note: This custom cmdlet help file explains how the Set-Content cmdlet works in a KeyVault drive. For information about the Set-Content cmdlet in all drives, type "Get-Help Set-Content -Path $null" or see Set-Content at http://go.microsoft.com/fwlink/?LinkID=113392.

## EXAMPLES

### Example 1: Set the SecretValue of a Secret
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $SecretValue = ConvertTo-SecureSecret -String p@ssw0rd -AsPlainText -Force
PS C:\> Set-Content -Path kv:/vault1/Secrets/secret1 -Value $SecretValue -PassThru

Vault Name   : vault1
Name         : secret1
Version      : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id           : https://vault1.vault.azure.net:443/secrets/secret1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled      : True
Expires      : 
Not Before   : 
Created      : 5/10/2018 6:21:56 PM
Updated      : 5/10/2018 6:21:56 PM
Content Type : 
Tags         : 
```

## PARAMETERS

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

### -Value
Specifies the new content for the item. For KeyVault Provider, this object must be of type SecureString.

```yaml
Type: Object[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Security.SecureString

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret

## NOTES

## RELATED LINKS
