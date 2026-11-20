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
$script:fixtureResourceGroups = [System.Collections.Generic.List[hashtable]]::new()
function Protect-HorizonDbPasswordRecording {
    param(
        [Parameter(Mandatory)]
        [string]$Path
    )

    $recording = Get-Content -LiteralPath $Path -Raw -ErrorAction Stop | ConvertFrom-Json
    foreach ($entry in $recording.psobject.Properties) {
        $request = $entry.Value.Request
        if ($request.RequestUri -like '*/authentications/passwordMethod*' -and $request.Content) {
            $body = $request.Content | ConvertFrom-Json
            if ($null -ne $body.properties.administratorLoginPassword) {
                $body.properties.administratorLoginPassword = '[REDACTED]'
                $request.Content = $body | ConvertTo-Json -Depth 100 -Compress
            }
        }
    }
    Set-Content -LiteralPath $Path -Value ($recording | ConvertTo-Json -Depth 100) -ErrorAction Stop
}

function Get-HorizonDbTestParameter {
    @(
        @{ Name = 'application_name'; Value = 'horizondb-production' }
        @{ Name = 'autovacuum'; Value = 'off' }
        @{ Name = 'work_mem'; Value = '8192' }
        @{ Name = 'xmlbinary'; Value = 'base64' }
    )
}

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
    $env.newClusterName = $env.AddWithCache('newClusterName', 'horizondb-new-cluster-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.newPoolName = $env.AddWithCache('newPoolName', 'horizondb-new-pool-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.newClusterPoolName = $env.AddWithCache('newClusterPoolName', 'horizondb-new-pool-cluster-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.newParameterGroupName = $env.AddWithCache('newParameterGroupName', 'production-parameters-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedParameterGroupName = $env.AddWithCache('sharedParameterGroupName', 'shared-parameters-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedResourceGroup = $env.AddWithCache('sharedResourceGroup', 'horizondb-fixture-rg-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedClusterName = $env.AddWithCache('sharedClusterName', 'horizondb-fixture-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $env.sharedPoolName = $env.AddWithCache('sharedPoolName', 'horizondb-pool-' + (RandomString $false 8), $UsePreviousConfigForRecord)
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env) -ErrorAction Stop

    $null = New-AzResourceGroup -Name $env.sharedResourceGroup -SubscriptionId $env.SubscriptionId -Location $env.location -ErrorAction Stop
    $script:fixtureResourceGroups.Add(@{
        Name = $env.sharedResourceGroup
        SubscriptionId = $env.SubscriptionId
    })

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
    if ($null -eq $TestName -or $TestName -contains 'Get-AzHorizonDbParameterGroup' -or $TestName -contains 'Update-AzHorizonDbParameterGroup') {
        $parameterGroup = New-AzHorizonDbParameterGroup -ResourceGroupName $env.sharedResourceGroup -Name $env.sharedParameterGroupName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -Tag @{ environment = 'production' } -Description 'Parameters for production transactional workloads' -Parameter @(Get-HorizonDbTestParameter) -ErrorAction Stop
        if ($parameterGroup.Name -ne $env.sharedParameterGroupName -or [string]::IsNullOrEmpty($parameterGroup.Id)) {
            throw 'Shared HorizonDB parameter group creation did not return the expected name and resource ID.'
        }
    }
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env) -ErrorAction Stop

    if ($null -eq $TestName -or $TestName -contains 'New-AzHorizonDbCluster' -or $TestName -contains 'New-AzHorizonDbPool' -or $TestName -contains 'New-AzHorizonDbFirewallRule' -or $TestName -contains 'New-AzHorizonDbMicrosoftEntraAuthentication' -or $TestName -contains 'New-AzHorizonDbPasswordAuthentication' -or $TestName -contains 'New-AzHorizonDbParameterGroup') {
        $null = New-AzResourceGroup -Name $env.clusterResourceGroup -SubscriptionId $env.SubscriptionId -Location $env.location -ErrorAction Stop
        $script:fixtureResourceGroups.Add(@{
            Name = $env.clusterResourceGroup
            SubscriptionId = $env.SubscriptionId
        })

        if ($null -eq $TestName -or $TestName -contains 'New-AzHorizonDbPool') {
            $cluster = New-AzHorizonDbCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.newClusterPoolName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -BackupGeoRedundancy 'Disabled' -NetworkPublicAccess 'Disabled' -ErrorAction Stop
            if ($cluster.ProvisioningState -ne 'Succeeded') {
                throw "New-pool test cluster did not succeed. Provisioning state: '$($cluster.ProvisioningState)'."
            }
        }

        if ($null -eq $TestName -or $TestName -contains 'New-AzHorizonDbFirewallRule') {
            $parameters = @{
                location = @{ value = $env.location }
                clusterName = @{ value = $env.newClusterName }
                poolName = @{ value = $env.newPoolName }
            }
            $deployment = New-AzDeployment -Name 'horizondb-new-firewall-fixture' -ResourceGroupName $env.clusterResourceGroup -SubscriptionId $env.SubscriptionId -Mode Incremental -TemplateFile (Join-Path $PSScriptRoot 'prereqs.json') -TemplateParameterObject $parameters -ErrorAction Stop
            if ($deployment.ProvisioningState -ne 'Succeeded') {
                throw "New-firewall test fixture deployment did not succeed. Provisioning state: '$($deployment.ProvisioningState)'."
            }
        } elseif ($TestName -contains 'New-AzHorizonDbMicrosoftEntraAuthentication' -or $TestName -contains 'New-AzHorizonDbPasswordAuthentication') {
            $cluster = New-AzHorizonDbCluster -ResourceGroupName $env.clusterResourceGroup -Name $env.newClusterName -SubscriptionId $env.SubscriptionId -Location $env.location -PostgreSqlVersion '17' -BackupGeoRedundancy 'Disabled' -NetworkPublicAccess 'Disabled' -ErrorAction Stop
            if ($cluster.ProvisioningState -ne 'Succeeded') {
                throw "New-authentication test cluster did not succeed. Provisioning state: '$($cluster.ProvisioningState)'."
            }
        }
    }
}
function cleanupEnv() {
    if ($TestMode -eq 'playback') {
        return
    }

    $cleanupErrors = [System.Collections.Generic.List[System.Exception]]::new()
    foreach ($resourceGroup in $script:fixtureResourceGroups.ToArray()) {
        try {
            $null = Remove-AzResourceGroup -Name $resourceGroup.Name -SubscriptionId $resourceGroup.SubscriptionId -Confirm:$false -ErrorAction Stop
            $null = $script:fixtureResourceGroups.Remove($resourceGroup)
        }
        catch {
            $cleanupErrors.Add($_.Exception)
        }
    }
    if ($cleanupErrors.Count -gt 0) {
        $message = 'Failed to clean up HorizonDB test resource groups: ' + (($cleanupErrors | ForEach-Object { $_.Message }) -join '; ')
        throw [System.AggregateException]::new($message, $cleanupErrors)
    }
}

