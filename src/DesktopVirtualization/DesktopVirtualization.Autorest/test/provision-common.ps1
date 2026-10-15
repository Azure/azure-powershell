function Get-AvdTestResourceConfig {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][ValidateSet('Stable', 'Preview')][string]$Profile,
        [Parameter(Mandatory)][ValidateNotNullOrEmpty()][string]$TenantId,
        [Parameter(Mandatory)][ValidateNotNullOrEmpty()][string]$SubscriptionId,
        [Parameter(Mandatory)][ValidateNotNullOrEmpty()][string]$ResourceGroupName,
        [Parameter(Mandatory)][ValidateNotNullOrEmpty()][string]$Location,
        [string]$StatePath
    )

    $identity = "$Profile|$TenantId|$SubscriptionId|$ResourceGroupName".ToLowerInvariant()
    $sha = [System.Security.Cryptography.SHA256]::Create()
    try {
        $hash = $sha.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($identity))
    } finally {
        $sha.Dispose()
    }
    $suffix = -join ($hash[0..3] | ForEach-Object { $_.ToString('x2') })
    $prefix = "azps-$($Profile.ToLowerInvariant())-$suffix"
    $sessionPrefix = "as$suffix"
    $lifecyclePrefix = "al$suffix"
    $storageAccount = "azps${suffix}sa"
    if (-not $StatePath) {
        $StatePath = Join-Path $PSScriptRoot "provision-$($Profile.ToLowerInvariant())-$suffix.state.json"
    }
    if (-not [System.IO.Path]::IsPathFullyQualified($StatePath)) {
        throw 'StatePath must be absolute.'
    }
    [pscustomobject]@{
        Profile = $Profile
        Tenant = $TenantId
        SubscriptionId = $SubscriptionId
        ResourceGroup = $ResourceGroupName
        ResourceGroupPersistent = $ResourceGroupName
        Location = $Location
        StatePath = [System.IO.Path]::GetFullPath($StatePath)
        StandardHostPoolPersistent = "$prefix-standard"
        HostPoolPersistent = "$prefix-session"
        AutomatedHostpoolPersistent = "$prefix-session"
        SHMHostPoolPersistent = "$prefix-shm"
        SessionHostNamePrefixOfAutomatedHostpoolPersistent = $sessionPrefix
        SessionHostName = "$sessionPrefix-0"
        SHMSessionHostNamePrefix = $lifecyclePrefix
        SHMSessionHostReprovisioning = "$lifecyclePrefix-1"
        SHMSessionHostNameRemove = "$lifecyclePrefix-2"
        PersistentDesktopAppGroup = "$prefix-dag"
        PersistentRemoteAppGroup = "$prefix-rag"
        VnetName = "$prefix-vnet"
        KeyVaultPersistentResourceName = "azps${suffix}kv"
        MarketplaceInfoPublisher = 'microsoftwindowsdesktop'
        MarketplaceInfoSku = 'win11-25h2-avd'
        MarketplaceInfoOffer = 'windows-11'
        MSIXImagePath = "\\$storageAccount.file.core.windows.net\appattach\Apps\VHDX\XmlNotepad\XmlNotepad.vhdx"
        MSIXImageFamilyName = '43906ChrisLovett.XmlNotepad_hndwmj480pefj'
        MSIXImagePackageName = '43906ChrisLovett.XmlNotepad'
        MSIXImagePackageAlias = '43906chrislovettxmlnotepad'
        MSIXImagePackageRelativePath = '\apps\43906ChrisLovett.XmlNotepad_2.9.0.16_neutral__hndwmj480pefj'
    }
}

function Build-AvdTestEnv {
    param([Parameter(Mandatory)]$Config, [Parameter(Mandatory)][string]$RunId)

    $runtime = @{}
    foreach ($property in $Config.PSObject.Properties) { $runtime[$property.Name] = $property.Value }
    $runtime.RunId = $RunId
    $suffix = "$($Config.Profile.ToLowerInvariant())-$RunId"
    $names = @{
        HostPool = 'pshostpool1'; HostPool2 = 'pshostpool2'; Workspace = 'psworkspace'
        PvtLinkWS = 'pspvtlinkws'; PvtLinkHP = 'pspvtlinkhp'
        RemoteApplicationGroup = 'psremoteag'; DesktopApplicationGroup = 'psdesktopag'
        PrivateEndpointConnectionNameWS = 'pspecws'; PrivateEndpointConnectionNameWS1 = 'pspecws1'
        PrivateEndpointConnectionNameHP = 'pspechp'; PrivateEndpointConnectionNameHP1 = 'pspechp1'
        PrivateEndpointNameWS = 'pspews'; PrivateEndpointNameWS1 = 'pspews1'
        PrivateEndpointNameHP = 'pspehp'; PrivateEndpointNameHP1 = 'pspehp1'
    }
    foreach ($key in $names.Keys) { $runtime[$key] = "$($names[$key])-$suffix" }
    $runtime.PECGroupIdWorkspace = 'feed'
    $runtime.PECGroupIdHostPool = 'connection'
    $runtime.PrivateEndpointConnectionName = $null
    $runtime.PrivateEndpointConnectionName0 = $null
    $runtime.PrivateEndpointConnectionName1 = $null
    $resourceGroupPath = "/subscriptions/$($Config.SubscriptionId)/resourcegroups/$($Config.ResourceGroup)"
    $avdPath = "$resourceGroupPath/providers/Microsoft.DesktopVirtualization"
    $runtime.ResourceGroupArmPath = $resourceGroupPath
    $runtime.KeyVaultPersistentArmPath = $resourceGroupPath
    $runtime.HostPoolArmPath = "$avdPath/hostpools/$($runtime.HostPool)"
    $runtime.HostPoolArmPath2 = "$avdPath/hostpools/$($runtime.HostPool2)"
    $runtime.HostPoolPersistentArmPath = "$avdPath/hostpools/$($Config.HostPoolPersistent)"
    $runtime.DesktopApplicationGroupPath = "$avdPath/applicationgroups/$($runtime.DesktopApplicationGroup)"
    $runtime.RemoteApplicationGroupPath = "$avdPath/applicationgroups/$($runtime.RemoteApplicationGroup)"
    $runtime.VnetSubnetId = "$resourceGroupPath/providers/Microsoft.Network/virtualNetworks/$($Config.VnetName)/subnets/default"
    $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri = "https://$($Config.KeyVaultPersistentResourceName).vault.azure.net/secrets/password"
    $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri = "https://$($Config.KeyVaultPersistentResourceName).vault.azure.net/secrets/username"
    return $runtime
}

