# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
    Idempotently provisions the PERSISTENT Azure resources that the
    DesktopVirtualization Pester tests depend on, so they no longer need to be
    created by hand. Resource inputs are shared with setupEnv in test/utils.ps1.

.DESCRIPTION
    Creates (only if missing):
      * ControlPlane : resource group, VNet+subnet, KeyVault (+ username/password
                       secrets), Workspace, the 'automated' HostPool (+ Desktop and
                       RemoteApp application groups), and the 'automated2' HostPool.
      * SessionHosts : Entra-joined session host VMs registered to those host pools
                       (auto-0 -> automated; auto2-0 / auto2-2 -> automated2).
      * Msix         : a storage account + SMB file share, and (optionally) uploads a
                       prebuilt .vhdx to the UNC path named in MSIXImagePath.

    The only thing this script cannot do is create an ACTIVE user session - that
    requires a real interactive RDP logon. See the note printed at the end.

    Requires: Az.Accounts, Az.Resources, Az.Network, Az.KeyVault, Az.Compute,
    Az.Storage, Az.DesktopVirtualization. Run Connect-AzAccount first.

.EXAMPLE
    ./test/provision.ps1 -ResourceGroupName 'avd-powershell-tests'
    # Generates a session host VM local administrator credential and stores it in Key Vault.

.EXAMPLE
    ./test/provision.ps1 -Include ControlPlane -WhatIf
#>
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Medium')]
param(
    [ValidateNotNullOrEmpty()]
    [string]$ResourceGroupName,

    [ValidateSet('All', 'ControlPlane', 'SessionHosts', 'Msix')]
    [string[]]$Include = @('All'),

    # Optional override. When omitted and SessionHosts are included, the script
    # generates a strong local administrator credential and stores it in Key Vault.
    [pscredential]$VMAdminCredential,

    [string]$Location,

    # When omitted, the script selects the first region-available SKU with enough
    # family quota for all missing session host VMs.
    [string]$VMSize,

    # Optional override: upload this prebuilt VHDX instead of building XmlNotepad
    # from the pinned public GitHub release.
    [string]$MsixVhdxSourcePath,

    [string]$XmlNotepadMsixBundleUrl = 'https://github.com/microsoft/XmlNotepad/releases/download/2.9.0.16/XmlNotepadPackage_2.9.0.16_AnyCPU.msixbundle',

    [string]$MsixMgrUrl = 'https://aka.ms/msixmgr',

    # AVD agent install (DSC) artifact. Bump if registration starts failing.
    [string]$AvdDscConfigUrl = 'https://wvdportalstorageblob.blob.core.windows.net/galleryartifacts/Configuration_1.0.02790.438.zip'
)

$ErrorActionPreference = 'Stop'
# Note: no Set-StrictMode - the resource config may legitimately omit optional
# persistent field names; absent names must read as $null so we skip them.
. (Join-Path $PSScriptRoot 'utils.ps1')

#region helpers -------------------------------------------------------------------
function Write-Step([string]$Message) { Write-Host "==> $Message" -ForegroundColor Cyan }
function Write-Skip([string]$Message) { Write-Host "    (exists) $Message" -ForegroundColor DarkGray }
function Write-Made([string]$Message) { Write-Host "    (created) $Message" -ForegroundColor Green }

function Get-ProvisionConfig {
    return Get-AvdTestResourceConfig
}

function Convert-ToVmComputerName([string]$sessionHostName) {
    # Session host names may be "name.domain"; the VM computer name is the short name (<=15 chars).
    $short = ($sessionHostName -split '\.')[0]
    if ($short.Length -gt 15) { $short = $short.Substring(0, 15) }
    return $short
}

function Get-PlannedSessionHostNames($cfg) {
    return @(
        $cfg.SessionHostName
        $cfg.SHMSessionHostReprovisioning
        $cfg.SHMSessionHostNameRemove
    ) | Where-Object { -not [string]::IsNullOrWhiteSpace($_) } | Select-Object -Unique
}

