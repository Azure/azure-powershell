### Example 1: Get file shares limitation
```powershell
Get-AzFileShareLimit -Location uaecentral
```

```output
LimitMaxFileShare                             : 1000
LimitMaxFileSharePrivateEndpointConnection    : 100
LimitMaxFileShareSnapshot                     : 200
LimitMaxFileShareSubnet                       : 400
LimitMaxProvisionedIoPerSec                   : 100000
LimitMaxProvisionedStorageGiB                 : 262144
LimitMaxProvisionedThroughputMiBPerSec        : 10240
LimitMinProvisionedIoPerSec                   : 3000
LimitMinProvisionedStorageGiB                 : 32
LimitMinProvisionedThroughputMiBPerSec        : 125
ProvisioningConstantBaseIoPerSec              : 3000
ProvisioningConstantBaseThroughputMiBPerSec   : 125
ProvisioningConstantGuardrailIoPerSecScalar   : 5
ProvisioningConstantGuardrailThroughputScalar : 5
ProvisioningConstantScalarIoPerSec            : 1
ProvisioningConstantScalarThroughputMiBPerSec : 0.1
```

This command gets file shares limitation of a specific location.