function Get-AvdProvisionPlan {
    param($Config, [string[]]$Include)

    $management = if ($Config.Profile -eq 'Preview') { 'Automated' } else { 'Standard' }
    [pscustomobject]@{
        Config = $Config
        Phases = @('ControlPlane', 'SessionHosts', 'Msix' | Where-Object { $Include -contains 'All' -or $Include -contains $_ })
        Pools = @(
            [pscustomobject]@{ Name = $Config.StandardHostPoolPersistent; Role = 'RegistrationTests'; ManagementType = 'Standard'; Hosts = @() }
            [pscustomobject]@{ Name = $Config.HostPoolPersistent; Role = 'UserSessions'; ManagementType = $management; Hosts = @($Config.SessionHostName) }
            [pscustomobject]@{ Name = $Config.SHMHostPoolPersistent; Role = 'DestructiveLifecycle'; ManagementType = $management; Hosts = @($Config.SHMSessionHostReprovisioning, $Config.SHMSessionHostNameRemove) }
        )
        SessionHostOperations = if ($Config.Profile -eq 'Preview') {
            @('New-AzWvdSessionHostConfiguration', 'New-AzWvdSessionHostManagement', 'Update-AzWvdSessionHostManagement')
        } else {
            @('New-AzVM', 'Set-AzVMExtension')
        }
        Pending = @('Manual Entra tenant configuration and test-user login', 'Live service readiness and lifecycle scheduling', 'Record, sanitized recording review, and Playback acceptance')
    }
}

function Invoke-AvdProvision {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)][ValidateSet('Stable', 'Preview')][string]$Profile,
        [Parameter(Mandatory)][string]$TenantId,
        [Parameter(Mandatory)][string]$SubscriptionId,
        [Parameter(Mandatory)][string]$ResourceGroupName,
        [Parameter(Mandatory)][string]$Location,
        [ValidateSet('All', 'ControlPlane', 'SessionHosts', 'Msix')][string[]]$Include = @('All'),
        [string]$StatePath,
        [string]$RuntimeEnvPath,
        [pscredential]$VMAdminCredential,
        [string]$VMSize,
        [string]$MsixVhdxSourcePath,
        [string]$AvdDscConfigUrl = 'https://wvdportalstorageblob.blob.core.windows.net/galleryartifacts/Configuration_1.0.02790.438.zip',
        [switch]$RepairSessionHosts,
        [switch]$PlanOnly
    )

    $config = Get-AvdTestResourceConfig -Profile $Profile -TenantId $TenantId -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -Location $Location -StatePath $StatePath
    $plan = Get-AvdProvisionPlan -Config $config -Include $Include
    if ($PlanOnly) { return $plan }
    if (-not $PSCmdlet.ShouldProcess($config.ResourceGroup, "Provision $Profile fixtures: $($plan.Phases -join ', ')")) { return $plan }
    Invoke-AvdProvisionResources -Config $config -Plan $plan -Options $PSBoundParameters
}

function Assert-AvdIdentity {
    param($Expected, $Actual)

    foreach ($key in @('Profile', 'Tenant', 'SubscriptionId', 'ResourceGroup', 'Location')) {
        if ([string]::IsNullOrWhiteSpace([string]$Actual.$key) -or $Expected.$key -ne $Actual.$key) {
            throw "AVD $key mismatch. Refusing to reuse another profile or identity."
        }
    }
}

function Assert-AvdContext {
    param($Config)

    $context = Get-AzContext -ErrorAction Stop
    if (-not $context -or $context.Tenant.Id -ne $Config.Tenant -or $context.Subscription.Id -ne $Config.SubscriptionId) {
        throw 'Azure context does not match the explicit tenant/subscription. Select the intended context manually before continuing.'
    }
}

function Read-AvdState {
    param([Parameter(Mandatory)][string]$Path, $Expected)

    if (-not [System.IO.Path]::IsPathFullyQualified($Path)) { throw 'State/runtime path must be absolute.' }
    $state = Get-Content -LiteralPath $Path -Raw -ErrorAction Stop | ConvertFrom-Json -AsHashtable -ErrorAction Stop
    if ($Expected) { Assert-AvdIdentity $Expected $state }
    return $state
}

function Write-AvdJson {
    [CmdletBinding(SupportsShouldProcess)]
    param([Parameter(Mandatory)][string]$Path, [Parameter(Mandatory)]$Value, [switch]$Required)

    if (-not [System.IO.Path]::IsPathFullyQualified($Path)) { throw 'State/runtime path must be absolute.' }
    if ([System.IO.Path]::GetExtension($Path) -ne '.json' -or [System.IO.Path]::GetFileName($Path) -match '(^env\.json$|^localEnv\.json$|\.Recording\.json$)') {
        throw 'State/runtime writes must target a separate JSON file, never playback environment or recordings.'
    }
    $json = ConvertTo-Json -InputObject $Value -Depth 12
    if ($json -match '"(?:password|credential|token|accessToken|registrationInfoToken|SecretValue)"\s*:') {
        throw 'Secrets must not be serialized into provisioning state.'
    }
    if ($PSCmdlet.ShouldProcess($Path, 'Write secret-free AVD state')) {
        if (-not (Test-Path -LiteralPath (Split-Path -Parent $Path) -PathType Container)) {
            throw 'State/runtime directory must already exist.'
        }
        Set-Content -LiteralPath $Path -Value $json -Encoding utf8 -ErrorAction Stop
    } elseif ($Required) {
        throw 'Required AVD journal write was declined. No dependent mutation may proceed.'
    }
}

function Confirm-AvdMutation {
    param($Caller, [string]$Target, [string]$Action)

    if (-not $Caller.ShouldProcess($Target, $Action)) {
        throw [System.OperationCanceledException]::new('Provisioning phase is incomplete because a required operation was declined.')
    }
    return $true
}

