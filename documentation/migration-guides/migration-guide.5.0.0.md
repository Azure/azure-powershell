# Breaking changes for Microsoft Azure PowerShell 5.0.0

This document serves as both a breaking change notification and migration guide for consumers of the Microsoft Azure PowerShell cmdlets. Each section describes both the impetus for the breaking change and the migration path of least resistance. For in-depth context, please refer to the pull request associated with each change.

## Table of Contents

- [Breaking changes to ApiManagement cmdlets](#breaking-changes-to-apimanagement-cmdlets)
- [Breaking changes to Batch cmdlets](#breaking-changes-to-batch-cmdlets)
- [Breaking changes to Compute cmdlets](#breaking-changes-to-compute-cmdlets)
- [Breaking changes to EventHub cmdlets](#breaking-changes-to-eventhub-cmdlets)
- [Breaking changes to Insights cmdlets](#breaking-changes-to-insights-cmdlets)
- [Breaking changes to Network cmdlets](#breaking-changes-to-network-cmdlets)
- [Breaking changes to Resources cmdlets](#breaking-changes-to-resources-cmdlets)
- [Breaking Changes to ServiceBus Cmdlets](#breaking-changes-to-servicebus-cmdlets)

## Breaking changes to ApiManagement cmdlets

### **New-AzureRmApiManagementBackendProxy**
- Parameters "UserName" and "Password" are being replaced in favor of a PSCredential

```powershell
# Old
New-AzureRmApiManagementBackendProxy [other required parameters] -UserName "plain-text string" -Password "plain-text string"

# New
New-AzureRmApiManagementBackendProxy [other required parameters] -Credential $PSCredentialVariable
```

### **New-AzureRmApiManagementUser**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmApiManagementUser [other required parameters] -Password "plain-text string"

# New
New-AzureRmApiManagementUser [other required parameters] -Password $SecureStringVariable
```

### **Set-AzureRmApiManagementUser**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
Set-AzureRmApiManagementUser [other required parameters] -Password "plain-text string"

# New
Set-AzureRmApiManagementUser [other required parameters] -Password $SecureStringVariable
```

## Breaking changes to Batch cmdlets

### **New-AzureBatchCertificate**
- Parameter `Password` being replaced in favor of a Secure string

```powershell
# Old
New-AzureBatchCertificate [other required parameters] -Password "plain-text string"

# New
New-AzureBatchCertificate [other required parameters] -Password $SecureStringVariable
```

### **New-AzureBatchComputeNodeUser**
- Parameter `Password` being replaced in favor of a Secure string

```powershell
# Old
New-AzureBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
New-AzureBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```

### **Set-AzureRmBatchComputeNodeUser**
- Parameter `Password` being replaced in favor of a Secure string

```powershell
# Old
Set-AzureRmBatchComputeNodeUser [other required parameters] -Password "plain-text string"

# New
Set-AzureRmBatchComputeNodeUser [other required parameters] -Password $SecureStringVariable
```

### **New-AzureBatchTask**
 - Removed the `RunElevated` switch and replaced it with `UserIdentity`.

```powershell
# Old
New-AzureBatchTask -Id $taskId1 -JobId $jobId -CommandLine "cmd /c echo hello" -RunElevated $TRUE

# New
$autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
$userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
New-AzureBatchTask -Id $taskId1 -JobId $jobId -CommandLine "cmd /c echo hello" -UserIdentity $userIdentity
```

This additionally impacts the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`.

### **PSMultiInstanceSettings**

- `PSMultiInstanceSettings` constructor no longer takes a required `numberOfInstances` parameter, instead it takes a required `coordinationCommandLine` parameter.

```powershell
# Old
$settings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @(2)
$settings.CoordinationCommandLine = "cmd /c echo hello"
New-AzureBatchTask [other parameters] -MultiInstanceSettings $settings

# New
$settings = New-Object Microsoft.Azure.Commands.Batch.Models.PSMultiInstanceSettings -ArgumentList @("cmd /c echo hello", 2)
New-AzureBatchTask [other parameters] -MultiInstanceSettings $settings
```

### **Get-AzureBatchTask**
 - Removed the `RunElevated` property on `PSCloudTask`. The `UserIdentity` property has been added to replace `RunElevated`.

```powershell
# Old
$task = Get-AzureBatchTask [parameters]
$task.RunElevated

# New
$task = Get-AzureBatchTask [parameters]
$task.UserIdentity.AutoUser.ElevationLevel
```

This additionally impacts the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`.

### **Multiple types**

- Renamed the `SchedulingError` property on `PSExitConditions` to `PreProcessingError`.

```powershell
# Old
$task = Get-AzureBatchTask [parameters]
$task.ExitConditions.SchedulingError

# New
$task = Get-AzureBatchTask [parameters]
$task.ExitConditions.PreProcessingError
```

### **Multiple types**

- Renamed the `SchedulingError` property on `PSJobPreparationTaskExecutionInformation`, `PSJobReleaseTaskExecutionInformation`, `PSStartTaskInformation`, `PSSubtaskInformation`, and `PSTaskExecutionInformation` to `FailureInformation`.
  - `FailureInformation` is returned any time there is a task failure. This includes all previous scheduling error cases, as well as nonzero task exit codes, and file upload failures from the new output files feature.
  - This is structured the same as before, so no code change is needed when using this type.

```powershell
# Old
$task = Get-AzureBatchTask [parameters]
$task.ExecutionInformation.SchedulingError

# New
$task = Get-AzureBatchTask [parameters]
$task.ExecutionInformation.FailureInformation
```

This additionally impacts: Get-AzureBatchPool, Get-AzureBatchSubtask, and Get-AzureBatchJobPreparationAndReleaseTaskStatus

### **New-AzureBatchPool**
 - Removed `TargetDedicated` and replaced it with `TargetDedicatedComputeNodes` and `TargetLowPriorityComputeNodes`.
 - `TargetDedicatedComputeNodes` has an alias `TargetDedicated`.

```powershell
# Old
New-AzureBatchPool [other parameters] [-TargetDedicated <Int32>]

# New
New-AzureBatchPool [other parameters] [-TargetDedicatedComputeNodes <Int32>] [-TargetLowPriorityComputeNodes <Int32>]
```

This also impacts: Start-AzureBatchPoolResize

### **Get-AzureBatchPool**
 - Renamed the `TargetDedicated` and `CurrentDedicated` properties on `PSCloudPool` to `TargetDedicatedComputeNodes` and `CurrentDedicatedComputeNodes`.

```powershell
# Old
$pool = Get-AzureBatchPool [parameters]
$pool.TargetDedicated
$pool.CurrentDedicated

# New
$pool = Get-AzureBatchPool [parameters]
$pool.TargetDedicatedComputeNodes
$pool.CurrentDedicatedComputeNodes
```

### **Type PSCloudPool**

- Renamed `ResizeError` to `ResizeErrors` on `PSCloudPool`, and it is now a collection.

```powershell
# Old
$pool = Get-AzureBatchPool [parameters]
$pool.ResizeError

# New
$pool = Get-AzureBatchPool [parameters]
$pool.ResizeErrors[0]
```

### **New-AzureBatchJob**
- Renamed the `TargetDedicated` property on `PSPoolSpecification` to `TargetDedicatedComputeNodes`.

```powershell
# Old
$poolInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
$poolInfo.AutoPoolSpecification = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
$poolInfo.AutoPoolSpecification.PoolSpecification = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
$poolInfo.AutoPoolSpecification.PoolSpecification.TargetDedicated = 5
New-AzureBatchJob [other parameters] -PoolInformation $poolInfo

# New
$poolInfo = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolInformation
$poolInfo.AutoPoolSpecification = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoPoolSpecification
$poolInfo.AutoPoolSpecification.PoolSpecification = New-Object Microsoft.Azure.Commands.Batch.Models.PSPoolSpecification
$poolInfo.AutoPoolSpecification.PoolSpecification.TargetDedicatedComputeNodes = 5
New-AzureBatchJob [other parameters] -PoolInformation $poolInfo
```

### **Get-AzureBatchNodeFile**
 - Removed `Name` and replaced it with `Path`.
 - `Path` has an alias `Name`.

```powershell
# Old
Get-AzureBatchNodeFile [other parameters] [[-Name] <String>]

# New
Get-AzureBatchNodeFile [other parameters] [[-Path] <String>]
```

This also impacts: Get-AzureBatchNodeFileContent, Remove-AzureBatchNodeFile

### Type **PSNodeFile**

 - Renamed the `Name` property on `PSNodeFile` to `Path`.

```powershell
# Old
$file = Get-AzureBatchNodeFile [parameters]
$file.Name

# New
$file = Get-AzureBatchNodeFile [parameters]
$file.Path
```

### **Get-AzureBatchSubtask**
- The `PreviousState` and `State` properties of `PSSubtaskInformation` are no longer of type `TaskState`, instead they are of type `SubtaskState`.
  - Unlike `TaskState`, `SubtaskState` has no `Active` value, since it is not possible for subtasks to be in an `Active` state.

```powershell
# Old
$subtask = Get-AzureBatchSubtask [parameters]
if ($subtask.State -eq Microsoft.Azure.Batch.Common.TaskState.Running) { }

# New
$subtask = Get-AzureBatchSubtask [parameters]
if ($subtask.State -eq Microsoft.Azure.Batch.Common.SubtaskState.Running) { }
```

## Breaking changes to Compute cmdlets

### **Set-AzureRmVMAccessExtension**
- Parameters "UserName" and "Password" are being replaced in favor of a PSCredential

```powershell
# Old
Set-AzureRmVMAccessExtension [other required parameters] -UserName "plain-text string" -Password "plain-text string"

# New
Set-AzureRmVMAccessExtension [other required parameters] -Credential $PSCredential
```

## Breaking changes to EventHub cmdlets

### **New-AzureRmEventHubNamespaceAuthorizationRule**
- The 'New-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmEventHubAuthorizationRule' cmdlet
	
### **Get-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Get-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmEventHubAuthorizationRule' cmdlet
	
### **Set-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Set-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmEventHubAuthorizationRule' cmdlet
	
### **Remove-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Remove-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmEventHubAuthorizationRule' cmdlet
	
### **New-AzureRmEventHubNamespaceKey**
- The 'New-AzureRmEventHubNamespaceKey' cmdlet has been removed. Please use the 'New-AzureRmEventHubKey' cmdlet
	
### **Get-AzureRmEventHubNamespaceKey**
- The 'Get-AzureRmEventHubNamespaceKey' cmdlet has been removed. Please use the 'Get-AzureRmEventHubKey' cmdlet
	
### **New-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property  
$namespace = New-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Get-AzureRmEventHubNamespace <parameters>
```
	
### **Get-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property 
$namespace = Get-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Get-AzureRmEventHubNamespace <parameters>
```
	
### **Set-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property 
$namespace = Set-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Set-AzureRmEventHubNamespace <parameters>
```	
  
### **New-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
```
	
### **Set-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
```
	
### **Get-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
```

## Breaking changes to Insights cmdlets

### **Add-AzureRMLogAlertRule**
- The **Add-AzureRMLogAlertRule** cmdlet has been deprecated
- After October 1st using this cmdlet will no longer have any effect as this functionality is being transitioned to Activity Log Alerts. Please see https://aka.ms/migratemealerts for more information.

### **Get-AzureRMUsage**
- The **Get-AzureRMUsage** cmdlet has been deprecated

### **Get-AzureRmAlertHistory** / **Get-AzureRmAutoscaleHistory** / **Get-AzureRmLogs**
- Output change: The field EventChannels from the EventData object (returned by these cmdlets) is being deprecated since it now returns a constant value (Admin,Operation.)

### **Get-AzureRmAlertRule**
- Output change: The output of this cmdlet will be flattened, i.e. elimination of the properties field, to improve the user experience.

```powershell
# Old
$rules = Get-AzureRmAlertRule -ResourceGroup $resourceGroup
if ($rules -and $rules.count -ge 1)
{
	Write-Host -Foreground Red "Error updating alert rule"
	Write-Host $rules[0].Id
	Write-Host $rules[0].Properties.IsEnabled
	Write-Host $rules[0].Properties.Condition
}

# New
$rules = Get-AzureRmAlertRule -ResourceGroup $resourceGroup
if ($rules -and $rules.count -ge 1)
{
	Write-Host -Foreground red "Error updating alert rule"
	Write-Host $rules[0].Id

	# Properties will remain for a while
	Write-Host $rules[0].Properties.IsEnabled
      
	# But the properties will be at the top level too. Later Properties will be removed
	Write-Host $rules[0].IsEnabled
	Write-Host $rules[0].Condition
}
```

### **Get-AzureRmAutoscaleSetting**
- Output change: The AutoscaleSettingResourceName field will be deprecated since it always equals the Name field.

```powershell
# Old
$s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
if ($s1.AutoscaleSettingResourceName -ne $s1.Name)
{
	Write-Host "There is something wrong with the name"
}

# New
$s1 = Get-AzureRmAutoscaleSetting -ResourceGroup $resourceGroup -Name MySetting
    
# there won't be a AutoscaleSettingResourceName
Write-Host $s1.Name    
```

### **Remove-AzureRmAlertRule** / **Remove-AzureRmLogProfile**
- Output change: The type of the output will change to return a single object containing the request Id and the status code.

```powershell
# Old
$s1 = Remove-AzureRmAlertRule -ResourceGroup $resourceGroup -name $ruleName
if ($s1 -ne $null)
{
	$r = $s1[0].RequestId
	$s = $s1[0].StatusCode
}

# New
$s1 = Remove-AzureRmAlertRule -ResourceGroup $resourceGroup -name $ruleName
$r = $s1.RequestId
$s = $s1.StatusCode
```

## Breaking changes to Network cmdlets

### **Add-AzureRmApplicationGatewaySslCertificate**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
Add-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password "plain-text string"

# New
Add-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmApplicationGatewaySslCertificate**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password "plain-text string"

# New
New-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password $SecureStringVariable
```

### **Set-AzureRmApplicationGatewaySslCertificate**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
Set-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password "plain-text string"

# New
Set-AzureRmApplicationGatewaySslCertificate [other required parameters] -Password $SecureStringVariable
```

## Breaking changes to Resources cmdlets

### **New-AzureRmADAppCredential**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmADAppCredential [other required parameters] -Password "plain-text string"

# New
New-AzureRmADAppCredential [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADApplication**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmADApplication [other required parameters] -Password "plain-text string"

# New
New-AzureRmADApplication [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADServicePrincipal**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmADServicePrincipal [other required parameters] -Password "plain-text string"

# New
New-AzureRmADServicePrincipal [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADSpCredential**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmADSpCredential [other required parameters] -Password "plain-text string"

# New
New-AzureRmADSpCredential [other required parameters] -Password $SecureStringVariable
```

### **New-AzureRmADUser**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
New-AzureRmADUser [other required parameters] -Password "plain-text string"

# New
New-AzureRmADUser [other required parameters] -Password $SecureStringVariable
```

### **Set-AzureRmADUser**
- Parameter "Password" being replaced in favor of a SecureString

```powershell
# Old
Set-AzureRmADUser [other required parameters] -Password "plain-text string"

# New
Set-AzureRmADUser [other required parameters] -Password $SecureStringVariable
```

## Breaking changes to ServiceBus cmdlets

### **Get-AzureRmServiceBusTopicAuthorizationRule**
- The 'Get-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.	

### **Get-AzureRmServiceBusTopicKey**
- The 'Get-AzureRmServiceBusTopicKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

### **New-AzureRmServiceBusTopicAuthorizationRule**
- The 'New-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

### **New-AzureRmServiceBusTopicKey**
- The 'New-AzureRmServiceBusTopicKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

### **Remove-AzureRmServiceBusTopicAuthorizationRule**
- The 'Remove-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Set-AzureRmServiceBusTopicAuthorizationRule**
- The 'Set-AzureRmServiceBusTopicAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule'cmdlet.

### **New-AzureRmServiceBusNamespaceKey**
- The 'New-AzureRmServiceBusNamespaceKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

### **Get-AzureRmServiceBusQueueAuthorizationRule**
- The 'Get-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Get-AzureRmServiceBusQueueKey**
- The 'Get-AzureRmServiceBusQueueKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

### **New-AzureRmServiceBusQueueAuthorizationRule**
- The 'New-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

### **New-AzureRmServiceBusQueueKey**
- The 'New-AzureRmServiceBusQueueKey' cmdlet has been removed. Please use the 'New-AzureRmServiceBusKey' cmdlet.

### **Remove-AzureRmServiceBusQueueAuthorizationRule**
- The 'Remove-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'GRemove-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Set-AzureRmServiceBusQueueAuthorizationRule**
- The 'Set-AzureRmServiceBusQueueAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Get-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Get-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Get-AzureRmServiceBusNamespaceKey**
- The 'Get-AzureRmServiceBusNamespaceKey' cmdlet has been removed. Please use the 'Get-AzureRmServiceBusKey' cmdlet.

### **New-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'New-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Remove-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Remove-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Set-AzureRmServiceBusNamespaceAuthorizationRule**
- The 'Set-AzureRmServiceBusNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmServiceBusAuthorizationRule' cmdlet.

### **Type NamespaceAttributes**
- The following properties have been removed
    - Enabled
    - Status
   
```powershell
# Old
# The $namespace has Status and Enabled property 
$namespace = Get-AzureRmServiceBusNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Enabled and Status properties    
$namespace = Get-AzureRmServiceBusNamespace <parameters>
```

### **Type QueueAttribute**
- The following properties are marked as obsolete:
    - EnableBatchedOperations
    - EntityAvailabilityStatus
    - IsAnonymousAccessible
    - SupportOrdering

```powershell
# Old
# The $queue has EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties
$queue = Get-AzureRmServiceBusQueue <parameters>
$queue.EntityAvailabilityStatus
$queue.EnableBatchedOperations
$queue.IsAnonymousAccessible
$queue.SupportOrdering	

# New
# The call remains the same, but the returned values Queue object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$queue = Get-AzureRmServiceBusQueue <parameters>
```
   
### **Type TopicAttribute**
- The following properties are marked as obsolete:
    - Location
    - IsExpress
    - IsAnonymousAccessible
    - FilteringMessagesBeforePublishing
    - EnableSubscriptionPartitioning
    - EntityAvailabilityStatus

```powershell
# Old
# The $topic has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing properties
$topic = Get-AzureRmServiceBusTopic <parameters>
$topic.EntityAvailabilityStatus
$topic.EnableSubscriptionPartitioning
$topic.IsAnonymousAccessible
$topic.IsExpress
$topic.FilteringMessagesBeforePublishing
$topic.Location

# New
# The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$topic = Get-AzureRmServiceBusTopic <parameters>
```
   
### **Type SubscriptionAttribute**
- The following properties are marked as obsolete
    - DeadLetteringOnFilterEvaluationExceptions
    - EntityAvailabilityStatus
    - IsReadOnly
    - Location
   
```powershell
# Old
# The $subscription has EntityAvailabilityStatus, EnableSubscriptionPartitioning, IsAnonymousAccessible, IsExpress, Location and FilteringMessagesBeforePublishing properties
$subscription = Get-AzureRmServiceBussubscription <parameters>
$subscription.EntityAvailabilityStatus
$subscription.EnableSubscriptionPartitioning
$subscription.IsAnonymousAccessible
$subscription.IsExpress
$subscription.FilteringMessagesBeforePublishing
$subscription.Location

# New
# The call remains the same, but the returned values Topic object will not have the EntityAvailabilityStatus, EnableBatchedOperations, IsAnonymousAccessible and SupportOrdering properties    
$subscription = Get-AzureRmServiceBussubscription <parameters>
```