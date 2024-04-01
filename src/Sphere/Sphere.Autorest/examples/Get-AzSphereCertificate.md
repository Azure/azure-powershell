### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCertificate -CatalogName test2024 -ResourceGroupName joyer-test
```

```output
ExpiryUtc                    : 4/30/2024 10:51:54 PM
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/certificates/'serial number'
Name                         : 'serial number'
NotBeforeUtc                 : 1/31/2024 10:51:54 PM
PropertiesCertificate        : 'certificate information'
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere INT 7de8a199-bb33-4eda-9600-583103317243, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : 92C60521BB46C72D66FA72CF59EF701D9269A236
Type                         : Microsoft.AzureSphere/catalogs/certificates
```

This command get a list of certificate for the specified catalog with resource group.

