$PSModuleAutoLoadingPreference = 'None'
if (Get-Module Az.*) { throw 'Run offline checks in a fresh PowerShell process without Az modules loaded.' }
$repoRoot = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../../../..'))
$exceptionAssemblyPath = Join-Path $repoRoot 'artifacts/Debug/Az.DesktopVirtualization/DesktopVirtualization.Autorest/bin/Az.DesktopVirtualization.private.dll'
if (-not (Test-Path -LiteralPath $exceptionAssemblyPath)) { throw 'Offline typed exception checks require the existing local DesktopVirtualization build assembly.' }
$null = [System.Reflection.Assembly]::LoadFrom($exceptionAssemblyPath)
$null = [System.Reflection.Assembly]::LoadFrom((Join-Path (Split-Path -Parent $exceptionAssemblyPath) 'Azure.Core.dll'))
. (Join-Path $PSScriptRoot 'provision-common.ps1')
. (Join-Path $PSScriptRoot 'utils.ps1')
$script:recordedEnvPath = Join-Path $PSScriptRoot 'env.json'
$script:localEnvPath = Join-Path $PSScriptRoot 'localEnv.json'
$script:parentEnvPath = Join-Path (Split-Path -Parent $PSScriptRoot) 'env.json'

function Get-AzContext { throw 'Unmocked Azure call' }
function Get-AzVMUsage { param($Location) throw 'Unmocked Azure call' }
function Get-AzComputeResourceSku { throw 'Unmocked Azure call' }
function Get-AzVM { param($ResourceGroupName) throw 'Unmocked Azure call' }
function Get-AzWvdSessionHost { [CmdletBinding()]param($ResourceGroupName, $SubscriptionId, $HostPoolName) throw 'Unmocked Azure call' }
function Set-AzVMExtension { throw 'Unmocked Azure call' }
function Restart-AzVM { throw 'Unmocked Azure call' }
function Update-AzWvdHostPool { throw 'Unmocked Azure call' }
function Set-AzContext { param($SubscriptionId, $Tenant) throw 'Unmocked Azure call' }
function Get-AzWvdWorkspace { param($ResourceGroupName, $SubscriptionId) throw 'Unmocked Azure call' }
function Remove-AzWvdWorkspace { [CmdletBinding(SupportsShouldProcess)]param($ResourceGroupName, $SubscriptionId, $Name) throw 'Unmocked Azure call' }
function Get-AzVirtualNetwork { param($ResourceGroupName, $Name) throw 'Unmocked Azure call' }
function Get-AzVMImage { param($Location, $PublisherName, $Offer, $Skus) throw 'Unmocked Azure call' }
function Get-AzWvdHostPool { param($ResourceGroupName, $SubscriptionId, $Name) throw 'Unmocked Azure call' }
function Get-AzPrivateEndpoint { param($ResourceGroupName) throw 'Unmocked Azure call' }
function New-AzWvdWorkspace { param($Name, $ResourceGroupName, $SubscriptionId, $Location) throw 'Unmocked Azure call' }
function New-AzWvdHostPool { param($Name, $ResourceGroupName, $SubscriptionId, $Location, $HostPoolType, $LoadBalancerType, $MaxSessionLimit, $PreferredAppGroupType, $ManagementType, $IdentityType) throw 'Unmocked Azure call' }
function Get-AzKeyVaultSecret { param($VaultName, $Name, [switch]$AsPlainText) throw 'Unmocked secret access' }
function Get-AzWvdSessionHostConfiguration { [CmdletBinding()]param($SubscriptionId, $ResourceGroupName, $HostPoolName) throw 'Unmocked Azure call' }
function New-AzWvdSessionHostConfiguration {
    param($SubscriptionId, $ResourceGroupName, $HostPoolName, $ManagedDiskType, $DomainInfoJoinType, $ImageInfoImageType, $NetworkInfoSubnetId,
        $VMAdminCredentialsPasswordKeyvaultSecretUri, $VMAdminCredentialsUserNameKeyvaultSecretUri, $VMNamePrefix, $VMSizeId,
        $MarketplaceInfoExactVersion, $MarketplaceInfoOffer, $MarketplaceInfoPublisher, $MarketplaceInfoSku,
        [switch]$SecurityInfoSecureBootEnabled, $SecurityInfoType, [switch]$SecurityInfoVTpmEnabled, $VmLocation, $VmResourceGroup)
    throw 'Unmocked Azure call'
}
function Get-AzWvdSessionHostManagement { [CmdletBinding()]param($SubscriptionId, $ResourceGroupName, $HostPoolName) throw 'Unmocked Azure call' }
function New-AzWvdSessionHostManagement { param($SubscriptionId, $ResourceGroupName, $HostPoolName, $ScheduledDateTimeZone, $UpdateLogOffDelayMinute, $UpdateMaxVmsRemoved, $ProvisioningInstanceCount) throw 'Unmocked Azure call' }
function Update-AzWvdSessionHostManagement { param($SubscriptionId, $ResourceGroupName, $HostPoolName, $ProvisioningInstanceCount) throw 'Unmocked Azure call' }
function Get-AzWvdActiveSessionHostConfiguration { [CmdletBinding()]param($SubscriptionId, $ResourceGroupName, $HostPoolName) throw 'Unmocked Azure call' }
function Get-AzWvdSessionHostProvisioningStatus { [CmdletBinding()]param($SubscriptionId, $ResourceGroupName, $HostPoolName) throw 'Unmocked Azure call' }
function Get-AzResourceGroup { throw 'Unmocked Azure call' }
function Get-AzKeyVault { param($ResourceGroupName, $VaultName) throw 'Unmocked Azure call' }
function Get-AzWvdApplicationGroup { param($ResourceGroupName, $SubscriptionId) throw 'Unmocked Azure call' }
function New-AzWvdApplicationGroup { param($Name, $ResourceGroupName, $SubscriptionId, $Location, $HostPoolArmPath, $ApplicationGroupType) throw 'Unmocked Azure call' }
function New-AzPrivateLinkServiceConnection { param($Name, $PrivateLinkServiceId, $GroupId) throw 'Unmocked Azure call' }
function New-AzPrivateEndpoint { param($Name, $ResourceGroupName, $Location, $Subnet, $PrivateLinkServiceConnection, [switch]$Force) throw 'Unmocked Azure call' }
function Get-AzWvdPrivateEndpointConnection { param($SubscriptionId, $ResourceGroupName, $WorkspaceName, $HostPoolName) throw 'Unmocked Azure call' }
function Remove-AzPrivateEndpoint { param($ResourceGroupName, $Name, [switch]$Force) throw 'Unmocked Azure call' }
function Remove-AzWvdHostPool { [CmdletBinding(SupportsShouldProcess)]param($ResourceGroupName, $SubscriptionId, $Name) throw 'Unmocked Azure call' }
function Set-AzKeyVaultSecret { param($VaultName, $Name, $SecretValue) throw 'Unmocked secret write' }
function Get-AzStorageAccount { param($ResourceGroupName) throw 'Unmocked Azure call' }
function Get-AzADServicePrincipal { param($DisplayName) throw 'Unmocked Azure call' }
function Get-AzStorageShare { param($Context) throw 'Unmocked Azure call' }
function Get-AzStorageFile { [CmdletBinding()]param($ShareName, $Path, $ShareDirectoryClient, $Context) throw 'Unmocked Azure call' }
function New-AzStorageDirectory { param($ShareName, $Path, $Context) throw 'Unmocked Azure call' }
function Set-AzStorageFileContent { param($ShareName, $Source, $Path, $Context, [switch]$Force) throw 'Unmocked Azure call' }

