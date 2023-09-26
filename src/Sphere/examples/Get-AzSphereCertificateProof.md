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