function Resolve-AvdVMSize($cfg, [string]$loc, [string]$requestedSize) {
    $missingVMs = @(
        Get-PlannedSessionHostNames $cfg | Where-Object {
            $vmName = Convert-ToVmComputerName $_
            -not (Get-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent -Name $vmName -ErrorAction SilentlyContinue)
        }
    )
    if ($missingVMs.Count -eq 0) {
        return $requestedSize
    }

    Write-Step "Checking VM SKU availability and quota for $($missingVMs.Count) missing session host VM(s)"
    $usage = Get-AzVMUsage -Location $loc
    $skus = Get-AzComputeResourceSku | Where-Object {
        $_.ResourceType -eq 'virtualMachines' -and $_.Locations -contains $loc
    }
    $regionalUsage = $usage | Where-Object { $_.Name.Value -eq 'cores' } | Select-Object -First 1
    $minimumRequiredCores = 2 * $missingVMs.Count
    if ($regionalUsage) {
        $regionalAvailableCores = $regionalUsage.Limit - $regionalUsage.CurrentValue
        if ($regionalAvailableCores -lt $minimumRequiredCores) {
            throw "The total regional vCPU quota in '$loc' has $regionalAvailableCores core(s) available, but $minimumRequiredCores are required for $($missingVMs.Count) Windows 11 session host VM(s). No VM SKU retry can succeed. Choose another -Location, delete unused VMs, or request a regional vCPU quota increase."
        }
    }

    $candidates = if ($requestedSize) {
        @($requestedSize)
    } else {
        $eligible = foreach ($sku in $skus) {
            if ($sku.Restrictions | Where-Object { $_.ReasonCode -and $_.ReasonCode -ne 'None' }) {
                continue
            }

            $cores = [int](($sku.Capabilities | Where-Object Name -eq 'vCPUs' | Select-Object -First 1).Value)
            $memoryValue = ($sku.Capabilities | Where-Object Name -eq 'MemoryGB' | Select-Object -First 1).Value
            $memory = if ($memoryValue) { [decimal]$memoryValue } else { 0 }
            $hyperVGenerations = ($sku.Capabilities | Where-Object Name -eq 'HyperVGenerations' | Select-Object -First 1).Value
            $trustedLaunchDisabled = ($sku.Capabilities | Where-Object Name -eq 'TrustedLaunchDisabled' | Select-Object -First 1).Value
            if ($sku.Name -notmatch '^Standard_[BDE]' -or
                $cores -lt 2 -or $cores -gt 4 -or
                $memory -lt 4 -or
                $hyperVGenerations -notmatch 'V2' -or
                $trustedLaunchDisabled -eq 'True') {
                continue
            }

            $familyUsage = $usage | Where-Object { $_.Name.Value -ieq $sku.Family } | Select-Object -First 1
            if (-not $familyUsage -or
                ($familyUsage.Limit - $familyUsage.CurrentValue) -lt ($cores * $missingVMs.Count)) {
                continue
            }

            [pscustomobject]@{
                Name = $sku.Name
                Cores = $cores
                MemoryGB = $memory
            }
        }

        $preferred = @('Standard_E2ds_v6', 'Standard_D2s_v6', 'Standard_D2s_v4', 'Standard_D2s_v3', 'Standard_B2s')
        @(
            $preferred | Where-Object { $_ -in $eligible.Name }
            $eligible | Sort-Object Cores, MemoryGB, Name | Select-Object -ExpandProperty Name
        ) | Select-Object -Unique
    }

    $rejections = @()
    foreach ($candidate in $candidates) {
        $sku = $skus | Where-Object Name -eq $candidate | Select-Object -First 1
        if (-not $sku) {
            $rejections += "${candidate}: not available in $loc"
            continue
        }
        if ($sku.Restrictions | Where-Object { $_.ReasonCode -and $_.ReasonCode -ne 'None' }) {
            $rejections += "${candidate}: unavailable for this subscription"
            continue
        }

        $coresPerVM = [int](($sku.Capabilities | Where-Object Name -eq 'vCPUs' | Select-Object -First 1).Value)
        $requiredCores = $coresPerVM * $missingVMs.Count
        $familyUsage = $usage | Where-Object { $_.Name.Value -eq $sku.Family } | Select-Object -First 1
        if (-not $familyUsage) {
            $rejections += "${candidate}: quota record for family '$($sku.Family)' not found"
            continue
        }
        $familyAvailable = $familyUsage.Limit - $familyUsage.CurrentValue
        if ($familyAvailable -lt $requiredCores) {
            $rejections += "${candidate}: family quota has $familyAvailable core(s), needs $requiredCores"
            continue
        }

        if ($regionalUsage -and (($regionalUsage.Limit - $regionalUsage.CurrentValue) -lt $requiredCores)) {
            $rejections += "${candidate}: regional quota is insufficient for $requiredCores core(s)"
            continue
        }

        Write-Host "    Selected $candidate ($coresPerVM vCPU each; $requiredCores total; family quota available: $familyAvailable)" -ForegroundColor Green
        return $candidate
    }

    throw "No VM size has enough availability/quota for $($missingVMs.Count) VM(s) in '$loc'. $($rejections -join '; ')"
}
#endregion

#region control plane -------------------------------------------------------------
function Ensure-ResourceGroup($cfg, $loc) {
    Write-Step "Resource group '$($cfg.ResourceGroupPersistent)'"
    $rg = Get-AzResourceGroup -Name $cfg.ResourceGroupPersistent -ErrorAction SilentlyContinue
    if ($rg) { Write-Skip $cfg.ResourceGroupPersistent; return }
    if ($PSCmdlet.ShouldProcess($cfg.ResourceGroupPersistent, 'New-AzResourceGroup')) {
        New-AzResourceGroup -Name $cfg.ResourceGroupPersistent -Location $loc | Out-Null
        Write-Made $cfg.ResourceGroupPersistent
    }
}

function Ensure-Vnet($cfg, $loc) {
    Write-Step "VNet '$($cfg.VnetName)' (+ default subnet)"
    $vnet = Get-AzVirtualNetwork -Name $cfg.VnetName -ResourceGroupName $cfg.ResourceGroupPersistent -ErrorAction SilentlyContinue
    if ($vnet) {
        if ($vnet.Location -ne $loc) {
            throw "VNet '$($cfg.VnetName)' already exists in '$($vnet.Location)', but Provision requested '$loc'. Use the matching location or a different ResourceGroupName."
        }
        Write-Skip $cfg.VnetName
        return $vnet
    }
    if ($PSCmdlet.ShouldProcess($cfg.VnetName, 'New-AzVirtualNetwork')) {
        $subnet = New-AzVirtualNetworkSubnetConfig -Name 'default' -AddressPrefix '10.0.0.0/24' -PrivateEndpointNetworkPoliciesFlag 'Disabled'
        $vnet = New-AzVirtualNetwork -Name $cfg.VnetName -ResourceGroupName $cfg.ResourceGroupPersistent -Location $loc -AddressPrefix '10.0.0.0/16' -Subnet $subnet
        Write-Made $cfg.VnetName
    }
    return $vnet
}

function Get-CurrentAzPrincipalObjectId {
    # Resolve the current principal from the ARM token rather than Microsoft
    # Graph. Get-AzADUser/Get-AzADServicePrincipal can fail when Az.Resources
    # cannot use the SharedTokenCache, even though the ARM login is valid.
    $accessToken = Get-AzAccessToken -ResourceUrl 'https://management.azure.com/' -ErrorAction Stop
    if ($accessToken.Token -is [securestring]) {
        $rawToken = [System.Net.NetworkCredential]::new('', $accessToken.Token).Password
    } else {
        $rawToken = [string]$accessToken.Token
    }

    $parts = $rawToken.Split('.')
    if ($parts.Count -lt 2) {
        throw 'The ARM access token is not a valid JWT; unable to resolve the current principal object ID.'
    }
    $payload = $parts[1].Replace('-', '+').Replace('_', '/')
    while (($payload.Length % 4) -ne 0) {
        $payload += '='
    }
    try {
        $claims = [System.Text.Encoding]::UTF8.GetString(
            [System.Convert]::FromBase64String($payload)
        ) | ConvertFrom-Json
    } catch {
        throw "Unable to decode the ARM access token while resolving the current principal object ID. $($_.Exception.Message)"
    }
    if ([string]::IsNullOrWhiteSpace($claims.oid)) {
        throw 'The ARM access token does not contain an oid claim; unable to assign the Key Vault role.'
    }
    return $claims.oid
}

