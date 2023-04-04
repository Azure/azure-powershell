---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDatastoreCredentialObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreCredentialObject

## SYNOPSIS
Create an in-memory object for CertificateDatastoreCredentials.

## SYNTAX

```
New-AzMLWorkspaceDatastoreCredentialObject -Certificate <String> -ClientId <String> -TenantId <String>
 -Thumbprint <String> [-AuthorityUrl <String>] [-ResourceUrl <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CertificateDatastoreCredentials.

## EXAMPLES

### Example 1: Create an in-memory object for CertificateDatastoreCredential
```powershell
New-AzMLWorkspaceDatastoreCredentialObject
```

Create an in-memory object for CertificateDatastoreCredential

## PARAMETERS

### -AuthorityUrl
Authority URL used for authentication.

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

### -Certificate
[Required] Service principal certificate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
[Required] Service principal client ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUrl
Resource the service principal has access to.

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

### -TenantId
[Required] ID of the tenant to which the service principal belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Thumbprint
[Required] Thumbprint of the certificate used for authentication.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.CertificateDatastoreCredentials

## NOTES

ALIASES

## RELATED LINKS

