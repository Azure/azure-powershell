---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspherecertificateproof
schema: 2.0.0
---

# Get-AzSphereCertificateProof

## SYNOPSIS
Gets the proof of possession nonce.

## SYNTAX

### RetrieveExpanded (Default)
```
Get-AzSphereCertificateProof -CatalogName <String> -ResourceGroupName <String> -SerialNumber <String>
 -ProofOfPossessionNonce <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RetrieveViaIdentityCatalogExpanded
```
Get-AzSphereCertificateProof -CatalogInputObject <ISphereIdentity> -SerialNumber <String>
 -ProofOfPossessionNonce <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RetrieveViaIdentityExpanded
```
Get-AzSphereCertificateProof -InputObject <ISphereIdentity> -ProofOfPossessionNonce <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets the proof of possession nonce.

## EXAMPLES

### Example 1: Get proof of possession nonce
```powershell
Get-AzSphereCertificateProof -CatalogName "MyCEVtest" -ResourceGroupName "glumenCEVRG" -SerialNumber "11D6501213A2B3987929F7909769F7B5" -ProofOfPossessionNonce "BFF18CC17D19D7E3B7884091981E0190F8E84181"
```

```output
Certificate       : MIICKjCCAbCgAwIBAgIRAJ0Bv2x21vVb3RlsnKOLnx4wCgYIKoZIzj0EAwMwgZoxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xRDBCBgNVBAMTO0
                    1pY3Jvc29mdCBBenVyZSBTcGhlcmUgYmU1MTA1N2UtZTZlYi00ODdkLTgyYzgtYTcwNDNjY2FiOWUxMB4XDTIzMDcxNDE4NTMyN1oXDTIzMDcxNDE5NTgyN1owMzExMC8GA1UEAxMoQkZGMThDQzE3RDE5RDdFM0I3ODg0MDkxOTgxRTAxOTBGOEU4NDE4
                    MTB2MBAGByqGSM49AgEGBSuBBAAiA2IABJYzRLCg2BTjUCZTARW7F4dEWnysqzz2FuIIwIGKlK9BcFAGAow1SxPtAxPnQHRAAoKfqlzWAzux4vW134ZPQnOBG98CEX5PWMrmAupVE5BVmq+aLeUI9+lwY8qS9n0PnKMgMB4wDgYDVR0PAQH/BAQDAgABMA
                    wGA1UdJQEB/wQCMAAwCgYIKoZIzj0EAwMDaAAwZQIxALHFPhMjGpIMeLrH6HEt4Hix+uvlRrpiQP2+fGD6Wr5OThAaj8qTtx2JBLUzkmduQwIwcoWNNpamt6Ib8UP2JdBYdO4VZ0B6S1swM9CrmAYuxH0gU9Ewx34u7VnZoMwU+xKT
ExpiryUtc         : 
NotBeforeUtc      : 
ProvisioningState : 
Status            : 
Subject           : 
Thumbprint        : 
```

This command gets the proof of possession nonce.

## PARAMETERS

### -CatalogInputObject
Identity Parameter
To construct, see NOTES section for CATALOGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: RetrieveViaIdentityCatalogExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

```yaml
Type: System.String
Parameter Sets: RetrieveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: RetrieveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProofOfPossessionNonce
The proof of possession nonce

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
Parameter Sets: RetrieveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
Serial number of the certificate.
Use '.default' to get current active certificate.

```yaml
Type: System.String
Parameter Sets: RetrieveExpanded, RetrieveViaIdentityCatalogExpanded
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
Type: System.String[]
Parameter Sets: RetrieveExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IProofOfPossessionNonceResponse

## NOTES

## RELATED LINKS