function Ensure-AzRoleAssignmentRest(
    [string]$scope,
    [string]$principalId,
    [string]$roleDefinitionGuid,
    [string]$roleName,
    [string]$subscriptionId
) {
    $roleDefinitionId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/roleDefinitions/$roleDefinitionGuid"
    $assignmentKey = "$scope|$principalId|$roleDefinitionGuid".ToLowerInvariant()
    $sha = [System.Security.Cryptography.SHA256]::Create()
    try {
        $assignmentHash = $sha.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($assignmentKey))
    } finally {
        $sha.Dispose()
    }
    $assignmentBytes = [byte[]]::new(16)
    [System.Array]::Copy($assignmentHash, $assignmentBytes, 16)
    $assignmentId = [guid]::new($assignmentBytes)

    if ($PSCmdlet.ShouldProcess($scope, "Assign '$roleName' to principal '$principalId'")) {
        $path = "$scope/providers/Microsoft.Authorization/roleAssignments/${assignmentId}?api-version=2022-04-01"
        $body = @{
            properties = @{
                roleDefinitionId = $roleDefinitionId
                principalId = $principalId
            }
        } | ConvertTo-Json -Depth 4
        $response = $null
        for ($attempt = 1; $attempt -le 5; $attempt++) {
            try {
                $response = Invoke-AzRestMethod -Method PUT -Path $path -Payload $body -ErrorAction Stop
                break
            } catch {
                $isTimeout = $_.Exception.Message -match 'Timeout|timed out|canceled'
                if (-not $isTimeout -or $attempt -eq 5) {
                    throw
                }
                Write-Host "    Retrying ARM role assignment after timeout ($attempt/5)..." -ForegroundColor DarkGray
                Start-Sleep -Seconds 10
            }
        }
        if ($response.StatusCode -notin 200, 201) {
            $errorCode = try { ($response.Content | ConvertFrom-Json).error.code } catch { $null }
            if ($response.StatusCode -ne 409 -or $errorCode -ne 'RoleAssignmentExists') {
                throw "ARM returned HTTP $($response.StatusCode): $($response.Content)"
            }
            Write-Skip "$roleName role for principal '$principalId'"
        } elseif ($response.StatusCode -eq 200) {
            Write-Skip "$roleName role for principal '$principalId'"
        } else {
            Write-Made "$roleName role for principal '$principalId'"
        }
    }
}

