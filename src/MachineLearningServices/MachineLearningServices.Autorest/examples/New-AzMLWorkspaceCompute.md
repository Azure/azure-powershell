### Example 1: Creates or updates compute. This call will overwrite a compute if it exists
```powershell
# The datastore type includes 'AKS', 'Kubernetes', 'AmlCompute', 'ComputeInstance','DataFactory', 'VirtualMachine', 'HDInsight', 'Databricks', 'DataLakeAnalytics', 'SynapseSpark'.
# You can use following command to create it then pass it as value to Compute parameter of the New-AzMLWorkspaceCompute cmdlet.
# New-AzMLWorkspaceAmlComputeObject
# New-AzMLWorkspaceComputeInstanceObject
# New-AzMLWorkspaceAksObject
# New-AzMLWorkspaceKubernetesObject
# New-AzMLWorkspaceVirtualMachineObject
# New-AzMLWorkspaceHDInsightObject
# New-AzMLWorkspaceDataFactoryObject
# New-AzMLWorkspaceDatabricksObject
# New-AzMLWorkspaceDataLakeAnalyticsObject
# New-AzMLWorkspaceSynapseSparkObject

$aml = New-AzMLWorkspaceAmlComputeObject -OSType 'Linux' -VMSize "STANDARD_DS3_V2" -ScaleMaxNodeCount 8 -ScaleMinNodeCount 0 -RemoteLoginPortPublicAccess 'NotSpecified' -EnableNodePublicIP $true
New-AzMLWorkspaceCompute -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name aml02 -Location eastus -Compute $aml
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/computes/aml02
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : 
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : aml02
Property                     : {
                                 "computeType": "AmlCompute",
                                 "computeLocation": "eastus",
                                 "provisioningState": "Succeeded",
                                 "createdOn": "2025-11-05T09:49:10.7733198Z",
                                 "modifiedOn": "2025-11-05T09:49:21.5072399Z",
                                 "isAttachedCompute": false,
                                 "disableLocalAuth": false,
                                 "properties": {
                                   "scaleSettings": {
                                     "maxNodeCount": 8,
                                     "minNodeCount": 0,
                                     "nodeIdleTimeBeforeScaleDown": "PT2M"
                                   },
                                   "nodeStateCounts": {
                                     "idleNodeCount": 0,
                                     "runningNodeCount": 0,
                                     "preparingNodeCount": 0,
                                     "unusableNodeCount": 0,
                                     "leavingNodeCount": 0,
                                     "preemptedNodeCount": 0
                                   },
                                   "osType": "Linux",
                                   "vmSize": "STANDARD_DS3_V2",
                                   "vmPriority": "Dedicated",
                                   "isolatedNetwork": false,
                                   "remoteLoginPortPublicAccess": "Enabled",
                                   "allocationState": "Steady",
                                   "allocationStateTransitionTime": "2025-11-05T09:49:20.0360000Z",
                                   "currentNodeCount": 0,
                                   "targetNodeCount": 0,
                                   "enableNodePublicIp": true
                                 }
                               }
ResourceGroupName            : ml-test
SkuCapacity                  : 
SkuFamily                    : 
SkuName                      : 
SkuSize                      : 
SkuTier                      : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/computes  
```

These commands create or update compute. This call will overwrite a compute if it exists.
