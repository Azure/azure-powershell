---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 0743C43D-2A1F-4950-B0F3-1FED4014EEC5
online version: 
schema: 2.0.0
---

# Get-AzureKeyVaultCertificateOperation

## SYNOPSIS
Gets the status of a certificate operation.

## SYNTAX

```
Get-AzureKeyVaultCertificateOperation [-VaultName] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureKeyVaultCertificateOperation** cmdlet gets the status of a certificate operation.

## EXAMPLES

### Example 1: Get the status of a certificate operation
```
PS C:\>Get-AzureKeyVaultCertificateOperation -VaultName "ContosoKV01" -Name "TestCert01"
Status                    : inProgress
CancellationRequested     : False
CertificateSigningRequest : MIICpjCCAY4CAQAwFjEUMBIGA1UEAxMLY29udG9zby5jb20wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC73w3VRBOlgJ5Od1PjDh+2ytngNZp+ZP4fkuX8K1Ti5LA6Ih7eWx1fgAN/iTb6l
                            5K6LvAIJvsTNVePMNxfSdaEIJ70Inm45wVU4A/kf+UxQWAYVMsBrLtDFWxnVhzf6n7RGYke6HLBj3j5ASb9g+olSs6eON25ibF0t+u6JC+sIR0LmVGar9Q0eZys1rdfzJBIKq+laOM7z2pJijb5ANqve9
                            i7rH5mnhQk4V8WsRstOhYR9jgLqSSxokDoeaBClIOidSBYqVc1yNv4ASe1UWUCR7ZK6OQXiecNWSWPmgWEyawu6AR9eb1YotCr2ScheMOCxlm3103luitxrd8A7kMjAgMBAAGgSzBJBgkqhkiG9w0BCQ4
                            xPDA6MA4GA1UdDwEB/wQEAwIFoDAdBgNVHSUEFjAUBggrBgEFBQcDAQYIKwYBBQUHAwIwCQYDVR0TBAIwADANBgkqhkiG9w0BAQsFAAOCAQEAIHhsDJV37PKi8hor5eQf7+Tct1preIvSwqV0NF6Uo7O6
                            YnC9Py7Wp7CHfKzuqeptUk2Tsu7B5dHB+o9Ypeeqw8fWhTN0GFGRKO7WjZQlDqL+lRNcjlFSaP022oIP0kmvVhBcmZqRQlALXccAaxEclFA/3y/aNj2gwWeKpH/pwAkZ39zMEzpQCaRfnQk7e3l4MV8cf
                            eC2HPYdRWkXxAeDcNPxBuVmKy49AzYvly+APNVDU3v66gxl3fIKrGRsKi2Cp/nO5rBxG2h8t+0Za4l/HJ7ZWR9wKbd/xg7JhdZZFVBxMHYzw8KQ0ys13x8HY+PXU92Y7yD3uC2Rcj+zbAf+Kg==
ErrorCode                 : 
ErrorMessage              :
```

This command gets the status of the certificate operation for TestCert01 on the ContosoKV01 key vault.

## PARAMETERS

### -Name
Specifies the name of a certificate.

```yaml
Type: String
Parameter Sets: (All)
Aliases: CertificateName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of a key vault.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.KeyVaultCertificateOperation

## NOTES

## RELATED LINKS

[Remove-AzureKeyVaultCertificateOperation](./Remove-AzureKeyVaultCertificateOperation.md)

[Stop-AzureKeyVaultCertificateOperation](./Stop-AzureKeyVaultCertificateOperation.md)

