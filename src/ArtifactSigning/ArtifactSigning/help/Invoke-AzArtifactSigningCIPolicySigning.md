---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ArtifactSigning.dll-Help.xml
Module Name: Az.ArtifactSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.artifactsigning/invoke-azartifactsigningcipolicysigning
schema: 2.0.0
---

# Invoke-AzArtifactSigningCIPolicySigning

## SYNOPSIS
Invoke CI Policy signing to Azure.ArtifactSigning

## SYNTAX

### ByAccountProfileNameParameterSet (Default)
```
Invoke-AzArtifactSigningCIPolicySigning [-AccountName] <String> [-ProfileName] <String> [-EndpointUrl] <String>
 [-Path] <String> -Destination <String> [-TimeStamperUrl <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByMetadataFileParameterSet
```
Invoke-AzArtifactSigningCIPolicySigning [-MetadataFilePath] <String> [-Path] <String> -Destination <String>
 [-TimeStamperUrl <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzArtifactSigningCIPolicySigning** cmdlet signs the CI Policy bin file.
Use this cmdlet to sign a CI Policy bin file.
There are two sets of parameters. One set uses AccountName, ProfileName, and EndpointUrl. 
Another set uses MetadataFilePath.
Path is the original unsigned CI Policy file path.
Destination is the signing CI Policy file path, which includes file name.
TimeStamperUrl is optional, but it's strongly recommended to do TimeStamping along with Signing. 

## EXAMPLES

### Example 1: Sign a CI Policy .bin file by account and profile name

```powershell
Invoke-AzArtifactSigningCIPolicySigning -AccountName 'contoso' -ProfileName 'contososigning' -EndpointUrl 'https://wus.artifactsigning.azure.net' -Path 'c:\cisigning\contosocipolicy.bin' -Destination 'c:\cisigning\signed_contosocipolicy.bin' -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
CI Policy is successfully signed. c:\cisigning\signed_contosocipolicy.bin
```

This command signs a CI policy by account and profile, it also timestamps the signature using the timestamp url provided.

### Example 2: Sign a CI Policy .bin file by metadata file configuration

```powershell
Invoke-AzArtifactSigningCIPolicySigning  -MetadataFilePath 'c:\cisigning\metadata_input.json' -Path 'c:\cisigning\contosocipolicy.bin' -Destination 'c:\cisigning\signed_contosocipolicy.bin' -TimeStamperUrl 'http://timestamp.acs.microsoft.com'
```

```output
CI Policy is successfully signed. c:\cisigning\signed_contosocipolicy.bin
```

This command signs a CI policy by the metadata configuration, it also timestamps the signature using the timestamp url provided.

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
Specifies the signed CI policy file path. The signed CI policy file extension is .bin. 

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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

### -Path
Specifies the original unsigned CI policy file path. The CI policy file extension is .bin, not xml. 

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

### -TimeStamperUrl
Specifies Azure ArtifactSigning TimeStamper Url used to sign CI policy. The format is Url, recommended timestamper is http://timestamp.acs.microsoft.com.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

[Get-AzArtifactSigningCertificateroot](./Get-AzArtifactSigningCertificateroot.md)

[Get-AzArtifactSigningCertificateChain](./Get-AzArtifactSigningCertificateChain.md)
