if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzMigrateLocalServerReplication' -Tag 'LiveOnly' {
    It 'ByID' {
        $output = Set-AzMigrateLocalServerReplication `
            -TargetObjectID $env.hciProtectedItem1 `
            -SubscriptionId $env.hciSubscriptionId `
            -IsDynamicMemoryEnabled "true"
        $output.Count | Should -BeGreaterOrEqual 1
    }
}

Describe 'Set-AzMigrateLocalServerReplicationSecurityOption' {
    # The mapping runs after a protected item lookup that playback cannot satisfy, so drive the
    # decision directly. The helper lives in a nested module that InModuleScope cannot reach.
    function Resolve-SecurityOption {
        param(
            [string]$Mode,
            [string]$Generation,
            [bool]$HasSecurityOption,
            [string]$SecurityOption = '',
            [bool]$HasEnableSecureBoot,
            [bool]$SecureBootEnabled
        )

        $custom = (Get-Module Az.Migrate).NestedModules |
            Where-Object { $_.Name -eq 'Az.Migrate.custom' }

        & $custom {
            param($mode, $generation, $hasSo, $so, $hasEsb, $esb)
            Resolve-AzMigrateTargetSecurityOption `
                -Mode $mode `
                -HyperVGeneration $generation `
                -HasTargetVMSecurityOption $hasSo `
                -TargetVMSecurityOption $so `
                -HasEnableSecureBoot $hasEsb `
                -SecureBootEnabled $esb
        } $Mode $Generation $HasSecurityOption $SecurityOption $HasEnableSecureBoot $SecureBootEnabled
    }

    It 'Update-MapsSupportedCombinationsOnGen2' {
        $trustedLaunch = Resolve-SecurityOption -Mode Update -Generation '2' -HasSecurityOption $true -SecurityOption 'TrustedLaunch' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $trustedLaunch.SecurityOption | Should -Be 'TrustedLaunch'
        $trustedLaunch.Gen2Required | Should -BeFalse

        # Standard on its own drops vTPM but keeps Secure Boot, matching the portal.
        $standard = Resolve-SecurityOption -Mode Update -Generation '2' -HasSecurityOption $true -SecurityOption 'Standard' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $standard.SecurityOption | Should -Be 'SecureBootEnabled'

        $on = Resolve-SecurityOption -Mode Update -Generation '2' -HasSecurityOption $false -HasEnableSecureBoot $true -SecureBootEnabled $true
        $on.SecurityOption | Should -Be 'SecureBootEnabled'
        $on.VerifySourceSecureBoot | Should -BeFalse

        $off = Resolve-SecurityOption -Mode Update -Generation '2' -HasSecurityOption $false -HasEnableSecureBoot $true -SecureBootEnabled $false
        $off.SecurityOption | Should -Be 'None'
        $off.VerifySourceSecureBoot | Should -BeTrue
    }

    It 'Update-RejectsSecureBootRequestsOnGen1' {
        $trustedLaunch = Resolve-SecurityOption -Mode Update -Generation '1' -HasSecurityOption $true -SecurityOption 'TrustedLaunch' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $trustedLaunch.Gen2Required | Should -BeTrue

        $on = Resolve-SecurityOption -Mode Update -Generation '1' -HasSecurityOption $false -HasEnableSecureBoot $true -SecureBootEnabled $true
        $on.Gen2Required | Should -BeTrue
    }

    It 'Update-AllowsStandardOnGen1' {
        # Gen 1 cannot hold Secure Boot, so the inherit default resolves to None instead of failing.
        $standard = Resolve-SecurityOption -Mode Update -Generation '1' -HasSecurityOption $true -SecurityOption 'Standard' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $standard.Gen2Required | Should -BeFalse
        $standard.SecurityOption | Should -Be 'None'

        $off = Resolve-SecurityOption -Mode Update -Generation '1' -HasSecurityOption $false -HasEnableSecureBoot $true -SecureBootEnabled $false
        $off.Gen2Required | Should -BeFalse
        $off.SecurityOption | Should -Be 'None'
        $off.VerifySourceSecureBoot | Should -BeFalse
    }

    It 'Create-LeavesTargetInheritingWhenNoSecureBootChoice' {
        $standard = Resolve-SecurityOption -Mode Create -Generation '2' -HasSecurityOption $true -SecurityOption 'Standard' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $null -eq $standard.SecurityOption | Should -BeTrue

        $gen1Standard = Resolve-SecurityOption -Mode Create -Generation '1' -HasSecurityOption $true -SecurityOption 'Standard' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $gen1Standard.Gen2Required | Should -BeFalse
        $null -eq $gen1Standard.SecurityOption | Should -BeTrue
    }

    It 'Create-MapsSupportedCombinations' {
        $trustedLaunch = Resolve-SecurityOption -Mode Create -Generation '2' -HasSecurityOption $true -SecurityOption 'TrustedLaunch' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $trustedLaunch.SecurityOption | Should -Be 'TrustedLaunch'

        $off = Resolve-SecurityOption -Mode Create -Generation '2' -HasSecurityOption $false -HasEnableSecureBoot $true -SecureBootEnabled $false
        $off.SecurityOption | Should -Be 'None'
        $off.VerifySourceSecureBoot | Should -BeTrue

        $gen1TrustedLaunch = Resolve-SecurityOption -Mode Create -Generation '1' -HasSecurityOption $true -SecurityOption 'TrustedLaunch' -HasEnableSecureBoot $false -SecureBootEnabled $false
        $gen1TrustedLaunch.Gen2Required | Should -BeTrue
    }

    It 'EnableSecureBoot-RejectsTrustedLaunchOptOut' {
        # Rejected before the protected item lookup, so no service call is made.
        $err = $null
        try {
            Set-AzMigrateLocalServerReplication `
                -TargetObjectID 'protectedItem' `
                -TargetVMSecurityOption 'TrustedLaunch' `
                -EnableSecureBoot 'false'
        }
        catch {
            $err = $_
        }

        $err | Should -Not -BeNullOrEmpty
        $err.Exception.Message | Should -BeLike "*cannot be used with -TargetVMSecurityOption 'TrustedLaunch'*"
    }
}