function Set-AvdProcessSelection {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, [string]$RuntimeEnvPath)

    if ($RuntimeEnvPath -and -not [System.IO.Path]::IsPathFullyQualified($RuntimeEnvPath)) {
        throw 'RuntimeEnvPath must be absolute.'
    }
    if ($PSCmdlet.ShouldProcess('Process environment', 'Select AVD profile and state')) {
        $env:AVD_TEST_PROFILE = $Config.Profile
        $env:AVD_TEST_STATE_PATH = $Config.StatePath
        $env:AVD_TEST_RUNTIME_ENV_PATH = $RuntimeEnvPath
        $env:AVD_TEST_TENANT_ID = $Config.Tenant
        $env:AVD_TEST_SUBSCRIPTION_ID = $Config.SubscriptionId
        $env:AVD_TEST_RESOURCE_GROUP = $Config.ResourceGroup
        $env:AVD_TEST_LOCATION = $Config.Location
    }
}

function Get-AvdSelectedConfig {
    if (-not $env:AVD_TEST_PROFILE -or -not $env:AVD_TEST_STATE_PATH) {
        throw 'Select AVD_TEST_PROFILE and an absolute AVD_TEST_STATE_PATH from a provisioning entry. No legacy live defaults are used.'
    }
    $state = Read-AvdState $env:AVD_TEST_STATE_PATH
    $config = Get-AvdTestResourceConfig -Profile $env:AVD_TEST_PROFILE -TenantId $state.Tenant -SubscriptionId $state.SubscriptionId -ResourceGroupName $state.ResourceGroup -Location $state.Location -StatePath $env:AVD_TEST_STATE_PATH
    Assert-AvdIdentity $config $state
    $overrides = @{
        Tenant = $env:AVD_TEST_TENANT_ID; SubscriptionId = $env:AVD_TEST_SUBSCRIPTION_ID
        ResourceGroup = $env:AVD_TEST_RESOURCE_GROUP; Location = $env:AVD_TEST_LOCATION
    }
    foreach ($key in $overrides.Keys) {
        if ($overrides[$key] -and $overrides[$key] -ne $config.$key) { throw "AVD $key override conflicts with saved state." }
    }
    return $config
}

function Assert-AvdPool {
    param($Config, $Pool, [string]$ManagementType)

    if (-not $Pool) { throw 'Persistent host pool is missing. Run the ControlPlane phase.' }
    if ($Pool.ManagementType -and $Pool.ManagementType -ne $ManagementType) { throw 'Existing host pool has an incompatible management type.' }
    if ($Config.Profile -eq 'Preview' -and -not $Pool.ManagementType) { throw 'Preview management type is unavailable; import the matching Preview module.' }
    if ($Pool.Location -ne $Config.Location) { throw 'Existing host pool location does not match configuration.' }
    if ($ManagementType -eq 'Automated' -and -not $Pool.IdentityPrincipalId) { throw 'Automated host pool requires system-assigned identity.' }
}

function Assert-AvdDependencies {
    param($Config, $Plan)

    $modules = @('Az.Accounts', 'Az.Resources', 'Az.Network', 'Az.KeyVault', 'Az.Compute', 'Az.DesktopVirtualization')
    if ($Plan.Phases -contains 'Msix') { $modules += 'Az.Storage' }
    foreach ($module in $modules) {
        if (-not (Get-Module -Name $module)) { throw "Import the installed $module module in this PowerShell session first. No automatic installation or login is performed." }
    }
    if ($Config.Profile -eq 'Preview') {
        foreach ($command in @('New-AzWvdSessionHostConfiguration', 'New-AzWvdSessionHostManagement', 'Update-AzWvdSessionHostManagement')) {
            if (-not (Get-Command $command -ErrorAction SilentlyContinue)) { throw "The imported Preview module must expose $command." }
        }
        if (-not (Get-Command New-AzWvdSessionHostManagement).Parameters.ContainsKey('ProvisioningInstanceCount')) {
            throw 'The imported Preview module lacks ProvisioningInstanceCount. Refresh/import the matching build manually.'
        }
    }
}

function Ensure-AvdRole {
    [CmdletBinding(SupportsShouldProcess)]
    param([string]$Scope, [string]$PrincipalId, [string]$Role)

    if (-not $PrincipalId -or -not $Scope) { throw 'A role assignment requires an explicit principal and scope.' }
    $existing = Get-AzRoleAssignment -ObjectId $PrincipalId -Scope $Scope -RoleDefinitionName $Role -ErrorAction Stop
    if (-not $existing -and (Confirm-AvdMutation $PSCmdlet $Scope "Assign $Role to $PrincipalId")) {
        New-AzRoleAssignment -ObjectId $PrincipalId -RoleDefinitionName $Role -Scope $Scope -ErrorAction Stop | Out-Null
    }
}

function Get-AvdCurrentPrincipal {
    [CmdletBinding(SupportsShouldProcess)]
    param()

    $null = Confirm-AvdMutation $PSCmdlet 'Current principal' 'Read ARM token claims for role assignment'
    $accessToken = Get-AzAccessToken -ResourceTypeName Arm -ErrorAction Stop
    $rawToken = if ($accessToken.Token -is [securestring]) { [System.Net.NetworkCredential]::new('', $accessToken.Token).Password } else { [string]$accessToken.Token }
    try {
        $parts = $rawToken.Split('.')
        if ($parts.Count -lt 2) { throw 'Unable to resolve principal from ARM token.' }
        $payload = $parts[1].Replace('-', '+').Replace('_', '/')
        $payload = $payload.PadRight($payload.Length + ((4 - $payload.Length % 4) % 4), '=')
        $claims = [System.Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($payload)) | ConvertFrom-Json
        if (-not $claims.oid) { throw 'ARM token has no principal object ID.' }
        return $claims.oid
    } finally {
        $rawToken = $null
        $accessToken = $null
    }
}

