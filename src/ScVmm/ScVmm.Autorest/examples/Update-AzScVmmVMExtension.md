### Example 1: Update extension
```powershell
Update-AzScVmmVMExtension -vmName 'test-vm' -ResourceGroupName 'test-rg-01' -ExtensionName 'RunCommand' -Setting @{"commandToExecute"="echo %SYSTEMROOT%"}
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
                                   "commandToExecute": "echo %SYSTEMROOT%"
                                 }
StatusCode                     : 0
StatusDisplayStatus            :
StatusLevel                    : Information
StatusMessage                  : Extension Message: , StdOut: C:\Windows

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

Update a VM extension.
