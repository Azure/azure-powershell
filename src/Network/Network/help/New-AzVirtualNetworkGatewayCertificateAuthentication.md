---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewaycertificateauthentication
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayCertificateAuthentication

## SYNOPSIS
Creates a certificate authentication configuration object for VPN gateway connections.

## SYNTAX

```
New-AzVirtualNetworkGatewayCertificateAuthentication [-OutboundAuthCertificate <String>]
 [-InboundAuthCertificateSubjectName <String>] [-InboundAuthCertificateChain <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a certificate authentication configuration object that can be used when creating or updating a VPN gateway connection with certificate-based authentication.

## EXAMPLES

### Example 1: Create a certificate authentication object
```powershell
# Create certificate chain array with base64-encoded certificates (without BEGIN/END CERTIFICATE headers)
$certChain = @(
    "MIIDfzCCAmegAwIBAgIQIFxjNWTuGjYGa8zJVnpfnDANBgkqhkiG9w0BAQsFADAYMRYwFAYDVQQDDA1DZXJ0QmFzZWRBdXRoMB4XDTI0MTIxODA1MjkzOVoXDTI1MTIxODA2MDk...",
    "MIIDezCCAmOgAwIBAgIQQIpJdJF8D8JwkqF6fJ6zGDANBgkqhkiG9w0BAQsFADAYMRYwFAYDVQQDDA1DZXJ0QmFzZWRBdXRoMB4XDTI0MTIxODA1MjkzOVoXDTI1MTIxODA2MDk..."
)

$certAuth = New-AzVirtualNetworkGatewayCertificateAuthentication `
    -OutboundAuthCertificate "https://myvault.vault.azure.net/certificates/mycert/abc123" `
    -InboundAuthCertificateSubjectName "MyCertSubject" `
    -InboundAuthCertificateChain $certChain
```

This example creates a certificate authentication object with a Key Vault certificate URL for outbound authentication, a certificate subject name for inbound authentication, and a certificate chain. This object can then be used with New-AzVirtualNetworkGatewayConnection or Set-AzVirtualNetworkGatewayConnection.

## PARAMETERS

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

### -InboundAuthCertificateChain
Inbound authentication certificate public keys.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InboundAuthCertificateSubjectName
Inbound authentication certificate subject name.

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

### -OutboundAuthCertificate
Keyvault secret ID for outbound authentication certificate.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSCertificateAuthentication

## NOTES

## RELATED LINKS
