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
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $playbackIdentifier = 'ffffffff-ffff-ffff-ffff-ffffffffffff'
    $testSubscriptionId = $env:AZPS_TEST_SUBSCRIPTION_ID
    $testTenantId = $env:AZPS_TEST_TENANT_ID

    if ($TestMode -eq 'playback') {
        $testSubscriptionId = $playbackIdentifier
        $testTenantId = $playbackIdentifier
    }

    $context = Get-AzContext

    if ([string]::IsNullOrWhiteSpace($testSubscriptionId) -and $null -ne $context) {
        $testSubscriptionId = $context.Subscription.Id
    }

    if ([string]::IsNullOrWhiteSpace($testTenantId) -and $null -ne $context) {
        $testTenantId = $context.Tenant.Id
    }

    if ([string]::IsNullOrWhiteSpace($testSubscriptionId)) {
        throw "SubscriptionId is required. Set AZPS_TEST_SUBSCRIPTION_ID or run Connect-AzAccount."
    }

    $env.SubscriptionId = $testSubscriptionId
    if (-not [string]::IsNullOrWhiteSpace($testTenantId)) {
        $env.Tenant = $testTenantId
    }

    if (-not $env.ContainsKey('mainLocation')) {
        $env.Add('mainLocation', 'canadacentral')
    }

    if (-not $env.ContainsKey('pairedLocation')) {
        $env.Add('pairedLocation', 'canadaeast')
    }

    if (-not $env.ContainsKey('ResourceGroupNamePrefix')) {
        $env.Add('ResourceGroupNamePrefix', 'psqlflex-autorest-')
    }

    if (-not $env.ContainsKey('ServerNamePrefix')) {
        $env.Add('ServerNamePrefix', 'psqlflex-autorest-')
    }

    $resourceCount = 6
    for ($i = 1; $i -le $resourceCount; $i++) {
        $resourceGroupKey = "ResourceGroupName$i"
        if (-not $env.ContainsKey($resourceGroupKey)) {
            $env.Add($resourceGroupKey, ($env.ResourceGroupNamePrefix + (RandomString -allChars $false -len 6)))
        }
    }

    $adminUser = 'azpsadmin'
    $adminPassword = ConvertTo-SecureString ('Azps!' + (RandomString -allChars $false -len 12) + 'A1') -AsPlainText -Force

    $resourceGroups = @(
        $env.ResourceGroupName1,
        $env.ResourceGroupName2,
        $env.ResourceGroupName3,
        $env.ResourceGroupName4,
        $env.ResourceGroupName5,
        $env.ResourceGroupName6
    )
    $availabilityZones = @('1', '2', '3')
    $serverVersions = @('13', '14', '15', '16', '17', '18')
    $geoBackupOptions = @('Enabled', 'Disabled')
    $storageTypes = @('Premium_LRS', 'PremiumV2_LRS')
    $haModes = @('SameZone', 'ZoneRedundant')
    $serverPlans = @()
    for ($i = 0; $i -lt $resourceGroups.Count; $i++) {
        $resourceGroupName = $resourceGroups[$i]
        $resourceGroup = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
        if (-not $resourceGroup) {
            New-AzResourceGroup -Name $resourceGroupName -Location $env.mainLocation | Out-Null
        } else {
            throw "Resource group '$resourceGroupName' already exists."
        }

        $existingServer = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $resourceGroupName -ErrorAction SilentlyContinue | Select-Object -First 1
        if ($null -ne $existingServer) {
            throw "Server '$($existingServer.Name)' already exists in resource group '$resourceGroupName'."
        }

        $serverName = $env.ServerNamePrefix + (RandomString -allChars $false -len 8)
        $availabilityZone = $availabilityZones[$i % $availabilityZones.Count]
        $serverVersion = $serverVersions[$i]
        $geoBackupOption = $geoBackupOptions[$i % $geoBackupOptions.Count]
        $storageType = $storageTypes[$i % $storageTypes.Count]
        $skuTier = 'GeneralPurpose'
        $skuName = 'Standard_D4ds_v5'

        $enableHighAvailability = ($i % 2) -eq 0
        $haMode = $null
        $haStandbyZone = $null
        if ($enableHighAvailability) {
            $haMode = $haModes[($i / 2) % $haModes.Count]
            if ($haMode -eq 'SameZone') {
                $haStandbyZone = $availabilityZone
            } else {
                $haStandbyZone = ($availabilityZones | Where-Object { $_ -ne $availabilityZone })[0]
            }
        }

        $newServerParams = @{
            Name = $serverName
            ResourceGroupName = $resourceGroupName
            Location = $env.mainLocation
            Version = $serverVersion
            SkuTier = $skuTier
            SkuName = $skuName
            StorageSizeGb = 32
            StorageType = $storageType
            AvailabilityZone = $availabilityZone
            BackupGeoRedundantBackup = $geoBackupOption
            AdministratorLogin = $adminUser
            AdministratorLoginPassword = $adminPassword
        }

        if ($storageType -eq 'PremiumV2_LRS') {
            $newServerParams['StorageIop'] = 3000
            $newServerParams['StorageThroughput'] = 125
        }

        if ($enableHighAvailability) {
            $newServerParams['HighAvailabilityMode'] = $haMode
            $newServerParams['HighAvailabilityStandbyAvailabilityZone'] = $haStandbyZone
        }

        # Queue create requests asynchronously to provision servers in parallel.
        $newServerParams['NoWait'] = $true
        New-AzPostgreSqlFlexibleServer @newServerParams | Out-Null

        $index = $i + 1
        $serverPlans += [ordered]@{
            Index = $index
            ResourceGroupName = $resourceGroupName
            ServerName = $serverName
            ServerVersion = $serverVersion
            ServerZone = $availabilityZone
            ServerGeoBackup = $geoBackupOption
            ServerStorageType = $storageType
            ServerSkuTier = $skuTier
            ServerSkuName = $skuName
            EnableHighAvailability = $enableHighAvailability
            HighAvailabilityMode = $haMode
            HighAvailabilityStandbyZone = $haStandbyZone
        }
    }

    $pollIntervalSeconds = 15
    $timeoutSeconds = 1800 # 30 minutes
    $timeoutAt = (Get-Date).AddSeconds($timeoutSeconds)
    foreach ($plan in $serverPlans) {
        while ($true) {
            $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $plan.ResourceGroupName -Name $plan.ServerName -ErrorAction SilentlyContinue
            if ($null -ne $server) {
                if ($server.State -eq 'Ready') {
                    $readyForValidation = $true
                    if ($plan.EnableHighAvailability) {
                        if ($server.HighAvailabilityState -ne 'Healthy') {
                            $readyForValidation = $false
                        }
                    }
                    
                    if ($readyForValidation) {
                        break
                    }
                }
            }

            if ((Get-Date) -gt $timeoutAt) {
                throw "Timed out waiting for server '$($plan.ServerName)' in resource group '$($plan.ResourceGroupName)' to provision."
            }

            Start-TestSleep -Seconds $pollIntervalSeconds
        }

        if ($plan.EnableHighAvailability) {
            if ($server.HighAvailabilityMode -ne $plan.HighAvailabilityMode) {
                throw "Server '$($plan.ServerName)' expected HighAvailabilityMode '$($plan.HighAvailabilityMode)' but found '$($server.HighAvailabilityMode)'."
            }

            if ($plan.HighAvailabilityMode -eq 'SameZone') {
                if ($server.HighAvailabilityStandbyAvailabilityZone -ne $server.AvailabilityZone) {
                    throw "Server '$($plan.ServerName)' expected standby zone '$($server.AvailabilityZone)' for SameZone mode but found '$($server.HighAvailabilityStandbyAvailabilityZone)'."
                }
            }

            if ($plan.HighAvailabilityMode -eq 'ZoneRedundant') {
                if ($server.HighAvailabilityStandbyAvailabilityZone -eq $server.AvailabilityZone) {
                    throw "Server '$($plan.ServerName)' expected standby zone to differ from primary zone for ZoneRedundant mode, but both were '$($server.AvailabilityZone)'."
                }
            }
        }

        $env["ServerName$($plan.Index)"] = $plan.ServerName
        $env["ServerVersion$($plan.Index)"] = $plan.ServerVersion
        $env["ServerZone$($plan.Index)"] = $plan.ServerZone
        $env["ServerGeoBackup$($plan.Index)"] = $plan.ServerGeoBackup
        $env["ServerStorageType$($plan.Index)"] = $plan.ServerStorageType
        $env["ServerSkuTier$($plan.Index)"] = $plan.ServerSkuTier
        $env["ServerSkuName$($plan.Index)"] = $plan.ServerSkuName
        $env["ServerEnableHighAvailability$($plan.Index)"] = $plan.EnableHighAvailability
        $env["ServerHighAvailabilityMode$($plan.Index)"] = $plan.HighAvailabilityMode
        $env["ServerHighAvailabilityStandbyZone$($plan.Index)"] = $plan.HighAvailabilityStandbyZone
    }

    $env['ServerName'] = $env.ServerName1

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    # Do not persist subscription and tenant identifiers to tracked env files.
    $persistEnv = @{}
    foreach ($entry in $env.GetEnumerator()) {
        if ($entry.Key -in @('SubscriptionId', 'Tenant')) {
            continue
        }

        $persistEnv[$entry.Key] = $entry.Value
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $persistEnv)
}
function cleanupEnv() {
    # Clean resources you create for testing
    $resourceGroups = @(
        $env.ResourceGroupName1,
        $env.ResourceGroupName2,
        $env.ResourceGroupName3,
        $env.ResourceGroupName4,
        $env.ResourceGroupName5,
        $env.ResourceGroupName6
    ) | Where-Object { -not [string]::IsNullOrWhiteSpace($_) } | Select-Object -Unique

    if ($resourceGroups.Count -eq 0) {
        Write-Host "cleanupEnv: No resource groups found to delete."
        return
    }

    $pollIntervalSeconds = 15
    $timeoutSeconds = 1800 # 30 minutes
    $cleanupFailures = @()

    foreach ($resourceGroupName in $resourceGroups) {
        Write-Host "cleanupEnv: Deleting resource group '$resourceGroupName'."
        try {
            Remove-AzResourceGroup -Name $resourceGroupName -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
        catch {
            $cleanupFailures += "Failed to start delete for resource group '$resourceGroupName': $($_.Exception.Message)"
            continue
        }

        $timeoutAt = (Get-Date).AddSeconds($timeoutSeconds)
        while ($true) {
            $resourceGroup = Get-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
            if ($null -eq $resourceGroup) {
                Write-Host "cleanupEnv: Resource group '$resourceGroupName' deleted."
                break
            }

            if ((Get-Date) -gt $timeoutAt) {
                $cleanupFailures += "Timed out deleting resource group '$resourceGroupName'."
                break
            }

            Start-TestSleep -Seconds $pollIntervalSeconds
        }
    }

    if ($cleanupFailures.Count -gt 0) {
        throw ("cleanupEnv encountered failures:`n - " + ($cleanupFailures -join "`n - "))
    }
}