function Ensure-AvdControlPlane {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, $Plan)

    $resourceGroup = Get-AzResourceGroup -ErrorAction Stop | Where-Object ResourceGroupName -eq $Config.ResourceGroup
    if (-not $resourceGroup -and (Confirm-AvdMutation $PSCmdlet $Config.ResourceGroup 'Create resource group')) {
        New-AzResourceGroup -Name $Config.ResourceGroup -Location $Config.Location -ErrorAction Stop | Out-Null
    }
    $vnet = Get-AzVirtualNetwork -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop | Where-Object Name -eq $Config.VnetName
    if ($vnet -and ($vnet.Location -ne $Config.Location -or -not ($vnet.Subnets | Where-Object Name -eq 'default'))) {
        throw 'Existing VNet has incompatible location or no default subnet.'
    }
    if (-not $vnet -and (Confirm-AvdMutation $PSCmdlet $Config.VnetName 'Create VNet and default subnet')) {
        $subnet = New-AzVirtualNetworkSubnetConfig -Name default -AddressPrefix '10.0.0.0/24' -PrivateEndpointNetworkPoliciesFlag Disabled
        New-AzVirtualNetwork -Name $Config.VnetName -ResourceGroupName $Config.ResourceGroup -Location $Config.Location -AddressPrefix '10.0.0.0/16' -Subnet $subnet -ErrorAction Stop | Out-Null
    }
    $vault = Get-AzKeyVault -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop | Where-Object VaultName -eq $Config.KeyVaultPersistentResourceName
    if (-not $vault -and (Confirm-AvdMutation $PSCmdlet $Config.KeyVaultPersistentResourceName 'Create Key Vault')) {
        New-AzKeyVault -VaultName $Config.KeyVaultPersistentResourceName -ResourceGroupName $Config.ResourceGroup -Location $Config.Location -EnabledForTemplateDeployment -EnableRbacAuthorization -ErrorAction Stop | Out-Null
    }
    $existingPools = @(Get-AzWvdHostPool -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop)
    foreach ($poolPlan in $Plan.Pools) {
        $pool = $existingPools | Where-Object Name -eq $poolPlan.Name
        if (-not $pool -and (Confirm-AvdMutation $PSCmdlet $poolPlan.Name 'Create host pool')) {
            $parameters = @{
                Name = $poolPlan.Name; ResourceGroupName = $Config.ResourceGroup; SubscriptionId = $Config.SubscriptionId
                Location = $Config.Location; HostPoolType = 'Pooled'; LoadBalancerType = 'BreadthFirst'
                PreferredAppGroupType = 'Desktop'; MaxSessionLimit = 10; ErrorAction = 'Stop'
            }
            if ($Config.Profile -eq 'Preview') {
                $parameters.ManagementType = $poolPlan.ManagementType
                if ($poolPlan.ManagementType -eq 'Automated') { $parameters.IdentityType = 'SystemAssigned' }
            }
            $pool = New-AzWvdHostPool @parameters
        }
        if ($pool) { Assert-AvdPool $Config $pool $poolPlan.ManagementType }
        if ($poolPlan.Role -eq 'UserSessions' -and $pool) {
            $ssoProperty = 'enablerdsaadauth:i:1'
            if ($pool.CustomRdpProperty -notmatch "(^|;)$([regex]::Escape($ssoProperty))(;|$)" -and (Confirm-AvdMutation $PSCmdlet $pool.Name 'Enable Entra SSO')) {
                $properties = @([string]$pool.CustomRdpProperty -split ';' | Where-Object { $_ -and $_ -notmatch '^enablerdsaadauth:i:' }) + $ssoProperty
                Update-AzWvdHostPool -SubscriptionId $Config.SubscriptionId -ResourceGroupName $Config.ResourceGroup -Name $pool.Name -CustomRdpProperty (($properties -join ';') + ';') -ErrorAction Stop | Out-Null
            }
            $groups = @()
            foreach ($type in @('Desktop', 'RemoteApp')) {
                $name = if ($type -eq 'Desktop') { $Config.PersistentDesktopAppGroup } else { $Config.PersistentRemoteAppGroup }
                $group = Get-AzWvdApplicationGroup -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop | Where-Object Name -eq $name
                if ($group -and ($group.HostPoolArmPath -ne $pool.Id -or $group.ApplicationGroupType -ne $type)) { throw 'Existing application group belongs to a different pool or type.' }
                if (-not $group -and (Confirm-AvdMutation $PSCmdlet $name 'Create application group')) {
                    $group = New-AzWvdApplicationGroup -Name $name -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -Location $Config.Location -HostPoolArmPath $pool.Id -ApplicationGroupType $type -ErrorAction Stop
                }
                if ($group) { $groups += $group }
            }
            $workspaceName = "$($pool.Name)-workspace"
            $workspace = Get-AzWvdWorkspace -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop | Where-Object Name -eq $workspaceName
            if (-not $workspace -and (Confirm-AvdMutation $PSCmdlet $workspaceName 'Create workspace')) {
                New-AzWvdWorkspace -Name $workspaceName -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -Location $Config.Location -ApplicationGroupReference @($groups.Id) -ErrorAction Stop | Out-Null
            } elseif ($workspace) {
                $references = @(@($workspace.ApplicationGroupReference) + @($groups.Id) | Where-Object { $_ } | Select-Object -Unique)
                if (@(Compare-Object @($workspace.ApplicationGroupReference) $references).Count -and (Confirm-AvdMutation $PSCmdlet $workspaceName 'Register application groups')) {
                    Update-AzWvdWorkspace -Name $workspaceName -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ApplicationGroupReference $references -ErrorAction Stop | Out-Null
                }
            }
            $context = Get-AzContext
            if ($context.Account.Type -eq 'User') {
                $principal = Get-AvdCurrentPrincipal
                Ensure-AvdRole -PrincipalId $principal -Scope ($groups | Where-Object Name -eq $Config.PersistentDesktopAppGroup).Id -Role 'Desktop Virtualization User'
                Ensure-AvdRole -PrincipalId $principal -Scope "/subscriptions/$($Config.SubscriptionId)/resourceGroups/$($Config.ResourceGroup)" -Role 'Virtual Machine User Login'
            }
        }
    }
}

