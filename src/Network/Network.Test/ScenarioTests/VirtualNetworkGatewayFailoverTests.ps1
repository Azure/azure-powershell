<#
.SYNOPSIS
Tests the retrieval of resiliency information for a virtual network gateway.
.DESCRIPTION
This test assumes the virtual network gateway already exists and is properly configured.
#>
function Test-VirtualNetworkGatewayResiliencyInformation
{
    $rgName = "shubhati_failover"   # <-- Replace with actual resource group
    $vnetGatewayName = "shubhati_failoverGw"   # <-- Replace with actual gateway name

     #Safeguard: Skip test if the resource doesn't exist
    if (-not (Get-AzVirtualNetworkGateway -ResourceGroupName $rgName -Name $vnetGatewayName -ErrorAction SilentlyContinue)) {
        Write-Warning "Test skipped: Virtual Network Gateway '$vnetGatewayName' not found in RG '$rgName'."
        return
    }

    Write-Debug "Fetching resiliency information for Virtual Network Gateway: $vnetGatewayName in RG: $rgName"

    $resultJson = Get-AzVirtualNetworkGatewayResiliencyInformation `
        -ResourceGroupName $rgName `
        -VirtualNetworkGatewayName $vnetGatewayName `
        -AttemptRefresh:$true

    Write-Debug "`nResiliency Info JSON:"
    Write-Debug $resultJson

    # Assert that the result is not null
    Assert-NotNull $resultJson "The resiliency information result is null."

    Write-Debug "`nTest completed successfully."
}

<#
.SYNOPSIS
Tests the retrieval of route information for a virtual network gateway.
.DESCRIPTION
This test assumes the virtual network gateway already exists and is properly configured.
#>
function Test-VirtualNetworkGatewayRoutesInformation
{
    $rgName = "shubhati_failover"   # <-- Replace with actual resource group
    $vnetGatewayName = "shubhati_failoverGw"   # <-- Replace with actual gateway name

    # Safeguard: Skip test if the resource doesn't exist
    if (-not (Get-AzVirtualNetworkGateway -ResourceGroupName $rgName -Name $vnetGatewayName -ErrorAction SilentlyContinue)) {
        Write-Warning "Test skipped: Virtual Network Gateway '$vnetGatewayName' not found in RG '$rgName'."
        return
    }

    Write-Host "Fetching route information for Virtual Network Gateway: $vnetGatewayName in RG: $rgName"

    # Fetch route information
    $resultJson = Get-AzVirtualNetworkGatewayRoutesInformation `
        -ResourceGroupName $rgName `
        -VirtualNetworkGatewayName $vnetGatewayName

    Write-Debug "`nRoute Information JSON:"
    Write-Debug $resultJson

    # Assert that the result is not null
    Assert-NotNull $resultJson "The route information result is null."

    Write-Debug "`nTest completed successfully."
}

<#
.SYNOPSIS
Tests the start of the virtual network gateway site failover.
.DESCRIPTION
This test triggers the start of a site failover on a virtual network gateway. It assumes the resources are pre-created.
#>
function Test-StartAzureVirtualNetworkGatewaySiteFailoverTest
{
    $rgName = "shubhati_failover"   # <-- Replace with actual resource group
    $vnetGatewayName = "shubhati_failoverGw"   # <-- Replace with actual gateway name
    $peeringLocation = "London2"   # <-- Replace with actual peering location

    # Safeguard: Skip test if the resource doesn't exist
    if (-not (Get-AzVirtualNetworkGateway -ResourceGroupName $rgName -Name $vnetGatewayName -ErrorAction SilentlyContinue)) {
        Write-Warning "Test skipped: Virtual Network Gateway '$vnetGatewayName' not found in RG '$rgName'."
        return
    }

    Write-Debug "Starting failover test for Virtual Network Gateway: $vnetGatewayName in RG: $rgName"

    # Start failover test
    $resultFailover = Start-AzVirtualNetworkGatewaySiteFailoverTest `
        -ResourceGroupName $rgName `
        -VirtualNetworkGatewayName $vnetGatewayName `
        -PeeringLocation $peeringLocation `
        -Type "SingleSiteFailover"

    Write-Debug "`nFailover Test Result:"
    Write-Debug $resultFailover

    # Assert that the result is not null
    Assert-NotNull $resultFailover "The failover test result is null."

    Write-Debug "`nFailover Test started successfully."
}

