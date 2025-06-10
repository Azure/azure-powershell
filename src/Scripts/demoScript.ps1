# 1. Connect to Azure Account
# Connect-AzAccount -UseDeviceAuthentication

####################################################################################
####################################################################################

# 2. Local variables for the demo script

$pipelineName =  "corptest"
$location = "eastus"
$rgName = "rpaas-rg"
$subId = "389ff96a-b137-405b-a3c8-4d22514708b5"


####################################################################################
####################################################################################

# 3. Create a new Data Transfer Connection for receive side
$connectionParams = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Receive"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Receive side for PS testing"
    RemoteSubscriptionId = $subId
    RequirementId        = 0
    Name                 = "faikh-demo-recv-1"
    PrimaryContact       = "test@microsoft.com"
}

$recvConnection = New-AzDataTransferConnection @connectionParams

####################################################################################
####################################################################################

# 4. Approve the Data Transfer Connection and get the PIN
$approvedRecvConnection = Approve-AzDataTransferConnection -ConnectionId $recvConnection.Id -StatusReason "Approving for demo" -ResourceGroupName  $rgName -PipelineName  $pipelineName

####################################################################################
####################################################################################

# 5. Create a new Data Transfer Connection for SEND side using the PIN from the approved receive connection

$connectionParamsSend = @{
    Location             = $location
    PipelineName         = $pipelineName
    Direction            = "Send"
    FlowType             = "Mission"
    ResourceGroupName    = $rgName
    Justification        = "Send side for PS testing"
    Name                 = "faikh-demo-send-1"
    PrimaryContact       = "test@microsoft.com"
    PIN                  = $approvedRecvConnection.PIN
}

$sendConnection = New-AzDataTransferConnection @connectionParamsSend

####################################################################################
####################################################################################

# 6. Link the pending connection (send connection) to the approved receive connection
Invoke-AzDataTransferLinkPendingConnection -PendingConnectionId $sendConnection.Id -ResourceGroupName $rgName -ConnectionName $recvConnection.Name -StatusReason "Linking for demo"


####################################################################################
####################################################################################
# 7. Clean up the demo connections

# Remove-AzDataTransferConnection -ResourceGroupName $rgName -ConnectionName $recvConnection.Name
# Remove-AzDataTransferConnection -ResourceGroupName $rgName -ConnectionName $sendConnection.Name