function Ensure-KeyVaultSecretRole($kv) {
    if (-not $kv.EnableRbacAuthorization) { return }

    $principalId = Get-CurrentAzPrincipalObjectId
    $roleName = 'Key Vault Secrets Officer'
    $roleDefinitionGuid = 'b86a8fe4-44ce-4948-aee5-eccb2c155cd7'
    try {
        Ensure-AzRoleAssignmentRest -scope $kv.ResourceId -principalId $principalId `
            -roleDefinitionGuid $roleDefinitionGuid -roleName $roleName -subscriptionId $cfg.SubscriptionId
    } catch {
        throw "Unable to assign '$roleName' on Key Vault '$($kv.VaultName)'. The current account needs Microsoft.Authorization/roleAssignments/write (for example Owner or User Access Administrator). $($_.Exception.Message)"
    }
}

function Set-AvdKeyVaultSecretWithRetry([string]$vaultName, [string]$name, [securestring]$value) {
    $attempts = 12
    for ($attempt = 1; $attempt -le $attempts; $attempt++) {
        try {
            Set-AzKeyVaultSecret -VaultName $vaultName -Name $name -SecretValue $value -ErrorAction Stop | Out-Null
            return
        } catch {
            $isAuthorizationPropagation = $_.Exception.Message -match 'Forbidden|not authorized'
            if (-not $isAuthorizationPropagation -or $attempt -eq $attempts) {
                throw
            }
            Write-Host "    Waiting for Key Vault RBAC propagation ($attempt/$attempts)..." -ForegroundColor DarkGray
            Start-Sleep -Seconds 10
        }
    }
}

function Ensure-KeyVault($cfg, $loc) {
    if ([string]::IsNullOrWhiteSpace($cfg.KeyVaultPersistentResourceName)) { return }
    Write-Step "KeyVault '$($cfg.KeyVaultPersistentResourceName)' (+ username/password secrets)"
    $kv = Get-AzKeyVault -VaultName $cfg.KeyVaultPersistentResourceName -ErrorAction SilentlyContinue
    if (-not $kv) {
        if ($PSCmdlet.ShouldProcess($cfg.KeyVaultPersistentResourceName, 'New-AzKeyVault')) {
            $kv = New-AzKeyVault -VaultName $cfg.KeyVaultPersistentResourceName -ResourceGroupName $cfg.ResourceGroupPersistent -Location $loc -EnabledForTemplateDeployment
            Write-Made $cfg.KeyVaultPersistentResourceName
        }
    } else { Write-Skip $cfg.KeyVaultPersistentResourceName }

    if ($VMAdminCredential) {
        Ensure-KeyVaultSecretRole $kv
        $userName = $VMAdminCredential.UserName
        if ($PSCmdlet.ShouldProcess("$($cfg.KeyVaultPersistentResourceName)/username,password", 'Set-AzKeyVaultSecret')) {
            Set-AvdKeyVaultSecretWithRetry -vaultName $cfg.KeyVaultPersistentResourceName -name 'username' -value (ConvertTo-SecureString $userName -AsPlainText -Force)
            Set-AvdKeyVaultSecretWithRetry -vaultName $cfg.KeyVaultPersistentResourceName -name 'password' -value $VMAdminCredential.Password
            Write-Made 'secrets username/password'
        }
    } else {
        Write-Warning "No -VMAdminCredential supplied; skipping KeyVault username/password secrets."
    }
}

function Ensure-HostPool($cfg, $loc, [string]$name, [string]$preferredAppGroupType) {
    Write-Step "HostPool '$name'"
    $hp = Get-AzWvdHostPool -Name $name -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId -ErrorAction SilentlyContinue
    if ($hp) { Write-Skip $name; return $hp }
    if ($PSCmdlet.ShouldProcess($name, 'New-AzWvdHostPool')) {
        $hp = New-AzWvdHostPool -Name $name -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId `
            -Location $loc -HostPoolType 'Pooled' -LoadBalancerType 'BreadthFirst' -PreferredAppGroupType $preferredAppGroupType `
            -MaxSessionLimit 10
        Write-Made $name
    }
    return $hp
}

function Ensure-HostPoolEntraSso($cfg, $hostPool) {
    $ssoProperty = 'enablerdsaadauth:i:1'
    if ($hostPool.CustomRdpProperty -match "(^|;)$([regex]::Escape($ssoProperty))(;|$)") {
        Write-Skip "Microsoft Entra SSO on HostPool '$($hostPool.Name)'"
        return
    }

    $rdpProperties = @(
        [string]$hostPool.CustomRdpProperty -split ';' |
            Where-Object {
                -not [string]::IsNullOrWhiteSpace($_) -and
                $_ -notmatch '^enablerdsaadauth:i:'
            }
        $ssoProperty
    )
    $customRdpProperty = ($rdpProperties -join ';') + ';'
    if ($PSCmdlet.ShouldProcess($hostPool.Name, 'Enable Microsoft Entra SSO')) {
        $hostPool = Update-AzWvdHostPool -SubscriptionId $cfg.SubscriptionId `
            -ResourceGroupName $cfg.ResourceGroupPersistent -Name $hostPool.Name `
            -CustomRdpProperty $customRdpProperty
        Write-Made "Microsoft Entra SSO on HostPool '$($hostPool.Name)'"
    }
    return $hostPool
}

function Test-TenantEntraRdpAuthentication {
    try {
        $accessToken = Get-AzAccessToken -ResourceUrl 'https://graph.microsoft.com/' -ErrorAction Stop
        if ($accessToken.Token -is [securestring]) {
            $token = [System.Net.NetworkCredential]::new('', $accessToken.Token).Password
        } else {
            $token = [string]$accessToken.Token
        }
        $headers = @{ Authorization = "Bearer $token" }
        $servicePrincipal = (
            Invoke-RestMethod -Uri "https://graph.microsoft.com/v1.0/servicePrincipals?`$filter=appId eq '270efc09-cd0d-444b-a71f-39af4910ec45'&`$select=id" `
                -Headers $headers -ErrorAction Stop
        ).value | Select-Object -First 1
        if (-not $servicePrincipal) {
            Write-Warning 'Windows Cloud Login service principal was not found. A tenant administrator must enable Microsoft Entra RDP authentication before SSO can work.'
            return
        }
        $configuration = Invoke-RestMethod `
            -Uri "https://graph.microsoft.com/beta/servicePrincipals/$($servicePrincipal.id)/remoteDesktopSecurityConfiguration" `
            -Headers $headers -ErrorAction Stop
        if ($configuration.isRemoteDesktopProtocolEnabled) {
            Write-Skip 'Tenant-level Microsoft Entra RDP authentication'
        } else {
            Write-Warning 'HostPool SSO is enabled, but tenant-level Microsoft Entra RDP authentication is disabled. An Application Administrator or Cloud Application Administrator must enable Windows Cloud Login > Remote connection configuration once in Microsoft Entra ID.'
        }
    } catch {
        Write-Warning "Could not verify tenant-level Microsoft Entra RDP authentication. An Entra administrator should verify Windows Cloud Login > Remote connection configuration. $($_.Exception.Message)"
    }
}

function Ensure-AppGroup($cfg, $loc, [string]$name, [string]$type, $hostPool) {
    if ([string]::IsNullOrWhiteSpace($name)) { return $null }
    Write-Step "ApplicationGroup '$name' ($type)"
    $ag = Get-AzWvdApplicationGroup -Name $name -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId -ErrorAction SilentlyContinue
    if ($ag) { Write-Skip $name; return $ag }
    if ($PSCmdlet.ShouldProcess($name, 'New-AzWvdApplicationGroup')) {
        $ag = New-AzWvdApplicationGroup -Name $name -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId `
            -Location $loc -HostPoolArmPath $hostPool.Id -ApplicationGroupType $type
        Write-Made $name
    }
    return $ag
}

function Ensure-Workspace($cfg, $loc, $appGroups) {
    if ([string]::IsNullOrWhiteSpace($cfg.AutomatedHostpoolPersistent)) { return }
    $wsName = "$($cfg.AutomatedHostpoolPersistent)-workspace"
    Write-Step "Workspace '$wsName'"
    $refs = @($appGroups | Where-Object { $_ } | ForEach-Object { $_.Id })
    $ws = Get-AzWvdWorkspace -Name $wsName -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId -ErrorAction SilentlyContinue
    if ($ws) {
        Write-Skip $wsName
        if ($refs -and $PSCmdlet.ShouldProcess($wsName, 'Update-AzWvdWorkspace (app group refs)')) {
            Update-AzWvdWorkspace -Name $wsName -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId -ApplicationGroupReference $refs | Out-Null
        }
        return
    }
    if ($PSCmdlet.ShouldProcess($wsName, 'New-AzWvdWorkspace')) {
        New-AzWvdWorkspace -Name $wsName -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId `
            -Location $loc -ApplicationGroupReference $refs | Out-Null
        Write-Made $wsName
    }
}

