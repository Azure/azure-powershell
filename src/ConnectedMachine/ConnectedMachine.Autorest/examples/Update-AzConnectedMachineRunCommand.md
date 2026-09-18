### Example 1: Update a run command with tags
```powershell
$tags = @{Tag1="tag1"; Tag2="tag2"}
Update-AzConnectedMachineRunCommand -ResourceGroupName $env.ResourceGroupName -RunCommandName $env.RunCommandName -MachineName $env.MachineName -Subscription $env.SubscriptionId -Tag $tags
```

```output
AsyncExecution                    : False
ErrorBlobManagedIdentityClientId  :
ErrorBlobManagedIdentityObjectId  :
ErrorBlobUri                      :
Id                                : /subscriptions/********-****-****-****-**********/resourceGroups/ytong
                                    test/providers/Microsoft.HybridCompute/machines/testmachine/runcommands/
                                    myRunCommand
InstanceViewEndTime               : 11/8/2024 7:50:54 PM
InstanceViewError                 :
InstanceViewExecutionMessage      : RunCommand script execution completed
InstanceViewExecutionState        : Succeeded
InstanceViewExitCode              : 0
InstanceViewOutput                : Hello World!
InstanceViewStartTime             : 11/8/2024 7:50:54 PM
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
                                      "Tag1": "tag1",
                                      "Tag2": "tag2"
                                    }
TimeoutInSecond                   : 0
Type                              : Microsoft.HybridCompute/machines/runcommands
```

Update a run command with tags

