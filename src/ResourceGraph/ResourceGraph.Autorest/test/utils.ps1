function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    # For any resources you created for test, you should add it to $env here.
    # Generate some random strings for use in the test.
    $env.rstr1 = RandomString -allChars $false -len 6
    $env.rstr2 = RandomString -allChars $false -len 6
    $env.rstr3 = RandomString -allChars $false -len 6

    $env.query01 = 'query-' + (RandomString -allChars $false -len 6)
    $env.query02 = 'query-' + (RandomString -allChars $false -len 6)
    $env.query03 = 'query-' + (RandomString -allChars $false -len 6)
    $env.query04 = 'query-' + (RandomString -allChars $false -len 6)

    # Configuration parameters
    $env.kqlFilePath = 'Query.kql'
    $env.location = 'global'

    # Create the test group
    Write-Host -ForegroundColor Green "start to create test group"
    $env.resourceGroup = 'resourcegraph-rg-' + $rstr1
    New-AzResourceGroup -Name $env.resourceGroup -Location eastus
    Write-Host -ForegroundColor Green "----------------------------"

    # Create ResourceGraphQuery for test
    Write-Host -ForegroundColor Green  "Create ResourceGraphQuery for test "
    New-AzResourceGraphQuery -Name $env.query01 -ResourceGroupName $env.resourceGroup -Location $env.location -Description "requesting a subset of resource fields." -Query "project id, name, type, location, tags"
    New-AzResourceGraphQuery -Name $env.query02 -ResourceGroupName $env.resourceGroup -Location $env.location -Description "requesting a subset of resource fields." -Query "project id, name, type, location, tags"
    Write-Host -ForegroundColor Green "----------------------------"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Removing resourcegroup will clean all the resources created for testing.
    Remove-AzResourceGroup -Name $env.resourceGroup
}