Describe 'Offline profile configuration' {
    It 'runs both fixed PlanOnly entries with no state IO' {
        Mock Get-Content { throw 'IO is forbidden' }
        Mock Set-Content { throw 'IO is forbidden' }
        $identity = @{ TenantId = 'tenant'; SubscriptionId = 'subscription'; ResourceGroupName = 'rg'; Location = 'westus2' }
        $stable = & (Join-Path $PSScriptRoot 'provision-stable.ps1') @identity -PlanOnly
        $preview = & (Join-Path $PSScriptRoot 'provision-preview.ps1') @identity -PlanOnly
        $stable.Config.Profile | Should -Be 'Stable'
        $preview.Config.Profile | Should -Be 'Preview'
        @($stable.Pools | Where-Object ManagementType -ne Standard).Count | Should -Be 0
        $stable.SessionHostOperations | Should -Not -Contain 'New-AzWvdSessionHost'
        $preview.SessionHostOperations | Should -Contain 'New-AzWvdSessionHostConfiguration'
        $runtime = Build-AvdTestEnv $preview.Config 'run123'
        $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri | Should -Match '/secrets/password$'
        $runtime.VnetSubnetId | Should -Match '/subnets/default$'
        $runtime.HostPool | Should -Match 'preview-run123$'
        Assert-MockCalled Set-Content -Times 0
    }
    It 'separates identities without Azure discovery or IO' {
        $identity = @{ TenantId = 'tenant'; SubscriptionId = 'subscription'; ResourceGroupName = 'rg'; Location = 'westus2' }
        $stable = Get-AvdTestResourceConfig @identity -Profile Stable
        $preview = Get-AvdTestResourceConfig @identity -Profile Preview
        $stable.HostPoolPersistent | Should -Not -Be $preview.HostPoolPersistent
        $stable.StatePath | Should -Not -Be $preview.StatePath
        $preview.StandardHostPoolPersistent | Should -Not -Be $preview.AutomatedHostpoolPersistent
        $preview.SHMHostPoolPersistent | Should -Not -Be $preview.AutomatedHostpoolPersistent
        $preview.ResourceGroup | Should -Be $preview.ResourceGroupPersistent
        [System.IO.Path]::IsPathFullyQualified($preview.StatePath) | Should -Be $true
    }
}

Describe 'Offline state and safety guards' {
    BeforeEach {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
    }

    It 'rejects every identity mismatch' {
        foreach ($key in @('Profile', 'Tenant', 'SubscriptionId', 'ResourceGroup', 'Location')) {
            $state = $config | ConvertTo-Json | ConvertFrom-Json -AsHashtable
            $state[$key] = 'other'
            { Assert-AvdIdentity $config $state } | Should -Throw 'mismatch'
        }
    }

    It 'rejects a wrong context without changing it' {
        Mock Get-AzContext { @{ Tenant = @{ Id = 'wrong' }; Subscription = @{ Id = 'subscription' } } }
        { Assert-AvdContext $config } | Should -Throw 'context'
    }

    It 'round trips only secret-free state and rejects relative paths' {
        $path = Join-Path $TestDrive 'state.json'
        Write-AvdJson -Path $path -Value $config
        $state = Read-AvdState -Path $path -Expected $config
        $state.Profile | Should -Be 'Preview'
        { Write-AvdJson -Path $path -Value @{ password = 'must-not-write' } } | Should -Throw 'Secrets'
        { Read-AvdState -Path 'relative.json' } | Should -Throw 'absolute'
        { Write-AvdJson -Path (Join-Path $TestDrive 'example.Recording.json') -Value $config } | Should -Throw 'never playback'
    }

    Context 'WhatIf suppression' {
    It 'suppresses writes and all provisioning under WhatIf' {
        Mock Set-Content { throw 'Write forbidden' }
        Mock Get-AzContext { throw 'Context access forbidden' }
        Invoke-AvdProvision -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2 -WhatIf | Out-Null
        Write-AvdJson -Path (Join-Path $TestDrive 'state.json') -Value $config -WhatIf
        Assert-MockCalled Set-Content -Times 0
        Assert-MockCalled Get-AzContext -Times 0 -Scope It
    }
    }

    Context 'D2 required writes' {
    It 'D2 refuses required journal declines and failed writes' {
        $caller = [pscustomobject]@{}
        $caller | Add-Member -MemberType ScriptMethod -Name ShouldProcess -Value { param($target, $action) $false }
        { Confirm-AvdMutation $caller 'target' 'action' } | Should -Throw 'declined'
        $path = Join-Path $TestDrive 'required.json'
        { Write-AvdJson $path $config -Required -WhatIf } | Should -Throw 'Required AVD journal'
        Test-Path $path | Should -Be $false
        Mock Set-Content { throw 'Synthetic disk failure' }
        { Write-AvdJson $path $config -Required } | Should -Throw 'Synthetic disk failure'
    }
    }

    Context 'D2 phase results' {
    It 'D2 reports declined nested phases separately from completed phases' {
        $config.StatePath = Join-Path $TestDrive 'phase.state.json'
        Mock Assert-AvdDependencies { }
        Mock Assert-AvdContext { }
        Mock Set-AvdProcessSelection { }
        Mock Get-AzResourceGroup { @() }
        Mock Get-AzVirtualNetwork { throw 'No discovery after decline' }
        Mock Confirm-AvdMutation { $true }
        Mock Confirm-AvdMutation { throw [System.OperationCanceledException]::new('Synthetic nested decline') } -ParameterFilter { $Action -eq 'Create resource group' }
        Mock Ensure-AvdMsix { $true }
        $result = Invoke-AvdProvisionResources $config (Get-AvdProvisionPlan $config @('ControlPlane', 'Msix')) @{}
        $result.Status | Should -Be 'Incomplete'
        @($result.CompletedPhases).Count | Should -Be 1
        $result.CompletedPhases | Should -Contain 'Msix'
        @($result.SkippedPhases).Count | Should -Be 1
        $result.SkippedPhases | Should -Contain 'ControlPlane'
        Assert-MockCalled Get-AzVirtualNetwork -Times 0 -Scope It
    }
    }

    It 'rejects incompatible existing pools and missing Automated identity' {
        { Assert-AvdPool $config @{ ManagementType = 'Standard'; Location = 'westus2' } 'Automated' } | Should -Throw 'incompatible'
        { Assert-AvdPool $config @{ ManagementType = 'Automated'; Location = 'westus2' } 'Automated' } | Should -Throw 'identity'
    }

    It 'fails with actionable missing dependencies without installing anything' {
        Mock Get-Module { $null }
        { Assert-AvdDependencies $config (Get-AvdProvisionPlan $config @('All')) } | Should -Throw 'Import the installed'
    }

    It 'selects a quota-compatible SKU and rejects insufficient quota' {
        Mock Get-AzVMUsage { @(
            @{ Name = @{ Value = 'cores' }; CurrentValue = 0; Limit = 8 }
            @{ Name = @{ Value = 'family' }; CurrentValue = 0; Limit = 8 }
        ) }
        Mock Get-AzComputeResourceSku { @{
            Name = 'Standard_D2s_v3'; Family = 'family'; ResourceType = 'virtualMachines'; Locations = @('westus2')
            Capabilities = @(@{ Name = 'vCPUs'; Value = '2' }, @{ Name = 'MemoryGB'; Value = '8' }, @{ Name = 'HyperVGenerations'; Value = 'V2' })
        } }
        Get-AvdVMSize $config 3 | Should -Be 'Standard_D2s_v3'
        { Get-AvdVMSize $config 5 } | Should -Throw 'quota'
    }
}

Describe 'Offline host provisioning safety' {
    It 'does not refresh tokens, reapply extensions or restart existing registered Stable hosts' {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        Mock Get-AzVM { @{ Name = $config.SessionHostName } }
        Mock Get-AzWvdSessionHost { @{ Name = "$($config.HostPoolPersistent)/$($config.SessionHostName)" } }
        Mock Set-AzVMExtension { throw 'Extension must not be reapplied' }
        Mock Restart-AzVM { throw 'Restart forbidden' }
        Mock Update-AzWvdHostPool { throw 'Token refresh forbidden' }
        Ensure-AvdDirectHost -Config $config -PoolName $config.HostPoolPersistent -HostName $config.SessionHostName
        Assert-MockCalled Set-AzVMExtension -Times 0 -Scope It
        Assert-MockCalled Restart-AzVM -Times 0 -Scope It
        Assert-MockCalled Update-AzWvdHostPool -Times 0 -Scope It
    }

    It 'requires explicit repair for an unregistered existing VM' {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        Mock Get-AzVM { @{ Name = $config.SessionHostName } }
        Mock Get-AzWvdSessionHost { $null }
        { Ensure-AvdDirectHost -Config $config -PoolName $config.HostPoolPersistent -HostName $config.SessionHostName } | Should -Throw 'RepairSessionHosts'
    }

    It 'blocks all direct registration on Preview' {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        { Ensure-AvdDirectHost -Config $config } | Should -Throw 'Stable'
    }

    It 'suppresses direct hosts, secrets and MSIX operations under WhatIf' {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        Mock Get-AzVM { throw 'No VM access' }
        Mock Test-Path { throw 'No filesystem access' }
        Ensure-AvdDirectHost -Config $config -HostName host -WhatIf
        Get-AvdVMCredential -Config $config -WhatIf
        Ensure-AvdMsix -Config $config -WhatIf
        Assert-MockCalled Get-AzVM -Times 0 -Scope It
        Assert-MockCalled Test-Path -Times 0 -Scope It
    }
}

