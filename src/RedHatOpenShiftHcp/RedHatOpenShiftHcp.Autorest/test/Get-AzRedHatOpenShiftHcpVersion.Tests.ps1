if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRedHatOpenShiftHcpVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedHatOpenShiftHcpVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRedHatOpenShiftHcpVersion' {
    # Custom cmdlet (C4): wraps the generated version list, adding -ControlPlane / -NodePool views and
    # CLI-parity filtering (enabled-only, semver-sorted) on the default list.

    It 'List (default, CLI parity: enabled-only, sorted)' {
        $versions = Get-AzRedHatOpenShiftHcpVersion -Location $env.Location
        $versions.Count | Should -BeGreaterOrEqual 1
        # default list hides disabled versions (enabled -ne $false)
        @($versions | Where-Object { $_.Enabled -eq $false }).Count | Should -Be 0
        # ascending by semver
        $names = @($versions | ForEach-Object { $_.Name })
        $expected = @($names | Sort-Object -Property @{ Expression = { [version]$_ } })
        ($names -join ',') | Should -Be ($expected -join ',')
    }

    It 'ControlPlane view returns distinct MAJOR.MINOR' {
        $cp = @(Get-AzRedHatOpenShiftHcpVersion -Location $env.Location -ControlPlane)
        $cp.Count | Should -BeGreaterOrEqual 1
        foreach ($v in $cp) { $v.Name | Should -Match '^\d+\.\d+$' }   # X.Y only, no patch
        # distinct
        ($cp.Name | Select-Object -Unique).Count | Should -Be $cp.Count
    }

    It 'NodePool view returns full X.Y.Z' {
        $np = @(Get-AzRedHatOpenShiftHcpVersion -Location $env.Location -NodePool)
        $np.Count | Should -BeGreaterOrEqual 1
        foreach ($v in $np) { $v.Name | Should -Match '^\d+\.\d+\.\d+' }   # has a patch component
    }

    It 'ControlPlane and NodePool are mutually exclusive' {
        { Get-AzRedHatOpenShiftHcpVersion -Location $env.Location -ControlPlane -NodePool } |
            Should -Throw 'cannot be used together'
    }

    It 'Single -Name lookup is returned as-is' {
        $np = @(Get-AzRedHatOpenShiftHcpVersion -Location $env.Location -NodePool)
        $one = Get-AzRedHatOpenShiftHcpVersion -Location $env.Location -Name $np[0].Name
        $one.Name | Should -Be $np[0].Name
    }
}