function Ensure-CurrentUserTestAccess($cfg, $desktopAppGroup) {
    $context = Get-AzContext
    if ($context.Account.Type -ne 'User') {
        Write-Warning "The current Azure account '$($context.Account.Id)' is not an interactive user. Skipping AVD desktop and VM login assignments."
        return
    }
    if (-not $desktopAppGroup) {
        throw 'The persistent Desktop Application Group was not created or found.'
    }

    $principalId = Get-CurrentAzPrincipalObjectId
    Write-Step "Granting AVD test login access to '$($context.Account.Id)'"
    Ensure-AzRoleAssignmentRest -scope $desktopAppGroup.Id -principalId $principalId `
        -roleDefinitionGuid '1d18fff3-a72a-46b5-b4a9-0b38a3cd7e63' `
        -roleName 'Desktop Virtualization User' -subscriptionId $cfg.SubscriptionId

    $resourceGroupScope = "/subscriptions/$($cfg.SubscriptionId)/resourceGroups/$($cfg.ResourceGroupPersistent)"
    Ensure-AzRoleAssignmentRest -scope $resourceGroupScope -principalId $principalId `
        -roleDefinitionGuid 'fb879df8-f326-4884-b1cf-06f3ad86be52' `
        -roleName 'Virtual Machine User Login' -subscriptionId $cfg.SubscriptionId
}
#endregion

#region session hosts (Entra join) ------------------------------------------------
function Get-HostPoolRegistrationToken($cfg, [string]$hostPoolName) {
    $expiry = (Get-Date).ToUniversalTime().AddHours(4).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')
    Update-AzWvdHostPool -Name $hostPoolName -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId `
        -RegistrationInfoExpirationTime $expiry -RegistrationInfoRegistrationTokenOperation 'Update' | Out-Null
    return (Get-AzWvdRegistrationInfo -HostPoolName $hostPoolName -ResourceGroupName $cfg.ResourceGroupPersistent -SubscriptionId $cfg.SubscriptionId).Token
}

function Ensure-SessionHostVm($cfg, $loc, $vnet, [string]$hostPoolName, [string]$sessionHostName, [string]$token) {
    $vmName = Convert-ToVmComputerName $sessionHostName
    Write-Step "Session host VM '$vmName' -> hostpool '$hostPoolName'"
    $existing = Get-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent -Name $vmName -ErrorAction SilentlyContinue
    if (-not $VMAdminCredential) { throw "SessionHosts phase needs -VMAdminCredential (local admin for the VM)." }

    if ($existing) {
        Write-Skip "$vmName (VM already exists)"
        if ($existing.Identity.Type -notmatch 'SystemAssigned' -and $PSCmdlet.ShouldProcess($vmName, 'Enable system-assigned managed identity')) {
            Update-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent -VM $existing -IdentityType SystemAssigned | Out-Null
            Write-Made "$vmName (system-assigned managed identity)"
        }
    } elseif ($PSCmdlet.ShouldProcess($vmName, 'New-AzVM (win11-24h2-avd, Entra-joined)')) {
        $subnetId = (Get-AzVirtualNetwork -Name $cfg.VnetName -ResourceGroupName $cfg.ResourceGroupPersistent).Subnets[0].Id
        $nicName = "$vmName-nic"
        $nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $cfg.ResourceGroupPersistent -Location $loc -SubnetId $subnetId -Force

        $vmConfig = New-AzVMConfig -VMName $vmName -VMSize $VMSize -SecurityType 'TrustedLaunch' -IdentityType SystemAssigned |
            Set-AzVMOperatingSystem -Windows -ComputerName $vmName -Credential $VMAdminCredential -ProvisionVMAgent -EnableAutoUpdate |
            Set-AzVMSourceImage -PublisherName $cfg.MarketplaceInfoPublisher -Offer $cfg.MarketplaceInfoOffer -Skus $cfg.MarketplaceInfoSku -Version 'latest' |
            Add-AzVMNetworkInterface -Id $nic.Id
        New-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent -Location $loc -VM $vmConfig | Out-Null
        Write-Made "$vmName (VM)"
    }

    # Entra join
    if ($PSCmdlet.ShouldProcess($vmName, 'AADLoginForWindows extension (Entra join)')) {
        Set-AzVMExtension -ResourceGroupName $cfg.ResourceGroupPersistent -VMName $vmName -Location $loc `
            -Name 'AADLoginForWindows' -Publisher 'Microsoft.Azure.ActiveDirectory' -ExtensionType 'AADLoginForWindows' `
            -TypeHandlerVersion '2.0' -ForceRerun ([guid]::NewGuid().ToString()) | Out-Null
        Write-Made "$vmName (Entra join)"
    }

    if ($PSCmdlet.ShouldProcess($vmName, 'Restart VM after Entra join')) {
        Restart-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent -Name $vmName | Out-Null
        Write-Made "$vmName (restarted after Entra join)"
    }

    # AVD agent install + registration (DSC)
    if ($PSCmdlet.ShouldProcess($vmName, 'AVD agent DSC extension (register to host pool)')) {
        $settings = @{ modulesUrl = $AvdDscConfigUrl; configurationFunction = 'Configuration.ps1\AddSessionHost'; properties = @{ hostPoolName = $hostPoolName; registrationInfoToken = $token; aadJoin = $true } }
        Set-AzVMExtension -ResourceGroupName $cfg.ResourceGroupPersistent -VMName $vmName -Location $loc `
            -Name 'Microsoft.PowerShell.DSC' -Publisher 'Microsoft.Powershell' -ExtensionType 'DSC' -TypeHandlerVersion '2.73' `
            -Settings $settings -ForceRerun ([guid]::NewGuid().ToString()) | Out-Null
        Write-Made "$vmName (AVD agent registered)"
    }
}

function Invoke-SessionHostsPhase($cfg, $loc, $vnet) {
    # automated pool: one host (SessionHostName, e.g. auto-0)
    if (-not [string]::IsNullOrWhiteSpace($cfg.SessionHostName)) {
        $token = Get-HostPoolRegistrationToken $cfg $cfg.AutomatedHostpoolPersistent
        Ensure-SessionHostVm $cfg $loc $vnet $cfg.AutomatedHostpoolPersistent $cfg.SessionHostName $token
    }
    # automated2 pool (SHM): auto2-0 (reprovision) + auto2-2 (remove)
    if (-not [string]::IsNullOrWhiteSpace($cfg.SHMHostPoolPersistent)) {
        $token2 = Get-HostPoolRegistrationToken $cfg $cfg.SHMHostPoolPersistent
        foreach ($sh in @($cfg.SHMSessionHostReprovisioning, $cfg.SHMSessionHostNameRemove)) {
            if (-not [string]::IsNullOrWhiteSpace($sh)) {
                Ensure-SessionHostVm $cfg $loc $vnet $cfg.SHMHostPoolPersistent $sh $token2
            }
        }
    }
}
#endregion

#region MSIX ----------------------------------------------------------------------
function Get-AvdServicePrincipalObjectIds {
    $accessToken = Get-AzAccessToken -ResourceUrl 'https://graph.microsoft.com/' -ErrorAction Stop
    if ($accessToken.Token -is [securestring]) {
        $token = [System.Net.NetworkCredential]::new('', $accessToken.Token).Password
    } else {
        $token = [string]$accessToken.Token
    }
    $headers = @{
        Authorization = "Bearer $token"
        ConsistencyLevel = 'eventual'
    }
    $search = [uri]::EscapeDataString('"displayName:Virtual Desktop"')
    $uri = "https://graph.microsoft.com/v1.0/servicePrincipals?`$search=$search&`$select=id,appId,displayName&`$count=true"
    $principals = (Invoke-RestMethod -Uri $uri -Headers $headers -ErrorAction Stop).value |
        Where-Object {
            $_.displayName -eq 'Azure Virtual Desktop' -or
            $_.displayName -eq 'Azure Virtual Desktop ARM Provider' -or
            $_.displayName -eq 'Azure Virtual Desktop selfhost'
        }
    if (-not $principals) {
        throw 'No Azure Virtual Desktop service principals were found in the current tenant.'
    }
    return $principals
}

