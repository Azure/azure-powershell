### Example 1: Update a specific Attestation Provider.
 
```powershell
Update-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg -Tag @{"k"="v"} | fl
```

```output
AttestUri                    : https://testprovider.eus.attest.azure.net
Id                           : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/ 
                               attestationProviders/testprovider
Location                     : eastus
Name                         : testprovider
PrivateEndpointConnection    : 
ResourceGroupName            : test-rg
Status                       : Ready
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                                 "k": "v"
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

This command updates a specific Attestation Provider.

### Example 2: Update a specific Attestation Provider by piping

```powershell
Get-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg | Update-AzAttestationProvider -Tag @{"k"="v"} | fl
```

```output
AttestUri                    : https://testprovider.eus.attest.azure.net
Id                           : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/ 
                               attestationProviders/testprovider
Location                     : eastus
Name                         : testprovider
PrivateEndpointConnection    : 
ResourceGroupName            : test-rg
Status                       : Ready
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                                 "k": "v"
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

These commands update a specific Attestation Provider by piping.

