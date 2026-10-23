Describe 'SecretSetup.Unit' {
    $utilsPath = Join-Path $PSScriptRoot 'utils.ps1'
    $parseErrors = $null
    $utilsAst = [System.Management.Automation.Language.Parser]::ParseFile(
        $utilsPath, [ref]$null, [ref]$parseErrors)
    if ($parseErrors) { throw $parseErrors[0] }
    foreach ($name in @('Initialize-TestSecretAccess', 'Clear-TestSecretAccess', 'setupEnv', 'cleanupEnv')) {
        $functionAst = $utilsAst.Find({
            param($node)
            $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and $node.Name -eq $name
        }, $true)
        Set-Item -Path "Function:$name" -Value $functionAst.Body.GetScriptBlock()
    }

    function Get-AzFrontDoorCdnProfile {
        [CmdletBinding()] param($Name, $ResourceGroupName)
        throw 'Unexpected unmocked profile read.'
    }
    function Update-AzFrontDoorCdnProfile {
        [CmdletBinding()] param($Name, $ResourceGroupName, $IdentityType, $IdentityUserAssignedIdentity)
        throw 'Unexpected unmocked profile update.'
    }
    function Get-AzKeyVault {
        [CmdletBinding()] param($VaultName, $ResourceGroupName)
        throw 'Unexpected unmocked Key Vault read.'
    }
    function Get-AzRoleAssignment {
        [CmdletBinding()] param($ObjectId, $RoleDefinitionName, $Scope)
        throw 'Unexpected unmocked role assignment read.'
    }
    function New-AzRoleAssignment {
        [CmdletBinding()] param($ObjectId, $ObjectType, $RoleDefinitionName, $Scope)
        throw 'Unexpected unmocked role assignment creation.'
    }
    function Remove-AzRoleAssignment {
        [CmdletBinding(SupportsShouldProcess)] param($ObjectId, $RoleDefinitionName, $Scope)
        throw 'Unexpected unmocked role assignment removal.'
    }
    function Set-AzKeyVaultAccessPolicy {
        [CmdletBinding()] param($VaultName, $ResourceGroupName, $ObjectId, $PermissionsToSecrets, [switch]$BypassObjectIdValidation)
        throw 'Unexpected unmocked access policy update.'
    }
    function Remove-AzKeyVaultAccessPolicy {
        [CmdletBinding(SupportsShouldProcess)] param($VaultName, $ResourceGroupName, $ObjectId)
        throw 'Unexpected unmocked access policy removal.'
    }
    function New-AzFrontDoorCdnSecretCustomerCertificateParametersObject {
        [CmdletBinding()] param($UseLatestVersion, $Type, $SecretSourceId)
        throw 'Unexpected unmocked certificate parameter creation.'
    }
    function New-AzFrontDoorCdnSecret {
        [CmdletBinding()] param($Name, $ProfileName, $ResourceGroupName, $Parameter)
        throw 'Unexpected unmocked secret creation.'
    }
    function Remove-AzFrontDoorCdnSecret {
        [CmdletBinding()] param($Name, $ProfileName, $ResourceGroupName)
        throw 'Unexpected unmocked secret removal.'
    }
    function Get-AzContext {
        [CmdletBinding()] param()
        throw 'Unexpected unmocked Azure context read.'
    }
    function Get-AzResourceGroup {
        [CmdletBinding()] param($Name)
        throw 'Unexpected unmocked resource group read.'
    }
    function New-AzResourceGroup {
        [CmdletBinding()] param($Name, $Location)
        throw 'Unexpected unmocked resource group creation.'
    }
    function New-AzCdnProfile {
        [CmdletBinding()] param($SkuName, $Name, $ResourceGroupName, $Location)
        throw 'Unexpected unmocked Classic profile creation.'
    }
    function New-AzFrontDoorCdnProfile {
        [CmdletBinding()] param($SkuName, $Name, $ResourceGroupName, $Location, $IdentityType)
        throw 'Unexpected unmocked profile creation.'
    }
    function Remove-AzResourceGroup {
        [CmdletBinding(SupportsShouldProcess)] param($Name, [switch]$Force)
        throw 'Unexpected unmocked resource group removal.'
    }
    function RandomString { param($allChars, $len) throw 'Unexpected unmocked random string generation.' }
    function Start-TestSleep { param($Seconds) throw 'Unexpected unmocked sleep.' }

    BeforeEach {
        $script:env = @{
            SubscriptionId = 'offline-subscription'
            ResourceGroupName = 'offline-test-rg'
            FrontDoorCdnProfileName = 'offline-profile'
            ClassicCdnProfileName = 'offline-classic'
        }
        $script:TestName = @('New-AzFrontDoorCdnSecret')
        $script:TestMode = 'record'
        $script:UsePreviousConfigForRecord = $false
        $script:secretAccessCleanup = $null
        $script:testProfile = [pscustomobject]@{
            IdentityType = 'SystemAssigned'
            IdentityPrincipalId = 'offline-principal'
        }
        $script:testVault = [pscustomobject]@{
            VaultName = 'offline-vault'
            ResourceGroupName = 'offline-vault-rg'
            ResourceId = '/subscriptions/offline/resourceGroups/offline-vault-rg/providers/Microsoft.KeyVault/vaults/offline-vault'
            EnableRbacAuthorization = $true
            AccessPolicies = @()
        }
        $script:probeAttempts = 0
        Mock Get-AzFrontDoorCdnProfile { $script:testProfile }
        Mock Update-AzFrontDoorCdnProfile {
            [pscustomobject]@{ IdentityType = 'SystemAssigned'; IdentityPrincipalId = 'offline-principal' }
        }
        Mock Get-AzKeyVault { $script:testVault }
        Mock Get-AzRoleAssignment { @() }
        Mock New-AzRoleAssignment {}
        Mock Remove-AzRoleAssignment {}
        Mock Set-AzKeyVaultAccessPolicy {}
        Mock Remove-AzKeyVaultAccessPolicy {}
        Mock New-AzFrontDoorCdnSecretCustomerCertificateParametersObject { @{ Type = 'CustomerCertificate' } }
        Mock New-AzFrontDoorCdnSecret {}
        Mock Remove-AzFrontDoorCdnSecret {}
        Mock RandomString { 'offline' }
        Mock Start-TestSleep {}
        Mock Write-Warning {}
        Mock Import-Module {}
        Mock Get-AzContext {
            [pscustomobject]@{
                Subscription = [pscustomobject]@{ Id = 'offline-subscription' }
                Tenant = [pscustomobject]@{ Id = 'offline-tenant' }
            }
        }
        Mock Get-AzResourceGroup { [pscustomobject]@{ ResourceGroupName = 'offline-test-rg' } }
        Mock New-AzResourceGroup {}
        Mock New-AzCdnProfile {}
        Mock New-AzFrontDoorCdnProfile {}
        Mock Remove-AzResourceGroup {}
        Mock Set-Content {}
    }

    It 'Enables identity on a reused profile before granting least-privilege vault access' {
        $script:testProfile.IdentityPrincipalId = $null
        $script:testProfile.IdentityType = 'None'
        Initialize-TestSecretAccess
        Assert-MockCalled Update-AzFrontDoorCdnProfile -Times 1 -Exactly -Scope It -ParameterFilter {
            $IdentityType -eq 'SystemAssigned' -and $Name -eq 'offline-profile'
        }
        Assert-MockCalled New-AzRoleAssignment -Times 1 -Exactly -Scope It -ParameterFilter {
            $ObjectId -eq 'offline-principal' -and $ObjectType -eq 'ServicePrincipal' -and
                $RoleDefinitionName -eq 'Key Vault Secrets User' -and $Scope -eq $script:testVault.ResourceId
        }
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 1 -Exactly -Scope It -ParameterFilter { $Name -like 'kvsecret-setup-*' }
        Assert-MockCalled Remove-AzFrontDoorCdnSecret -Times 1 -Exactly -Scope It -ParameterFilter { $Name -like 'kvsecret-setup-*' }
    }

    It 'Preserves user-assigned identities when adding a system-assigned identity' {
        $script:testProfile.IdentityPrincipalId = $null
        $script:testProfile.IdentityType = 'UserAssigned'
        $script:testProfile | Add-Member ScriptMethod ToJsonString {
            '{"identity":{"type":"UserAssigned","userAssignedIdentities":{"/subscriptions/offline/userAssignedIdentities/existing":{}}}}'
        }
        Initialize-TestSecretAccess
        Assert-MockCalled Update-AzFrontDoorCdnProfile -Times 1 -Exactly -Scope It -ParameterFilter {
            $IdentityType -eq 'SystemAssigned, UserAssigned' -and
                $IdentityUserAssignedIdentity.ContainsKey('/subscriptions/offline/userAssignedIdentities/existing')
        }
    }

    It 'Fails explicitly if enabling identity produces no principal ID' {
        $script:testProfile.IdentityPrincipalId = $null
        Mock Update-AzFrontDoorCdnProfile { [pscustomobject]@{ IdentityPrincipalId = $null } }
        { Initialize-TestSecretAccess } | Should -Throw 'principal ID'
        Assert-MockCalled Get-AzKeyVault -Times 0 -Exactly -Scope It
    }

    It 'Does not duplicate or remove existing role assignments' {
        Mock Get-AzRoleAssignment { [pscustomobject]@{ ObjectId = 'offline-principal' } }
        Initialize-TestSecretAccess
        Clear-TestSecretAccess
        Assert-MockCalled Update-AzFrontDoorCdnProfile -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzRoleAssignment -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzRoleAssignment -Times 0 -Exactly -Scope It
    }

    It 'Removes only the role assignment created by setup and clears cleanup state' {
        Initialize-TestSecretAccess
        Clear-TestSecretAccess
        Clear-TestSecretAccess
        Assert-MockCalled Remove-AzRoleAssignment -Times 1 -Exactly -Scope It -ParameterFilter {
            $ObjectId -eq 'offline-principal' -and $RoleDefinitionName -eq 'Key Vault Secrets User' -and
                $Scope -eq $script:testVault.ResourceId
        }
    }

    It 'Grants and removes get-only access for a legacy access-policy vault' {
        $script:testVault.EnableRbacAuthorization = $false
        Initialize-TestSecretAccess
        Assert-MockCalled Set-AzKeyVaultAccessPolicy -Times 1 -Exactly -Scope It -ParameterFilter {
            $ObjectId -eq 'offline-principal' -and $PermissionsToSecrets.Count -eq 1 -and
                $PermissionsToSecrets[0] -eq 'get' -and $BypassObjectIdValidation
        }
        Clear-TestSecretAccess
        Assert-MockCalled Remove-AzKeyVaultAccessPolicy -Times 1 -Exactly -Scope It -ParameterFilter {
            $ObjectId -eq 'offline-principal' -and $VaultName -eq 'offline-vault'
        }
        Assert-MockCalled New-AzRoleAssignment -Times 0 -Exactly -Scope It
    }

    It 'Preserves and restores existing secret permissions on an access policy' {
        $script:testVault.EnableRbacAuthorization = $false
        $script:testVault.AccessPolicies = @([pscustomobject]@{
            ObjectId = 'offline-principal'; ApplicationId = $null; PermissionsToSecrets = @('list')
        })
        Initialize-TestSecretAccess
        Assert-MockCalled Set-AzKeyVaultAccessPolicy -Times 1 -Exactly -Scope It -ParameterFilter {
            $PermissionsToSecrets -contains 'get' -and $PermissionsToSecrets -contains 'list'
        }
        Clear-TestSecretAccess
        Assert-MockCalled Set-AzKeyVaultAccessPolicy -Times 1 -Exactly -Scope It -ParameterFilter {
            $PermissionsToSecrets.Count -eq 1 -and $PermissionsToSecrets[0] -eq 'list'
        }
        Assert-MockCalled Remove-AzKeyVaultAccessPolicy -Times 0 -Exactly -Scope It
    }

    It 'Leaves an existing get-capable access policy unchanged' {
        $script:testVault.EnableRbacAuthorization = $false
        $script:testVault.AccessPolicies = @([pscustomobject]@{
            ObjectId = 'offline-principal'; ApplicationId = $null; PermissionsToSecrets = @('get', 'list')
        })
        Initialize-TestSecretAccess
        Clear-TestSecretAccess
        Assert-MockCalled Set-AzKeyVaultAccessPolicy -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzKeyVaultAccessPolicy -Times 0 -Exactly -Scope It
    }

    It 'Restores an existing access policy with no secret permissions without removing it' {
        $script:testVault.EnableRbacAuthorization = $false
        $script:testVault.AccessPolicies = @([pscustomobject]@{
            ObjectId = 'offline-principal'; ApplicationId = $null; PermissionsToSecrets = @()
        })
        Initialize-TestSecretAccess
        Clear-TestSecretAccess
        Assert-MockCalled Set-AzKeyVaultAccessPolicy -Times 1 -Exactly -Scope It -ParameterFilter {
            $null -ne $PermissionsToSecrets -and $PermissionsToSecrets.Count -eq 0
        }
        Assert-MockCalled Remove-AzKeyVaultAccessPolicy -Times 0 -Exactly -Scope It
    }

    It 'Retries only identity and permission propagation failures before the probe succeeds' {
        Mock New-AzFrontDoorCdnSecret {
            $script:probeAttempts++
            if ($script:probeAttempts -eq 1) { throw 'No usable managed identity is available on the current AFD profile.' }
            if ($script:probeAttempts -eq 2) { throw 'We cannot access the secret in your Key Vault using the managed identities configured on the current AFD profile.' }
        }
        Initialize-TestSecretAccess
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 3 -Exactly -Scope It
        Assert-MockCalled Start-TestSleep -Times 2 -Exactly -Scope It -ParameterFilter { $Seconds -eq 10 }
        Assert-MockCalled Remove-AzFrontDoorCdnSecret -Times 1 -Exactly -Scope It
    }

    It 'Bounds propagation retries and preserves the final service failure' {
        Mock New-AzFrontDoorCdnSecret { throw 'No usable managed identity is available on the current AFD profile.' }
        { Initialize-TestSecretAccess } | Should -Throw 'No usable managed identity'
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 30 -Exactly -Scope It
        Assert-MockCalled Start-TestSleep -Times 29 -Exactly -Scope It
        Assert-MockCalled Remove-AzFrontDoorCdnSecret -Times 0 -Exactly -Scope It
        Clear-TestSecretAccess
        Assert-MockCalled Remove-AzRoleAssignment -Times 1 -Exactly -Scope It
    }

    It 'Does not retry unrelated service errors' {
        Mock New-AzFrontDoorCdnSecret { throw 'The certificate format is invalid.' }
        { Initialize-TestSecretAccess } | Should -Throw 'certificate format'
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 1 -Exactly -Scope It
        Assert-MockCalled Start-TestSleep -Times 0 -Exactly -Scope It
    }

    It 'Propagates authorization errors instead of continuing to Secret tests' {
        Mock New-AzRoleAssignment { throw 'AuthorizationFailed' }
        { Initialize-TestSecretAccess } | Should -Throw 'AuthorizationFailed'
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 0 -Exactly -Scope It
    }

    It 'Avoids Key Vault access for unrelated targeted tests' {
        $script:TestName = @('Get-AzFrontDoorCdnOrigin', 'ApiUpgrade.Unit')
        Initialize-TestSecretAccess
        Assert-MockCalled Get-AzKeyVault -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzFrontDoorCdnProfile -Times 0 -Exactly -Scope It
    }

    It 'Initializes access for the full suite and wildcard Secret selections' -TestCases @(
        @{ Selection = $null },
        @{ Selection = @('*FrontDoorCdnSecret') }
    ) {
        param($Selection)
        $script:TestName = $Selection
        Initialize-TestSecretAccess
        Assert-MockCalled New-AzFrontDoorCdnSecret -Times 1 -Exactly -Scope It
    }

    It 'Repairs identity and access when reusing an existing environment' {
        $script:UsePreviousConfigForRecord = $true
        $script:testProfile.IdentityPrincipalId = $null
        setupEnv
        Assert-MockCalled New-AzFrontDoorCdnProfile -Times 0 -Exactly -Scope It
        Assert-MockCalled Update-AzFrontDoorCdnProfile -Times 1 -Exactly -Scope It
        Assert-MockCalled New-AzRoleAssignment -Times 1 -Exactly -Scope It
    }

    It 'Enables identity and initializes access when recreating the cached environment' {
        $script:UsePreviousConfigForRecord = $true
        Mock Get-AzResourceGroup { $null }
        setupEnv
        Assert-MockCalled New-AzFrontDoorCdnProfile -Times 1 -Exactly -Scope It -ParameterFilter {
            $IdentityType -eq 'SystemAssigned' -and $Name -eq 'offline-profile'
        }
        Assert-MockCalled New-AzRoleAssignment -Times 1 -Exactly -Scope It
    }

    It 'Enables identity and initializes access when creating a fresh environment' {
        $script:env = @{}
        setupEnv
        Assert-MockCalled New-AzFrontDoorCdnProfile -Times 1 -Exactly -Scope It -ParameterFilter {
            $IdentityType -eq 'SystemAssigned'
        }
        Assert-MockCalled New-AzRoleAssignment -Times 1 -Exactly -Scope It
        Assert-MockCalled Set-Content -Times 1 -Exactly -Scope It
    }

    It 'Still deletes the test resource group when permission cleanup fails' {
        Initialize-TestSecretAccess
        Mock Remove-AzRoleAssignment { throw 'Permission cleanup failed.' }
        { cleanupEnv } | Should -Throw 'Permission cleanup failed'
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq 'offline-test-rg' -and $Force -and -not $Confirm
        }
    }
}