function Ensure-AppAttachStorageAccess($cfg, $storageAccount) {
    # Entra-joined session hosts use AVD service principals to retrieve Azure
    # Files access keys for App Attach. PPE uses the selfhost service principals.
    $roleName = 'Reader and Data Access'
    $roleDefinitionGuid = 'c12c1c16-33a1-487b-954d-41c89c60f349'
    Write-Step 'Granting App Attach storage access to AVD service principals'
    foreach ($principal in (Get-AvdServicePrincipalObjectIds)) {
        Ensure-AzRoleAssignmentRest -scope $storageAccount.Id -principalId $principal.id `
            -roleDefinitionGuid $roleDefinitionGuid -roleName "$roleName ($($principal.displayName))" `
            -subscriptionId $cfg.SubscriptionId
    }
}

function New-XmlNotepadAppAttachVhdx {
    $workDir = Join-Path $env:TEMP "avd-msix-$([guid]::NewGuid().ToString('N'))"
    New-Item -Path $workDir -ItemType Directory -Force | Out-Null
    $bundlePath = Join-Path $workDir 'XmlNotepad.msixbundle'
    $bundleZipPath = Join-Path $workDir 'XmlNotepad.bundle.zip'
    $bundleDirectory = Join-Path $workDir 'bundle'
    $msixMgrZipPath = Join-Path $workDir 'msixmgr.zip'
    $msixMgrDirectory = Join-Path $workDir 'msixmgr'
    $vhdxPath = Join-Path $workDir 'XmlNotepad.vhdx'
    $builderPath = Join-Path $workDir 'Build-AppAttachVhdx.ps1'
    $logPath = Join-Path $workDir 'build.log'

    Write-Step 'Downloading pinned XmlNotepad 2.9.0.16 MSIX bundle'
    Invoke-WebRequest -Uri $XmlNotepadMsixBundleUrl -OutFile $bundlePath
    Copy-Item -Path $bundlePath -Destination $bundleZipPath
    Expand-Archive -Path $bundleZipPath -DestinationPath $bundleDirectory

    [xml]$bundleManifest = Get-Content -Path (Join-Path $bundleDirectory 'AppxMetadata\AppxBundleManifest.xml')
    $applicationPackage = $bundleManifest.Bundle.Packages.Package |
        Where-Object { $_.Type -eq 'application' -and $_.Architecture -eq 'neutral' } |
        Select-Object -First 1
    if (-not $applicationPackage) {
        throw "The XmlNotepad bundle does not contain a neutral application package."
    }
    $msixPath = Join-Path $bundleDirectory $applicationPackage.FileName

    Write-Step 'Downloading official MSIXMGR'
    Invoke-WebRequest -Uri $MsixMgrUrl -OutFile $msixMgrZipPath
    Expand-Archive -Path $msixMgrZipPath -DestinationPath $msixMgrDirectory
    $msixMgrPath = Get-ChildItem -Path $msixMgrDirectory -Recurse -Filter 'msixmgr.exe' |
        Where-Object { $_.FullName -match '[\\/]x64[\\/]' } |
        Select-Object -First 1 -ExpandProperty FullName
    if (-not $msixMgrPath) {
        throw 'The downloaded MSIXMGR archive does not contain x64\msixmgr.exe.'
    }

    # MSIXMGR's integrated -create path fails on some current Windows builds.
    # Create/format the VHDX with native Hyper-V cmdlets, then use MSIXMGR only
    # for package expansion and App Attach ACLs.
    @'
param(
    [Parameter(Mandatory)][string]$MsixMgrPath,
    [Parameter(Mandatory)][string]$MsixPath,
    [Parameter(Mandatory)][string]$VhdxPath,
    [Parameter(Mandatory)][string]$LogPath
)
$ErrorActionPreference = 'Stop'
try {
    New-VHD -Path $VhdxPath -Dynamic -SizeBytes 256MB | Out-Null
    $disk = Mount-VHD -Path $VhdxPath -PassThru | Get-Disk
    Initialize-Disk -Number $disk.Number -PartitionStyle MBR
    $partition = New-Partition -DiskNumber $disk.Number -UseMaximumSize -AssignDriveLetter
    Format-Volume -Partition $partition -FileSystem NTFS -AllocationUnitSize 65536 -Confirm:$false | Out-Null
    $destination = "$($partition.DriveLetter):\apps"
    New-Item -Path $destination -ItemType Directory -Force | Out-Null

    & $MsixMgrPath -Unpack -packagePath $MsixPath -destination $destination -applyACLs
    if ($LASTEXITCODE -ne 0) {
        throw "MSIXMGR failed with exit code $LASTEXITCODE."
    }

    $packageFolder = Get-ChildItem -Path $destination -Directory | Select-Object -First 1
    $manifestPath = Join-Path $packageFolder.FullName 'AppxManifest.xml'
    [xml]$manifest = Get-Content -Path $manifestPath
    if ($manifest.Package.Identity.Name -ne '43906ChrisLovett.XmlNotepad' -or
        $manifest.Package.Identity.Version -ne '2.9.0.16') {
        throw "Unexpected package identity: $($manifest.Package.Identity.Name) $($manifest.Package.Identity.Version)."
    }

    Dismount-VHD -Path $VhdxPath
    "Created $VhdxPath from $($applicationPackage.FileName)" | Set-Content -Path $LogPath
    exit 0
} catch {
    $_ | Out-String | Set-Content -Path $LogPath
    Dismount-VHD -Path $VhdxPath -ErrorAction SilentlyContinue
    exit 1
}
'@ | Set-Content -Path $builderPath

    $arguments = @(
        '-NoProfile'
        '-ExecutionPolicy', 'Bypass'
        '-File', "`"$builderPath`""
        '-MsixMgrPath', "`"$msixMgrPath`""
        '-MsixPath', "`"$msixPath`""
        '-VhdxPath', "`"$vhdxPath`""
        '-LogPath', "`"$logPath`""
    )
    $isElevated = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(
        [Security.Principal.WindowsBuiltInRole]::Administrator
    )
    try {
        $startParams = @{
            FilePath = [System.Diagnostics.Process]::GetCurrentProcess().Path
            ArgumentList = $arguments
            Wait = $true
            PassThru = $true
        }
        if (-not $isElevated) {
            Write-Host '    Administrator approval is required once to create the App Attach VHDX.' -ForegroundColor Yellow
            $startParams.Verb = 'RunAs'
        }
        $process = Start-Process @startParams
    } catch {
        $message = $_.Exception.Message
        Remove-Item -Path $workDir -Recurse -Force -ErrorAction SilentlyContinue
        if ($message -match 'canceled by the user|cancelled by the user') {
            throw "Administrator approval for VHDX creation was canceled. Re-run the Msix phase and approve the Windows UAC prompt, or run PowerShell/Rider as Administrator. Existing Azure resources do not need to be recreated."
        }
        throw "Unable to start the elevated VHDX build process. $message"
    }
    if ($process.ExitCode -ne 0 -or -not (Test-Path -Path $vhdxPath)) {
        $details = if (Test-Path -Path $logPath) { Get-Content -Raw -Path $logPath } else { 'No build log was produced.' }
        Remove-Item -Path $workDir -Recurse -Force -ErrorAction SilentlyContinue
        throw "Creating the XmlNotepad App Attach VHDX failed. $details"
    }

    Write-Made 'XmlNotepad 2.9.0.16 App Attach VHDX'
    return [pscustomobject]@{
        WorkDirectory = $workDir
        VhdxPath = $vhdxPath
    }
}

function Invoke-MsixPhase($cfg, $loc) {
    if ([string]::IsNullOrWhiteSpace($cfg.MSIXImagePath)) { Write-Warning 'MSIXImagePath empty; skipping Msix phase.'; return }
    # \\<sa>.file.core.windows.net\<share>\<dir...>\<file.vhdx>
    if ($cfg.MSIXImagePath -notmatch '^\\\\([^.]+)\.file\.core\.windows\.net\\([^\\]+)\\(.+)$') {
        Write-Warning "MSIXImagePath '$($cfg.MSIXImagePath)' is not an Azure Files UNC path; skipping."
        return
    }
    $saName = $Matches[1]; $shareName = $Matches[2]; $relPath = $Matches[3] -replace '\\', '/'
    Write-Step "Storage account '$saName' + file share '$shareName'"

    $sa = Get-AzStorageAccount -ResourceGroupName $cfg.ResourceGroupPersistent -Name $saName -ErrorAction SilentlyContinue
    if (-not $sa) {
        if ($PSCmdlet.ShouldProcess($saName, 'New-AzStorageAccount')) {
            $sa = New-AzStorageAccount -ResourceGroupName $cfg.ResourceGroupPersistent -Name $saName -Location $loc -SkuName 'Standard_LRS' -Kind 'StorageV2'
            Write-Made $saName
        }
    } else { Write-Skip $saName }

    Ensure-AppAttachStorageAccess $cfg $sa
    $ctx = $sa.Context
    if (-not (Get-AzStorageShare -Name $shareName -Context $ctx -ErrorAction SilentlyContinue)) {
        if ($PSCmdlet.ShouldProcess($shareName, 'New-AzStorageShare')) { New-AzStorageShare -Name $shareName -Context $ctx | Out-Null; Write-Made $shareName }
    } else { Write-Skip $shareName }

    $existingFile = Get-AzStorageFile -ShareName $shareName -Path $relPath -Context $ctx -ErrorAction SilentlyContinue
    if ($existingFile) {
        Write-Skip "VHDX already uploaded -> $relPath"
        return
    }

    $generatedArtifact = $null
    try {
        $sourcePath = $MsixVhdxSourcePath
        if ($sourcePath) {
            if (-not (Test-Path $sourcePath)) { throw "MsixVhdxSourcePath not found: $sourcePath" }
        } else {
            $generatedArtifact = New-XmlNotepadAppAttachVhdx
            $sourcePath = $generatedArtifact.VhdxPath
        }

        # ensure directory chain exists
        $pathSegments = @($relPath -split '/')
        $directorySegments = $pathSegments[0..($pathSegments.Count - 2)]
        $acc = ''
        foreach ($seg in $directorySegments) {
            $acc = if ($acc) { "$acc/$seg" } else { $seg }
            if (-not (Get-AzStorageFile -ShareName $shareName -Path $acc -Context $ctx -ErrorAction SilentlyContinue)) {
                New-AzStorageDirectory -ShareName $shareName -Path $acc -Context $ctx -ErrorAction Stop | Out-Null
            }
        }
        if ($PSCmdlet.ShouldProcess($relPath, 'Set-AzStorageFileContent (upload vhdx)')) {
            Set-AzStorageFileContent -ShareName $shareName -Source $sourcePath -Path $relPath -Context $ctx -Force
            Write-Made "uploaded vhdx -> $relPath"
        }
    } finally {
        if ($generatedArtifact -and (Test-Path -Path $generatedArtifact.WorkDirectory)) {
            Remove-Item -Path $generatedArtifact.WorkDirectory -Recurse -Force -ErrorAction SilentlyContinue
        }
    }
}
#endregion

# ---------------------------------------------------------------------------------
if ($PSBoundParameters.ContainsKey('ResourceGroupName')) {
    # Environment variables are process-scoped, so setupEnv in a subsequent
    # test-module.ps1 call from this PowerShell session uses the same resource group.
    $env:AVD_TEST_RESOURCE_GROUP = $ResourceGroupName
}
if ($PSBoundParameters.ContainsKey('Location')) {
    $env:AVD_TEST_LOCATION = $Location
}
$provisionContext = Get-AzContext
$env:AVD_TEST_SUBSCRIPTION_ID = $provisionContext.Subscription.Id
$env:AVD_TEST_TENANT_ID = $provisionContext.Tenant.Id
$cfg = Get-ProvisionConfig
if ([string]::IsNullOrWhiteSpace($cfg.SubscriptionId)) {
    $cfg | Add-Member -NotePropertyName SubscriptionId -NotePropertyValue $provisionContext.Subscription.Id -Force
}
$needsSessionHosts = ($Include -contains 'All') -or ($Include -contains 'SessionHosts')
if ($needsSessionHosts -and -not $VMAdminCredential) {
    $existingSessionHostVMs = @(
        Get-PlannedSessionHostNames $cfg | Where-Object {
            Get-AzVM -ResourceGroupName $cfg.ResourceGroupPersistent `
                -Name (Convert-ToVmComputerName $_) -ErrorAction SilentlyContinue
        }
    )
    $keyVault = Get-AzKeyVault -VaultName $cfg.KeyVaultPersistentResourceName -ErrorAction SilentlyContinue
    if ($keyVault) {
        try {
            $storedUserName = Get-AzKeyVaultSecret -VaultName $cfg.KeyVaultPersistentResourceName `
                -Name 'username' -AsPlainText -ErrorAction Stop
            $storedPassword = Get-AzKeyVaultSecret -VaultName $cfg.KeyVaultPersistentResourceName `
                -Name 'password' -AsPlainText -ErrorAction Stop
            $VMAdminCredential = [pscredential]::new(
                $storedUserName,
                (ConvertTo-SecureString $storedPassword -AsPlainText -Force)
            )
            Write-Host 'Reused the existing session host VM credential from Key Vault.' -ForegroundColor Green
        } catch {
            if ($existingSessionHostVMs) {
                throw "Session host VMs already exist, but their credential could not be read from Key Vault '$($cfg.KeyVaultPersistentResourceName)'. Supply -VMAdminCredential explicitly. $($_.Exception.Message)"
            }
        }
    }
    if (-not $VMAdminCredential) {
        $generatedPassword = "Avd!9$([guid]::NewGuid().ToString('N'))"
        $VMAdminCredential = [pscredential]::new(
            'avdlocaladmin',
            (ConvertTo-SecureString $generatedPassword -AsPlainText -Force)
        )
        Write-Host 'Generated the session host VM local administrator credential; it will be stored in Key Vault.' -ForegroundColor Green
    }
}
$loc = if ($Location) { $Location } elseif ($cfg.Location) { $cfg.Location } else { 'westus2' }
$do = { param($p) ($Include -contains 'All') -or ($Include -contains $p) }