Describe 'Offline saved-run cleanup' {
    It 'uses the saved tenant subscription RG and names after selection changes' {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        $runtime = Build-AvdTestEnv $config ('a' * 32)
        $runtime.OwnedResources = @(@{ Kind = 'Workspace'; Name = $runtime.PvtLinkWS })
        $path = Join-Path $TestDrive 'partial.runtime.json'
        Write-AvdJson $path $runtime
        $oldSelection = $env:AVD_TEST_RESOURCE_GROUP
        try {
            $env:AVD_TEST_RESOURCE_GROUP = 'changed-rg'
            $script:cleanupContext = @{ Tenant = @{ Id = 'changed' }; Subscription = @{ Id = 'changed' } }
            Mock Get-AzContext { $script:cleanupContext }
            Mock Set-AzContext { $script:cleanupContext = @{ Tenant = @{ Id = $Tenant }; Subscription = @{ Id = $SubscriptionId } } }
            Mock Get-AzWvdWorkspace { @{ Name = $runtime.PvtLinkWS } }
            Mock Remove-AzWvdWorkspace { }
            cleanupEnv -RuntimeEnvPath $path
            Assert-MockCalled Set-AzContext -Times 1 -Scope It -ParameterFilter { $SubscriptionId -eq 'subscription' -and $Tenant -eq 'tenant' }
            Assert-MockCalled Remove-AzWvdWorkspace -Times 1 -Scope It -ParameterFilter { $ResourceGroupName -eq 'rg' -and $SubscriptionId -eq 'subscription' -and $Name -eq $runtime.PvtLinkWS }
            Test-Path $path | Should -Be $false
        } finally {
            $env:AVD_TEST_RESOURCE_GROUP = $oldSelection
        }
    }

    It 'rejects cleanup of persistent or foreign resources' {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        $runtime = Build-AvdTestEnv $config ('a' * 32)
        $runtime.OwnedResources = @(@{ Kind = 'HostPool'; Name = $config.HostPoolPersistent })
        $path = Join-Path $TestDrive 'foreign.runtime.json'
        Write-AvdJson $path $runtime
        { cleanupEnv -RuntimeEnvPath $path } | Should -Throw 'not owned'
    }
}

