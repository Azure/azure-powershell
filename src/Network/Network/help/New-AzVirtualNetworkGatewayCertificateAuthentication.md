---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewaycertificateauthentication
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayCertificateAuthentication

## SYNOPSIS
Creates a certificate authentication object for VPN gateway connections.

## SYNTAX

```
New-AzVirtualNetworkGatewayCertificateAuthentication [-OutboundAuthCertificate <String>]
 [-InboundAuthCertificateSubjectName <String>] [-InboundAuthCertificateChain <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualNetworkGatewayCertificateAuthentication cmdlet creates a certificate authentication object that can be used with New-AzVirtualNetworkGatewayConnection to configure certificate-based authentication for VPN gateway connections. This enables secure authentication using certificates instead of pre-shared keys.

## EXAMPLES

### Example 1: Create a certificate authentication object with outbound certificate
```powershell
PS C:\> $certAuth = New-AzVirtualNetworkGatewayCertificateAuthentication -OutboundAuthCertificate "https://myvault.vault.azure.net/secrets/client-cert"
```

Creates a certificate authentication object with only an outbound authentication certificate from Azure Key Vault.

### Example 2: Create a complete certificate authentication object
```powershell
PS C:\> $certChain = @("-----BEGIN CERTIFICATE-----`nMIIC...`n-----END CERTIFICATE-----")
PS C:\> $certAuth = New-AzVirtualNetworkGatewayCertificateAuthentication -OutboundAuthCertificate "https://myvault.vault.azure.net/secrets/client-cert" -InboundAuthCertificateSubjectName "CN=MyRootCA,O=MyOrg,C=US" -InboundAuthCertificateChain $certChain
```

Creates a complete certificate authentication object with outbound certificate, inbound certificate subject name, and certificate chain.

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

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSCertificateAuthentication

## NOTES

## RELATED LINKS
