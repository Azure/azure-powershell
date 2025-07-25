### Example 1: Update a firmware.
```powershell
Update-AzFirmwareAnalysisFirmware -FirmwareId firmwareId -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version
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

Update a firmware.

