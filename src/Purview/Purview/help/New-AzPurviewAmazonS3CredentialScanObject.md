---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purview/new-AzPurviewAmazonS3CredentialScanObject
schema: 2.0.0
---

# New-AzPurviewAmazonS3CredentialScanObject

## SYNOPSIS
Create an in-memory object for AmazonS3CredentialScan.

## SYNTAX

```
New-AzPurviewAmazonS3CredentialScanObject -Kind <ScanAuthorizationType> [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-ConnectedViaReferenceName <String>] [-CredentialReferenceName <String>]
 [-CredentialType <CredentialType>] [-IsMauiScan <Boolean>] [-RoleArn <String>] [-ScanRulesetName <String>]
 [-ScanRulesetType <ScanRulesetType>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmazonS3CredentialScan.

## EXAMPLES

### Example 1: Create Amazon S3 Credential scan object
```powershell
New-AzPurviewAmazonS3CredentialScanObject -Kind 'AmazonS3Credential' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialReferenceName 'rolearncred' -CredentialType 'AmazonARN' -ScanRulesetName 'AmazonS3' -ScanRulesetType 'System' -IsMauiScan $false
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : rolearncred
CredentialType            : AmazonARN
Id                        :
IsMauiScan                : False
Kind                      : AmazonS3Credential
LastModifiedAt            :
Name                      :
Result                    :
RoleArn                   :
ScanRulesetName           : AmazonS3
ScanRulesetType           : System
Worker                    :
```

Create Amazon S3 Credential scan object

## PARAMETERS

### -CollectionReferenceName

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionType

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedViaReferenceName

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialReferenceName

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.CredentialType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMauiScan

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanAuthorizationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleArn

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetName

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.ScanRulesetType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Worker

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AmazonS3CredentialScan

## NOTES

ALIASES

## RELATED LINKS
