---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/get-azcodesigningrootcert
schema: 2.0.0
---

# Get-AzCodeSigningRootCert

## SYNOPSIS
Retrieve Azure.CodeSigning Root Cert

## SYNTAX

### InteractiveSubmit (Default)
```
Get-AzCodeSigningRootCert [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> 
-MetadataFilePath <String> 
```


## DESCRIPTION
The **Get-AzCodeSigningRootCert** cmdlet retrieves Azure CodeSigning Root Cert.
Use this cmdlet to retrieve Azure CodeSigning Root Cert.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Destination is the downloaded root cert file path, which incldues the file name and extension .cer.
## EXAMPLES

### Example 1: Retrieve a root cert by account and profile name
```powershell
Get-AzCodeSigningRootCert -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net' -Destination 'c:\acs\rootcert.cer'
```

```output
Thumbprint                               Subject
----------                               -------
3A7B1F8C2E9D5A0B4F6E2C1D9F4B8A3E         CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microsoft
```

This command retrieves a root certificate that is currently in use for signing by the account and profile.

### Example 2: Retrieve a root cert using the metadata file path configuration

```powershell
Get-AzCodeSigningRootCert -MetadataFilePath 'c:\cisigning\metadata_input.json' -Destination 'c:\acs\rootcert.cer'
```

```output
Thumbprint                               Subject
----------                               -------
3A7B1F8C2E9D5A0B4F6E2C1D9F4B8A3E         CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microsoft
```

This command retrieves a root certificate that is currently in use for signing by the metadata configuration.

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
Specifies the downloaed root cert file path. 

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

[Get-AzCodeSigningCertChain](./Get-AzCodeSigningCertChain.md)

[Invoke-AzCodeSigningCIPolicySigning](./Invoke-AzCodeSigningCIPolicySigning.md)
