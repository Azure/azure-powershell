### Example 1: Crete a new hardware setting for a specific resource with expanded parameters
```powershell
New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -DeviceId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "xxxx.x"
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" with specified parameters such as device ID, disk space, hardware SKU, memory, node count, OEM, solution builder extension, total cores, and version at registration.

### Example 2: Create a new hardware setting for a specific resource using DisconnectedOperation identity
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
New-AzDisconnectedOperationsHardwareSetting -DisconnectedOperationInputObject $disconnectedOperation -HardwareSettingName "default" -DeviceId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "xxxx.x"
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the DisconnectedOperation identity with specified parameters such as device ID, disk space, hardware SKU, memory, node count, OEM, solution builder extension, total cores, and version at registration.

### Example 3: Create a new hardware setting for a specific resource using a JSON file path
```powershell
New-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default" -JsonFilePath "path/to/jsonFiles/CreateHardwareSetting.json"
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the configuration specified in the JSON file located at "path/to/jsonFiles/CreateHardwareSetting.json".

### Example 4: Creates a new hardware setting for a specific resource using a JSON string
```powershell
New-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default" -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"xxxx.x","solutionBuilderExtension":"xyz","deviceId":"xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"}}'
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 64
Name                         : default
Node                         : 3
Oem                          : contoso
ProvisioningState            : Succeeded
ResourceGroupName            : winfield-demo-rg-2
SolutionBuilderExtension     : xyz
SystemDataCreatedAt          : 03/02/2026 10:55:32
SystemDataCreatedBy          : user1@outlook.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 03/02/2026 10:55:32
SystemDataLastModifiedBy     : user1@outlook.com
SystemDataLastModifiedByType : User
TotalCore                    : 200
Type                         : microsoft.edge/disconnectedoperations/hardwaresettings
VersionAtRegistration        : xxxx.x
```

This command creates a new hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2" using the configuration specified in the JSON string.