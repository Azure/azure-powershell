### Example 1: Get a proof Of Possession Nonce
```powershell
Get-AzSphereCertificateProof -CatalogName test2024 -ResourceGroupName joyer-test -SerialNumber 'serial number' -ProofOfPossessionNonce proofOfPossessionNonce
```

```output
Certificate       : 'information'
ExpiryUtc         : 
NotBeforeUtc      : 
ProvisioningState : 
Status            : 
Subject           : 
Thumbprint        : 
```

This command gets a proof Of Possession Nonce for specified catalog and serial number.

