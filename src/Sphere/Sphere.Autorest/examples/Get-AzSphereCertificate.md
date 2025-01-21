### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCertificate -CatalogName test2024 -ResourceGroupName group-test
```

```output
ExpiryUtc                    : 4/30/2024 10:51:54 PM
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/certificates/'serial number'
Name                         : 'serial number'
NotBeforeUtc                 : 1/31/2024 10:51:54 PM
PropertiesCertificate        : 'certificate information'
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
Status                       : Active
Subject                      : CN=Microsoft Azure Sphere INT 11111111-2222-3333-4444-123456789101, O=Microsoft Corporation, L=Redmond, S=Washington, C=US
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Thumbprint                   : ****************
Type                         : Microsoft.AzureSphere/catalogs/certificates
```

This command get a list of certificate for the specified catalog with resource group.