<#
.SYNOPSIS
Tests the stop of the virtual network gateway site failover.
.DESCRIPTION
This test triggers the stop of a site failover on a virtual network gateway. It assumes the resources are pre-created.
#>
function Test-StopAzureVirtualNetworkGatewaySiteFailoverTest
{
    $rgName = "shubhati_failover"   # <-- Replace with actual resource group
    $vnetGatewayName = "shubhati_failoverGw"   # <-- Replace with actual gateway name
    $peeringLocation = "London2"   # <-- Replace with actual peering location

    # Safeguard: Skip test if the resource doesn't exist
    if (-not (Get-AzVirtualNetworkGateway -ResourceGroupName $rgName -Name $vnetGatewayName -ErrorAction SilentlyContinue)) {
        Write-Warning "Test skipped: Virtual Network Gateway '$vnetGatewayName' not found in RG '$rgName'."
        return
    }

    Write-Debug "Waiting for 5 minutes before stopping the failover test for Virtual Network Gateway: $vnetGatewayName in RG: $rgName"

    # Sleep for 5 minutes (300 seconds)
    Start-Sleep -Seconds 300

    Write-Debug "Starting the process of stopping the failover test"

    # Define failover connection details
    $details = @(
        [Microsoft.Azure.Management.Network.Models.FailoverConnectionDetails]@{
            FailoverConnectionName = "shubhati_ER_Arista--conn--shubhati_failoverGw"
            FailoverLocation = "eastus2euap"
            IsVerified = $true
        }
    )

    # Stop the failover test
    $resultStopFailover = Stop-AzVirtualNetworkGatewaySiteFailoverTest `
        -ResourceGroupName $rgName `
        -VirtualNetworkGatewayName $vnetGatewayName `
        -PeeringLocation $peeringLocation `
        -Details $details `
        -WasSimulationSuccessful $true

    Write-Debug "`nStop Failover Test Result:"
    Write-Debug $resultStopFailover

    # Assert that the stop failover result is not null
    Assert-NotNull $resultStopFailover "The stop failover test result is null."

    Write-Debug "`nStop Failover Test completed successfully."
}

<#
.SYNOPSIS
Tests the retrieval of failover test details for a virtual network gateway.
.DESCRIPTION
This test first retrieves a list of all failover tests for a virtual network gateway, then fetches details of a specific failover test based on the first test's results.
#>
function Test-CombinedAzureVirtualNetworkGatewayFailoverTestDetails
{
    $rgName = "shubhati_failover"   # <-- Replace with actual resource group
    $vnetGatewayName = "shubhati_failoverGw"   # <-- Replace with actual gateway name

    # Safeguard: Skip test if the resource doesn't exist
    if (-not (Get-AzVirtualNetworkGateway -ResourceGroupName $rgName -Name $vnetGatewayName -ErrorAction SilentlyContinue)) {
        Write-Warning "Test skipped: Virtual Network Gateway '$vnetGatewayName' not found in RG '$rgName'."
        return
    }

    Write-Debug "Fetching all failover tests for Virtual Network Gateway: $vnetGatewayName in RG: $rgName"

    # Fetch all failover tests
    $resultAllTests = Get-AzVirtualNetworkGatewayFailoverAllTestsDetails `
        -ResourceGroupName $rgName `
        -VirtualNetworkGatewayName $vnetGatewayName `
        -Type "SingleSiteFailover" `
        -FetchLatest $true

    Write-Debug "`nAll Failover Tests:"
    Write-Debug $resultAllTests

    # Assert that the result is not null or empty
    Assert-NotNull $resultAllTests "The failover all test details are null or empty."

    # Check if there is at least one result and fetch the details of the first test
    if ($resultAllTests.value.Count -gt 0) {
        $firstTest = $resultAllTests.value[0]
        $testGuid = $firstTest.TestGuid
        $peeringLocation = $firstTest.PeeringLocation

        Write-Debug "Fetching details for Failover Test ID: $testGuid at Peering Location: $peeringLocation"

        # Fetch details for a specific failover test using the TestGuid from the previous step
        $resultSingleTest = Get-AzVirtualNetworkGatewayFailoverSingleTestDetails `
            -ResourceGroupName $rgName `
            -VirtualNetworkGatewayName $vnetGatewayName `
            -PeeringLocation $peeringLocation `
            -FailoverTestId $testGuid

        Write-Debug "`nSingle Failover Test Details:"
        Write-Debug $resultSingleTest

        # Assert that the result is not null or empty
        Assert-NotNull $resultSingleTest "The failover single test details for specific test are null or empty."

        # Further assertions can be made depending on the specifics of the test data
        Assert-True ($resultSingleTest.value.Count -gt 0) "No details found for the failover test."
    }
    else {
        Write-Warning "No failover tests were found for Virtual Network Gateway '$vnetGatewayName'."
    }

    Write-Debug "`nCombined Failover Test completed successfully."
}