# Script to setup test env

## Connection to approve

$pipelineName =  "corptest"
$location = "eastus"
$rgName = "rpaas-rg"
$subId = "389ff96a-b137-405b-a3c8-4d22514708b5"
$connectionToApprove = "faikh-connection-to-approve-2"
$connectionApproved = "faikh-test-approved-connection-1"
$connectionApprovedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionApproved"
$connectionRejected = "faikh-test-rejected-connection-1"
$connectionRejectedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionRejected"

$connectionLinked = "faikh-test-linked-connection-1"
$connectionLinkedId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionLinked"

$connectionLinkedSend = "faikh-test-linked-send-connection-1"
$connectionLinkedSendId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionLinkedSend"


$storageAccountName = "/subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg-faikh/providers/Microsoft.Storage/storageAccounts/armstrongtest"
$storageContainerName = "armstrong-test-container"

$faikhRecvFlow = "faikh-recv-flow-1"
$faikhSendFlow = "faikh-send-flow-1"
$faikhSendFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionLinkedSend/flows/$faikhSendFlow"


$faikhEnabledFlow = "faikh-recv-enabled-flow-1"
$faikhDisabledFlow = "faikh-send-disabled-flow-1"
$faikhEnabledFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionLinked/flows/$faikhEnabledFlow"
$faikhDisabledFlowId = "/subscriptions/$subId/resourceGroups/$rgName/providers/Private.AzureDataTransfer/connections/$connectionLinkedSend/flows/$faikhDisabledFlow"

$connectionParams = @{
       Location             =  $location
       PipelineName         =  $pipelineName
       Direction            = "Receive"
       FlowType             = "Mission"
       ResourceGroupName    =  $rgName
       Justification        = "Receive side for PS testing"
       RemoteSubscriptionId =  $subId
       RequirementId        = 0
       Name                 = $connectionToApprove
       PrimaryContact       = "faikh@microsoft.com"
    }
    
New-AzDataTransferConnection @connectionParams

####################################################################################
####################################################################################

$connectionParamsApproved = @{
    Location             =  $location
    PipelineName         =  $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    =  $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId =  $subId
    RequirementId        = 0
    Name                 = $connectionApproved
    PrimaryContact       = "faikh@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsApproved

Approve-AzDataTransferConnection -ConnectionId $connectionApprovedId -StatusReason "Approving for PS testing" -ResourceGroupName  $rgName -PipelineName  $pipelineName

####################################################################################
####################################################################################

$connectionParamsDenied = @{
    Location             =  $location
    PipelineName         =  $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    =  $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId =  $subId
    RequirementId        = 0
    Name                 = $connectionRejected
    PrimaryContact       = "faikh@microsoft.com"
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
    PrimaryContact       = "faikh@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsLinked

Approve-AzDataTransferConnection -ConnectionId $connectionLinkedId -StatusReason "Approving for PS testing" -ResourceGroupName  $rgName -PipelineName  $pipelineName

$connectionToLink = Get-AzDataTransferConnection -ResourceGroupName  $rgName  -ConnectionName $connectionLinked

$connectionParamsSendLinked = @{
    Location             =  $location
    PipelineName         =  $pipelineName
    Direction            = "Send"
    FlowType             = "Mission"
    ResourceGroupName    =  $rgName
    Justification        = "Send side for PS testing"
    Name                 = $connectionLinkedSend
    PrimaryContact       = "faikh@microsoft.com"
    PIN                  = $connectionToLink.PIN
}

New-AzDataTransferConnection @connectionParamsSendLinked

Invoke-AzDataTransferLinkPendingConnection -PendingConnectionId $connectionLinkedSendId -ResourceGroupName  $rgName -ConnectionName $connectionLinked -StatusReason "Linking for PS testing"

####################################################################################
####################################################################################

##### Create flows ########

$recvFlowParams = @{
       ResourceGroupName     =  $rgName
       ConnectionName        = $connectionLinked
       Name                  = $faikhRecvFlow
       Location              =  $location
       FlowType              = "Mission"
       DataType              = "Blob"
       StorageAccountName    = $storageAccountName
       StorageContainerName  = $storageContainerName
    }
    
New-AzDataTransferFlow @recvFlowParams


$sendFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinkedSend
    Name                  = $faikhSendFlow
    Location              = $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
 }
 
New-AzDataTransferFlow @sendFlowParams

Invoke-AzDataTransferLinkPendingFlow -PendingFlowId $faikhSendFlowId -ResourceGroupName  $rgName -FlowName $faikhRecvFlow -StatusReason "Linking for PS testing" -ConnectionName $connectionLinked

####################################################################################
####################################################################################

$enabledFlowParams = @{
    ResourceGroupName     = $rgName
    ConnectionName        = $connectionLinked
    Name                  = $faikhEnabledFlow
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
    Name                  = $faikhDisabledFlow
    Location              =  $location
    FlowType              = "Mission"
    DataType              = "Blob"
    StorageAccountName    = $storageAccountName
    StorageContainerName  = $storageContainerName
}

New-AzDataTransferFlow @disabledFlowParams

Invoke-AzDataTransferLinkPendingFlow -PendingFlowId $faikhDisabledFlowId -ResourceGroupName  $rgName -FlowName $faikhEnabledFlow -StatusReason "Linking for PS testing" -ConnectionName $connectionLinked

Enable-AzDataTransferFlow -ResourceGroupName  $rgName -FlowName $faikhEnabledFlow -ConnectionName $connectionLinked

Disable-AzDataTransferFlow -ResourceGroupName  $rgName -FlowName $faikhDisabledFlow -ConnectionName $connectionLinkedSend
