### Example 1: Get the default provider by location
```powershell
Get-AzAttestationDefaultProvider -Location "East US"
```

```output
Get-AzAttestationDefaultProvider -Location "East US"

Location Name      ResourceGroupName
-------- ----      -----------------
east us  sharedeus
```

This command gets the default provider in "East US".

### Example 2: List default providers
```powershell
Get-AzAttestationDefaultProvider
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedeus2",
                                 "name": "sharedeus2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "East US 2",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedeus2.eus2.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedcus",
                                 "name": "sharedcus",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "Central US",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedcus.cus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/shareduks",
                                 "name": "shareduks",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "UK South",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://shareduks.uks.attest.azure.net"
                                 }
                               }, {
                                 "id": "/providers/Microsoft.Attestation/attestationProviders/sharedeus",
                                 "name": "sharedeus",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "east us",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://sharedeus.eus.attest.azure.net"
                                 }
                               }…}
```

This commands lists default providers.