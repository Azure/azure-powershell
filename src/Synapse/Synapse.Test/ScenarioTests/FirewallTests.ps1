<#
.SYNOPSIS
Tests Synapse Firewall Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseFirewall
{
    param
    (
        $resourceGroupName = (Get-ResourceGroupName),
        $workspaceName = (Get-SynapseWorkspaceName)
    )

    try
    {
        $resourceGroupName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("resourceGroupName", $resourceGroupName)
        $workspaceName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable("workspaceName", $workspaceName)
        $workspace = Get-AzSynapseWorkspace -resourceGroupName $resourceGroupName -Name $workspaceName
		$firewallRuleName = "originRuleName"
		$StartIpAddress = "0.0.0.0"
		$NewStartIpAddress = "10.0.0.0"
		$EndIpAddress = "255.255.255.255"
	    $NewEndIpAddress = "255.0.0.0"
		$SucessState = "Succeeded"
		
		# create firewall
		$firewallCreated = New-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $firewallRuleName  -StartIpAddress $StartIpAddress  -EndIpAddress $EndIpAddress

        Assert-AreEqual $StartIpAddress $firewallCreated.StartIpAddress
        Assert-AreEqual $EndIpAddress $firewallCreated.EndIpAddress

		# Wait for 10 seconds for the create completion
		[Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities]::Wait(10000)

		# List firewall
		$firewallList = Get-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName 
		Assert-NotNull  $firewallList

		# Get firewall
		$firewallGet = Get-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $firewallRuleName 
		Assert-AreEqual $SucessState $firewallGet.ProvisioningState
		Assert-AreEqual $StartIpAddress $firewallGet.StartIpAddress
        Assert-AreEqual $EndIpAddress $firewallGet.EndIpAddress

		# Update firewall
		$firewallUpdate = Update-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $firewallRuleName -StartIpAddress $NewStartIpAddress  -EndIpAddress $NewEndIpAddress
        Assert-AreEqual $NewStartIpAddress $firewallUpdate.StartIpAddress
        Assert-AreEqual $NewEndIpAddress $firewallUpdate.EndIpAddress

        # Delete firewall
        Assert-True {Remove-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $firewallRuleName -PassThru} "Remove firewall rule failed"
	}
    finally
    {
        # cleanup the firewallRuleName created by test code.      
    }
}
