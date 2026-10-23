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
$script:secretAccessCleanup = $null
function Initialize-TestSecretAccess() {
    $secretTests = @('Get-AzFrontDoorCdnSecret', 'New-AzFrontDoorCdnSecret', 'Remove-AzFrontDoorCdnSecret')
    if ($TestName) {
        $requiresSecretAccess = $false
        foreach ($name in $TestName) {
            if (@($secretTests -like $name).Count -gt 0) {
                $requiresSecretAccess = $true
                break
            }
        }
        if (-not $requiresSecretAccess) {
            return
        }
    }

    $frontDoorProfile = Get-AzFrontDoorCdnProfile -Name $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
    if (-not $frontDoorProfile.IdentityPrincipalId) {
        $identityParameters = @{ IdentityType = 'SystemAssigned' }
        if ($frontDoorProfile.IdentityType -match 'UserAssigned') {
            $identityParameters.IdentityType = 'SystemAssigned, UserAssigned'
            $identityParameters.IdentityUserAssignedIdentity = ($frontDoorProfile.ToJsonString() | ConvertFrom-Json -AsHashtable).identity.userAssignedIdentities
        }
        $frontDoorProfile = Update-AzFrontDoorCdnProfile -Name $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName @identityParameters -ErrorAction Stop
    }
    if (-not $frontDoorProfile.IdentityPrincipalId) {
        throw 'The test Front Door profile did not receive a system-assigned identity principal ID.'
    }

    # These fixtures use the same existing certificate as the three Secret tests.
    $vault = Get-AzKeyVault -VaultName 'jingnanxukvtest' -ResourceGroupName 'testps-rg-cdn-debug' -ErrorAction Stop
    $principalId = $frontDoorProfile.IdentityPrincipalId
    if ($vault.EnableRbacAuthorization) {
        $assignments = @(Get-AzRoleAssignment -ObjectId $principalId -RoleDefinitionName 'Key Vault Secrets User' -Scope $vault.ResourceId -ErrorAction Stop)
        if ($assignments.Count -eq 0) {
            New-AzRoleAssignment -ObjectId $principalId -ObjectType ServicePrincipal -RoleDefinitionName 'Key Vault Secrets User' -Scope $vault.ResourceId -ErrorAction Stop | Out-Null
            $script:secretAccessCleanup = @{
                Mode = 'Rbac'
                PrincipalId = $principalId
                Scope = $vault.ResourceId
            }
        }
    } else {
        $policy = $vault.AccessPolicies | Where-Object { $_.ObjectId -eq $principalId -and -not $_.ApplicationId }
        if (-not $policy -or $policy.PermissionsToSecrets -notcontains 'get') {
            $permissions = @($policy.PermissionsToSecrets | Where-Object { $_ })
            Set-AzKeyVaultAccessPolicy -VaultName $vault.VaultName -ResourceGroupName $vault.ResourceGroupName -ObjectId $principalId -PermissionsToSecrets @($permissions + 'get') -BypassObjectIdValidation -ErrorAction Stop
            $script:secretAccessCleanup = @{
                Mode = 'AccessPolicy'
                PrincipalId = $principalId
                VaultName = $vault.VaultName
                ResourceGroupName = $vault.ResourceGroupName
                PolicyExisted = [bool]$policy
                PreviousSecretPermissions = $permissions
            }
        }
    }

    # Probe new-secret creation, not preflight validation, which can use importer credentials.
    $probeName = 'kvsecret-setup-' + (RandomString -allChars $false -len 8)
    $parameter = New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -Type 'CustomerCertificate' -SecretSourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/testps-rg-cdn-debug/providers/Microsoft.KeyVault/vaults/jingnanxukvtest/secrets/wildcard-azfdtest-xyz"
    for ($attempt = 1; $attempt -le 30; $attempt++) {
        try {
            New-AzFrontDoorCdnSecret -Name $probeName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Parameter $parameter -ErrorAction Stop | Out-Null
            break
        } catch {
            if ($attempt -eq 30 -or $_.Exception.Message -notmatch 'No usable managed identity is available|We cannot access the secret in your Key Vault using the managed identities') {
                throw
            }
            Write-Warning "Waiting for test profile identity and Key Vault permissions to propagate (attempt $attempt of 30)."
            Start-TestSleep -Seconds 10
        }
    }
    Remove-AzFrontDoorCdnSecret -Name $probeName -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
}

