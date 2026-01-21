---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorfrontendendpointobject
schema: 2.0.0
---

# New-AzFrontDoorFrontendEndpointObject

## SYNOPSIS
Create an in-memory object for FrontendEndpoint.

## SYNTAX

```
New-AzFrontDoorFrontendEndpointObject [-CertificateSource <String>] [-MinimumTlsVersion <String>]
 [-CertificateType <String>] [-HostName <String>] [-SecretName <String>] [-SecretVersion <String>]
 [-Name <String>] [-SessionAffinityEnabledState <String>] [-SessionAffinityTtlInSeconds <Int32>]
 [-Vault <String>] [-WebApplicationFirewallPolicyLinkId <String>] [-Id <String>] [-ProtocolType <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FrontendEndpoint.

## EXAMPLES

### Example 1: Create a PSFrontendEndpoint Object for Front Door creation
```powershell
New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName "frontendendpoint1"
```

```output
CertificateSource                  :
CertificateType                    :
CustomHttpsProvisioningState       :
CustomHttpsProvisioningSubstate    :
HostName                           : frontendendpoint1
Id                                 :
MinimumTlsVersion                  :
Name                               : frontendendpoint1
ProtocolType                       : ServerNameIndication
ResourceGroupName                  :
ResourceState                      :
SecretName                         :
SecretVersion                      :
SessionAffinityEnabledState        : Enabled
SessionAffinityTtlInSeconds        : 0
Type                               :
Vault                              :
WebApplicationFirewallPolicyLinkId
```

Create a PSFrontendEndpoint Object for Front Door creation

## PARAMETERS

### -CertificateSource
Defines the source of the SSL certificate.

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

### -CertificateType
Defines the type of the certificate used for secure connections to a frontendEndpoint.

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

### -MinimumTlsVersion
The minimum TLS version required from the clients to establish an SSL handshake with Front Door.

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

### -ProtocolType
The TLS extension protocol that is used for secure delivery

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

### -SecretName
The name of the Key Vault secret representing the full certificate PFX.

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

### -SecretVersion
The version of the Key Vault secret representing the full certificate PFX.

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

### -SessionAffinityTtlInSeconds
UNUSED.
This field will be ignored.
The TTL to use in seconds for session affinity, if applicable.

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

### -Vault
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
