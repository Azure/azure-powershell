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

# Retries an operation on transient failures and returns its result.
# - ARM 5xx/gateway errors and -AlsoRetryOn matches are retried until -TimeoutMinutes.
# - 403 authorization errors (AuthorizationFailed, LinkedAuthorizationFailed) occur while RBAC on a newly created
#   service group propagates. Tests retry them only for -AuthorizationTimeoutMinutes, so a real permission bug fails
#   the test quickly instead of leaving a live run hanging.
# - 401 'AAD authentication failed' is retried only with -Setup: the service returns it while a new service group
#   propagates, but inside a test it is a real authentication failure (e.g. unifiedResilienceItems) and must surface.
# Fixture setup/cleanup passes -Setup, which retries all of the above until -TimeoutMinutes.
# Start-TestSleep keeps playback fast; the recorded failed attempts are replayed in order.
function Invoke-ResiliencyWithRetry {
    param(
        [Parameter(Mandatory = $true)][scriptblock]$Command,
        [int]$TimeoutMinutes = 30,
        [int]$DelaySeconds = 30,
        # Additional error pattern to treat as retryable, e.g. a conflicting operation still in progress.
        [string]$AlsoRetryOn,
        [int]$AuthorizationTimeoutMinutes = 10,
        [switch]$Setup
    )

    $PSDefaultParameterValues = $PSDefaultParameterValues.Clone()
    $PSDefaultParameterValues['*:ErrorAction'] = 'Stop'
    $deadline = (Get-Date).AddMinutes($TimeoutMinutes)
    $authorizationDeadline = if ($Setup) { $deadline } else { (Get-Date).AddMinutes([Math]::Min($AuthorizationTimeoutMinutes, $TimeoutMinutes)) }
    while ($true) {
        try {
            return & $Command
        }
        catch {
            $errorText = "$($_.FullyQualifiedErrorId) $($_.ErrorDetails.Message) $($_.Exception.ToString())"
            $retryUntil = $null
            if ($errorText -match 'ServiceUnavailable|Service Unavailable|GatewayTimeout|\((502|503|504)\)' -or ($AlsoRetryOn -and $errorText -match $AlsoRetryOn)) {
                $retryUntil = $deadline
            }
            elseif ($errorText -match 'AuthorizationFailed|does not have permission to perform action' -or ($Setup -and $errorText -match 'AAD authentication failed')) {
                $retryUntil = $authorizationDeadline
            }
            if (-not $retryUntil -or (Get-Date) -gt $retryUntil) {
                throw
            }
            Write-Host "Retrying after transient error: $(($errorText -split "`n")[0])"
            Start-TestSleep -Seconds $DelaySeconds
        }
    }
}

# Polls a Get-AzResiliency* call until the resource has succeeded and the optional condition holds.
function Wait-ResiliencySucceeded {
    param([Parameter(Mandatory = $true)][scriptblock]$Command, [scriptblock]$Until = { $true }, [int]$TimeoutMinutes = 20)

    $deadline = (Get-Date).AddMinutes($TimeoutMinutes)
    while ($true) {
        $resource = Invoke-ResiliencyWithRetry $Command
        if ($resource.ProvisioningState -eq 'Succeeded' -and (& $Until $resource)) {
            return $resource
        }
        if ($resource.ProvisioningState -in 'Failed', 'Canceled' -or (Get-Date) -gt $deadline) {
            throw "Resource did not reach the expected state (provisioning state: $($resource.ProvisioningState))."
        }
        Start-TestSleep -Seconds 10
    }
}

# Splits an operation-status URL (e.g. the Target of a -NoWait response) into location and operation ID.
function Get-ResiliencyOperationFromUrl {
    param([string]$Url)

    if ($Url -notmatch '/locations/(?<location>[^/]+)/operationStatuses/(?<operationId>[^/?]+)') {
        throw "Not an operation-status URL: $Url"
    }
    return @{ Location = $Matches.location; OperationId = [System.Uri]::UnescapeDataString($Matches.operationId) }
}

function Invoke-ResiliencyFixtureRequest {
    param([string]$Method, [string]$Path, [object]$Body)

    $parameters = @{ Method = $Method; Path = $Path }
    if ($null -ne $Body) {
        $parameters.Payload = ConvertTo-Json $Body -Depth 30 -Compress
    }
    $response = Invoke-AzRestMethod @parameters
    if ($Method -eq 'DELETE' -and $response.StatusCode -eq 404) {
        return
    }
    if ($response.StatusCode -ge 400) {
        throw "Fixture request $Method failed ($($response.StatusCode)): $($response.Content)"
    }
    if ($response.Content) {
        return $response.Content | ConvertFrom-Json
    }
}

function Get-ResiliencyFixtureResource {
    param([string]$Path)

    $response = Invoke-AzRestMethod -Method GET -Path $Path
    if ($response.StatusCode -eq 404) {
        return $null
    }
    if ($response.StatusCode -ge 400) {
        throw "Fixture request GET failed ($($response.StatusCode)): $($response.Content)"
    }
    return $response.Content | ConvertFrom-Json
}

function Wait-ResiliencyFixtureProvisioning {
    param([string]$Path, [string]$Description, [int]$TimeoutMinutes = 30, [switch]$AllowMissing)

    $deadline = (Get-Date).AddMinutes($TimeoutMinutes)
    $state = 'Unknown'
    while ((Get-Date) -lt $deadline) {
        $resource = Invoke-ResiliencyWithRetry -Setup { Get-ResiliencyFixtureResource $Path } -TimeoutMinutes $TimeoutMinutes
        $state = if ($resource) { $resource.properties.provisioningState } else { 'NotFound' }
        if ($state -eq 'Succeeded') {
            return $resource
        }
        if ($state -in 'Failed', 'Canceled') {
            throw "$Description provisioning $state`: $($resource.properties | ConvertTo-Json -Depth 10 -Compress)"
        }
        if ($state -eq 'NotFound' -and -not $AllowMissing) {
            throw "$Description was not found."
        }
        Start-TestSleep -Seconds 15
    }
    throw "Timed out waiting for $Description (last state: $state)."
}

