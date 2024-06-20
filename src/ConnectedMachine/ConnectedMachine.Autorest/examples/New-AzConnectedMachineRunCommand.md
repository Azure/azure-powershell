### Example 1: Create a run-command for a machine
```powershell
New-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -Location "eastus2euap" -SourceScript "Write-Host Hello World!" -RunCommandName "myRunCommand3" -MachineName "testmachine" -SubscriptionId ********-****-****-****-**********
```

```output
AsyncExecution                    : False
ErrorBlobManagedIdentityClientId  :
ErrorBlobManagedIdentityObjectId  :
ErrorBlobUri                      :
Id                                : /subscriptions/********-****-****-****-**********/resourceGroups/az-sdk-test/prov
                                    iders/Microsoft.HybridCompute/machines/testmachine/runcommands/myRunCommand3
InstanceViewEndTime               : 12/5/2023 7:27:26 PM
InstanceViewError                 :
InstanceViewExecutionMessage      : RunCommand script execution completed
InstanceViewExecutionState        : Succeeded
InstanceViewExitCode              : 0
InstanceViewOutput                : Hello World!
InstanceViewStartTime             : 12/5/2023 7:27:24 PM
InstanceViewStatuses              :
Location                          : eastus2euap
Name                              : myRunCommand3
OutputBlobManagedIdentityClientId :
OutputBlobManagedIdentityObjectId :
OutputBlobUri                     :
Parameter                         :
ProtectedParameter                :
ProvisioningState                 : Succeeded
ResourceGroupName                 : az-sdk-test
RunAsPassword                     :
RunAsUser                         :
ScriptUriManagedIdentityClientId  :
ScriptUriManagedIdentityObjectId  :
SourceCommandId                   :
SourceScript                      : Write-Host Hello World!
SourceScriptUri                   :
SystemDataCreatedAt               :
SystemDataCreatedBy               :
SystemDataCreatedByType           :
SystemDataLastModifiedAt          :
SystemDataLastModifiedBy          :
SystemDataLastModifiedByType      :
Tag                               : {
                                    }
TimeoutInSecond                   : 0
Type                              : Microsoft.HybridCompute/machines/runcommands
```

Create a run-command for a machine