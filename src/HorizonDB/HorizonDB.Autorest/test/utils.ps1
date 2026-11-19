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
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
$script:sharedFixtureResourceGroup = $null
function setupEnv() {
    if ($TestMode -eq 'playback') {
        return
    }

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'indiasouthcentral'
    # Creation tests retain separate names so their cleanup cannot delete the shared fixture.
    $env.clusterResourceGroup = $env.AddWithCache('clusterResourceGroup', 'horizondb-test-rg-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.clusterName = $env.AddWithCache('clusterName', 'horizondb-test-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedResourceGroup = $env.AddWithCache('sharedResourceGroup', 'horizondb-fixture-rg-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedClusterName = $env.AddWithCache('sharedClusterName', 'horizondb-fixture-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedPoolName = $env.AddWithCache('sharedPoolName', 'horizondb-pool-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env) -ErrorAction Stop

    $null = New-AzResourceGroup -Name $env.sharedResourceGroup -SubscriptionId $env.SubscriptionId -Location $env.location -ErrorAction Stop
    $script:sharedFixtureResourceGroup = @{
        Name = $env.sharedResourceGroup
        SubscriptionId = $env.SubscriptionId
    }

    $parameters = @{
        location = @{ value = $env.location }
        clusterName = @{ value = $env.sharedClusterName }
        poolName = @{ value = $env.sharedPoolName }
    }
    $deployment = New-AzDeployment -Name 'horizondb-shared-fixture' -ResourceGroupName $env.sharedResourceGroup -SubscriptionId $env.SubscriptionId -Mode Incremental -TemplateFile (Join-Path $PSScriptRoot 'prereqs.json') -TemplateParameterObject $parameters -ErrorAction Stop
    if ($deployment.ProvisioningState -ne 'Succeeded') {
        throw "Shared HorizonDB fixture deployment did not succeed. Provisioning state: '$($deployment.ProvisioningState)'."
    }

    $nodes = @(Get-AzHorizonDbNode -ResourceGroupName $env.sharedResourceGroup -ClusterName $env.sharedClusterName -PoolName $env.sharedPoolName -SubscriptionId $env.SubscriptionId -ErrorAction Stop)
    if ($nodes.Count -ne 1 -or [string]::IsNullOrEmpty($nodes[0].Name) -or [string]::IsNullOrEmpty($nodes[0].Id)) {
        throw 'Expected the shared pool to contain exactly one node with a name and resource ID.'
    }
    $env.sharedNodeName = $nodes[0].Name
    $env.sharedNodeId = $nodes[0].Id
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env) -ErrorAction Stop
}
function cleanupEnv() {
    if ($TestMode -eq 'playback' -or $null -eq $script:sharedFixtureResourceGroup) {
        return
    }

    $null = Remove-AzResourceGroup -Name $script:sharedFixtureResourceGroup.Name -SubscriptionId $script:sharedFixtureResourceGroup.SubscriptionId -Confirm:$false -ErrorAction Stop
    $script:sharedFixtureResourceGroup = $null
}