function Get-ResiliencyVmTemplate {
    $nicId = "[resourceId('Microsoft.Network/networkInterfaces', 'resiliency-nic')]"
    return @{
        '$schema' = 'https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#'
        contentVersion = '1.0.0.0'
        parameters = @{
            vmName = @{ type = 'string' }
            location = @{ type = 'string' }
            zone = @{ type = 'string' }
            adminPassword = @{ type = 'secureString' }
        }
        resources = @(
            @{
                type = 'Microsoft.Network/virtualNetworks'
                apiVersion = '2024-05-01'
                name = 'resiliency-vnet'
                location = "[parameters('location')]"
                properties = @{
                    addressSpace = @{ addressPrefixes = @('10.0.0.0/16') }
                    subnets = @(@{ name = 'default'; properties = @{ addressPrefix = '10.0.0.0/24' } })
                }
            },
            @{
                type = 'Microsoft.Network/networkInterfaces'
                apiVersion = '2024-05-01'
                name = 'resiliency-nic'
                location = "[parameters('location')]"
                dependsOn = @("[resourceId('Microsoft.Network/virtualNetworks', 'resiliency-vnet')]")
                properties = @{
                    ipConfigurations = @(@{
                        name = 'default'
                        properties = @{
                            privateIPAllocationMethod = 'Dynamic'
                            subnet = @{ id = "[resourceId('Microsoft.Network/virtualNetworks/subnets', 'resiliency-vnet', 'default')]" }
                        }
                    })
                }
            },
            @{
                type = 'Microsoft.Compute/virtualMachines'
                apiVersion = '2024-11-01'
                name = "[parameters('vmName')]"
                location = "[parameters('location')]"
                zones = @("[parameters('zone')]")
                dependsOn = @($nicId)
                properties = @{
                    hardwareProfile = @{ vmSize = 'Standard_D2s_v5' }
                    storageProfile = @{
                        imageReference = @{
                            publisher = 'Canonical'
                            offer = '0001-com-ubuntu-server-jammy'
                            sku = '22_04-lts-gen2'
                            version = 'latest'
                        }
                        osDisk = @{ createOption = 'FromImage'; managedDisk = @{ storageAccountType = 'Standard_LRS' } }
                    }
                    osProfile = @{
                        computerName = "[parameters('vmName')]"
                        adminUsername = 'azureuser'
                        adminPassword = "[parameters('adminPassword')]"
                        linuxConfiguration = @{ disablePasswordAuthentication = $false }
                    }
                    networkProfile = @{ networkInterfaces = @(@{ id = $nicId }) }
                }
            }
        )
    }
}

