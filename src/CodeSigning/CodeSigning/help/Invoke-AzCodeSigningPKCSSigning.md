---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/invoke-azcodesigningpkcssigning
schema: 2.0.0
---

# Invoke-AzCodeSigningPKCSSigning

## SYNOPSIS
Invoke PKCS signing to Azure.CodeSigning

## SYNTAX

### InteractiveSubmit (Default)
```
Invoke-AzCodeSigningCIPolicySigning [-AccountName] <String> [-ProfileName] <String> -EndpointUrl <String> 
-MetadataFilePath <String> 
-Path <String> -Destination <String> -ContentType <String> -TimeStamperUrl <String> -Detached
```


## DESCRIPTION
The **Invoke-AzCodeSigningPKCSSigning** cmdlet help to acquire PKCS signature evelop of any type of file.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Path is the original unsigned arbitrary file path.
Destination is the signing arbitrary file path, which includes file name.
ContentType indicates the type of the associated content.  It is an object identifier; it is a unique string of integers assigned by an authority that defines the content type.
TimeStamperUrl is optional, but it's strongly recommended to do TimeStamping along with Signing. 
Detached is by default false i.e. it produces embedded signature. When
## EXAMPLES

### Example 1: Sign a .zip file by account and profile name to produce embedded signature

```powershell
Invoke-AzCodeSigningPKCSSigning -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.codesigning.azure.net' -Path 'c:\codesigning\compressfile.zip' -Destination 'c:\codesigning\signed_compressfile.zip' -ContentType 2.123.456.7.8.9 -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
Command Executed Successfully. Signed PKCS envelope stored at c:\codesigning\signed_compressfile.zip
```

This command signs a zip file by account and profile, it also timestamps the signature using the timestamp url provided.

### Example 2: Sign a .zip file by metadata file configuration to produce enveloped signature

```powershell
Invoke-AzCodeSigningPKCSSigning  -MetadataFilePath 'c:\cisigning\metadata_input.json' -Path 'c:\codesigning\compressfile.zip' -Destination 'c:\codesigning\signed_compressfile.zip' -ContentType 2.123.456.7.8.9 -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
Command Executed Successfully. Signed PKCS envelope stored at c:\codesigning\signed_compressfile.zip
```

This command signs a zip file by the metadata configuration, it also timestamps the signature using the timestamp url provided.

### Example 3: Sign a .zip file by metadata file configuration to produce detached signature

```powershell
Invoke-AzCodeSigningPKCSSigning  -MetadataFilePath 'c:\cisigning\metadata_input.json' -Path 'c:\codesigning\compressfile.zip' -Destination 'c:\codesigning\compressfile_signature.p7s' -ContentType 2.123.456.7.8.9 -TimeStamperUrl 'http://timestamp.acs.microsoft.com' -Detached
```

```output
Command Executed Successfully. Signed PKCS envelope stored at c:\codesigning\compressfile_signature.p7s
```

This command signs a zip file by the metadata configuration, it also timestamps the signature using the timestamp url provided. This produces the detached signature envelop.

## PARAMETERS

### -AccountName
Specifies Azure CodeSigning AccountName used to sign arbitrary file.

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
Specifies Azure CodeSigning ProfileName used to sign arbitrary file.

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
Specifies Azure CodeSigning Endpoint used to sign arbitrary file. It's an Url, format is `https://xxx.codesigning.azure.net`

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
Specifies Azure CodeSigning Metadata file path used to sign arbitrary file. It's a file path, and the metadata content is below. File content example:
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
Specifies the original unsigned arbitrary file path.

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
Specifies the signed arbitrary file. 

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
Specifies Azure CodeSigning TimeStamper Url used to sign arbitrary file.. The format is Url, recommended timestamper is http://timestamp.acs.microsoft.com.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies unique string of integers assigned by an authority that defines the content type.

```yaml
Type: System.String
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Detached
Specifies whether to produce detached the signature.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ByAccountProfileNameParameterSet, ByMetadataFileParameterSet

Required: False
Position: Named
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

### Azure CodeSigning UnSigned File Path

### Azure CodeSigning Signed File Path Destination

### System.String

## OUTPUTS

### Signed file or Signature envelop

## NOTES

## RELATED LINKS

[Get-AzCodeSigningCustomerEku](./Get-AzCodeSigningCustomerEku.md)

[Get-AzCodeSigningRootCert](./Get-AzCodeSigningRootCert.md)

[Invoke-AzCodeSigningCIPolicySigning](./Invoke-AzCodeSigningCIPolicySigning.md)
