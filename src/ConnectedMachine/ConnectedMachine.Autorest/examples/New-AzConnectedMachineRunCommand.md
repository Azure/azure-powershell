### Example 1: Create a run command
```powershell
New-AzConnectedMachineRunCommand -ResourceGroupName "ytongtest" -Location "eastus" -SourceScript "Write-Host Hello World!" -RunCommandName "myRunCommand2" -MachineName "testmachine" -Subscription "********-****-****-****-**********"
```

```output
AsyncExecution                    : False
ErrorBlobManagedIdentityClientId  :
ErrorBlobManagedIdentityObjectId  :
ErrorBlobUri                      :
Id                                : /subscriptions/********-****-****-****-**********/resourceGroups/ytong
                                    test/providers/Microsoft.HybridCompute/machines/testmachine/runcommands/
                                    myRunCommand
InstanceViewEndTime               : 11/8/2024 7:43:31 PM
InstanceViewError                 :
InstanceViewExecutionMessage      : RunCommand script execution completed
InstanceViewExecutionState        : Succeeded
InstanceViewExitCode              : 0
InstanceViewOutput                : Hello World!
InstanceViewStartTime             : 11/8/2024 7:43:31 PM
InstanceViewStatuses              :
Location                          : eastus
Name                              : myRunCommand
OutputBlobManagedIdentityClientId :
OutputBlobManagedIdentityObjectId :
OutputBlobUri                     :
Parameter                         :
ProtectedParameter                :
ProvisioningState                 : Succeeded
ResourceGroupName                 : ytongtest
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
Tags                              : {
                                    }
TimeoutInSecond                   : 0
Type                              : Microsoft.HybridCompute/machines/runcommands
```

Create a run command