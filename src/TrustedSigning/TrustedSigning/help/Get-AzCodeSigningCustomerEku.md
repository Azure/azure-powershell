---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.dll-Help.xml
Module Name: Az.TrustedSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/get-aztrustedsigningcustomereku
schema: 2.0.0
---

# Get-AzTrustedSigningCustomerEku

## SYNOPSIS
Retrieve Azure.TrustedSigning customer Eku

## SYNTAX

### InteractiveSubmit (Default)
```
Get-AzTrustedSigningCustomerEku [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> -MetadataFilePath <String>
```


## DESCRIPTION
The **Get-AzTrustedSigningCustomerEku ** cmdlet retrieves customer Eku.
Use this cmdlet to retrieve customer Eku.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.

## EXAMPLES

### Example 1: Retrieve customer Eku by account and profile name
```powershell
Get-AzTrustedSigningCustomerEku -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.trustedsigning.azure.net' 
```

```output
1.3.6.1.5.5.7.3.0
```

This command retrieves the customer eku by account and profile name.

### Example 2: Retrieve customer Eku by metadata file path

```powershell
Get-AzTrustedSigningCustomerEku -MetadataFilePath 'c:\cisigning\metadata_input.json'
```

```output
1.3.6.1.5.5.7.3.0
```

This command retrieves the customer eku by the metadata file configuration.

## PARAMETERS

### -AccountName
Specifies Azure TrustedSigning AccountName used to sign CI policy.

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
Specifies Azure TrustedSigning ProfileName used to sign CI policy.

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
Specifies Azure TrustedSigning Endpoint used to sign CI policy. It's an Url, format is `https://xxx.trustedsigning.azure.net`

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
Specifies Azure TrustedSigning Metadata file path used to sign CI policy. It's a file path, and the metadata content is below. File content example:
{
  "Endpoint": "https://xxx.trustedsigning.azure.net/",
  "TrustedSigningAccountName": "acstest",
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Azure TrustedSigning AccountName

### Azure TrustedSigning Profile Name

### Azure TrustedSigning Signing EndpointUrl

### Azure TrustedSigning UnSigned CI Policy File Path

### Azure TrustedSigning Signed CI Policy File Path Destination

### System.String

## OUTPUTS

### Signed CI Policy file

## NOTES

## RELATED LINKS

[Get-AzTrustedSigningCertificateroot](./Get-AzTrustedSigningCertificateroot.md)

[Get-AzTrustedSigningCertificateChain](./Get-AzTrustedSigningCertificateChain.md)

[Invoke-AzTrustedSigningCIPolicySigning](./Invoke-AzTrustedSigningCIPolicySigning.md)