Write-Host "Provisioning AVD test dependencies in RG '$($cfg.ResourceGroupPersistent)' (sub $($cfg.SubscriptionId), $loc)" -ForegroundColor Yellow

if (& $do 'ControlPlane') {
    Ensure-ResourceGroup $cfg $loc
    $vnet = Ensure-Vnet $cfg $loc
    Ensure-KeyVault $cfg $loc
    $automated = Ensure-HostPool $cfg $loc $cfg.AutomatedHostpoolPersistent 'Desktop'
    $automated = Ensure-HostPoolEntraSso $cfg $automated
    Test-TenantEntraRdpAuthentication
    $dag = Ensure-AppGroup $cfg $loc $cfg.PersistentDesktopAppGroup 'Desktop' $automated
    $rag = Ensure-AppGroup $cfg $loc $cfg.PersistentRemoteAppGroup 'RemoteApp' $automated
    Ensure-Workspace $cfg $loc @($dag, $rag)
    Ensure-CurrentUserTestAccess $cfg $dag
    Ensure-HostPool $cfg $loc $cfg.SHMHostPoolPersistent 'Desktop' | Out-Null
}

if (& $do 'SessionHosts') {
    $VMSize = Resolve-AvdVMSize $cfg $loc $VMSize
    $vnet = Get-AzVirtualNetwork -Name $cfg.VnetName -ResourceGroupName $cfg.ResourceGroupPersistent -ErrorAction SilentlyContinue
    Invoke-SessionHostsPhase $cfg $loc $vnet
}

if (& $do 'Msix') {
    Invoke-MsixPhase $cfg $loc
}

if (-not $WhatIfPreference) {
    [ordered]@{
        SubscriptionId = $cfg.SubscriptionId
        TenantId = $provisionContext.Tenant.Id
        ResourceGroupName = $cfg.ResourceGroupPersistent
        Location = $loc
    } | ConvertTo-Json | Set-Content -Path (Join-Path $PSScriptRoot 'provision-state.json')
}

Write-Host ''
Write-Host '-------------------- Done --------------------' -ForegroundColor Green
Write-Host 'MANUAL STEP (cannot be automated): to exercise the user-session tests' -ForegroundColor Yellow
Write-Host "(Get/Remove/Disconnect-AzWvdUserSession, Send-AzWvdUserSessionMessage), RDP-connect" -ForegroundColor Yellow
Write-Host "as a test user to session host '$($cfg.SessionHostName)' in host pool '$($cfg.AutomatedHostpoolPersistent)'" -ForegroundColor Yellow
Write-Host 'so that an active user session exists, then run those tests in -Live mode.' -ForegroundColor Yellow
