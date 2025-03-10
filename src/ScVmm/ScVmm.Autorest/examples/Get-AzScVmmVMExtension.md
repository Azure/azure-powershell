### Example 1: Get all extensions of a SCVMM VM
```powershell
Get-AzScVmmVMExtension -vmName 'test-vm' -ResourceGroupName 'test-rg-01'
```

```output
Name                  ResourceGroupName Location    ProvisioningState
----                  ----------------- --------    -----------------
RunCommand            test-rg-01        eastus      Succeeded
GenevaMonitoringAgent test-rg-01        eastus      Succeeded
```

Get all extensions of a SCVMM VM.

### Example 2: Get extension of a SCVMM VM
```powershell
Get-AzScVmmVMExtension -vmName 'test-vm' -ResourceGroupName 'test-rg-01' -ExtensionName 'RunCommand'
```

```output
AutoUpgradeMinorVersion        : False
EnableAutomaticUpgrade         : True
ForceUpdateTag                 :
Id                             : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm/extensions/RunCommand
InstanceViewName               : RunCommand
InstanceViewType               : CustomScriptExtension
InstanceViewTypeHandlerVersion : 1.10.20
Location                       : eastus
Name                           : RunCommand
PropertiesType                 : CustomScriptExtension
ProtectedSetting               : {
                                 }
ProvisioningState              : Succeeded
Publisher                      : Microsoft.Compute
ResourceGroupName              : test-rg-01
Setting                        : {
                                   "commandToExecute": "whoami"
                                 }
StatusCode                     : 0
StatusDisplayStatus            :
StatusLevel                    : Information
StatusMessage                  : Extension Message: , StdOut: nt authority\system

StatusTime                     :
SystemDataCreatedAt            :
SystemDataCreatedBy            :
SystemDataCreatedByType        :
SystemDataLastModifiedAt       :
SystemDataLastModifiedBy       :
SystemDataLastModifiedByType   :
Tag                            : {
                                 }
Type                           : Microsoft.HybridCompute/machines/extensions
TypeHandlerVersion             : 1.10.20
```

Get extension of a SCVMM VM.

