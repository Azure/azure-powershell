if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateLocalServerReplication' {
    # See Test-AzMigrateLocalEndToEnd.Tests.ps1 for end to end tests.
    It 'ByIdDefaultUser' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByIdPowerUser' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'MigrateAsArcVM-ParameterExists' {
        $cmd = Get-Command New-AzMigrateLocalServerReplication
        $param = $cmd.Parameters['MigrateAsArcVM']
        $param | Should -Not -BeNullOrEmpty
        $param.ParameterType.Name | Should -Be 'String'
    }

    It 'MigrateAsArcVM-NotOnSetCmdlet' {
        $cmd = Get-Command Set-AzMigrateLocalServerReplication
        $cmd.Parameters.Keys | Should -Not -Contain 'MigrateAsArcVM'
    }

    It 'TargetVMSecurityOption-ParameterExists' {
        foreach ($name in 'New-AzMigrateLocalServerReplication', 'Set-AzMigrateLocalServerReplication') {
            foreach ($paramName in 'TargetVMSecurityOption', 'EnableSecureBoot') {
                $param = (Get-Command $name).Parameters[$paramName]
                $param | Should -Not -BeNullOrEmpty
                $param.ParameterType.Name | Should -Be 'String'
            }
        }
    }

    It 'TargetVMSecurityOption-OffersOnlySupportedValues' {
        # 'EnablevTPM' and 'SecureBootEnabled' are wire values, not user-facing security types.
        foreach ($name in 'New-AzMigrateLocalServerReplication', 'Set-AzMigrateLocalServerReplication') {
            $completer = (Get-Command $name).Parameters['TargetVMSecurityOption'].Attributes |
                Where-Object { $_ -is [System.Management.Automation.ArgumentCompleterAttribute] }
            $values = & $completer.ScriptBlock
            $values | Should -Be @('Standard', 'TrustedLaunch')
            $values | Should -Not -Contain 'EnablevTPM'
        }
    }

    It 'TargetVMSecurityOption-RejectsUnsupportedValue' {
        # Rejected while binding the inner cmdlet, so no service call is made.
        $err = $null
        try {
            New-AzMigrateLocalServerReplication `
                -MachineId 'machine' `
                -TargetStoragePathId 'storagePath' `
                -TargetResourceGroupId 'resourceGroup' `
                -TargetVMName 'vm' `
                -SourceApplianceName 'source' `
                -TargetApplianceName 'target' `
                -TargetVirtualSwitchId 'switch' `
                -OSDiskID 'osDisk' `
                -TargetVMSecurityOption 'EnablevTPM' `
                -ErrorAction Stop
        }
        catch {
            $err = $_
        }

        $err | Should -Not -BeNullOrEmpty
        $err.Exception.Message | Should -BeLike '*does not belong to the set*'
    }

    It 'EnableSecureBoot-RejectsTrustedLaunchOptOut' {
        $err = $null
        try {
            New-AzMigrateLocalServerReplication `
                -MachineId 'machine' `
                -TargetStoragePathId 'storagePath' `
                -TargetResourceGroupId 'resourceGroup' `
                -TargetVMName 'vm' `
                -SourceApplianceName 'source' `
                -TargetApplianceName 'target' `
                -TargetVirtualSwitchId 'switch' `
                -OSDiskID 'osDisk' `
                -TargetVMSecurityOption 'TrustedLaunch' `
                -EnableSecureBoot 'false' `
                -ErrorAction Stop
        }
        catch {
            $err = $_
        }

        $err | Should -Not -BeNullOrEmpty
        $err.Exception.Message | Should -BeLike '*Trusted Launch requires Secure Boot*'
    }

    # The custom helpers live in a nested module that Get-Module and InModuleScope cannot reach, so
    # go through the root module and shadow the REST call inside that scope.
    function Invoke-SecureBootLookup {
        param([int]$StatusCode = 200, [string]$Content = '{}', [switch]$FailTransport)

        $custom = (Get-Module Az.Migrate).NestedModules |
            Where-Object { $_.Name -eq 'Az.Migrate.custom' }

        & $custom {
            param($statusCode, $content, $failTransport)

            function Invoke-AzRestMethod {
                param($Path, $Method)
                $script:capturedPath = $Path
                if ($failTransport) { throw 'transport failure' }
                [PSCustomObject]@{ StatusCode = $statusCode; Content = $content }
            }

            try {
                $state = Get-AzMigrateSourceSecureBootState -MachineId '/machines/m'
                [PSCustomObject]@{
                    ApiVersion = $ApiVersions.OffAzureMachineRead
                    Path       = $script:capturedPath
                    State      = $state
                    IsBool     = $state -is [bool]
                }
            }
            finally {
                Remove-Item Function:\Invoke-AzRestMethod -ErrorAction SilentlyContinue
                Remove-Variable -Name capturedPath -Scope Script -ErrorAction SilentlyContinue
            }
        } $StatusCode $Content $FailTransport.IsPresent
    }

    It 'SecureBootLookup-ReadsStateFromNewerApiVersion' {
        $on = Invoke-SecureBootLookup -Content '{"properties":{"secureBootEnabled":true}}'
        $on.ApiVersion | Should -Be '2024-12-01-preview'
        $on.Path | Should -Be '/machines/m?api-version=2024-12-01-preview'
        ($on.IsBool -and $on.State) | Should -BeTrue

        $off = Invoke-SecureBootLookup -Content '{"properties":{"secureBootEnabled":false}}'
        ($off.IsBool -and -not $off.State) | Should -BeTrue
    }

    It 'SecureBootLookup-FailsOpenWhenStateUnknown' {
        # Older appliances, and clouds still serving the GA contract, omit the field entirely.
        $absent = Invoke-SecureBootLookup -Content '{"properties":{"displayName":"vm"}}'
        $null -eq $absent.State | Should -BeTrue

        $notFound = Invoke-SecureBootLookup -StatusCode 404 -Content '{}'
        $null -eq $notFound.State | Should -BeTrue

        $broken = Invoke-SecureBootLookup -FailTransport
        $null -eq $broken.State | Should -BeTrue
    }
}
