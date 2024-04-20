---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudContentCertificateObject
schema: 2.0.0
---

# New-AzSpringCloudContentCertificateObject

## SYNOPSIS
Create an in-memory object for ContentCertificateProperties.

## SYNTAX

```
New-AzSpringCloudContentCertificateObject [-Content <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContentCertificateProperties.

## EXAMPLES

### Example 1: Create an in-memory object for ContentCertificateProperties
```powershell
New-AzSpringCloudContentCertificateObject -Content "ContentCertificate"
```

```output
ActivateDate DnsName ExpirationDate IssuedDate Issuer SubjectName Thumbprint Content
------------ ------- -------------- ---------- ------ ----------- ---------- -------
                                                                             ContentCertificate
```

Create an in-memory object for ContentCertificateProperties.

## PARAMETERS

### -Content
The content of uploaded certificate.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ContentCertificateProperties

## NOTES

## RELATED LINKS
