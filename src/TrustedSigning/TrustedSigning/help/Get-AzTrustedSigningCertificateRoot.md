---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.dll-Help.xml
Module Name: Az.TrustedSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/get-aztrustedsigningcertificateroot
schema: 2.0.0
---

# Get-AzTrustedSigningCertificateRoot

## SYNOPSIS
Retrieve Azure.TrustedSigning Root Cert

## SYNTAX

### ByAccountProfileNameParameterSet (Default)
```
Get-AzTrustedSigningCertificateRoot [-AccountName] <String> [-ProfileName] <String> [-EndpointUrl] <String>
 [-Destination] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByMetadataFileParameterSet
```
Get-AzTrustedSigningCertificateRoot [-MetadataFilePath] <String> [-Destination] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzTrustedSigningCertificateRoot** cmdlet retrieves Azure TrustedSigning Root Cert.
Use this cmdlet to retrieve Azure TrustedSigning Root Cert.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Destination is the downloaded root cert file path, which includes the file name and extension .cer.

## EXAMPLES

### Example 1: Retrieve a root cert by account and profile name
```powershell
Get-AzTrustedSigningCertificateRoot -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.trustedsigning.azure.net' -Destination 'c:\acs\certificateroot.cer'
```

```output
Thumbprint                               Subject
----------                               -------
3A7B1F8C2E9D5A0B4F6E2C1D9F4B8A3E         CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microsoft
```

This command retrieves a root certificate that is currently in use for signing by the account and profile.

### Example 2: Retrieve a root cert using the metadata file path configuration

```powershell
Get-AzTrustedSigningCertificateRoot -MetadataFilePath 'c:\cisigning\metadata_input.json' -Destination 'c:\acs\certificateroot.cer'
```

```output
Thumbprint                               Subject
----------                               -------
3A7B1F8C2E9D5A0B4F6E2C1D9F4B8A3E         CN=Microsoft Identity Verification Root Certificate Authority 2020, O=Microsoft
```

This command retrieves a root certificate that is currently in use for signing by the metadata configuration.

## PARAMETERS

### -AccountName
Specifies Azure TrustedSigning AccountName used to sign CI policy.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Specifies the downloaded root cert file path. 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndpointUrl
Specifies Azure TrustedSigning Endpoint used to sign CI policy. It's an Url, format is `https://xxx.trustedsigning.azure.net`

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProfileName
Specifies Azure TrustedSigning ProfileName used to sign CI policy.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

[Get-AzTrustedSigningCustomerEku](./Get-AzTrustedSigningCustomerEku.md)

[Get-AzTrustedSigningCertificateChain](./Get-AzTrustedSigningCertificateChain.md)

[Invoke-AzTrustedSigningCIPolicySigning](./Invoke-AzTrustedSigningCIPolicySigning.md)
