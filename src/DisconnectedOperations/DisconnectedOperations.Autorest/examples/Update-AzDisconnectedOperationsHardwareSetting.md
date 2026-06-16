### Example 1: Update hardware settings using expanded parameters.
```powershell
Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -MemoryInGb 32
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 32
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

This command updates the `default` hardware settings of the named `winfield-ps-test` in the resource group `winfield-demo-rg-2` to set the memory in gb to `32`. 

### Example 2: Update the hardware settings using Disconnected Operations Identity.
```powershell
$disconnectedOperation = @{
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Update-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -DisconnectedOperationInputObject $disconnectedOperation -MemoryInGb 32
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 32
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

This command updates the `default` hardware settings of the named `winfield-ps-test` in the resource group `winfield-demo-rg-2` to set the memory in gb to `32`. 

### Example 3: Update the hardware settings using input identity object.
```powershell
$inputObject = @{
  "HardwareSettingName" = "default";
  "ResourceGroupName" = "winfield-demo-rg-2";
  "Name" = "winfield-ps-test";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Update-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject -MemoryInGb 32
```

```output
DeviceId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
DiskSpaceInGb                : 1024
HardwareSku                  : MC-760
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test/hardwareSettings/default
MemoryInGb                   : 32
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

This command updates the `default` hardware settings of the named `winfield-ps-test` in the resource group `winfield-demo-rg-2` to set the memory in gb to `32`. 