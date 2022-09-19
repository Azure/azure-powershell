---
external help file:
Module Name: Az.Attestation
online version: https://docs.microsoft.com/powershell/module/az.attestation/new-azattestationprovider
schema: 2.0.0
---

# New-AzAttestationProvider

## SYNOPSIS
Creates a new Attestation Provider.

## SYNTAX

```
New-AzAttestationProvider -ProviderName <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-PolicySigningCertificateKey <IJsonWebKey[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Attestation Provider.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The supported Azure location where the attestation provider should be created.

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

### -PolicySigningCertificateKey
The value of the "keys" parameter is an array of JWK values.
Bydefault, the order of the JWK values within the array does not implyan order of preference among them, although applications of JWK Setscan choose to assign a meaning to the order for their purposes, ifdesired.
To construct, see NOTES section for POLICYSIGNINGCERTIFICATEKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api10.IJsonWebKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderName
Name of the attestation provider.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags that will be assigned to the attestation provider.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICYSIGNINGCERTIFICATEKEY <IJsonWebKey[]>`: The value of the "keys" parameter is an array of JWK values. Bydefault, the order of the JWK values within the array does not implyan order of preference among them, although applications of JWK Setscan choose to assign a meaning to the order for their purposes, ifdesired.
  - `Kty <String>`: The "kty" (key type) parameter identifies the cryptographic algorithm         family used with the key, such as "RSA" or "EC". "kty" values should         either be registered in the IANA "JSON Web Key Types" registry         established by [JWA] or be a value that contains a Collision-         Resistant Name.  The "kty" value is a case-sensitive string.
  - `[Alg <String>]`: The "alg" (algorithm) parameter identifies the algorithm intended for         use with the key.  The values used should either be registered in the         IANA "JSON Web Signature and Encryption Algorithms" registry         established by [JWA] or be a value that contains a Collision-         Resistant Name.
  - `[Crv <String>]`: The "crv" (curve) parameter identifies the curve type
  - `[D <String>]`: RSA private exponent or ECC private key
  - `[Dp <String>]`: RSA Private Key Parameter
  - `[Dq <String>]`: RSA Private Key Parameter
  - `[E <String>]`: RSA public exponent, in Base64
  - `[K <String>]`: Symmetric key
  - `[Kid <String>]`: The "kid" (key ID) parameter is used to match a specific key.  This         is used, for instance, to choose among a set of keys within a JWK Set         during key rollover.  The structure of the "kid" value is         unspecified.  When "kid" values are used within a JWK Set, different         keys within the JWK Set SHOULD use distinct "kid" values.  (One         example in which different keys might use the same "kid" value is if         they have different "kty" (key type) values but are considered to be         equivalent alternatives by the application using them.)  The "kid"         value is a case-sensitive string.
  - `[N <String>]`: RSA modulus, in Base64
  - `[P <String>]`: RSA secret prime
  - `[Q <String>]`: RSA secret prime, with p < q
  - `[Qi <String>]`: RSA Private Key Parameter
  - `[Use <String>]`: Use ("public key use") identifies the intended use of         the public key. The "use" parameter is employed to indicate whether         a public key is used for encrypting data or verifying the signature         on data. Values are commonly "sig" (signature) or "enc" (encryption).
  - `[X <String>]`: X coordinate for the Elliptic Curve point
  - `[X5C <String[]>]`: The "x5c" (X.509 certificate chain) parameter contains a chain of one         or more PKIX certificates [RFC5280].  The certificate chain is         represented as a JSON array of certificate value strings.  Each         string in the array is a base64-encoded (Section 4 of [RFC4648] --         not base64url-encoded) DER [ITU.X690.1994] PKIX certificate value.         The PKIX certificate containing the key value MUST be the first         certificate.
  - `[Y <String>]`: Y coordinate for the Elliptic Curve point

## RELATED LINKS

