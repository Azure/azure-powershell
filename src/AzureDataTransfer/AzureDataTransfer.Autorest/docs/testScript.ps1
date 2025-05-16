# Script to setup test env

## Connection to approve


$connectionParams = @{
       Location             = "westcentralus"
       PipelineName         = "ctsnewrppipeline"
       Direction            = "Receive"
       FlowType             = "Mission"
       ResourceGroupName    = "rpaas-rg"
       Justification        = "Receive side for PS testing"
       RemoteSubscriptionId = "389ff96a-b137-405b-a3c8-4d22514708b5"
       RequirementId        = 0
       Name                 = "faikh-connection-to-approve-1"
       PrimaryContact       = "faikh@microsoft.com"
    }
    
New-AzDataTransferConnection @connectionParams

####################################################################################
####################################################################################

$connectionParamsApproved = @{
    Location             = "westcentralus"
    PipelineName         = "ctsnewrppipeline"
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = "rpaas-rg"
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = "389ff96a-b137-405b-a3c8-4d22514708b5"
    RequirementId        = 0
    Name                 = "faikh-test-approved-connection-1"
    PrimaryContact       = "faikh@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsApproved

Approve-AzDataTransferConnection -ConnectionId /subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/faikh-test-approved-connection-1 -StatusReason "Approving for PS testing" -ResourceGroupName "rpaas-rg" -PipelineName "ctsnewrppipeline"

####################################################################################
####################################################################################

$connectionParamsDenied = @{
    Location             = "westcentralus"
    PipelineName         = "ctsnewrppipeline"
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = "rpaas-rg"
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = "389ff96a-b137-405b-a3c8-4d22514708b5"
    RequirementId        = 0
    Name                 = "faikh-test-rejected-connection-1"
    PrimaryContact       = "faikh@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsDenied

Deny-AzDataTransferConnection -ConnectionId /subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/faikh-test-rejected-connection-1 -StatusReason "Rejecting for PS testing" -ResourceGroupName "rpaas-rg" -PipelineName "ctsnewrppipeline"

####################################################################################
####################################################################################

$connectionParamsLinked = @{
    Location             = "westcentralus"
    PipelineName         = "ctsnewrppipeline"
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = "rpaas-rg"
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = "389ff96a-b137-405b-a3c8-4d22514708b5"
    RequirementId        = 0
    Name                 = "faikh-test-linked-connection-1"
    PrimaryContact       = "faikh@microsoft.com"
 }
 
New-AzDataTransferConnection @connectionParamsLinked

Approve-AzDataTransferConnection -ConnectionId /subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/faikh-test-linked-connection-1 -StatusReason "Approving for PS testing" -ResourceGroupName "rpaas-rg" -PipelineName "ctsnewrppipeline"

$connectionToLink = Get-AzDataTransferConnection -ResourceGroupName "rpaas-rg" -PipelineName "ctsnewrppipeline" -ConnectionName "faikh-test-linked-connection-1"

$connectionParamsSendLinked = @{
    Location             = "westcentralus"
    PipelineName         = "ctsnewrppipeline"
    Direction            = "Send"
    FlowType             = "Mission"
    ResourceGroupName    = "rpaas-rg"
    Justification        = "Send side for PS testing"
    Status               = "Approved"
    Name                 = "faikh-test-linked-send-connection-1"
    PrimaryContact       = "faikh@microsoft.com"
    PIN                  = $connectionToLink.PIN
}

New-AzDataTransferConnection @connectionParamsSendLinked

Invoke-AzDataTransferLinkPendingConnection -ConnectionId /subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/faikh-test-linked-send-connection-1 -ResourceGroupName "rpaas-rg" -PipelineName "ctsnewrppipeline" -ConnectionName "faikh-test-linked-connection-1" -StatusReason "Linking for PS testing"