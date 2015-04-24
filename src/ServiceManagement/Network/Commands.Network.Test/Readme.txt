In order to record these scenario tests, the following features must be enabled in RDFE for the test subscription:

NetworkSecurityGroup
NetworkSecurityGroupV2
Routes
UserDefinedRoutes
IPForwarding

If you receive the following error:

"Set-AzureVNetConfig : BadRequest : An error occurred when setting the network configuration: The virtual network VirtualNetworkSiteName is currently in use."

that's because the de-allocation of the VM hasn't finished even after deleting it in RDFE. Call

# warning: this deletes all services in the subscription
Get-AzureService | Remove-AzureService -DeleteAll -Force

Wait for a few minutes and execute the failing test again.
