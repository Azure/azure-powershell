### Example 1: Create a new firmware using new guid.
```powershell
New-AzFirmwareAnalysisFirmware -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version
```

```output
Description                  : description
FileName                     : FileName
FileSize                     : 1
Id                           : 
Model                        : model
Name                         : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState            : 
ResourceGroupName            : 
Status                       :
StatusMessage                :
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : microsoft.iotfirmwaredefense/workspaces/firmwares
Vendor                       : vendor
Version                      : version
```

Create a new firmware using new guid.

### Example 2: Create a new firmware using a user specified firmwareId.
```powershell
New-AzFirmwareAnalysisFirmware -Id firmwareId -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version
```

```output
Description                  : description
FileName                     : FileName
FileSize                     : 1
Id                           : 
Model                        : model
Name                         : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState            : 
ResourceGroupName            : 
Status                       :
StatusMessage                :
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : microsoft.iotfirmwaredefense/workspaces/firmwares
Vendor                       : vendor
Version                      : version
```

Create a new firmware using a user specified firmwareId.

