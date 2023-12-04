### Example 1: Enable Guest Agent on VM Instances
```powershell
New-AzConnectedVMwareVMGuestAgent -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine" -CredentialsUsername "test-user" -CredentialsPassword "test-pw" -ProvisioningAction "install"
```

```output
CredentialsPassword          :
CredentialsUsername          : abc
CustomResourceName           : d04a3534-2dfa-42c8-8959-83796a1bcac1
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/guestAgents/default
Name                         : default
PrivateLinkScopeResourceId   :
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Status                       : Enabled
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T14:47:02.1828535Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T14:47:02.1828535Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 2:45:33 PM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 2:45:33 PM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Type                         : microsoft.connectedvmwarevsphere/virtualmachineinstances/guestagents
Uuid                         : 6a37a700-e02c-476d-a19f-258761575c40
```

This command Enable Guest Agent of a VM Instances of machine named `test-machine`.