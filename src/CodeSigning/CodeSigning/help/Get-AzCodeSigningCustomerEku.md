---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/get-azcodesigningcustomereku
schema: 2.0.0
---

# Get-AzCodeSigningCustomerEku

## SYNOPSIS
Retrieve Azure.CodeSigning customer Eku

## SYNTAX

### ByAccountProfileNameParameterSet (Default)
```
Get-AzCodeSigningCustomerEku [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> 
-MetadataFilePath <String> 
```


## DESCRIPTION
The **Get-AzCodeSigningCustomerEku ** cmdlet retrieves customer Eku.
Use this cmdlet to retrieve customer Eku.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.

## EXAMPLES

### Example: Retrieve customer Eku
```powershell
Get-AzCodeSigningCustomerEku -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net'
```

```output
Eku string or list
```

This command creates a software-protected key named ITSoftware in the key vault named Contoso.

## PARAMETERS

### -AccountName
Specifies Azure CodeSigning AccountName used to sign CI policy.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet

Required: True
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Specifies Azure CodeSigning ProfileName used to sign CI policy.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet

Required: True
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointUrl
Specifies Azure CodeSigning Endpoint used to sign CI policy. It's an Url, format is https://xxx.codesigning.azure.net

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: True
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataFilePath
Specifies Azure CodeSigning Metadata file path used to sign CI policy. It's a file path, and the metadata content is below.
Example:
{
    "Endpoint": "https://xxx.codesigning.azure.net/",
    "CodeSigningAccountName": "acstest",
    "CertificateProfileName": "acstestCert1"
}

```yaml
Type: System.String
Parameter Sets: ByMetadataFileParameterSet

Required: True
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Azure CodeSigning AccountName

### Azure CodeSigning Profile Name

### Azure CodeSigning Signing EndpointUrl

### Azure CodeSigning UnSigned CI Policy File Path

### Azure CodeSigning Signed CI Policy File Path Destination

### System.String

## OUTPUTS

### Signed CI Policy file

## NOTES

## RELATED LINKS

[Get-AzCodeSigningCustomerEku](./Get-AzCodeSigningCustomerEku.md)

[Get-AzCodeSigningRootCert](./Get-AzCodeSigningRootCert.md)
