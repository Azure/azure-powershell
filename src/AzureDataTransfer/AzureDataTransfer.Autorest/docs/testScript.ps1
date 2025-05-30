# Script to setup test env

$pipelineName =  "corptest"
$location = "eastus"
$rgName = "rpaas-rg"
$subId = "389ff96a-b137-405b-a3c8-4d22514708b5"
$connectionToApprove = "test-connection-to-approve-1"
$connectionApproved = "test-approved-connection-1"
$connectionApprovedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionApproved"
$connectionRejected = "test-rejected-connection-1"
$connectionRejectedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionRejected"

$connectionSendPending = "test-send-pending-connection-1"

$connectionLinked = "test-linked-connection-1"
$connectionLinkedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionLinked"

$connectionLinkedSend = "test-linked-send-connection-1"
$connectionLinkedSendId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionLinkedSend"

$storageAccountName = "/subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg-faikh/providers/Microsoft.Storage/storageAccounts/armstrongtest"
$storageContainerName = "armstrong-test-container"

$testRecvFlow = "test-recv-flow-1"
$testSendFlow = "test-send-flow-1"
$testSendFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionLinkedSend/flows/$testSendFlow"

$testEnabledFlow = "test-recv-enabled-flow-1"
$testDisabledFlow = "test-send-disabled-flow-1"
$testEnabledFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionLinked/flows/$testEnabledFlow"
$testDisabledFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Microsoft.AzureDataTransfer/connections/$connectionLinkedSend/flows/$testDisabledFlow"

$pendingFlowName = "test-pending-flow-1"

$connectionParams = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = $subId
    RequirementId        = 0
    Name                 = $connectionToApprove
    PrimaryContact       = "test@microsoft.com"
}
    
New-AzDataTransferConnection @connectionParams

####################################################################################
####################################################################################

$connectionParamsApproved = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = $subId
    RequirementId        = 0
    Name                 = $connectionApproved
    PrimaryContact       = "test@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsApproved

Approve-AzDataTransferConnection -ConnectionId $connectionApprovedId -StatusReason "Approving for PS testing" -ResourceGroupName  $rgName -PipelineName  $pipelineName

####################################################################################
####################################################################################

$connectionParamsDenied = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = $subId
    RequirementId        = 0
    Name                 = $connectionRejected
    PrimaryContact       = "test@microsoft.com"
}

New-AzDataTransferConnection @connectionParamsDenied

Deny-AzDataTransferConnection -ConnectionId $connectionRejectedId -StatusReason "Rejecting for PS testing" -ResourceGroupName  $rgName -PipelineName  $pipelineName

####################################################################################
####################################################################################

$connectionParamsLinked = @{
    Location             =  $location
    PipelineName         =  $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    =  $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId =  $subId
    RequirementId        = 0
    Name                 = $connectionLinked
    PrimaryContact       = "test@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsLinked

Approve-AzDataTransferConnection -ConnectionId $connectionLinkedId -StatusReason "Approving for PS testing" -ResourceGroupName  $rgName -PipelineName  $pipelineName

$connectionToLink = Get-AzDataTransferConnection -ResourceGroupName  $rgName  -ConnectionName $connectionLinked

$connectionParamsSendLinked = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Send"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Send side for PS testing"
    Name                 = $connectionLinkedSend
    PrimaryContact       = "test@microsoft.com"
    PIN                  = $connectionToLink.PIN
}

New-AzDataTransferConnection @connectionParamsSendLinked

Invoke-AzDataTransferLinkPendingConnection -PendingConnectionId $connectionLinkedSendId -ResourceGroupName  $rgName -ConnectionName $connectionLinked -StatusReason "Linking for PS testing"


### pending connection ####
$appovedConnection = Get-AzDataTransferConnection -ResourceGroupName  $rgName  -ConnectionName $connectionApproved

$connectionParamsSendPending = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Send"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Send side for PS testing"
    Name                 = $connectionSendPending
    PrimaryContact       = "test@microsoft.com"
    PIN                  = $appovedConnection.PIN
}

New-AzDataTransferConnection @connectionParamsSendPending
####################################################################################
####################################################################################

##### Create flows ########

$recvFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinked
    Name                  = $testRecvFlow
    Location              = $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}

New-AzDataTransferFlow @recvFlowParams


$sendFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinkedSend
    Name                  = $testSendFlow
    Location              = $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}
 
New-AzDataTransferFlow @sendFlowParams

Invoke-AzDataTransferLinkPendingFlow -PendingFlowId $testSendFlowId -ResourceGroupName  $rgName -FlowName $testRecvFlow -StatusReason "Linking for PS testing" -ConnectionName $connectionLinked

####################################################################################
####################################################################################

$enabledFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinked
    Name                  = $testEnabledFlow
    Location              =  $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}
 
New-AzDataTransferFlow @enabledFlowParams


$disabledFlowParams = @{
    ResourceGroupName     =  $rgName
    ConnectionName        = $connectionLinkedSend
    Name                  = $testDisabledFlow
    Location              =  $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}

New-AzDataTransferFlow @disabledFlowParams

Invoke-AzDataTransferLinkPendingFlow -PendingFlowId $testDisabledFlowId -ResourceGroupName  $rgName -FlowName $testEnabledFlow -StatusReason "Linking for PS testing" -ConnectionName $connectionLinked

Enable-AzDataTransferFlow -ResourceGroupName  $rgName -FlowName $testEnabledFlow -ConnectionName $connectionLinked

Disable-AzDataTransferFlow -ResourceGroupName  $rgName -FlowName $testDisabledFlow -ConnectionName $connectionLinkedSend

### pending flow ###

$pendingFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinkedSend
    Name                  = $pendingFlowName
    Location              = $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}

New-AzDataTransferFlow @pendingFlowParams