function Set-ResiliencyEnvironmentIds {
    $env.resourceGroupId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupName)"
    $env.vmId = "$($env.resourceGroupId)/providers/Microsoft.Compute/virtualMachines/$($env.vmName)"
    $env.serviceGroupId = "/providers/Microsoft.Management/serviceGroups/$($env.serviceGroupName)"
    $env.enrollmentServiceGroupId = "/providers/Microsoft.Management/serviceGroups/$($env.enrollmentServiceGroupName)"
    $env.goalServiceGroupId = "/providers/Microsoft.Management/serviceGroups/$($env.goalServiceGroupName)"
    $env.usagePlanId = "$($env.resourceGroupId)/providers/Microsoft.AzureResilienceManagement/usagePlans/$($env.usagePlanName)"
    $env.goalAssignmentId = "$($env.serviceGroupId)/providers/Microsoft.AzureResilienceManagement/goalAssignments/$($env.goalAssignmentName)"
}

function Get-ResiliencyMembershipPath {
    return "$($env.vmId)/providers/Microsoft.Relationships/serviceGroupMember/$($env.serviceGroupName)?api-version=2026-08-01"
}

function New-ResiliencyServiceGroup {
    param([string]$Name)

    $path = "/providers/Microsoft.Management/serviceGroups/$Name`?api-version=2026-08-01"
    if (-not (Invoke-ResiliencyWithRetry -Setup { Get-ResiliencyFixtureResource $path })) {
        $null = Invoke-ResiliencyWithRetry -Setup {
            Invoke-ResiliencyFixtureRequest PUT $path @{
                properties = @{
                    displayName = $Name
                    parent = @{ resourceId = "/providers/Microsoft.Management/serviceGroups/$($env.Tenant)" }
                }
            }
        }
    }
}

function New-ResiliencyEnrollmentFixture {
    param([string]$UsagePlanName, [string]$EnrollmentName, [string]$ServiceGroupId)

    $path = "$($env.resourceGroupId)/providers/Microsoft.AzureResilienceManagement/usagePlans/$UsagePlanName/enrollments/$EnrollmentName`?api-version=2026-10-01"
    $existing = Invoke-ResiliencyWithRetry -Setup { Get-ResiliencyFixtureResource $path }
    if (-not $existing -or $existing.properties.provisioningState -in 'Failed', 'Canceled') {
        # The caller's linked authorization on a new service group can take ~20 minutes to propagate.
        $null = Invoke-ResiliencyWithRetry -Setup -TimeoutMinutes 40 {
            Invoke-ResiliencyFixtureRequest PUT $path @{ properties = @{ serviceGroupId = $ServiceGroupId } }
        }
    }
    $null = Wait-ResiliencyFixtureProvisioning $path "enrollment $EnrollmentName" -AllowMissing
}

