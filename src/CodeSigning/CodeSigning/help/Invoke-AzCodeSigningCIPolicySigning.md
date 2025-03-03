---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/invoke-azcodesigningcipolicysigning
schema: 2.0.0
---

# Invoke-AzCodeSigningCIPolicySigning

## SYNOPSIS
Invoke CI Policy signing to Azure.CodeSigning

## SYNTAX

### InteractiveSubmit (Default)
```
Invoke-AzCodeSigningCIPolicySigning [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> 
-MetadataFilePath <String> 
-Path <String> -Destination <String> -TimeStamperUrl <String> 
```


## DESCRIPTION
The **Invoke-AzCodeSigningCIPolicySigning** cmdlet signs the CI Policy bin file.
Use this cmdlet to sign a CI Policy bin file.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Path is the original unsigned CI Policy file path.
Destination is the signing CI Policy file path, which includes file name.
TimeStamperUrl is optional, but it's strongly recommended to do TimeStamping along with Signing. 

## EXAMPLES

### Example 1: Sign a CI Policy .bin file by account and profile name

```powershell
Invoke-AzCodeSigningCIPolicySigning -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net' -Path 'c:\cisigning\contosocipolicy.bin' -Destination 'c:\cisigning\signed_contosocipolicy.bin' -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
CI Policy is successfully signed. c:\cisigning\signed_contosocipolicy.bin
```

This command signs a CI policy by account and profile, it also timestamps the signature using the timestamp url provided.

### Example 2: Sign a CI Policy .bin file by metadata file configuration

```powershell
Invoke-AzCodeSigningCIPolicySigning  -MetadataFilePath 'c:\cisigning\metadata_input.json' -Path 'c:\cisigning\contosocipolicy.bin' -Destination 'c:\cisigning\signed_contosocipolicy.bin' -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
CI Policy is successfully signed. c:\cisigning\signed_contosocipolicy.bin
```

This command signs a CI policy by the metadata configuration, it also timestamps the signature using the timestamp url provided.

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

### -Path
Specifies the original unsigned CI policy file path. The CI policy file extension is .bin, not xml. 

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Specifies the signed CI policy file path. The signed CI policy file extension is .bin. 

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeStamperUrl
Specifies Azure CodeSigning TimeStamper Url used to sign CI policy. The format is Url, recommended timestamper is http://timestamp.acs.microsoft.com.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: False
Position: 1
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

[Get-AzCodeSigningCertChain](./Get-AzCodeSigningCertChain.md)
