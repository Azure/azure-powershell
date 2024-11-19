---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorfrontendendpointobject
schema: 2.0.0
---

# New-AzFrontDoorFrontendEndpointObject

## SYNOPSIS
Create an in-memory object for FrontendEndpoint.

## SYNTAX

```
New-AzFrontDoorFrontendEndpointObject [-CustomHttpsConfigurationCertificateSource <String>]
 [-CustomHttpsConfigurationMinimumTlsVersion <String>] [-CustomHttpsConfigurationProtocolType <String>]
 [-FrontDoorCertificateSourceParameterCertificateType <String>] [-HostName <String>] [-Id <String>]
 [-KeyVaultCertificateSourceParameterSecretName <String>]
 [-KeyVaultCertificateSourceParameterSecretVersion <String>] [-Name <String>]
 [-SessionAffinityEnabledState <String>] [-SessionAffinityTtlSecond <Int32>] [-VaultId <String>]
 [-WebApplicationFirewallPolicyLinkId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FrontendEndpoint.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -CustomHttpsConfigurationCertificateSource
Defines the source of the SSL certificate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CertificateSource

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHttpsConfigurationMinimumTlsVersion
The minimum TLS version required from the clients to establish an SSL handshake with Front Door.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MinimumTlsVersion

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHttpsConfigurationProtocolType
The TLS extension protocol that is used for secure delivery

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ProtocolType 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontDoorCertificateSourceParameterCertificateType
Defines the type of the certificate used for secure connections to a frontendEndpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CertificateType

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostName
The host name of the frontendEndpoint.
Must be a domain name.

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

### -Id
Resource ID.

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

### -KeyVaultCertificateSourceParameterSecretName
The name of the Key Vault secret representing the full certificate PFX.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SecretName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCertificateSourceParameterSecretVersion
The version of the Key Vault secret representing the full certificate PFX.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SecretVersion

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name.

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

### -SessionAffinityEnabledState
Whether to allow session affinity on this host.
Valid options are 'Enabled' or 'Disabled'.

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

### -SessionAffinityTtlSecond
UNUSED.
This field will be ignored.
The TTL to use in seconds for session affinity, if applicable.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: SessionAffinityTtlInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Vault

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApplicationFirewallPolicyLinkId
Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WebApplicationFirewallPolicyLink

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.FrontendEndpoint

## NOTES

## RELATED LINKS