function Initialize-ResiliencyGoalFixture {
    $goalPath = "$($env.goalAssignmentId)?api-version=2026-10-01"
    $goal = Invoke-ResiliencyWithRetry -Setup { Get-ResiliencyFixtureResource $goalPath }
    if (-not $goal) {
        $null = Invoke-ResiliencyWithRetry -Setup {
            Invoke-ResiliencyFixtureRequest PUT $goalPath @{ properties = @{ requireZonalResiliency = $true } }
        }
    }
    $null = Wait-ResiliencyFixtureProvisioning $goalPath "goal assignment $($env.goalAssignmentName)" -AllowMissing

    $deadline = (Get-Date).AddMinutes(40)
    $resource = $null
    while (-not $resource -and (Get-Date) -lt $deadline) {
        try {
            $null = Invoke-ResiliencyWithRetry -Setup {
                Invoke-ResiliencyFixtureRequest POST "$($env.goalAssignmentId)/refreshGoalResources?api-version=2026-10-01"
            }
        }
        catch {
            # A refresh is already running (the service starts one when the goal is created).
            if ("$_" -notmatch '\(409\)') {
                throw
            }
        }
        Start-TestSleep -Seconds 60
        $resources = Invoke-ResiliencyWithRetry -Setup {
            Invoke-ResiliencyFixtureRequest GET "$($env.goalAssignmentId)/goalResources?api-version=2026-10-01"
        }
        $resource = $resources.value | Where-Object { $_.properties.resourceArmId -eq $env.vmId } | Select-Object -First 1
    }
    if (-not $resource) {
        throw 'Timed out waiting for the VM to be discovered as a goal resource.'
    }
    $env.goalResourceName = $resource.name

    $deadline = (Get-Date).AddMinutes(15)
    $item = $null
    while (-not $item -and (Get-Date) -lt $deadline) {
        try {
            $items = Invoke-ResiliencyWithRetry -Setup -TimeoutMinutes 5 {
                Invoke-ResiliencyFixtureRequest GET "$($env.serviceGroupId)/providers/Microsoft.AzureResilienceManagement/unifiedResilienceItems?api-version=2026-10-01"
            }
            $item = @($items.value) | Select-Object -First 1
        }
        catch {
            Write-Warning "Unified resilience items are not readable yet: $(("$_" -split "`n")[0])"
        }
        if (-not $item) {
            Start-TestSleep -Seconds 60
        }
    }
    if ($item) {
        $env.unifiedResilienceItemName = $item.name
    }
    else {
        Write-Warning 'No unified resilience item was found in the service group.'
    }
}

function setupResiliencyEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = $env.AddWithCache('location', 'eastus2euap', $UsePreviousConfigForRecord)
    $env.zone = $env.AddWithCache('zone', '2', $UsePreviousConfigForRecord)
    $suffix = RandomString -allChars $false -len 6
    $null = $env.AddWithCache('resourceGroupName', "pstest-resiliency-rg-$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('vmName', "pstestvm$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('serviceGroupName', "pstest-sg-$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('enrollmentServiceGroupName', "pstest-sg-enr-$suffix", $UsePreviousConfigForRecord)
    # The service allows one goal assignment per service group, so goal create/delete tests use their own group.
    $null = $env.AddWithCache('goalServiceGroupName', "pstest-sg-goal-$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('usagePlanName', "pstest-plan-$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('enrollmentName', "pstest-enr-$suffix", $UsePreviousConfigForRecord)
    $null = $env.AddWithCache('goalAssignmentName', "pstest-goal-$suffix", $UsePreviousConfigForRecord)
    if (-not $UsePreviousConfigForRecord) {
        foreach ($key in 'goalResourceName', 'unifiedResilienceItemName') {
            $env.Remove($key)
        }
    }
    Set-ResiliencyEnvironmentIds
    # Persist the generated names immediately so an interrupted setup can be resumed with -UsePreviousConfigForRecord.
    Set-Content -Path (Join-Path $PSScriptRoot 'env.json') -Value (ConvertTo-Json $env)

    $tags = @{
        product = 'azurepowershell'
        module = 'resiliency'
        TestType = 'Other'
        DeleteBy = (Get-Date).AddMonths(2).ToString('MM-yyyy')
        ManagerAlias = 'none'
        Owner = 'azurepowershell'
        Workload = 'powershell-tests'
    }
    $null = Invoke-ResiliencyWithRetry -Setup {
        Invoke-ResiliencyFixtureRequest PUT "$($env.resourceGroupId)?api-version=2024-03-01" @{ location = $env.location; tags = $tags }
    }

    $deploymentPath = "$($env.resourceGroupId)/providers/Microsoft.Resources/deployments/resiliency-zonal-vm?api-version=2025-04-01"
    $deployment = Get-ResiliencyFixtureResource $deploymentPath
    if (-not $deployment -or $deployment.properties.provisioningState -ne 'Succeeded') {
        $null = Invoke-ResiliencyWithRetry -Setup {
            Invoke-ResiliencyFixtureRequest PUT $deploymentPath @{
                properties = @{
                    mode = 'Incremental'
                    template = Get-ResiliencyVmTemplate
                    parameters = @{
                        vmName = @{ value = $env.vmName }
                        location = @{ value = $env.location }
                        zone = @{ value = "$($env.zone)" }
                        adminPassword = @{ value = ('aA1!' + [guid]::NewGuid().ToString('N')) }
                    }
                }
            }
        }
    }

    New-ResiliencyServiceGroup $env.serviceGroupName
    New-ResiliencyServiceGroup $env.enrollmentServiceGroupName
    New-ResiliencyServiceGroup $env.goalServiceGroupName

    $planPath = "$($env.usagePlanId)?api-version=2026-10-01"
    if (-not (Get-ResiliencyFixtureResource $planPath)) {
        $null = Invoke-ResiliencyWithRetry -Setup {
            Invoke-ResiliencyFixtureRequest PUT $planPath @{ location = 'global'; properties = @{ planType = 'Standard' } }
        }
    }
    $null = Wait-ResiliencyFixtureProvisioning $planPath "usage plan $($env.usagePlanName)" -AllowMissing

    foreach ($group in $env.serviceGroupName, $env.enrollmentServiceGroupName, $env.goalServiceGroupName) {
        $null = Wait-ResiliencyFixtureProvisioning "/providers/Microsoft.Management/serviceGroups/$group`?api-version=2026-08-01" "service group $group" -AllowMissing
    }
    New-ResiliencyEnrollmentFixture $env.usagePlanName $env.enrollmentName $env.serviceGroupId
    New-ResiliencyEnrollmentFixture $env.usagePlanName "$($env.enrollmentName)-goal" $env.goalServiceGroupId
    # Warm up linked authorization on the second service group used by the enrollment create/delete tests.
    $warmupName = "$($env.enrollmentName)-warmup"
    New-ResiliencyEnrollmentFixture $env.usagePlanName $warmupName $env.enrollmentServiceGroupId
    $null = Invoke-ResiliencyWithRetry -Setup {
        Invoke-ResiliencyFixtureRequest DELETE "$($env.usagePlanId)/enrollments/$warmupName`?api-version=2026-10-01"
    }
    $deadline = (Get-Date).AddMinutes(15)
    while ((Get-ResiliencyFixtureResource "$($env.usagePlanId)/enrollments/$warmupName`?api-version=2026-10-01") -and (Get-Date) -lt $deadline) {
        Start-TestSleep -Seconds 15
    }

    $null = Wait-ResiliencyFixtureProvisioning $deploymentPath 'zonal VM deployment' -TimeoutMinutes 30
    $null = Invoke-ResiliencyWithRetry -Setup {
        Invoke-ResiliencyFixtureRequest PUT (Get-ResiliencyMembershipPath) @{
            properties = @{ sourceId = $env.serviceGroupId; sourceTenant = $env.Tenant }
        }
    }

    Initialize-ResiliencyGoalFixture

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function Remove-ResiliencyFixtureChildren {
    param([string]$ListPath)

    $children = Invoke-ResiliencyWithRetry -Setup -TimeoutMinutes 10 { Get-ResiliencyFixtureResource $ListPath }
    foreach ($child in @($children.value)) {
        $null = Invoke-ResiliencyWithRetry -Setup -TimeoutMinutes 10 {
            Invoke-ResiliencyFixtureRequest DELETE "$($child.id)?api-version=2026-10-01"
        }
    }
    $deadline = (Get-Date).AddMinutes(15)
    while (@((Invoke-ResiliencyWithRetry -Setup -TimeoutMinutes 10 { Get-ResiliencyFixtureResource $ListPath }).value).Count -gt 0 -and (Get-Date) -lt $deadline) {
        Start-TestSleep -Seconds 15
    }
}

# Removes identities, signatures and environment-specific endpoints so recordings can be committed
# and replayed against the canonical public endpoint with zeroed subscription and tenant IDs.
function Save-ResiliencySanitizedRecordings {
    param([string]$SubscriptionId, [string]$TenantId, [string]$Path = $PSScriptRoot)

    $endpoint = (Get-AzContext).Environment.ResourceManagerUrl.TrimEnd('/')
    $files = @(Get-ChildItem -Path $Path -Filter '*.Recording.json' -File) + @(Get-Item (Join-Path $Path 'env.json') -ErrorAction SilentlyContinue)
    foreach ($file in $files) {
        $content = Get-Content $file.FullName -Raw
        $content = $content.Replace($endpoint, 'https://management.azure.com')
        if ($SubscriptionId) {
            $content = $content.Replace($SubscriptionId, '00000000-0000-0000-0000-000000000000')
        }
        if ($TenantId) {
            $content = $content.Replace($TenantId, '00000000-0000-0000-0000-000000000000')
        }
        $content = $content `
            -replace '(\\?"(?:createdBy|lastModifiedBy|principalId|objectId|oid)\\?"\s*:\s*\\?")[^"\\]*', '${1}00000000-0000-0000-0000-000000000000' `
            -replace "object id '[^']+'", "object id '00000000-0000-0000-0000-000000000000'" `
            -replace '[\w.%+-]+@[\w-]+(\.[\w-]+)*\.[A-Za-z]{2,}', 'user@example.com' `
            -replace '(?:[?&]|\\u0026)sig=[^&"\\\s]+', '' `
            -replace '(operationStatuses/[^?"\\\s]+\?api-version=[\w.-]+)(?:&|\\u0026)(?:[^"\\\s]|\\u0026)*?(?=(?:\+\d+)?")', '$1'
        Set-Content -Path $file.FullName -Value $content -NoNewline
    }
}

function cleanupResiliencyEnv() {
    if ($TestMode -eq 'playback') {
        return
    }
    $subscriptionId = $env.SubscriptionId
    $tenantId = $env.Tenant
    try {
        if ($env.goalAssignmentId) {
            Remove-ResiliencyFixtureChildren "$($env.serviceGroupId)/providers/Microsoft.AzureResilienceManagement/goalAssignments?api-version=2026-10-01"
        }
        if ($env.goalServiceGroupId) {
            Remove-ResiliencyFixtureChildren "$($env.goalServiceGroupId)/providers/Microsoft.AzureResilienceManagement/goalAssignments?api-version=2026-10-01"
        }
        if ($env.resourceGroupId) {
            $plans = Get-ResiliencyFixtureResource "$($env.resourceGroupId)/providers/Microsoft.AzureResilienceManagement/usagePlans?api-version=2026-10-01"
            foreach ($plan in @($plans.value)) {
                Remove-ResiliencyFixtureChildren "$($plan.id)/enrollments?api-version=2026-10-01"
                $null = Invoke-ResiliencyFixtureRequest DELETE "$($plan.id)?api-version=2026-10-01"
            }
            $null = Invoke-ResiliencyFixtureRequest DELETE (Get-ResiliencyMembershipPath)
            $null = Invoke-ResiliencyFixtureRequest DELETE "$($env.resourceGroupId)?api-version=2024-03-01"
        }
    }
    finally {
        foreach ($group in $env.serviceGroupName, $env.enrollmentServiceGroupName, $env.goalServiceGroupName) {
            if ($group) {
                $null = Invoke-ResiliencyFixtureRequest DELETE "/providers/Microsoft.Management/serviceGroups/$group`?api-version=2026-08-01"
            }
        }
        if ($TestMode -eq 'record') {
            Save-ResiliencySanitizedRecordings -SubscriptionId $subscriptionId -TenantId $tenantId
        }
    }
}

. (Join-Path $PSScriptRoot 'ROTestSetup.ps1')
