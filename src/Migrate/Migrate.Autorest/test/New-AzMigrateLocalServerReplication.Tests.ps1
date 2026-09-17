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
}
