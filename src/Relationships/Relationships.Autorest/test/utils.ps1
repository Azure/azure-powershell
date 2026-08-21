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
    $env['location'] = 'westus2'

    # Common resource URIs
    $env['SubscriptionResourceUri'] = "/subscriptions/$($env.SubscriptionId)"

    # Resource groups for scoping relationships
    $env['DepResourceGroupName'] = 'rg-rel-dep-' + $env.RandomString
    New-AzResourceGroup -Name $env.DepResourceGroupName -Location $env.location
    $env['DepResourceGroupResourceUri'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.DepResourceGroupName)"

    $env['SgmResourceGroupName'] = 'rg-rel-sgm-' + $env.RandomString
    New-AzResourceGroup -Name $env.SgmResourceGroupName -Location $env.location
    $env['SgmResourceGroupResourceUri'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.SgmResourceGroupName)"

    # Target resource IDs
    # DependencyOf: source and target must be different. Use the other RG as target for RG-scoped tests.
    $env['DepTargetId'] = $env.SgmResourceGroupResourceUri
    # For subscription-scoped DependencyOf tests, target the dep resource group (source=sub, target=RG is valid)
    $env['DepTargetIdForSub'] = $env.DepResourceGroupResourceUri
    # ServiceGroup target for DependencyOf (RG source → SG target)
    $env['DepTargetServiceGroupId'] = "/providers/Microsoft.Management/serviceGroups/SDKTestsSG"
    $env['SgmTargetId'] = "/providers/Microsoft.Management/serviceGroups/SDKTestsSG"

    # --- Names for New tests (NOT created here; the tests create them) ---
    $env['DepRelNameForNew'] = 'deprelnew' + $env.RandomString
    $env['DepRelNameForNewJson'] = 'depreljson' + $env.RandomString
    $env['DepRelNameForNewSub'] = 'deprelsub' + $env.RandomString
    $env['DepRelNameForNewSgTarget'] = 'deprelsgt' + $env.RandomString
    $env['DepRelNameForNewSubToSg'] = 'deprelss' + $env.RandomString
    $env['DepRelNameForSameTarget'] = 'deprelst' + $env.RandomString
    $env['SgmRelNameForNew'] = 'sgmrelnew' + $env.RandomString
    $env['SgmRelNameForNewJson'] = 'sgmreljson' + $env.RandomString
    $env['SgmRelNameForNewSub'] = 'sgmrelsub' + $env.RandomString
    $env['SgmRelNameForNewJsonFile'] = 'sgmreljf' + $env.RandomString

    # --- Resources for Get tests ---
    $env['DepRelNameForGet'] = 'deprelget' + $env.RandomString
    New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForGet -TargetId $env.DepTargetId

    $env['SgmRelNameForGet'] = 'sgmrelget' + $env.RandomString
    New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForGet -TargetId $env.SgmTargetId

    # --- Resources for Update tests ---
    $env['DepRelNameToUpdate'] = 'deprelupt' + $env.RandomString
    New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToUpdate -TargetId $env.DepTargetId

    $env['SgmRelNameToUpdate'] = 'sgmrelupt' + $env.RandomString
    New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameToUpdate -TargetId $env.SgmTargetId

    # --- Resources for Remove tests ---
    $env['DepRelNameToDelete'] = 'depreldel' + $env.RandomString
    New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToDelete -TargetId $env.DepTargetId

    $env['DepRelNameToDeleteViaIdentity'] = 'depreldi' + $env.RandomString
    New-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToDeleteViaIdentity -TargetId $env.DepTargetId

    $env['SgmRelNameToDelete'] = 'sgmreldel' + $env.RandomString
    New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameToDelete -TargetId $env.SgmTargetId

    $env['SgmRelNameToDeleteViaIdentity'] = 'sgmreldi' + $env.RandomString
    New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameToDeleteViaIdentity -TargetId $env.SgmTargetId

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
    # Remove relationships first, then resource groups
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForGet -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameToUpdate -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNew -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNewJson -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.DepRelNameForNewSub -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.DepResourceGroupResourceUri -Name $env.DepRelNameForNewSgTarget -ErrorAction SilentlyContinue
    Remove-AzRelationshipsDependencyOfRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.DepRelNameForNewSubToSg -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForGet -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameToUpdate -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNew -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNewJson -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SubscriptionResourceUri -Name $env.SgmRelNameForNewSub -ErrorAction SilentlyContinue
    Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri $env.SgmResourceGroupResourceUri -Name $env.SgmRelNameForNewJsonFile -ErrorAction SilentlyContinue

    Remove-AzResourceGroup -Name $env.DepResourceGroupName -ErrorAction SilentlyContinue
    Remove-AzResourceGroup -Name $env.SgmResourceGroupName -ErrorAction SilentlyContinue
    Write-Host -ForegroundColor Magenta "Finished cleaning up test environment"
}

