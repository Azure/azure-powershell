### Example 1: Get run command of a machine
```powershell
Get-AzConnectedMachineRunCommand -ResourceGroupName "ytongtest" -MachineName "testmachine" -RunCommandName "myRunCommand2"
```

```output
AsyncExecution                    : False
ErrorBlobManagedIdentityClientId  :
ErrorBlobManagedIdentityObjectId  :
ErrorBlobUri                      :
Id                                : /subscriptions/********-****-****-****-**********/resourceGroups/ytong
                                    test/providers/Microsoft.HybridCompute/machines/testmachine/runcommands/
                                    myRunCommand2
InstanceViewEndTime               : 11/8/2024 7:43:31 PM
InstanceViewError                 :
InstanceViewExecutionMessage      : RunCommand script execution completed
InstanceViewExecutionState        : Succeeded
InstanceViewExitCode              : 0
InstanceViewOutput                : Hello World!
InstanceViewStartTime             : 11/8/2024 7:43:31 PM
InstanceViewStatuses              :
Location                          : eastus
Name                              : myRunCommand2
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

Get run command of a machine