Describe 'Offline Preview provisioning contracts' {
    BeforeEach {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        $config | Add-Member -NotePropertyName MarketplaceImageVersion -NotePropertyValue '1.0.0'
        $plan = Get-AvdProvisionPlan $config @('All')
        $runtime = Build-AvdTestEnv $config 'provision'
        Mock Get-AzWvdHostPool { @{ Name = $Name; Location = 'westus2'; ManagementType = 'Automated'; IdentityPrincipalId = 'principal' } }
        Mock Get-AzVirtualNetwork { @{ Subnets = @(@{ Id = $runtime.VnetSubnetId }) } }
        Mock Get-AzKeyVaultSecret { @(@{ Name = 'username' }, @{ Name = 'password' }) }
        Mock Ensure-AvdRole { }
        Mock Get-AzWvdSessionHostConfiguration { $null }
        Mock New-AzWvdSessionHostConfiguration { @{ VMNamePrefix = $VMNamePrefix; NetworkInfoSubnetId = $NetworkInfoSubnetId } }
        Mock Get-AzWvdSessionHostManagement { $null }
        Mock New-AzWvdSessionHostManagement { @{ ProvisioningInstanceCount = $ProvisioningInstanceCount } }
        Mock Update-AzWvdSessionHostManagement { throw 'Unexpected update' }
        Mock Get-AzWvdActiveSessionHostConfiguration { $null }
        Mock Get-AzWvdSessionHostProvisioningStatus { $null }
        Mock Get-AzWvdSessionHost { @() }
    }

    It 'requests separate session and lifecycle counts after SHC and identity roles' {
        $session = Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3'
        $lifecycle = Ensure-AvdManagedHosts $config $plan.Pools[2] 'Standard_D2s_v3'
        $session.RequestedCount | Should -Be 1
        $lifecycle.RequestedCount | Should -Be 3
        $session.MissingExpectedHosts | Should -Contain $config.SessionHostName
        $lifecycle.MissingExpectedHosts | Should -Contain $config.SHMSessionHostNameRemove
        $session.Pending | Should -Not -BeNullOrEmpty
        Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 2 -Scope It
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 1 -Scope It -ParameterFilter { $HostPoolName -eq $config.HostPoolPersistent -and $ProvisioningInstanceCount -eq 1 }
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 1 -Scope It -ParameterFilter { $HostPoolName -eq $config.SHMHostPoolPersistent -and $ProvisioningInstanceCount -eq 3 }
        Assert-MockCalled Ensure-AvdRole -Times 2 -Scope It -ParameterFilter { $Role -eq 'Desktop Virtualization Virtual Machine Contributor' }
        Assert-MockCalled Ensure-AvdRole -Times 2 -Scope It -ParameterFilter { $Role -eq 'Key Vault Secrets User' }
    }

    It 'refuses missing credential prerequisites before SHC or host provisioning' {
        Mock Get-AzKeyVaultSecret { @() }
        { Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' } | Should -Throw 'both Key Vault'
        Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 0 -Scope It
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
    }

    It 'creates initial SHC and SHM for typed AVD NotFound <ExceptionKind>' -TestCases @(
        @{ ExceptionKind = 'Undeclared' }
        @{ ExceptionKind = 'RestErrorResponse' }
    ) {
        param($ExceptionKind)
        $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::NotFound)
        $response.RequestMessage = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Get, 'https://offline.invalid/')
        $response.Content = [System.Net.Http.StringContent]::new('{}')
        $script:absenceException = if ($ExceptionKind -eq 'Undeclared') {
            [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.UndeclaredResponseException]::new($response)
        } else {
            [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.RestException[Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IErrorResponse]]::new($response, $null)
        }
        try {
            Mock Get-AzWvdSessionHostConfiguration { Write-Error -Exception $script:absenceException }
            Mock Get-AzWvdSessionHostManagement { Write-Error -Exception $script:absenceException }
            Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' | Out-Null
            Ensure-AvdManagedHosts $config $plan.Pools[2] 'Standard_D2s_v3' | Out-Null
            Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 2 -Exactly -Scope It
            Assert-MockCalled New-AzWvdSessionHostManagement -Times 1 -Exactly -Scope It -ParameterFilter { $ProvisioningInstanceCount -eq 1 }
            Assert-MockCalled New-AzWvdSessionHostManagement -Times 1 -Exactly -Scope It -ParameterFilter { $ProvisioningInstanceCount -eq 3 }
            Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
        } finally {
            $script:absenceException.Dispose()
            $response.Dispose()
        }
    }

    It 'propagates AVD <Status> from <Operation> without dependent creation or update' -TestCases @(
        foreach ($status in @(401, 403, 429, 500, 503, 0, -1, -2)) {
            foreach ($operation in @('Get-AzWvdSessionHostConfiguration', 'Get-AzWvdSessionHostManagement')) {
                @{ Status = $status; Operation = $operation }
            }
        }
    ) {
        param($Status, $Operation)
        $response = $null
        $script:discoveryException = if ($Status -eq 0) { [System.Net.Http.HttpRequestException]::new('Offline network failure') }
            elseif ($Status -lt 0) { [System.Exception]::new('404 NotFound is not typed absence') }
            else {
                $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]$Status)
                $response.RequestMessage = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Get, 'https://offline.invalid/')
                $response.Content = [System.Net.Http.StringContent]::new('{}')
                [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.RestException]::new($response)
            }
        if ($Status -eq -2) {
            $script:discoveryException | Add-Member -NotePropertyName StatusCode -NotePropertyValue ([System.Net.HttpStatusCode]::NotFound)
        }
        try {
            Mock Get-AzWvdSessionHostConfiguration { @{
                VMNamePrefix = $config.SessionHostNamePrefixOfAutomatedHostpoolPersistent; NetworkInfoSubnetId = $runtime.VnetSubnetId
                VMResourceGroup = $config.ResourceGroup; VMLocation = $config.Location
                VMAdminCredentialsPasswordKeyVaultSecretUri = $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri
                VMAdminCredentialsUsernameKeyVaultSecretUri = $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri
            } }
            Mock $Operation { Write-Error -Exception $script:discoveryException }
            $caught = $null
            try { Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' } catch { $caught = $_.Exception }
            $caught | Should -Be $script:discoveryException
            Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 0 -Scope It
            Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
            Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
        } finally {
            if ($response) {
                $script:discoveryException.Dispose()
                $response.Dispose()
            }
        }
    }

    It 'does not use Automated provisioning for the Standard registration-test pool' {
        { Ensure-AvdManagedHosts $config $plan.Pools[0] 'Standard_D2s_v3' } | Should -Throw 'Automated'
    }

    It 'does not reapply matching SHC or the existing instance count' {
        Mock Get-AzWvdSessionHostConfiguration { @{
            VMNamePrefix = $config.SessionHostNamePrefixOfAutomatedHostpoolPersistent; NetworkInfoSubnetId = $runtime.VnetSubnetId
            VMResourceGroup = $config.ResourceGroup; VMLocation = $config.Location
            VMAdminCredentialsPasswordKeyVaultSecretUri = $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri
            VMAdminCredentialsUsernameKeyVaultSecretUri = $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri
        } }
        Mock Get-AzWvdSessionHostManagement { @{ ProvisioningInstanceCount = 1 } }
        Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' | Out-Null
        Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 0 -Scope It
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
        Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
    }

    It 'D4 stops on nonterminating SHC discovery errors before any create or update' {
        Mock Get-AzWvdSessionHostConfiguration { Write-Error 'Synthetic authorization failure' }
        { Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' } | Should -Throw 'Synthetic authorization'
        Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 0 -Scope It
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
        Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
    }

    It 'D4 stops on nonterminating SHM discovery errors before requesting hosts' {
        Mock Get-AzWvdSessionHostManagement { Write-Error 'Synthetic transient failure' }
        { Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' } | Should -Throw 'Synthetic transient'
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
        Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
    }

    It 'D4 records sanitized observation failures and never completes the phase' {
        Mock Get-AzWvdActiveSessionHostConfiguration { Write-Error 'Synthetic private response' }
        Mock Get-AzWvdSessionHostProvisioningStatus { Write-Error 'Synthetic private response' }
        Mock Get-AzWvdSessionHost { Write-Error 'Synthetic private response' }
        $observation = Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3'
        $observation.ObservationFailures.Count | Should -Be 3
        $observation.ActiveConfigurationCount | Should -BeNullOrEmpty
        $observation.MissingExpectedHosts | Should -BeNullOrEmpty
        ($observation | ConvertTo-Json -Depth 8) | Should -Not -Match 'Synthetic private response'
        $config.StatePath = Join-Path $TestDrive 'observations.state.json'
        Mock Assert-AvdDependencies { }
        Mock Assert-AvdContext { }
        Mock Assert-AvdPool { }
        Mock Set-AvdProcessSelection { }
        Mock Get-AvdVMCredential { [pscredential]::new('synthetic', (ConvertTo-SecureString ([guid]::NewGuid().ToString('N')) -AsPlainText -Force)) }
        Mock Get-AzVMImage { @{ Version = '1.0.0' } }
        Mock Get-AzVM { @() }
        Mock Get-AvdVMSize { 'Standard_D2s_v3' }
        $result = Invoke-AvdProvisionResources $config (Get-AvdProvisionPlan $config @('SessionHosts')) @{}
        $result.Status | Should -Be 'Incomplete'
        $result.CompletedPhases.Count | Should -Be 0
        $result.FailedPhases | Should -Contain 'SessionHosts'
        $result.Observations.Count | Should -Be 2
    }

    It 'D3 rejects every mismatched or missing existing SHC destination field before requesting hosts' {
        $matching = @{
            VMNamePrefix = $config.SessionHostNamePrefixOfAutomatedHostpoolPersistent; NetworkInfoSubnetId = $runtime.VnetSubnetId
            VMResourceGroup = $config.ResourceGroup; VMLocation = $config.Location
            VMAdminCredentialsPasswordKeyVaultSecretUri = $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri
            VMAdminCredentialsUsernameKeyVaultSecretUri = $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri
        }
        foreach ($property in @($matching.Keys)) {
            foreach ($value in @('other', $null)) {
                $script:existingConfiguration = $matching.Clone()
                $script:existingConfiguration[$property] = $value
                Mock Get-AzWvdSessionHostConfiguration { $script:existingConfiguration }
                { Ensure-AvdManagedHosts $config $plan.Pools[1] 'Standard_D2s_v3' } | Should -Throw "Existing SHC $property"
            }
        }
        Assert-MockCalled New-AzWvdSessionHostConfiguration -Times 0 -Scope It
        Assert-MockCalled Get-AzWvdSessionHostManagement -Times 0 -Scope It
        Assert-MockCalled New-AzWvdSessionHostManagement -Times 0 -Scope It
        Assert-MockCalled Update-AzWvdSessionHostManagement -Times 0 -Scope It
    }
}

Describe 'Offline setup and loader handoff' {
    BeforeEach {
        $savedEnvironment = @{}
        foreach ($name in @('AVD_TEST_PROFILE', 'AVD_TEST_STATE_PATH', 'AVD_TEST_RUNTIME_ENV_PATH', 'AVD_TEST_PLAYBACK_ENV_PATH', 'AVD_TEST_TENANT_ID', 'AVD_TEST_SUBSCRIPTION_ID', 'AVD_TEST_RESOURCE_GROUP', 'AVD_TEST_LOCATION', 'AzPSAutorestTestPlaybackMode')) {
            $savedEnvironment[$name] = [Environment]::GetEnvironmentVariable($name, 'Process')
            [Environment]::SetEnvironmentVariable($name, $null, 'Process')
        }
        $statePath = Join-Path $TestDrive 'selected.state.json'
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2 -StatePath $statePath
        Write-AvdJson $statePath $config
        Set-AvdProcessSelection $config
        Mock Get-AzContext { @{ Tenant = @{ Id = 'tenant' }; Subscription = @{ Id = 'subscription' } } }
    }

    AfterEach {
        foreach ($name in $savedEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $savedEnvironment[$name], 'Process') }
        $script:AvdRuntimeEnvPath = $null
    }

    It 'D1 never cleans an older run when runner setup fails before claiming ownership' {
        $runtime = Build-AvdTestEnv $config ('a' * 32)
        $runtime.OwnedResources = @(@{ Kind = 'Workspace'; Name = $runtime.PvtLinkWS })
        $path = Join-Path $TestDrive 'older.runtime.json'
        Write-AvdJson $path $runtime
        $original = Get-Content -LiteralPath $path -Raw
        Mock Remove-AzWvdWorkspace { throw 'Must not remove an older run' }
        Mock Remove-AzWvdHostPool { throw 'Must not remove an older run' }
        Mock Remove-AzPrivateEndpoint { throw 'Must not remove an older run' }
        foreach ($failure in @('collision', 'selection')) {
            $script:AvdRuntimeEnvPath = $path
            $env:AVD_TEST_RUNTIME_ENV_PATH = $path
            if ($failure -eq 'selection') { $env:AVD_TEST_PROFILE = 'Stable' }
            { try { setupEnv } finally { cleanupEnv } } | Should -Throw
            (Get-Content -LiteralPath $path -Raw) | Should -BeExactly $original
            $script:AvdRuntimeEnvPath | Should -BeNullOrEmpty
        }
        Assert-MockCalled Remove-AzWvdWorkspace -Times 0 -Scope It
        Assert-MockCalled Remove-AzWvdHostPool -Times 0 -Scope It
        Assert-MockCalled Remove-AzPrivateEndpoint -Times 0 -Scope It
    }

    Context 'D2 setup journals' {
    It 'D2 prevents setup mutations when initial or per-resource journal commitment fails' {
        $derived = Build-AvdTestEnv $config 'provision'
        Mock Get-AzVirtualNetwork { @{ Subnets = @(@{ Id = $derived.VnetSubnetId }) } }
        Mock Get-AzVMImage { @{ Version = '1.0.0' } }
        Mock Get-AzWvdWorkspace { @() }
        Mock Get-AzWvdHostPool { @() }
        Mock Get-AzPrivateEndpoint { @() }
        Mock New-AzWvdWorkspace { throw 'Unjournaled mutation' }
        $script:journalWriter = (Get-Command Write-AvdJson).ScriptBlock
        foreach ($failureAt in @(1, 2)) {
            $script:journalCalls = 0
            Mock Write-AvdJson {
                $Required | Should -Be $true
                $script:journalCalls++
                if ($script:journalCalls -eq $failureAt) {
                    & $script:journalWriter -Path $Path -Value $Value -Required -WhatIf
                } else {
                    & $script:journalWriter -Path $Path -Value $Value -Required
                }
            }
            $path = Join-Path $TestDrive "declined-$failureAt.runtime.json"
            { try { setupEnv -RuntimeEnvPath $path } finally { cleanupEnv } } | Should -Throw 'Required AVD journal'
            Test-Path $path | Should -Be $false
        }
        Assert-MockCalled New-AzWvdWorkspace -Times 0 -Scope It
    }
    }

    It 'persists attempted resource ownership before a setup mutation fails' {
        $derived = Build-AvdTestEnv $config 'provision'
        Mock Get-AzVirtualNetwork { @{ Subnets = @(@{ Id = $derived.VnetSubnetId }) } }
        Mock Get-AzVMImage { @{ Version = '1.0.0' } }
        Mock Get-AzWvdWorkspace { @() }
        Mock Get-AzWvdHostPool { @() }
        Mock Get-AzPrivateEndpoint { @() }
        Mock New-AzWvdWorkspace {
            $saved = Read-AvdState $env:AVD_TEST_RUNTIME_ENV_PATH
            $saved.OwnedResources.Name | Should -Contain $Name
            throw 'Synthetic setup failure'
        }
        $runtimePath = Join-Path $TestDrive 'partial.runtime.json'
        { setupEnv -RuntimeEnvPath $runtimePath } | Should -Throw 'Synthetic setup failure'
        $saved = Read-AvdState $runtimePath
        $saved.SetupComplete | Should -Be $false
        $saved.OwnedResources.Count | Should -Be 1
        $saved.Tenant | Should -Be tenant
        Mock Get-AzWvdWorkspace { @{ Name = $saved.PvtLinkWS } }
        Mock Remove-AzWvdWorkspace { }
        cleanupEnv -RuntimeEnvPath $runtimePath
        Test-Path $runtimePath | Should -Be $false
    }

    It 'Direction1 creates and cleans six fixtures with exact WS and HP patterns for both returned names' {
        $derived = Build-AvdTestEnv $config 'provision'
        Mock Get-AzVirtualNetwork { @{ Subnets = @(@{ Id = $derived.VnetSubnetId }) } }
        Mock Get-AzVMImage { @{ Version = '1.0.0' } }
        Mock Get-AzWvdWorkspace { @() }
        Mock Get-AzWvdHostPool { @() }
        Mock Get-AzPrivateEndpoint { @() }
        Mock New-AzWvdWorkspace { @{ Id = '/workspace'; Name = $Name } }
        Mock New-AzWvdHostPool { @{ Id = '/hostpool'; Name = $Name } }
        Mock New-AzPrivateLinkServiceConnection { @{ Name = $Name } }
        Mock New-AzPrivateEndpoint { }
        Mock Get-AzWvdPrivateEndpointConnection {
            if ($WorkspaceName) { @(@{ Name = 'workspace.connection-0' }, @{ Name = 'workspace.connection-1' }) }
            else { @(@{ Name = 'pool.connection-0' }, @{ Name = 'pool.connection-1' }) }
        }
        $runtimePath = Join-Path $TestDrive 'complete.runtime.json'
        setupEnv -RuntimeEnvPath $runtimePath
        $saved = Read-AvdState $runtimePath
        $saved.SetupComplete | Should -Be $true
        $saved.OwnedResources.Count | Should -Be 6
        'workspace.connection-0' | Should -Match $saved.PrivateEndpointConnectionName0
        'pool.connection-1' | Should -Match $saved.PrivateEndpointConnectionName1
        @('workspace.connection-0', 'workspace.connection-1') | Should -Match $saved.PrivateEndpointConnectionNameWS
        @('pool.connection-0', 'pool.connection-1') | Should -Match $saved.PrivateEndpointConnectionNameHP
        @('workspaceXconnection-0', 'pool.connection-0', 'workspace.connection-0-extra') | Should -Not -Match $saved.PrivateEndpointConnectionNameWS
        @('poolXconnection-0', 'workspace.connection-0', 'pool.connection-0-extra') | Should -Not -Match $saved.PrivateEndpointConnectionNameHP
        Assert-MockCalled New-AzWvdHostPool -Times 1 -Scope It -ParameterFilter { $ManagementType -eq 'Standard' }
        Mock Get-AzWvdWorkspace { @{ Name = $saved.PvtLinkWS } }
        Mock Get-AzWvdHostPool { @{ Name = $saved.PvtLinkHP } }
        Mock Get-AzPrivateEndpoint { $saved.OwnedResources | Where-Object Kind -eq 'PrivateEndpoint' }
        Mock Remove-AzWvdWorkspace { }
        Mock Remove-AzWvdHostPool { }
        Mock Remove-AzPrivateEndpoint { }
        cleanupEnv -RuntimeEnvPath $runtimePath
        Assert-MockCalled Remove-AzPrivateEndpoint -Times 4 -Exactly -Scope It
        Assert-MockCalled Remove-AzWvdWorkspace -Times 1 -Exactly -Scope It
        Assert-MockCalled Remove-AzWvdHostPool -Times 1 -Exactly -Scope It
        Test-Path $runtimePath | Should -Be $false
        $env:AVD_TEST_PLAYBACK_ENV_PATH = "$runtimePath.playback.json"
        $snapshot = Read-AvdState $env:AVD_TEST_PLAYBACK_ENV_PATH
        $snapshot.PlaybackSnapshot | Should -Be $true
        $snapshot.ContainsKey('OwnedResources') | Should -Be $false
        foreach ($mode in @('playback', 'record')) {
            $env:AzPSAutorestTestPlaybackMode = if ($mode -eq 'record') { 'true' } else { $null }
            $loaded = & { $TestMode = $mode; . (Join-Path $PSScriptRoot 'loadEnv.ps1'); $env }
            foreach ($key in $saved.Keys | Where-Object { $_ -ne 'OwnedResources' }) {
                ($loaded.$key | ConvertTo-Json -Depth 12 -Compress) | Should -BeExactly ($saved[$key] | ConvertTo-Json -Depth 12 -Compress)
            }
        }
        { cleanupEnv -RuntimeEnvPath $env:AVD_TEST_PLAYBACK_ENV_PATH } | Should -Throw 'not a cleanup'
        { setupEnv -RuntimeEnvPath $runtimePath } | Should -Throw 'Playback snapshot already exists'
        $env:AzPSAutorestTestPlaybackMode = $null
        $env:AVD_TEST_RUNTIME_ENV_PATH = $env:AVD_TEST_PLAYBACK_ENV_PATH
        { & { $TestMode = 'live'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') } } | Should -Throw 'cannot select live'
    }

    Context 'Direction2 snapshot commitment' {
    It 'Direction2 prevents cleanup when the recording snapshot cannot be committed' {
        $runtime = Build-AvdTestEnv $config ('d' * 32)
        $runtime.SetupComplete = $true
        $runtime.OwnedResources = @(@{ Kind = 'Workspace'; Name = $runtime.PvtLinkWS })
        $path = Join-Path $TestDrive 'snapshot-failure.runtime.json'
        Write-AvdJson $path $runtime
        $original = Get-Content -LiteralPath $path -Raw
        Mock Write-AvdJson { throw 'Synthetic snapshot write failure' } -ParameterFilter { $Path -like '*.playback.json' -and $Required }
        Mock Remove-AzWvdWorkspace { throw 'Removal before snapshot commitment' }
        { cleanupEnv -RuntimeEnvPath $path } | Should -Throw 'Synthetic snapshot write failure'
        (Get-Content -LiteralPath $path -Raw) | Should -BeExactly $original
        Assert-MockCalled Remove-AzWvdWorkspace -Times 0 -Scope It
        Assert-MockCalled Get-AzContext -Times 0 -Scope It
    }
    }

    It 'Direction2 fails closed for missing or incomplete explicit Playback snapshots' {
        $path = Join-Path $TestDrive 'missing.playback.json'
        $env:AVD_TEST_PLAYBACK_ENV_PATH = $path
        { & { $TestMode = 'playback'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') } } | Should -Throw
        $snapshot = Build-AvdTestEnv $config ('c' * 32)
        $snapshot.PlaybackSnapshot = $true
        $snapshot.SetupComplete = $false
        Write-AvdJson $path $snapshot
        { & { $TestMode = 'playback'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') } } | Should -Throw 'not a completed recording snapshot'
    }

    It 'loads an absolute runtime in an isolated scope and rejects incomplete setup' {
        $runtime = Build-AvdTestEnv $config ('b' * 32)
        $runtime.SetupComplete = $true
        $path = Join-Path $TestDrive 'selected.runtime.json'
        Write-AvdJson $path $runtime
        $env:AVD_TEST_RUNTIME_ENV_PATH = $path
        $loaded = & { $TestMode = 'record'; . (Join-Path $PSScriptRoot 'loadEnv.ps1'); $env }
        $loaded.Tenant | Should -Be tenant
        $loaded.HostPool | Should -Be $runtime.HostPool
        $runtime.SetupComplete = $false
        Write-AvdJson $path $runtime
        { & { $TestMode = 'live'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') } } | Should -Throw 'incomplete'
    }

    It 'D5 rejects selected profile or state with missing runtime in Record and Live' {
        Mock Get-Content { throw 'Legacy environment must not be read' } -ParameterFilter { $LiteralPath -in @($script:recordedEnvPath, $script:localEnvPath, $script:parentEnvPath) }
        foreach ($selection in @('profile', 'state', 'both')) {
            $env:AVD_TEST_PROFILE = if ($selection -ne 'state') { 'Preview' } else { $null }
            $env:AVD_TEST_STATE_PATH = if ($selection -ne 'profile') { $statePath } else { $null }
            foreach ($mode in @('record', 'live')) {
                { & { $TestMode = $mode; . (Join-Path $PSScriptRoot 'loadEnv.ps1') } } | Should -Throw 'requires AVD_TEST_RUNTIME_ENV_PATH'
            }
        }
        Assert-MockCalled Get-Content -Times 0 -Scope It -ParameterFilter { $LiteralPath -in @($script:recordedEnvPath, $script:localEnvPath, $script:parentEnvPath) }
    }

    It 'preserves default Playback and unselected localEnv selection and reads the resolved parent path' {
        $env:AVD_TEST_RUNTIME_ENV_PATH = Join-Path $TestDrive 'does-not-exist.runtime.json'
        Mock Test-Path { $true } -ParameterFilter { $Path -in @($script:recordedEnvPath, $script:localEnvPath, $script:parentEnvPath) }
        Mock Get-Content { '{"Tenant":"recorded"}' } -ParameterFilter { $LiteralPath -in @($script:recordedEnvPath, $script:localEnvPath, $script:parentEnvPath) }
        $loaded = & { $TestMode = 'playback'; . (Join-Path $PSScriptRoot 'loadEnv.ps1'); $env }
        $loaded.Tenant | Should -Be recorded
        Assert-MockCalled Get-Content -Times 1 -Scope It -ParameterFilter { $LiteralPath -eq $script:recordedEnvPath }
        $env:AVD_TEST_RUNTIME_ENV_PATH = $null
        $env:AVD_TEST_PROFILE = $null
        $env:AVD_TEST_STATE_PATH = $null
        $null = & { $TestMode = 'live'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') }
        Assert-MockCalled Get-Content -Times 1 -Scope It -ParameterFilter { $LiteralPath -eq $script:localEnvPath }
        Mock Test-Path { $false } -ParameterFilter { $Path -eq $script:recordedEnvPath }
        $null = & { $TestMode = 'playback'; . (Join-Path $PSScriptRoot 'loadEnv.ps1') }
        Assert-MockCalled Get-Content -Times 1 -Scope It -ParameterFilter { $LiteralPath -eq $script:parentEnvPath }
    }

    It 'rejects mismatched explicit profile and environment overrides' {
        $env:AVD_TEST_PROFILE = 'Stable'
        { Get-AvdSelectedConfig } | Should -Throw 'mismatch'
        $env:AVD_TEST_PROFILE = 'Preview'
        $env:AVD_TEST_RESOURCE_GROUP = 'another-rg'
        { Get-AvdSelectedConfig } | Should -Throw 'conflicts'
    }
}

Describe 'Offline grouped recording environments' {
    BeforeEach {
        $savedEnvironment = @{}
        foreach ($entry in @(Get-ChildItem Env: | Where-Object { $_.Name -like 'AVD_TEST_*' -or $_.Name -eq 'AzPSAutorestTestPlaybackMode' })) {
            $savedEnvironment[$entry.Name] = $entry.Value
            [Environment]::SetEnvironmentVariable($entry.Name, $null, 'Process')
        }
        Copy-Item (Join-Path $PSScriptRoot 'loadEnv.ps1') $TestDrive
        Copy-Item (Join-Path $PSScriptRoot 'provision-common.ps1') $TestDrive
        $fixture = Join-Path $TestDrive 'Synthetic.Tests.ps1'
        Set-Content $fixture '. (Join-Path $PSScriptRoot "loadEnv.ps1"); $env'
        $grouped = @{ RecordingSets = @{
            first = @{ Tests = @('Synthetic.Tests.ps1'); Environment = @{ Tenant = 'first'; HostPool = 'first-pool' } }
            second = @{ Tests = @('Other.Tests.ps1'); Environment = @{ Tenant = 'second'; HostPool = 'second-pool' } }
        } }
        $fixtureEnv = Join-Path $TestDrive 'env.json'
        $grouped | ConvertTo-Json -Depth 12 | Set-Content $fixtureEnv
        $TestMode = 'playback'
    }

    AfterEach {
        foreach ($entry in @(Get-ChildItem Env: | Where-Object { $_.Name -like 'AVD_TEST_*' -or $_.Name -eq 'AzPSAutorestTestPlaybackMode' })) {
            [Environment]::SetEnvironmentVariable($entry.Name, $null, 'Process')
        }
        foreach ($name in $savedEnvironment.Keys) { [Environment]::SetEnvironmentVariable($name, $savedEnvironment[$name], 'Process') }
    }

    It 'selects the exact environment using the invoking test filename' {
        $loaded = & $fixture
        $loaded.Tenant | Should -Be first
        $loaded.HostPool | Should -Be first-pool
        $other = Join-Path $TestDrive 'Other.Tests.ps1'
        Copy-Item $fixture $other
        (& $other).Tenant | Should -Be second
    }

    It 'retains the originating test environment through helper reloads' {
        $helper = Join-Path $TestDrive 'Get-SyntheticSubscription.ps1'
        Copy-Item $fixture $helper
        Set-Content $fixture '& (Join-Path $PSScriptRoot "Get-SyntheticSubscription.ps1")'
        (& $fixture).Tenant | Should -Be first
        $other = Join-Path $TestDrive 'Other.Tests.ps1'
        Copy-Item $fixture $other
        (& $other).Tenant | Should -Be second
        { & $helper } | Should -Throw "Expected exactly one recording environment for 'Get-SyntheticSubscription.ps1'; found 0."
    }

    It 'honors playback mode despite unrelated live selection overrides' {
        $TestMode = 'record'
        $env:AzPSAutorestTestPlaybackMode = 'true'
        $env:AVD_TEST_PROFILE = 'Preview'
        $env:AVD_TEST_RUNTIME_ENV_PATH = Join-Path $TestDrive 'missing.json'
        (& $fixture).Tenant | Should -Be first
    }

    It 'rejects duplicate mappings' {
        $grouped.RecordingSets.second.Tests += 'Synthetic.Tests.ps1'
        $grouped | ConvertTo-Json -Depth 12 | Set-Content $fixtureEnv
        { & $fixture } | Should -Throw "Expected exactly one recording environment for 'Synthetic.Tests.ps1'; found 2."
    }

    It 'rejects missing mappings' {
        $grouped.RecordingSets.first.Tests = @()
        $grouped | ConvertTo-Json -Depth 12 | Set-Content $fixtureEnv
        { & $fixture } | Should -Throw "Expected exactly one recording environment for 'Synthetic.Tests.ps1'; found 0."
    }

    It 'rejects a mapped group without an environment' {
        $grouped.RecordingSets.first.Remove('Environment')
        $grouped | ConvertTo-Json -Depth 12 | Set-Content $fixtureEnv
        { & $fixture } | Should -Throw 'recording environment'
    }

    It 'retains explicit snapshot precedence over grouped mappings' {
        $env:AVD_TEST_PLAYBACK_ENV_PATH = Join-Path $TestDrive 'explicit.json'
        @{ PlaybackSnapshot = $true; SetupComplete = $true; RunId = ('a' * 32); Tenant = 'explicit' } |
            ConvertTo-Json | Set-Content $env:AVD_TEST_PLAYBACK_ENV_PATH
        (& $fixture).Tenant | Should -Be explicit
    }

    It 'preserves legacy flat Playback and unselected live environments' {
        @{ Tenant = 'legacy' } | ConvertTo-Json | Set-Content $fixtureEnv
        (& $fixture).Tenant | Should -Be legacy
        @{ Tenant = 'local' } | ConvertTo-Json | Set-Content (Join-Path $TestDrive 'localEnv.json')
        $TestMode = 'live'
        (& $fixture).Tenant | Should -Be local
    }
}

Describe 'Offline control plane profiles' {
    BeforeEach {
        Mock Get-AzResourceGroup { @{ ResourceGroupName = 'rg' } }
        Mock Get-AzVirtualNetwork { @{ Name = $config.VnetName; Location = 'westus2'; Subnets = @(@{ Name = 'default' }) } }
        Mock Get-AzKeyVault { @{ VaultName = $config.KeyVaultPersistentResourceName } }
        Mock Get-AzWvdHostPool { @() }
        Mock New-AzWvdHostPool { @{
            Name = $Name; Id = "/hostpools/$Name"; ManagementType = $ManagementType; Location = $Location
            IdentityPrincipalId = if ($IdentityType) { 'principal' } else { $null }
            CustomRdpProperty = 'enablerdsaadauth:i:1;'
        } }
        Mock Get-AzWvdApplicationGroup { @() }
        Mock New-AzWvdApplicationGroup { @{ Name = $Name; Id = "/applicationgroups/$Name" } }
        Mock Get-AzWvdWorkspace { @() }
        Mock New-AzWvdWorkspace { @{ Name = $Name } }
        Mock Get-AzContext { @{ Account = @{ Type = 'ServicePrincipal' } } }
    }

    It 'creates only Standard semantics without Preview parameters for Stable' {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        Ensure-AvdControlPlane $config (Get-AvdProvisionPlan $config @('ControlPlane'))
        Assert-MockCalled New-AzWvdHostPool -Times 3 -Exactly -Scope It -ParameterFilter { -not $ManagementType -and -not $IdentityType }
    }

    It 'creates one Standard registration pool and two Automated identity pools for Preview' {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        Ensure-AvdControlPlane $config (Get-AvdProvisionPlan $config @('ControlPlane'))
        Assert-MockCalled New-AzWvdHostPool -Times 1 -Exactly -Scope It -ParameterFilter { $ManagementType -eq 'Standard' -and -not $IdentityType -and $Name -eq $config.StandardHostPoolPersistent }
        Assert-MockCalled New-AzWvdHostPool -Times 2 -Exactly -Scope It -ParameterFilter { $ManagementType -eq 'Automated' -and $IdentityType -eq 'SystemAssigned' }
    }
}

Describe 'Offline source contracts' {
    It 'parses each touched script without duplicate function definitions' {
        foreach ($name in @('provision-common.ps1', 'provision-stable.ps1', 'provision-preview.ps1', 'utils.ps1', 'loadEnv.ps1', 'provisioning-checks.ps1')) {
            $tokens = $null
            $parseErrors = $null
            $ast = [System.Management.Automation.Language.Parser]::ParseFile((Join-Path $PSScriptRoot $name), [ref]$tokens, [ref]$parseErrors)
            $parseErrors.Count | Should -Be 0
            $functions = $ast.FindAll({ param($node) $node -is [System.Management.Automation.Language.FunctionDefinitionAst] }, $true)
            @($functions | Group-Object Name | Where-Object Count -gt 1).Count | Should -Be 0
        }
    }

    It 'preserves every environment field referenced by the unchanged live tests' {
        $config = Get-AvdTestResourceConfig -Profile Preview -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        $runtime = Build-AvdTestEnv $config ('a' * 32)
        $runtime.MarketplaceImageVersion = '1.0.0'
        $testFiles = @(Get-ChildItem -LiteralPath $PSScriptRoot -Filter '*.Tests.ps1')
        $testFiles.Count | Should -Be 72
        $missingFields = foreach ($file in $testFiles) {
            $tokens = $null
            $parseErrors = $null
            $ast = [System.Management.Automation.Language.Parser]::ParseFile($file.FullName, [ref]$tokens, [ref]$parseErrors)
            $members = $ast.FindAll({ param($node)
                $node -is [System.Management.Automation.Language.MemberExpressionAst] -and
                $node.Expression -is [System.Management.Automation.Language.VariableExpressionAst] -and
                $node.Expression.VariablePath.UserPath -eq 'env'
            }, $true)
            foreach ($member in $members) {
                if (-not $runtime.ContainsKey($member.Member.Value)) { "$($file.Name): $($member.Member.Value)" }
            }
        }
        $missingFields | Should -BeNullOrEmpty
    }

    It 'uses parameter names present in the generated DesktopVirtualization contracts' {
        $exports = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../../../../generated/DesktopVirtualization/DesktopVirtualization.Autorest/exports'))
        foreach ($source in @('provision-common.ps1', 'utils.ps1')) {
            $tokens = $null
            $parseErrors = $null
            $ast = [System.Management.Automation.Language.Parser]::ParseFile((Join-Path $PSScriptRoot $source), [ref]$tokens, [ref]$parseErrors)
            $commands = $ast.FindAll({ param($node) $node -is [System.Management.Automation.Language.CommandAst] -and $node.GetCommandName() -like '*-AzWvd*' }, $true)
            foreach ($command in $commands) {
                $definition = Join-Path $exports "$($command.GetCommandName()).ps1"
                Test-Path -LiteralPath $definition | Should -Be $true
                $generated = [System.Management.Automation.Language.Parser]::ParseFile($definition, [ref]$tokens, [ref]$parseErrors)
                $parameters = @($generated.FindAll({ param($node) $node -is [System.Management.Automation.Language.ParameterAst] }, $true) | ForEach-Object { $_.Name.VariablePath.UserPath }) + @('ErrorAction', 'Confirm')
                foreach ($argument in $command.CommandElements | Where-Object { $_ -is [System.Management.Automation.Language.CommandParameterAst] }) {
                    $parameters | Should -Contain $argument.ParameterName
                }
            }
        }
    }
}

Describe 'Offline credentials and prebuilt App Attach' {
    BeforeEach {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
    }

    It 'reuses a synthetic stored credential without rotating it' {
        Mock Get-AzKeyVault { @{ EnableRbacAuthorization = $false } }
        Mock Get-AzKeyVaultSecret {
            if (-not $Name) { @(@{ Name = 'username' }, @{ Name = 'password' }) }
            elseif ($Name -eq 'username') { 'synthetic-user' }
            else { @{ SecretValue = (ConvertTo-SecureString ([guid]::NewGuid().ToString('N')) -AsPlainText -Force) } }
        }
        Mock Set-AzKeyVaultSecret { throw 'Unexpected rotation' }
        $credential = Get-AvdVMCredential $config
        $credential.UserName | Should -Be 'synthetic-user'
        $credential.Password | Should -BeOfType securestring
        Assert-MockCalled Set-AzKeyVaultSecret -Times 0 -Scope It
    }

    It 'requires an explicit matching credential when existing VMs have no stored secrets' {
        Mock Get-AzKeyVault { @{ EnableRbacAuthorization = $false } }
        Mock Get-AzKeyVaultSecret { @() }
        Mock Get-AzVM { @{ Name = $config.SessionHostName } }
        { Get-AvdVMCredential $config } | Should -Throw 'rotated implicitly'
    }

    It 'D4 stops file and directory discovery errors before creating directories or uploading' {
        $accountName = ($config.MSIXImagePath -split '\\')[2].Split('.')[0]
        Mock Get-AzStorageAccount { @{ StorageAccountName = $accountName; Id = '/storage'; Context = 'synthetic-storage' } }
        Mock Get-AzADServicePrincipal { @{ DisplayName = $DisplayName; Id = 'synthetic-principal' } }
        Mock Ensure-AvdRole { }
        Mock Get-AzStorageShare { @{ Name = 'appattach' } }
        Mock New-AzStorageDirectory { throw 'Unexpected directory mutation' }
        Mock Set-AzStorageFileContent { throw 'Unexpected upload' }
        $source = Join-Path $TestDrive 'discovery.vhdx'
        Set-Content -LiteralPath $source -Value 'offline fixture only'
        foreach ($failurePath in @('', 'Apps')) {
            Mock Get-AzStorageFile {
                if ([string]$ShareDirectoryClient -eq $failurePath) { Write-Error 'Synthetic storage lookup failure' }
                else { @{ Name = 'Apps'; ShareDirectoryClient = 'Apps' } }
            }
            { Ensure-AvdMsix $config $source } | Should -Throw 'Synthetic storage lookup'
        }
        Assert-MockCalled New-AzStorageDirectory -Times 0 -Scope It
        Assert-MockCalled Set-AzStorageFileContent -Times 0 -Scope It
    }

    It 'uploads a prebuilt VHDX and refuses automatic downloads or elevation' {
        $accountName = ($config.MSIXImagePath -split '\\')[2].Split('.')[0]
        Mock Get-AzStorageAccount { @{ StorageAccountName = $accountName; Id = '/storage'; Context = 'synthetic-storage' } }
        Mock Get-AzADServicePrincipal { @{ DisplayName = $DisplayName; Id = 'synthetic-principal' } }
        Mock Ensure-AvdRole { }
        Mock Get-AzStorageShare { @{ Name = 'appattach' } }
        Mock Get-AzStorageFile { $null }
        Mock New-AzStorageDirectory { }
        Mock Set-AzStorageFileContent { }
        { Ensure-AvdMsix $config } | Should -Throw 'prebuilt'
        $source = Join-Path $TestDrive 'synthetic.vhdx'
        Set-Content -LiteralPath $source -Value 'offline fixture only'
        Ensure-AvdMsix $config $source
        Assert-MockCalled New-AzStorageDirectory -Times 3 -Exactly -Scope It
        Assert-MockCalled Set-AzStorageFileContent -Times 1 -Exactly -Scope It -ParameterFilter { $Source -eq $source -and $Path -eq 'Apps/VHDX/XmlNotepad/XmlNotepad.vhdx' }
    }
}

Describe 'Offline first-run storage boundary' {
    BeforeEach {
        $config = Get-AvdTestResourceConfig -Profile Stable -TenantId tenant -SubscriptionId subscription -ResourceGroupName rg -Location westus2
        $accountName = ($config.MSIXImagePath -split '\\')[2].Split('.')[0]
        Mock Get-AzStorageAccount { @{ StorageAccountName = $accountName; Id = '/storage'; Context = 'synthetic-storage' } }
        Mock Get-AzADServicePrincipal { @{ DisplayName = $DisplayName; Id = 'synthetic-principal' } }
        Mock Ensure-AvdRole { }
        Mock Get-AzStorageShare { @{ Name = 'appattach' } }
        Mock New-AzStorageDirectory { }
        Mock Set-AzStorageFileContent { }
        $source = Join-Path $TestDrive 'first-run.vhdx'
        Set-Content -LiteralPath $source -Value 'offline fixture only'
    }

    It 'creates only missing directories and uploads once with <ExistingDepth> existing levels' -TestCases @(
        @{ ExistingDepth = 0; MissingCount = 3 }
        @{ ExistingDepth = 1; MissingCount = 2 }
        @{ ExistingDepth = 3; MissingCount = 0 }
    ) {
        param($ExistingDepth, $MissingCount)
        $script:storageExistingDepth = $ExistingDepth
        Mock Get-AzStorageFile {
            if ($Path) { throw 'Path lookup forbidden' }
            $depth = if ($ShareDirectoryClient) { @($ShareDirectoryClient -split '/').Count } else { 0 }
            if ($depth -lt $script:storageExistingDepth) {
                $name = @('Apps', 'VHDX', 'XmlNotepad')[$depth]
                @{ Name = $name; ShareDirectoryClient = if ($ShareDirectoryClient) { "$ShareDirectoryClient/$name" } else { $name } }
            }
        }
        Ensure-AvdMsix $config $source | Should -Be $true
        Assert-MockCalled New-AzStorageDirectory -Times $MissingCount -Exactly -Scope It
        Assert-MockCalled Set-AzStorageFileContent -Times 1 -Exactly -Scope It
        Assert-MockCalled Get-AzStorageFile -Times ($ExistingDepth + 1) -Exactly -Scope It
    }

    It 'reuses the listed VHDX without source access or upload' {
        Mock Get-AzStorageFile {
            switch ([string]$ShareDirectoryClient) {
                '' { @{ Name = 'Apps'; ShareDirectoryClient = 'Apps' } }
                'Apps' { @{ Name = 'VHDX'; ShareDirectoryClient = 'Apps/VHDX' } }
                'Apps/VHDX' { @{ Name = 'XmlNotepad'; ShareDirectoryClient = 'Apps/VHDX/XmlNotepad' } }
                'Apps/VHDX/XmlNotepad' { @{ Name = 'XmlNotepad.vhdx' } }
            }
        }
        Mock Test-Path { throw 'Source access forbidden' }
        Ensure-AvdMsix $config | Should -Be $true
        Assert-MockCalled New-AzStorageDirectory -Times 0 -Scope It
        Assert-MockCalled Set-AzStorageFileContent -Times 0 -Scope It
    }

    It 'propagates storage <Status> at <FailureLevel> without directory creation or upload' -TestCases @(
        foreach ($status in @(401, 403, 404, 429, 500, 503, 0, -1)) {
            foreach ($failureLevel in @('root', 'leaf')) { @{ Status = $status; FailureLevel = $failureLevel } }
        }
    ) {
        param($Status, $FailureLevel)
        $script:storageFailureLevel = $FailureLevel
        $script:storageException = if ($Status -eq 0) { [System.Net.Http.HttpRequestException]::new('Offline network failure') }
            elseif ($Status -eq -1) { [System.Exception]::new('404 NotFound is not typed absence') }
            else { [Azure.RequestFailedException]::new($Status, 'Offline storage failure') }
        Mock Get-AzStorageFile {
            if ($script:storageFailureLevel -eq 'root' -or $ShareDirectoryClient -eq 'Apps/VHDX/XmlNotepad') {
                Write-Error -Exception $script:storageException
            } else {
                switch ([string]$ShareDirectoryClient) {
                    '' { @{ Name = 'Apps'; ShareDirectoryClient = 'Apps' } }
                    'Apps' { @{ Name = 'VHDX'; ShareDirectoryClient = 'Apps/VHDX' } }
                    'Apps/VHDX' { @{ Name = 'XmlNotepad'; ShareDirectoryClient = 'Apps/VHDX/XmlNotepad' } }
                }
            }
        }
        $caught = $null
        try { Ensure-AvdMsix $config $source } catch { $caught = $_.Exception }
        $caught | Should -Be $script:storageException
        Assert-MockCalled New-AzStorageDirectory -Times 0 -Scope It
        Assert-MockCalled Set-AzStorageFileContent -Times 0 -Scope It
    }
}