function Get-AvdVMSize {
    param($Config, [int]$MissingCount, [string]$RequestedSize)

    if ($MissingCount -eq 0) { return $RequestedSize }
    $usage = @(Get-AzVMUsage -Location $Config.Location -ErrorAction Stop)
    $regional = $usage | Where-Object { $_.Name.Value -eq 'cores' } | Select-Object -First 1
    $skus = @(Get-AzComputeResourceSku -ErrorAction Stop | Where-Object { $_.ResourceType -eq 'virtualMachines' -and $_.Locations -contains $Config.Location })
    $eligible = foreach ($sku in $skus) {
        if ($RequestedSize -and $sku.Name -ne $RequestedSize) { continue }
        if ($sku.Restrictions | Where-Object { $_.ReasonCode -and $_.ReasonCode -ne 'None' }) { continue }
        $cores = [int](($sku.Capabilities | Where-Object Name -eq 'vCPUs' | Select-Object -First 1).Value)
        $memory = [decimal](($sku.Capabilities | Where-Object Name -eq 'MemoryGB' | Select-Object -First 1).Value)
        $generation = ($sku.Capabilities | Where-Object Name -eq 'HyperVGenerations' | Select-Object -First 1).Value
        $trustedLaunchDisabled = ($sku.Capabilities | Where-Object Name -eq 'TrustedLaunchDisabled' | Select-Object -First 1).Value
        if ($cores -lt 2 -or $memory -lt 4 -or $generation -notmatch 'V2' -or $trustedLaunchDisabled -eq 'True') { continue }
        if (-not $RequestedSize -and ($sku.Name -notmatch '^Standard_[BDE]' -or $cores -gt 4)) { continue }
        $family = $usage | Where-Object { $_.Name.Value -ieq $sku.Family } | Select-Object -First 1
        $required = $cores * $MissingCount
        if (-not $regional -or -not $family -or $regional.Limit - $regional.CurrentValue -lt $required -or $family.Limit - $family.CurrentValue -lt $required) { continue }
        [pscustomobject]@{ Name = $sku.Name; Cores = $cores; Memory = $memory }
    }
    $preferred = @('Standard_E2ds_v6', 'Standard_D2s_v6', 'Standard_D2s_v4', 'Standard_D2s_v3', 'Standard_B2s')
    $selected = @($preferred | Where-Object { $_ -in $eligible.Name }) + @($eligible | Sort-Object Cores, Memory, Name | Select-Object -ExpandProperty Name)
    if (-not $selected) { throw "No compatible VM SKU has regional and family quota for $MissingCount hosts in $($Config.Location). Request quota or choose another region/VMSize." }
    return $selected[0]
}

function Get-AvdVMCredential {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, [pscredential]$Credential)

    if (-not $PSCmdlet.ShouldProcess($Config.KeyVaultPersistentResourceName, 'Read or initialize VM credentials in Key Vault')) { return }
    $vault = Get-AzKeyVault -VaultName $Config.KeyVaultPersistentResourceName -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop
    if (-not $vault) { throw 'Key Vault is missing. Run ControlPlane first.' }
    if ($vault.EnableRbacAuthorization) {
        Ensure-AvdRole -Scope $vault.ResourceId -PrincipalId (Get-AvdCurrentPrincipal) -Role 'Key Vault Secrets Officer'
    }
    $secrets = @(Get-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -ErrorAction Stop)
    $hasUsername = $secrets.Name -contains 'username'
    $hasPassword = $secrets.Name -contains 'password'
    if ($hasUsername -and $hasPassword -and -not $Credential) {
        $username = Get-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -Name username -AsPlainText -ErrorAction Stop
        $password = Get-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -Name password -ErrorAction Stop
        return [pscredential]::new($username, $password.SecretValue)
    }
    if (($hasUsername -or $hasPassword) -and -not $Credential) { throw 'Key Vault credential pair is incomplete. Supply the matching VMAdminCredential explicitly.' }
    if (-not $Credential) {
        $existing = @(Get-AzVM -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop | Where-Object Name -in @($Config.SessionHostName, $Config.SHMSessionHostReprovisioning, $Config.SHMSessionHostNameRemove))
        if ($existing) { throw 'Existing VMs have no stored credential. Supply the matching VMAdminCredential explicitly; credentials will not be rotated implicitly.' }
        $Credential = [pscredential]::new('avdlocaladmin', (ConvertTo-SecureString "Avd!9$([guid]::NewGuid().ToString('N'))" -AsPlainText -Force))
    }
    if (Confirm-AvdMutation $PSCmdlet $Config.KeyVaultPersistentResourceName 'Store username/password secrets') {
        Set-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -Name username -SecretValue (ConvertTo-SecureString $Credential.UserName -AsPlainText -Force) -ErrorAction Stop | Out-Null
        Set-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -Name password -SecretValue $Credential.Password -ErrorAction Stop | Out-Null
    }
    return $Credential
}

function Ensure-AvdDirectHost {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, [string]$PoolName, [string]$HostName, [string]$VMSize, [pscredential]$Credential, [string]$DscUrl, [switch]$Repair)

    if ($Config.Profile -ne 'Stable') { throw 'Direct VM registration is only supported by the Stable profile.' }
    if (-not $PSCmdlet.ShouldProcess($HostName, 'Ensure direct Entra/AVD session host')) { return }
    $existing = Get-AzVM -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop | Where-Object Name -eq $HostName
    $registered = Get-AzWvdSessionHost -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -HostPoolName $PoolName -ErrorAction Stop | Where-Object { ($_.Name -split '/')[-1] -eq $HostName }
    if ($existing -and -not $Repair) {
        if (-not $registered) { throw 'Existing VM is not registered to the intended pool. Inspect it and use RepairSessionHosts explicitly.' }
        return $true
    }
    if (-not $Credential) { throw 'A VM credential from Key Vault or VMAdminCredential is required.' }
    if (-not $existing -and (Confirm-AvdMutation $PSCmdlet $HostName 'Create NIC and Trusted Launch VM')) {
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $Config.ResourceGroup -Name $Config.VnetName -ErrorAction Stop
        $subnet = $vnet.Subnets | Where-Object Name -eq default
        if (-not $subnet.Id) { throw 'The default subnet is missing. Run ControlPlane first.' }
        $nic = New-AzNetworkInterface -Name "$HostName-nic" -ResourceGroupName $Config.ResourceGroup -Location $Config.Location -SubnetId $subnet.Id -ErrorAction Stop
        $vm = New-AzVMConfig -VMName $HostName -VMSize $VMSize -SecurityType TrustedLaunch -IdentityType SystemAssigned |
            Set-AzVMOperatingSystem -Windows -ComputerName $HostName -Credential $Credential -ProvisionVMAgent -EnableAutoUpdate |
            Set-AzVMSourceImage -PublisherName $Config.MarketplaceInfoPublisher -Offer $Config.MarketplaceInfoOffer -Skus $Config.MarketplaceInfoSku -Version $Config.MarketplaceImageVersion |
            Add-AzVMNetworkInterface -Id $nic.Id
        New-AzVM -ResourceGroupName $Config.ResourceGroup -Location $Config.Location -VM $vm -ErrorAction Stop | Out-Null
    } elseif ($existing -and $existing.Identity.Type -notmatch 'SystemAssigned' -and (Confirm-AvdMutation $PSCmdlet $HostName 'Enable VM system identity')) {
        Update-AzVM -ResourceGroupName $Config.ResourceGroup -VM $existing -IdentityType SystemAssigned -ErrorAction Stop | Out-Null
    }
    if (Confirm-AvdMutation $PSCmdlet $HostName 'Apply Entra join extension and restart newly created or explicitly repaired VM') {
        Set-AzVMExtension -ResourceGroupName $Config.ResourceGroup -VMName $HostName -Location $Config.Location -Name AADLoginForWindows -Publisher Microsoft.Azure.ActiveDirectory -ExtensionType AADLoginForWindows -TypeHandlerVersion '2.0' -ErrorAction Stop | Out-Null
        Restart-AzVM -ResourceGroupName $Config.ResourceGroup -Name $HostName -ErrorAction Stop | Out-Null
    }
    if (Confirm-AvdMutation $PSCmdlet $PoolName 'Refresh registration token and apply protected DSC registration') {
        $expiry = (Get-Date).ToUniversalTime().AddHours(4).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')
        Update-AzWvdHostPool -Name $PoolName -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -RegistrationInfoExpirationTime $expiry -RegistrationInfoRegistrationTokenOperation Update -ErrorAction Stop | Out-Null
        $token = (Get-AzWvdRegistrationInfo -HostPoolName $PoolName -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop).Token
        try {
            if (-not $token) { throw 'No registration token was returned.' }
            $settings = @{ modulesUrl = $DscUrl; configurationFunction = 'Configuration.ps1\AddSessionHost'; properties = @{ hostPoolName = $PoolName; aadJoin = $true } }
            $protectedSettings = @{ properties = @{ registrationInfoToken = $token } }
            Set-AzVMExtension -ResourceGroupName $Config.ResourceGroup -VMName $HostName -Location $Config.Location -Name Microsoft.PowerShell.DSC -Publisher Microsoft.Powershell -ExtensionType DSC -TypeHandlerVersion '2.73' -Settings $settings -ProtectedSettings $protectedSettings -ErrorAction Stop | Out-Null
        } finally {
            $token = $null
            $protectedSettings = $null
        }
    }
    return $true
}

