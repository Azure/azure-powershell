---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/get-content-for-keyvaultprovider
schema: 2.0.0
---

# Get-Content for KeyVault Provider

## SYNOPSIS
Gets the content of a KeyVault Key, Certificate, or Secret.

## SYNTAX

### Path (Default)
```
Get-Content [-Path] <String[]> [<CommonParameters>]
```

### LiteralPath
```
Get-Content -LiteralPath <String[]> [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Get-Content** cmdlet returns the hidden values of KeyVault Secrets, Certificates, and Key. It returns the SecretValueText of a Secret, the JsonWebKey for a Key, and the X509Certificate2 for a Certificate.

Note: This custom cmdlet help file explains how the Get-Content cmdlet works in a KeyVault drive. For information about the Get-Content cmdlet in all drives, type "Get-Help Get-Content -Path $null" or see Get-Content at http://go.microsoft.com/fwlink/?LinkID=113310.

## EXAMPLES

### Example 1: Get the SecretValueText from a Secret
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Content -Path kv:/vault1/Secrets/secret1
P@ssw0rd
```

### Example 2: Get the JsonWebKey from a Key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Content -Path kv:/vault1/Keys/key1

ReadCount     : 1
Kid           : https://mvault.vault.azure.net/keys/key1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Kty           : RSA
KeyOps        : {decrypt}
N             : 
E             : 
DP            :
DQ            :
QI            :
P             :
Q             :
CurveName     :
X             :
Y             :
D             :
K             :
T             :
ExtensionData :
```

### Example 3: Get the X509Certificate2 from a Certificate
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Content -Path kv:/vault1/Certificates/cert1

   PSParentPath: mykv:\mvault\Certificates

Thumbprint                                Subject
----------                                -------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx         CN=contoso.com
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.String
### Microsoft.Azure.KeyVault.WebKey.JsonWebKey
### System.Security.Cryptography.X509Certificates.X509Certificate2

## NOTES

## RELATED LINKS
