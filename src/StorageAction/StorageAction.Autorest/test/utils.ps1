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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    $env.resourceGroup = 'joyer-test'
    $env.region = 'eastus2euap'
    $env.testTaskName1 = 'storageactiontest1'
    $env.testTaskName2 = 'storageactiontest2'
    $env.assignmentTask = 'mytask1'
    
    Write-Host 'Start to create test resource group' $env.resourceGroup
    try {
        Get-AzResourceGroup -Name $env.resourceGroup -ErrorAction Stop
        Write-Host 'Get created group'
    } catch {
        New-AzResourceGroup -Name $env.resourceGroup -Location $env.region
    }

    # Make sure the user assigned identity is registered
    # Get-AzProviderFeature -ProviderNamespace "Microsoft.StorageActions" -ListAvailable
    # FeatureName          ProviderName             RegistrationState
    # -----------          ------------             -----------------
    # UserAssignedIdentity Microsoft.StorageActions NotRegistered
    # AzureStorageTask     Microsoft.StorageActions Registered
    # Register-AzProviderFeature -ProviderNamespace "Microsoft.StorageActions" -FeatureName "UserAssignedIdentity"

    try {
        $null = Get-AzStorageActionTask -Name $env.testTaskName1 -ResourceGroupName $env.resourceGroup -ErrorAction Stop
    }
    catch {
        $ifoperation = New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
        $null = New-AzStorageActionTask -Name $env.testTaskName1 -ResourceGroupName $env.resourceGroup -Location $env.region -Enabled -Description 'test storage task 1' -IfCondition "[[equals(AccessTier, 'Cool')]]" -IfOperation $ifoperation
    }
    #Add assignment and report without command 

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzStorageActionTask -Name $env.testTaskName1 -ResourceGroupName $env.resourceGroup
}

