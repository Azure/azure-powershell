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
    Write-Host -ForegroundColor Magenta "Setting up test environment"
    $env['SubscriptionId'] = (Get-AzContext).Subscription.Id
    $env['Tenant'] = (Get-AzContext).Tenant.Id
    $env['RandomString'] = RandomString -allChars $false -len 6

    # Common parent: tenant-level service group
    $env['TenantParentId'] = "/providers/Microsoft.Management/serviceGroups/$($env.Tenant)"
    $env['ServiceGroupDisplayName'] = 'Az PS Test Service Group'

    # --- Names for New tests (NOT created here; the tests create them) ---
    $env['ServiceGroupNameForNew'] = 'testsgnew' + $env.RandomString
    $env['ServiceGroupNameForNewJson'] = 'testsgnewjson' + $env.RandomString
    $env['ServiceGroupNameForNewJsonFile'] = 'testsgnewjsonf' + $env.RandomString
    $env['ChildServiceGroupNameForNew'] = 'testsgchildnew' + $env.RandomString

    # --- Resources for Get tests ---
    $env['ServiceGroupNameForGet'] = 'testsgget' + $env.RandomString
    New-AzServiceGroup -Name $env.ServiceGroupNameForGet -DisplayName $env.ServiceGroupDisplayName -ParentResourceId $env.TenantParentId

    # --- Resources for Update tests ---
    $env['ServiceGroupNameToUpdate'] = 'testsgtoupdate' + $env.RandomString
    New-AzServiceGroup -Name $env.ServiceGroupNameToUpdate -DisplayName 'Az PS SG To Update' -ParentResourceId $env.TenantParentId

    # --- Resources for Remove tests ---
    $env['ServiceGroupNameToDelete'] = 'testsgtodelete' + $env.RandomString
    New-AzServiceGroup -Name $env.ServiceGroupNameToDelete -DisplayName 'Az PS SG To Delete' -ParentResourceId $env.TenantParentId

    $env['ServiceGroupNameToDeleteViaIdentity'] = 'testsgdeletevi' + $env.RandomString
    New-AzServiceGroup -Name $env.ServiceGroupNameToDeleteViaIdentity -DisplayName 'Az PS SG To Delete Via Identity' -ParentResourceId $env.TenantParentId

    # --- Resources for Ancestor tests (child under ServiceGroupNameForGet) ---
    $env['ParentServiceGroupId'] = "/providers/Microsoft.Management/serviceGroups/$($env.ServiceGroupNameForGet)"
    $env['ChildServiceGroupName'] = 'testsgchild' + $env.RandomString
    New-AzServiceGroup -Name $env.ChildServiceGroupName -DisplayName 'Az PS Child Service Group' -ParentResourceId $env.ParentServiceGroupId

    # Write env file
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Write-Host -ForegroundColor Magenta "Writing environment file $envFile with $($env.Count) entries"
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 100)
}
function cleanupEnv() {
    Write-Host -ForegroundColor Magenta "Cleaning up test environment"
    # Delete children before parents
    Remove-AzServiceGroup -Name $env.ChildServiceGroupName -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ChildServiceGroupNameForNew -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameForNewJsonFile -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameForNewJson -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameForNew -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameToDeleteViaIdentity -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameToDelete -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameToUpdate -ErrorAction SilentlyContinue
    Remove-AzServiceGroup -Name $env.ServiceGroupNameForGet -ErrorAction SilentlyContinue
    Write-Host -ForegroundColor Magenta "Finished cleaning up test environment"
}

