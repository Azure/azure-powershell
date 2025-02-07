---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/get-azcodesigningcertchain
schema: 2.0.0
---

# Get-AzCodeSigningCertChain

## SYNOPSIS
Retrieve Azure.CodeSigning Certificate Chain

## SYNTAX

### InteractiveSubmit (Default)
```
Get-AzCodeSigningCertChain [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> 
-MetadataFilePath <String> 
```

## DESCRIPTION
The **Get-AzCodeSigningCertChain** cmdlet retrieves Azure CodeSigning Cert Chain.
Use this cmdlet to retrieve Azure CodeSigning Cert Chain.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Destination is the downloaded cert chain file path, which incldues the file name and extension .der.
## EXAMPLES

### Example 1: Retrieve a cert chain by account and profile name
```powershell
Get-AzCodeSigningCertChain -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net' -Destination 'c:\acs\certchain.der'
```

```output
Thumbprint                               Subject
----------                               -------
F40042E2E5F7E8EF8189FED15519AECE4        CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microso
8E750F459DAF9A79D6370DB747AD22268        CN=Microsoft ID Verified Code Signing PCA 2021, O=Microsoft Corporation, C=US
8BC0201379A2A31BA36EDD20223865C19        CN=Microsoft ID Verified CS EOC CA 02, O=Microsoft Corporation, C=US
1248C3FB98958560D5A73A75DEF9F624B        CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=WA, C=US
```

This command retrieves a certificate chain that is currently in use for signing by the account and profile.

### Example 2: Retrieve a cert chain using the metadata file path configuration

```powershell
Get-AzCodeSigningCertChain -MetadataFilePath 'c:\cisigning\metadata_input.json' -Destination 'c:\acs\certchain.der'
```

```output
Thumbprint                               Subject
----------                               -------
F40042E2E5F7E8EF8189FED15519AECE4        CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microso
8E750F459DAF9A79D6370DB747AD22268        CN=Microsoft ID Verified Code Signing PCA 2021, O=Microsoft Corporation, C=US
8BC0201379A2A31BA36EDD20223865C19        CN=Microsoft ID Verified CS EOC CA 02, O=Microsoft Corporation, C=US
1248C3FB98958560D5A73A75DEF9F624B        CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=WA, C=US
```

This command retrieves a certificate chain that is currently in use for signing by the metadata configuration.

## PARAMETERS

### -AccountName
Specifies Azure CodeSigning AccountName used to sign CI policy.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet

Required: True
Position: 1
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
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointUrl
Specifies Azure CodeSigning Endpoint used to sign CI policy. It's an Url, format is `https://xxx.codesigning.azure.net`

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataFilePath
Specifies Azure CodeSigning Metadata file path used to sign CI policy. It's a file path, and the metadata content is below. File content example:
{
  "Endpoint": "https://xxx.codesigning.azure.net/",
  "CodeSigningAccountName": "acstest",
  "CertificateProfileName": "acstestCert1"
}

```yaml
Type: System.String
Parameter Sets: ByMetadataFileParameterSet

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Specifies the downloaed cert chain file path. 

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: True
Position: 5
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

[Invoke-AzCodeSigningCIPolicySigning](./Invoke-AzCodeSigningCIPolicySigning.md)
