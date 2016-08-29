$resourceGroupName = "sdktest"
$location = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::Location
$recording = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::Recording
$installed = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::GatewayServiceInstalled 
$admin = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::IsAdmin 
$nodeName= [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::NodeName 
$nodePassword = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::NodePassword
$nodeUserName = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::NodeUserName
$sessionId= [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::SessionId

$creds = New-Object System.Management.Automation.PSCredential -ArgumentList $nodeUserName, (ConvertTo-SecureString $nodePassword -AsPlainText -Force)

function Ensure-GatewayIsCorrectlyConfigured {
	$GatewayName = "mygateway"

	if ($recording)  {
		# gateway service must be installed on recording machine for this stuff to work.

		# check to see if the gateway service is actually installed.
		Assert-True { $installed } "Gateway Service Is Not Installed on this computer."

		# and that we are actually admin
		Assert-True { $admin } "Recording for this test requires an elevated process."

		# and let's make sure that the gateway is created in the RP
		Write-Verbose "Getting gateway $gatewayName"
		$gateway = Get-AzureRmServerManagementGateway -ResourceGroupName $resourceGroupName -GatewayName $GatewayName -ea 0
		
		if( -not $gateway ) {
			# Well, don't panic, we can register the gateway and download and install the profile.
			Write-Verbose "Gateway $gatewayName is not registered in the RP; we're going to register it."
			

			Write-Verbose "Stopping Gateway Service."
			$null = stop-service ServerManagementToolsGateway -ea 0

			Write-Verbose "Creating Gateway in RP"
			$gateway = new-AzureRmServerManagementGateway -resourceGroupName $resourceGroupName -Location $location -gatewayname $GatewayName

			Write-Verbose "Resetting Profile for gateway $gatewayName"
			Reset-AzureRmServerManagementGatewayProfile $gateway 

			Write-Verbose "Downloading Profile for gateway $gatewayName"
			Save-AzureRmServerManagementGatewayProfile  $gateway -outputfile "$env:TMP\gatewayprofile.json"

			Write-Verbose "Checking for profile"
			assert-true { Test-Path "$env:TMP\gatewayprofile.json" } "Profile Does Not Exist!"

			Write-Verbose "Installing profile"
			Install-AzureRmServerManagementGatewayProfile  "$env:TMP\gatewayprofile.json" 
			
			Write-Verbose "Starting Gateway Service."
			$null = start-service ServerManagementToolsGateway -ea 0

			Write-Verbose "Waiting 3 minutes for Gateway Service to be in the correct state."
			sleep 180

			Write-Verbose "Getting Gateway Status."
			$gateway = new-AzureRmServerManagementGateway -resourceGroupName $resourceGroupName -Location $location -gatewayname $GatewayName

			$gateway | fl *
		}

		Write-Verbose "Last smoke check to make sure that $gatewayName is registered locally"
		Assert-NotNull $gateway 
	}
}

function Create-NodeForThisPC {
	$GatewayName = "mygateway"

	Write-Verbose "Getting gateway $gatewayName"
	$gateway = Get-AzureRmServerManagementGateway -ResourceGroupName $resourceGroupName -GatewayName $GatewayName -ea 0

	Assert-NotNull $gateway

	# make sure service is awake!
	$null = start-service ServerManagementToolsGateway -ea 0

	Write-Verbose "Create node for this PC via $( $gateway.Name )"
	$node = ($gateway | New-AzureRmServerManagementNode -NodeName $nodeName -Credential $creds )

	Write-Verbose "Verify that the node is good"
    Assert-NotNull $node 
	Assert-NotNull $node.Name 
	
	# Get same node by querying for it.
	Write-Verbose "Sanity Check - get the same node $( $node.Name ) for this PC"
	$tmp = ($node | GeT-AzureRmServerManagementNode )

	Assert-NotNull $tmp
	Assert-AreEqual $tmp.Name $node.Name
}


<#s
.SYNOPSIS
Tests create gateway.
#>
function Test-Gateway
{
    # resource group should exist

	# Ensure we get a gateway name for this test.
	$GatewayName = [Microsoft.Azure.Commands.ServerManagement.Test.ScenarioTests.ServerManagementTests]::GatewayName(1)

	 try {
	    Write-Verbose "Creating Gateway"
		$gateway = new-AzureRmServerManagementGateway -resourceGroupName $resourceGroupName -Location $location -gatewayname $GatewayName

		# did we get back an expected gateway?
		Write-Verbose "Verifying Gateway"
		Assert-NotNull $gateway
		Assert-AreEqual $gateway.Name $GatewayName
		Assert-AreEqual $gateway.Location $location
		Assert-AreEqual $gateway.AutoUpgrade "Off"

		# get object by object
		Write-Verbose "Getting Gateway by object"
		$gateway2 = Get-AzureRmServerManagementGateway  $gateway 

		# did that come back with an object?
		Write-Verbose "Verifying gateway by object"
		Assert-NotNull $gateway2
		Assert-AreEqual $gateway2.Name $gateway.Name
		Assert-AreEqual $gateway2.Location $gateway.Location

		# try with just text parameters
		Write-Verbose "Getting gateway by strings"
		$gateway2 = Get-AzureRmServerManagementGateway -ResourceGroupName $resourceGroupName -GatewayName $GatewayName

		# did that come back with an object?
		Write-Verbose "Verifying gateway by strings"
		Assert-NotNull $gateway2
		Assert-AreEqual $gateway2.Name $gateway.Name
		Assert-AreEqual $gateway2.Location $gateway.Location

		# try by pipeline
		Write-Verbose "Getting gateway by pipeline"
		$gateway | Get-AzureRmServerManagementGateway 

		# did that come back with an object?
		Write-Verbose "Verifying gateway by pipeline"
		Assert-NotNull $gateway2
		Assert-AreEqual $gateway2.Name $gateway.Name
		Assert-AreEqual $gateway2.Location $gateway.Location

		# delete the gateway we made
		Write-Verbose "Deleting Gateway"
		Remove-AzureRmServerManagementGateway $gateway

		# see if it is still there,
		Write-Verbose "Getting non-existant gateway by strings"
		Assert-Throws { Get-AzureRmServerManagementGateway -resourceGroupName $resourceGroupName -gatewayname $GatewayName }
		
	} finally {
	    # Remove all test gateways
		Get-AzureRmServerManagementGateway  -resourceGroupName $resourceGroupName |? { $_.name -match "test_gateway_" } | Remove-AzureRmServerManagementGateway

		# any left?
		$gateways = (Get-AzureRmServerManagementGateway  -resourceGroupName $resourceGroupName |? { $_.name -match "test_gateway_" })
		
		if( $gateways ) { 
			write-verbose "*sigh*"
			# assert the fail manually, since the framework doesn't properly interpret empty results as $false
			Assert-False { $true } "There should be no gateways called test_gateway_* still registered in the resource group $resourceGroupName" 
		}
	}
}

function Test-Node
{
    # resource group should exist
	# make sure that we have a proper gateway functioning on this computer.
	Ensure-GatewayIsCorrectlyConfigured

	try {
		$GatewayName = "mygateway"

		Write-Verbose "Getting gateway."
		$gateway = Get-AzureRmServerManagementGateway -ResourceGroupName $resourceGroupName -GatewayName $GatewayName -ea 0
		
		Write-Verbose "Verifying gateway is available."
		assert-notnull $gateway

		Write-Verbose "Creating an arbitrary node."
		$node = $gateway | New-AzureRmServerManagementNode -NodeName "testnode" -Credential $creds
		assert-notnull $node

		Write-Verbose "Retrieving the arbitrary node."
		$tmp = $node| Get-AzureRmServerManagementNode 
		assert-notnull $tmp

		Write-Verbose "Same node?"
		assert-areequal $node.Name $tmp.Name

	} finally {
		# Remove all test nodes
		$gateway  | Get-AzureRmServerManagementNode -ea 0 | Remove-AzureRmServerManagementNode
		
		$nodes = ($gateway | Get-AzureRmServerManagementNode -ea 0)

		Assert-Null $nodes
	}
}

function Test-Session
{
	# make sure that we have a proper gateway functioning on this computer.
	Ensure-GatewayIsCorrectlyConfigured

	try {
		Create-NodeForThisPC

		$node = GeT-AzureRmServerManagementNode -ResourceGroupName $resourceGroupName -NodeName $nodeName

		Write-Verbose "Verifying we have a node."
		Assert-NotNull $node

		Write-Verbose "Creating session for $sessionId/$($node.Name)/$($node.GetType())"
		$session = (New-AzureRmServerManagementSession $node -SessionName $sessionId -Credential $creds)
		
		Write-Verbose "Verifiyng session was created for $sessionId/$nodeUserName"
		Assert-NotNull $session
		Assert-AreEqual $nodeUserName $session.UserName 
				
		Write-Verbose "Invoke a powershell command."
		$results = ($session | Invoke-AzureRmServerManagementPowerShellCommand -Command { dir c:\ })

		Assert-NotNull $results
		Write-Verbose "Results: `n$results"

		Write-Verbose "Invoke a long-running powershell command."
		$results = ($session | Invoke-AzureRmServerManagementPowerShellCommand -Command { dir c:\ ; sleep 20 ; dir 'C:\Program Files' })

		Assert-NotNull $results
		Write-Verbose "Results: `n$results"

		# verify I can get the same session back
		Assert-NotNull $results ($session | Get-AzureRmServerManagementSession)

	} finally {
		Write-Verbose "Removing session"
		$session | Remove-AzureRmServerManagementSession

		Write-Verbose "Verifying session is not present"
		Assert-Throws { $session | Get-AzureRmServerManagementSession } 
	}
}