# Requires a Gen 2 protected item in replication whose source has Secure Boot disabled; with Secure
# Boot on at the source the None case is blocked by the downgrade check before any request is sent.
Describe 'Set-AzMigrateLocalServerReplicationSecurityOptionLive' -Tag 'LiveOnly' {
    It 'ByIdSecurityOptionTrustedLaunch' {
        # The service returns null for securityOption on later GETs, so the outgoing update is the
        # only place a dropped or wrong assignment is visible.
        $script:capturedBody = $null
        $capture = {
            param($message, $eventListener, $next)
            if ($message.RequestUri.AbsoluteUri -match '/protectedItems/' -and
                $message.Method.Method -in 'PATCH', 'PUT') {
                $script:capturedBody = $message.Content.ReadAsStringAsync().Result
            }
            $next.SendAsync($message, $eventListener)
        }

        $job = Set-AzMigrateLocalServerReplication `
            -TargetObjectID $env.hciTvmProtectedItemId `
            -TargetVMSecurityOption 'TrustedLaunch' `
            -HttpPipelinePrepend $capture

        $job | Should -Not -BeNullOrEmpty
        $script:capturedBody | Should -Not -BeNullOrEmpty
        $script:capturedBody | Should -Match '"securityOption"\s*:\s*"TrustedLaunch"'
    }

    It 'ByIdSecurityOptionNone' {
        $script:capturedBody = $null
        $capture = {
            param($message, $eventListener, $next)
            if ($message.RequestUri.AbsoluteUri -match '/protectedItems/' -and
                $message.Method.Method -in 'PATCH', 'PUT') {
                $script:capturedBody = $message.Content.ReadAsStringAsync().Result
            }
            $next.SendAsync($message, $eventListener)
        }

        $job = Set-AzMigrateLocalServerReplication `
            -TargetObjectID $env.hciTvmProtectedItemId `
            -EnableSecureBoot 'false' `
            -HttpPipelinePrepend $capture

        $job | Should -Not -BeNullOrEmpty
        $script:capturedBody | Should -Not -BeNullOrEmpty
        $script:capturedBody | Should -Match '"securityOption"\s*:\s*"None"'
    }
}
