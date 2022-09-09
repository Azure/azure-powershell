<#
.SYNOPSIS
Tests Synapse Firewall Lifecycle (Create, Update, Get, List, Delete).
#>
function Test-SynapseFirewall
{
	# Setup
	$testSuffix = getAssetName
	Create-FirewallRuleTestEnvironment $testSuffix
	$params = Get-FirewallRuleTestEnvironmentParameters $testSuffix

    $resourceGroupName = $params.rgname
    $workspaceName = $params.workspaceName

    try
    {
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
        Assert-True {Remove-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $firewallRuleName -PassThru -Force} "Remove firewall rule failed"

        # create firewall rule to allow all Azure IP
        $firewallCreated = New-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -AllowAllAzureIp
        Assert-AreEqual "0.0.0.0" $firewallCreated.StartIpAddress
        Assert-AreEqual "0.0.0.0" $firewallCreated.EndIpAddress

        $firewallCreated = New-AzSynapseFirewallRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -AllowAllIp
        Assert-AreEqual "0.0.0.0" $firewallCreated.StartIpAddress
        Assert-AreEqual "255.255.255.255" $firewallCreated.EndIpAddress
	}
    finally
    {
		# Cleanup
		Remove-FirewallRuleTestEnvironment $testSuffix
    }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-FirewallRuleTestEnvironment ($testSuffix)
{
	$params = Get-FirewallRuleTestEnvironmentParameters $testSuffix
	Create-TestEnvironmentWithParams $params $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the tests
#>
function Get-FirewallRuleTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "fw-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "fw" +$testSuffix;
			  storageAccountName = "fwstorage" + $testSuffix;
			  fileSystemName = "fwcmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
              location = "eastus";
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-FirewallRuleTestEnvironment ($testSuffix)
{
	$params = Get-FirewallRuleTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}