function Ensure-AvdManagedHosts {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, $PoolPlan, [string]$VMSize)

    if ($Config.Profile -ne 'Preview' -or $PoolPlan.ManagementType -ne 'Automated') { throw 'SHC/SHM provisioning requires a Preview Automated pool.' }
    if (-not $PSCmdlet.ShouldProcess($PoolPlan.Name, 'Ensure Automated SHC/SHM prerequisites and service-managed hosts')) { return }
    $path = @{ SubscriptionId = $Config.SubscriptionId; ResourceGroupName = $Config.ResourceGroup; HostPoolName = $PoolPlan.Name; ErrorAction = 'Stop' }
    $pool = Get-AzWvdHostPool -Name $PoolPlan.Name -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop
    Assert-AvdPool $Config $pool Automated
    $runtime = Build-AvdTestEnv $Config 'provision'
    $vnet = Get-AzVirtualNetwork -Name $Config.VnetName -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop
    if (-not ($vnet.Subnets | Where-Object Id -eq $runtime.VnetSubnetId)) { throw 'SHC requires the configured default subnet.' }
    $secretNames = @(Get-AzKeyVaultSecret -VaultName $Config.KeyVaultPersistentResourceName -ErrorAction Stop).Name
    if ('username' -notin $secretNames -or 'password' -notin $secretNames) { throw 'SHC requires both Key Vault credential secrets.' }
    Ensure-AvdRole -PrincipalId $pool.IdentityPrincipalId -Scope $runtime.ResourceGroupArmPath -Role 'Desktop Virtualization Virtual Machine Contributor'
    Ensure-AvdRole -PrincipalId $pool.IdentityPrincipalId -Scope $runtime.KeyVaultPersistentArmPath -Role 'Key Vault Secrets User'
    $prefix = if ($PoolPlan.Role -eq 'UserSessions') { $Config.SessionHostNamePrefixOfAutomatedHostpoolPersistent } else { $Config.SHMSessionHostNamePrefix }
    $configuration = $null
    try {
        $configuration = Get-AzWvdSessionHostConfiguration @path
    } catch [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.RestException] {
        if ($_.Exception.StatusCode -ne [System.Net.HttpStatusCode]::NotFound) { throw }
    } catch {
        if ($_.FullyQualifiedErrorId -ne 'NotFound,Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Cmdlets.GetAzWvdSessionHostConfiguration_Get') { throw }
    }
    if ($configuration) {
        $expectedConfiguration = @{
            VMNamePrefix = $prefix; NetworkInfoSubnetId = $runtime.VnetSubnetId
            VMResourceGroup = $Config.ResourceGroup; VMLocation = $Config.Location
            VMAdminCredentialsPasswordKeyVaultSecretUri = $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri
            VMAdminCredentialsUsernameKeyVaultSecretUri = $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri
        }
        foreach ($property in $expectedConfiguration.Keys) {
            if ($configuration.$property -cne $expectedConfiguration[$property]) {
                throw "Existing SHC $property does not match the intended VM destination or credentials. Reconcile it manually before provisioning."
            }
        }
    }
    if (-not $configuration -and (Confirm-AvdMutation $PSCmdlet $pool.Name 'Create session host configuration')) {
        $configuration = New-AzWvdSessionHostConfiguration @path -ManagedDiskType Standard_LRS -DomainInfoJoinType AzureActiveDirectory -ImageInfoImageType Marketplace `
            -NetworkInfoSubnetId $runtime.VnetSubnetId -VMAdminCredentialsPasswordKeyvaultSecretUri $runtime.VMAdminCredentialsPasswordKeyvaultSecretUri `
            -VMAdminCredentialsUserNameKeyvaultSecretUri $runtime.VMAdminCredentialsUserNameKeyvaultSecretUri -VMNamePrefix $prefix -VMSizeId $VMSize `
            -MarketplaceInfoExactVersion $Config.MarketplaceImageVersion -MarketplaceInfoOffer $Config.MarketplaceInfoOffer `
            -MarketplaceInfoPublisher $Config.MarketplaceInfoPublisher -MarketplaceInfoSku $Config.MarketplaceInfoSku `
            -SecurityInfoSecureBootEnabled -SecurityInfoType TrustedLaunch -SecurityInfoVTpmEnabled -VmLocation $Config.Location -VmResourceGroup $Config.ResourceGroup
    }
    if (-not $configuration) { throw 'SHC is not available. Check service authorization and RBAC propagation before retrying.' }
    $count = if ($PoolPlan.Role -eq 'UserSessions') { 1 } else { 3 }
    $management = $null
    try {
        $management = Get-AzWvdSessionHostManagement @path
    } catch [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.RestException] {
        if ($_.Exception.StatusCode -ne [System.Net.HttpStatusCode]::NotFound) { throw }
    } catch {
        if ($_.FullyQualifiedErrorId -ne 'NotFound,Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Cmdlets.GetAzWvdSessionHostManagement_Get') { throw }
    }
    if (-not $management -and (Confirm-AvdMutation $PSCmdlet $pool.Name 'Create session host management and request service-managed instances')) {
        $management = New-AzWvdSessionHostManagement @path -ScheduledDateTimeZone UTC -UpdateLogOffDelayMinute 1 -UpdateLogoffMessage 'Session hosts are being updated for test validation.' -UpdateMaxVmsRemoved 1 -UpdateDeleteOriginalVm -ProvisioningInstanceCount $count
    } elseif ($management.ProvisioningInstanceCount -ne $count -and (Confirm-AvdMutation $PSCmdlet $pool.Name 'Set service-managed instance count')) {
        $management = Update-AzWvdSessionHostManagement @path -ProvisioningInstanceCount $count
    }
    if (-not $management) { throw 'SHM is not available. Service-managed hosts have not been requested successfully.' }
    $observed = @{}
    $observationFailures = @()
    foreach ($command in @('Get-AzWvdActiveSessionHostConfiguration', 'Get-AzWvdSessionHostProvisioningStatus', 'Get-AzWvdSessionHost')) {
        try {
            $observed[$command] = @(& $command @path)
        } catch {
            $observationFailures += @{ Operation = $command; Detail = 'Discovery failed; absence and readiness are unknown. Recheck authorization and service availability.' }
        }
    }
    $missing = if ($observed.ContainsKey('Get-AzWvdSessionHost')) {
        @($PoolPlan.Hosts | Where-Object { $_ -notin @($observed['Get-AzWvdSessionHost'] | ForEach-Object { ($_.Name -split '/')[-1] }) })
    } else { $null }
    [pscustomobject]@{
        Pool = $pool.Name
        RequestedCount = $count
        ActiveConfigurationCount = if ($observed.ContainsKey('Get-AzWvdActiveSessionHostConfiguration')) { $observed['Get-AzWvdActiveSessionHostConfiguration'].Count } else { $null }
        ServiceStatus = @($observed['Get-AzWvdSessionHostProvisioningStatus'] | ForEach-Object { $_.Status })
        ObservationFailures = $observationFailures
        MissingExpectedHosts = $missing
        Pending = 'Inspect provisioning status/host health and active SHC in a later live phase. Lifecycle scheduling and real-user login are not performed.'
    }
}

function Ensure-AvdMsix {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, [string]$SourcePath)

    if (-not $PSCmdlet.ShouldProcess($Config.MSIXImagePath, 'Ensure App Attach storage and VHDX')) { return }
    if ($Config.MSIXImagePath -notmatch '^\\\\([^.]+)\.file\.core\.windows\.net\\([^\\]+)\\(.+)$') { throw 'MSIXImagePath must be an Azure Files UNC path.' }
    $accountName = $Matches[1]
    $shareName = $Matches[2]
    $relativePath = $Matches[3] -replace '\\', '/'
    $account = Get-AzStorageAccount -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop | Where-Object StorageAccountName -eq $accountName
    if (-not $account -and (Confirm-AvdMutation $PSCmdlet $accountName 'Create App Attach storage account')) {
        $account = New-AzStorageAccount -Name $accountName -ResourceGroupName $Config.ResourceGroup -Location $Config.Location -SkuName Standard_LRS -Kind StorageV2 -ErrorAction Stop
    }
    $principals = @(foreach ($displayName in @('Azure Virtual Desktop', 'Azure Virtual Desktop ARM Provider', 'Azure Virtual Desktop selfhost')) {
        Get-AzADServicePrincipal -DisplayName $displayName -ErrorAction Stop | Where-Object DisplayName -eq $displayName
    })
    if (-not $principals) { throw 'No AVD service principals found. An administrator must establish App Attach storage access.' }
    foreach ($principal in $principals) { Ensure-AvdRole -Scope $account.Id -PrincipalId $principal.Id -Role 'Reader and Data Access' }
    $storageContext = $account.Context
    $share = Get-AzStorageShare -Context $storageContext -ErrorAction Stop | Where-Object Name -eq $shareName
    if (-not $share -and (Confirm-AvdMutation $PSCmdlet $shareName 'Create file share')) {
        New-AzStorageShare -Name $shareName -Context $storageContext -ErrorAction Stop | Out-Null
    }
    $segments = $relativePath -split '/'
    $entries = @(Get-AzStorageFile -ShareName $shareName -Context $storageContext -ErrorAction Stop)
    $missingDirectories = @()
    $directory = ''
    for ($index = 0; $index -lt $segments.Count - 1; $index++) {
        $segment = $segments[$index]
        $directory = if ($directory) { "$directory/$segment" } else { $segment }
        $existingDirectory = $entries | Where-Object Name -eq $segment
        if ($existingDirectory) {
            if (-not $existingDirectory.ShareDirectoryClient) { throw "App Attach directory path is occupied by a file: $directory" }
            $entries = @(Get-AzStorageFile -ShareDirectoryClient $existingDirectory.ShareDirectoryClient -Context $storageContext -ErrorAction Stop)
        } else {
            $missingDirectories += $directory
            $entries = @()
        }
    }
    $existing = $entries | Where-Object Name -eq $segments[-1]
    if ($existing) {
        if ($existing.ShareDirectoryClient) { throw 'App Attach VHDX path is occupied by a directory.' }
        return $true
    }
    if (-not $SourcePath) { throw 'Provide MsixVhdxSourcePath with a prebuilt XmlNotepad 2.9.0.16 VHDX. Build it separately on an authorized elevated Windows machine; this script never downloads tools or requests elevation.' }
    if (-not (Test-Path -LiteralPath $SourcePath -PathType Leaf) -or [System.IO.Path]::GetExtension($SourcePath) -ne '.vhdx') { throw 'MsixVhdxSourcePath must reference an existing VHDX file.' }
    foreach ($directory in $missingDirectories) {
        if (Confirm-AvdMutation $PSCmdlet $directory 'Create Azure Files directory') {
            New-AzStorageDirectory -ShareName $shareName -Path $directory -Context $storageContext -ErrorAction Stop | Out-Null
        }
    }
    if (Confirm-AvdMutation $PSCmdlet $relativePath 'Upload prebuilt VHDX') {
        Set-AzStorageFileContent -ShareName $shareName -Source $SourcePath -Path $relativePath -Context $storageContext -Force -ErrorAction Stop | Out-Null
    }
    return $true
}

function Invoke-AvdProvisionResources {
    [CmdletBinding(SupportsShouldProcess)]
    param($Config, $Plan, $Options)

    $ErrorActionPreference = 'Stop'
    if (-not $PSCmdlet.ShouldProcess($Config.ResourceGroup, 'Provision persistent fixtures')) { return }
    Assert-AvdDependencies $Config $Plan
    Assert-AvdContext $Config
    if (Test-Path -LiteralPath $Config.StatePath) { $null = Read-AvdState $Config.StatePath $Config }
    if ($Options.RuntimeEnvPath) {
        if (-not [System.IO.Path]::IsPathFullyQualified($Options.RuntimeEnvPath) -or $Options.RuntimeEnvPath -eq $Config.StatePath) { throw 'RuntimeEnvPath must be absolute and distinct from StatePath.' }
        if (Test-Path -LiteralPath $Options.RuntimeEnvPath) { $null = Read-AvdState $Options.RuntimeEnvPath $Config }
    }
    Write-AvdJson -Path $Config.StatePath -Value $Config -Required
    Set-AvdProcessSelection -Config $Config -RuntimeEnvPath $Options.RuntimeEnvPath
    $completed = @()
    $skipped = @()
    $failed = @()
    $observations = @()
    foreach ($phase in $Plan.Phases) {
        try {
            $null = Confirm-AvdMutation $PSCmdlet $Config.ResourceGroup "Run $phase phase"
            switch ($phase) {
                ControlPlane { Ensure-AvdControlPlane $Config $Plan }
                Msix {
                    if (-not (Ensure-AvdMsix -Config $Config -SourcePath $Options.MsixVhdxSourcePath)) {
                        throw [System.OperationCanceledException]::new('App Attach was declined.')
                    }
                }
                SessionHosts {
                    foreach ($poolPlan in $Plan.Pools) {
                        $pool = Get-AzWvdHostPool -Name $poolPlan.Name -ResourceGroupName $Config.ResourceGroup -SubscriptionId $Config.SubscriptionId -ErrorAction Stop
                        Assert-AvdPool $Config $pool $poolPlan.ManagementType
                    }
                    $credential = Get-AvdVMCredential -Config $Config -Credential $Options.VMAdminCredential
                    if (-not $credential) { throw [System.OperationCanceledException]::new('Credential preparation was declined.') }
                    $image = Get-AzVMImage -Location $Config.Location -PublisherName $Config.MarketplaceInfoPublisher -Offer $Config.MarketplaceInfoOffer -Skus $Config.MarketplaceInfoSku -ErrorAction Stop | Sort-Object { [version]$_.Version } -Descending | Select-Object -First 1
                    if (-not $image.Version) { throw 'The configured Marketplace image is unavailable in this region.' }
                    $Config | Add-Member -NotePropertyName MarketplaceImageVersion -NotePropertyValue $image.Version -Force
                    $existingVMs = @(Get-AzVM -ResourceGroupName $Config.ResourceGroup -ErrorAction Stop)
                    $expectedNames = @($Config.SessionHostName, $Config.SHMSessionHostReprovisioning, $Config.SHMSessionHostNameRemove)
                    if ($Config.Profile -eq 'Preview') { $expectedNames += "$($Config.SHMSessionHostNamePrefix)-0" }
                    $missingCount = @($expectedNames | Where-Object { $_ -notin $existingVMs.Name }).Count
                    $size = Get-AvdVMSize $Config $missingCount $Options.VMSize
                    $dscUrl = if ($Options.AvdDscConfigUrl) { $Options.AvdDscConfigUrl } else { 'https://wvdportalstorageblob.blob.core.windows.net/galleryartifacts/Configuration_1.0.02790.438.zip' }
                    foreach ($poolPlan in $Plan.Pools | Where-Object { $_.Hosts.Count }) {
                        if ($Config.Profile -eq 'Preview') {
                            $observation = Ensure-AvdManagedHosts -Config $Config -PoolPlan $poolPlan -VMSize $size
                            if (-not $observation) { throw [System.OperationCanceledException]::new('Managed hosts were declined.') }
                            $observations += $observation
                        } else {
                            foreach ($hostName in $poolPlan.Hosts) {
                                if (-not (Ensure-AvdDirectHost -Config $Config -PoolName $poolPlan.Name -HostName $hostName -VMSize $size -Credential $credential -DscUrl $dscUrl -Repair:$Options.RepairSessionHosts)) {
                                    throw [System.OperationCanceledException]::new('Direct host was declined.')
                                }
                            }
                        }
                    }
                }
            }
            if ($phase -eq 'SessionHosts' -and ($observations | Where-Object { $_.ObservationFailures.Count })) {
                $failed += $phase
            } else {
                $completed += $phase
            }
        } catch [System.OperationCanceledException] {
            $skipped += $phase
        } finally {
            $credential = $null
        }
    }
    Write-AvdJson -Path $Config.StatePath -Value $Config -Required
    [pscustomobject]@{
        Profile = $Config.Profile; StatePath = $Config.StatePath; Status = if ($skipped.Count -or $failed.Count) { 'Incomplete' } else { 'PendingLiveValidation' }
        CompletedPhases = $completed; SkippedPhases = $skipped; FailedPhases = $failed; Observations = $observations; Pending = $Plan.Pending
        LoginHostPool = $Config.HostPoolPersistent; LoginHost = $Config.SessionHostName
        CredentialVault = $Config.KeyVaultPersistentResourceName
    }
}