---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ArtifactSigning.dll-Help.xml
Module Name: Az.ArtifactSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.artifactsigning/get-AzArtifactSigningCertificateChain
schema: 2.0.0
---

# Get-AzArtifactSigningCertificateChain

## SYNOPSIS
Retrieve Azure.ArtifactSigning Certificate Chain

## SYNTAX

### ByAccountProfileNameParameterSet (Default)
```
Get-AzArtifactSigningCertificateChain [-AccountName] <String> [-ProfileName] <String> [-EndpointUrl] <String>
 [-Destination] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByMetadataFileParameterSet
```
Get-AzArtifactSigningCertificateChain [-MetadataFilePath] <String> [-Destination] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzArtifactSigningCertificateChain** cmdlet retrieves Azure ArtifactSigning Cert Chain.
Use this cmdlet to retrieve Azure ArtifactSigning Cert Chain.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Destination is the downloaded cert chain file path, which includes the file name and extension .der.

## EXAMPLES

### Example 1: Retrieve a cert chain by account and profile name
```powershell
Get-AzArtifactSigningCertificateChain -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.artifactsigning.azure.net' -Destination 'c:\acs\certificatechain.der'
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
Get-AzArtifactSigningCertificateChain -MetadataFilePath 'c:\cisigning\metadata_input.json' -Destination 'c:\acs\certificatechain.der'
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
Specifies Azure ArtifactSigning AccountName used to sign CI policy.

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
Specifies the downloaded cert chain file path. 

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
Specifies Azure ArtifactSigning Endpoint used to sign CI policy. It's an Url, format is `https://xxx.artifactsigning.azure.net`

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
Specifies Azure ArtifactSigning Metadata file path used to sign CI policy. It's a file path, and the metadata content is below. File content example:
{
  "Endpoint": "https://xxx.artifactsigning.azure.net/",
  "ArtifactSigningAccountName": "acstest",
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
Specifies Azure ArtifactSigning ProfileName used to sign CI policy.

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

### Azure ArtifactSigning AccountName

### Azure ArtifactSigning Profile Name

### Azure ArtifactSigning Signing EndpointUrl

### Azure ArtifactSigning UnSigned CI Policy File Path

### Azure ArtifactSigning Signed CI Policy File Path Destination

### System.String

## OUTPUTS

### Signed CI Policy file

## NOTES

## RELATED LINKS

[Get-AzArtifactSigningCustomerEku](./Get-AzArtifactSigningCustomerEku.md)

[Get-AzArtifactSigningCertificateRoot](./Get-AzArtifactSigningCertificateRoot.md)

[Invoke-AzArtifactSigningCIPolicySigning](./Invoke-AzArtifactSigningCIPolicySigning.md)
