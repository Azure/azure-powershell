### Example 1:  List all the firmwares inside a workspace. 
```powershell
Get-AzFirmwareAnalysisFirmware -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName
```

```output
Description                  : 
FileName                     : 
FileSize                     :
Id                           : 
Model                        : 
Name                         : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState            : 
ResourceGroupName            : 
Status                       : 
StatusMessage                :
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SystemDataLastModifiedByType : 
Type                         : microsoft.iotfirmwaredefense/workspaces/firmwares
Vendor                       : 
Version                      : 
```

List all the firmwares inside a workspace.

### Example 2:  Get a firmware inside a workspace. 
```powershell
 Get-AzFirmwareAnalysisFirmware -Id FirmwareId -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName 
```

```output
Description                  : 
FileName                     : 
FileSize                     :
Id                           : 
Model                        : 
Name                         : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState            : 
ResourceGroupName            : 
Status                       : 
StatusMessage                :
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SystemDataLastModifiedByType : 
Type                         : microsoft.iotfirmwaredefense/workspaces/firmwares
Vendor                       : 
Version                      : 
```

 Get a firmware inside a workspace.  

