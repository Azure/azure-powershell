### Example 1: Get the status of a specific Attestation Provider
```powershell
Get-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg | fl
```

```output
AttestUri                    : https://testprovider1.eus.attest.azure.net
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1
Location                     : eastus
Name                         : testprovider1
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
                               }
TrustModel                   : AAD
Type                         : Microsoft.Attestation/attestationProviders
```

This command gets the status of a specific Attestation Provider named `testprovider1`.

### Example 2: List statuses of all Attestation Providers in current subscription
```powershell
Get-AzAttestationProvider
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/test",
                                 "name": "test",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://test.eus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1",
                                 "name": "testprovider1",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider1.eus.attest.azure.net"
                                 }
                               },{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Att 
                               estation/attestationProviders/testprovider2",
                                 "name": "testprovider2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "eastus",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider2.eus.attest.azure.net"
                                 }
                               }}
```

This command lists statuses of all Attestation Providers in current subscription.

### Example 2: List statuses of all Attestation Providers in a resource group
```powershell
Get-AzAttestationProvider -ResourceGroupName test-rg
```

```output
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Value                        : {{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/test",
                                 "name": "test",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://test.eus.attest.azure.net"
                                 }
                               }, {
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider1",
                                 "name": "testprovider1",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "tags": {
                                   "Test": "true",
                                   "CreationYear": "2020"
                                 },
                                 "location": "East US",
                                 "properties": {
                                   "trustModel": "Isolated",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider1.eus.attest.azure.net"
                                 }
                               },{
                                 "id": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Attestation/attestationProviders/testprovider2",
                                 "name": "testprovider2",
                                 "type": "Microsoft.Attestation/attestationProviders",
                                 "location": "eastus",
                                 "properties": {
                                   "trustModel": "AAD",
                                   "status": "Ready",
                                   "attestUri": "https://testprovider2.eus.attest.azure.net"
                                 }
                               }}
```

This command lists statuses of all Attestation Providers in a resource group.