function Clear-TestSecretAccess() {
    if (-not $script:secretAccessCleanup) {
        return
    }
    $access = $script:secretAccessCleanup
    if ($access.Mode -eq 'Rbac') {
        Remove-AzRoleAssignment -ObjectId $access.PrincipalId -RoleDefinitionName 'Key Vault Secrets User' -Scope $access.Scope -Confirm:$false -ErrorAction Stop
    } elseif ($access.PolicyExisted) {
        Set-AzKeyVaultAccessPolicy -VaultName $access.VaultName -ResourceGroupName $access.ResourceGroupName -ObjectId $access.PrincipalId -PermissionsToSecrets $access.PreviousSecretPermissions -BypassObjectIdValidation -ErrorAction Stop
    } else {
        Remove-AzKeyVaultAccessPolicy -VaultName $access.VaultName -ResourceGroupName $access.ResourceGroupName -ObjectId $access.PrincipalId -Confirm:$false -ErrorAction Stop
    }
    $script:secretAccessCleanup = $null
}

function setupEnv() {
    Write-Host -ForegroundColor Green "Start to import module."
    Import-Module -Name Az.FrontDoor
    Import-Module -Name Az.KeyVault

    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $subId = $env.SubscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'westus'

    # If UsePreviousConfigForRecord is set, reuse existing resources from env.json
    # This allows re-running individual failed tests without recreating all resources
    if ($UsePreviousConfigForRecord -and $env.ResourceGroupName) {
        $rgExists = Get-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction SilentlyContinue
        if ($rgExists) {
            Write-Host -ForegroundColor Green "Reusing previous environment from env.json (ResourceGroup: $($env.ResourceGroupName))"
            Initialize-TestSecretAccess
            return
        }
        # Resource group was deleted (e.g. by cleanupEnv), recreate with same names from env.json
        Write-Host -ForegroundColor Yellow "Resource group '$($env.ResourceGroupName)' no longer exists. Recreating with same names..."
        $resourceGroupName = $env.ResourceGroupName
        $classicCdnProfileName = $env.ClassicCdnProfileName
        $frontDoorCdnProfileName = $env.FrontDoorCdnProfileName

        New-AzResourceGroup -Name $resourceGroupName -Location $env.location
        Write-Host -ForegroundColor Green "Recreated resource group: $resourceGroupName"

        New-AzCdnProfile -SkuName "Standard_Microsoft" -Name $classicCdnProfileName -ResourceGroupName $resourceGroupName -Location Global | Out-Null
        Write-Host -ForegroundColor Green "Recreated Classic CDN profile: $classicCdnProfileName"

        New-AzFrontDoorCdnProfile -SkuName "Standard_AzureFrontDoor" -Name $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName -Location Global -IdentityType SystemAssigned -ErrorAction Stop | Out-Null
        Write-Host -ForegroundColor Green "Recreated FrontDoor CDN profile: $frontDoorCdnProfileName"

        Initialize-TestSecretAccess
        return
    }

    # Create the test resource group
    $resourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 4)
    Write-Host -ForegroundColor Green "Start to create test group $($resourceGroupName)"
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location
    Write-Host -ForegroundColor Green "test group $($resourceGroupName) created"
    $env.Add("ResourceGroupName", $resourceGroupName)

    # Create CDN profile with Standard_Microsoft SKU (used by CDN endpoint/origin/originGroup tests)
    $classicCdnProfileName = 'p-' + (RandomString -allChars $false -len 6)
    Write-Host -ForegroundColor Green "Start to create Standard_Microsoft SKU profile: $($classicCdnProfileName)"
    New-AzCdnProfile -SkuName "Standard_Microsoft" -Name $classicCdnProfileName -ResourceGroupName $resourceGroupName -Location Global | Out-Null
    $env.Add("ClassicCdnProfileName", $classicCdnProfileName)
    Write-Host -ForegroundColor Green "Standard_Microsoft SKU profile created."

    # Create FrontDoor CDN profile with Standard_AzureFrontDoor SKU
    $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6)
    Write-Host -ForegroundColor Green "Start to create Standard_AzureFrontDoor SKU profile: $($frontDoorCdnProfileName)"
    New-AzFrontDoorCdnProfile -SkuName "Standard_AzureFrontDoor" -Name $frontDoorCdnProfileName -ResourceGroupName $resourceGroupName -Location Global -IdentityType SystemAssigned -ErrorAction Stop | Out-Null
    $env.Add("FrontDoorCdnProfileName", $frontDoorCdnProfileName)
    Write-Host -ForegroundColor Green "Standard_AzureFrontDoor SKU profile created."

    Initialize-TestSecretAccess
    Write-Host -ForegroundColor Green "Setup complete. Individual tests will create their own sub-resources."

    # Save env
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green "Clean resources created for testing."
    try {
        Clear-TestSecretAccess
    } finally {
        Remove-AzResourceGroup -Name $env.ResourceGroupName -Force -Confirm:$false -ErrorAction Stop
    }
}
