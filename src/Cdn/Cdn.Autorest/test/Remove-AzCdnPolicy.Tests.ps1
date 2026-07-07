if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzCdnPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCdnPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzCdnPolicy' {
    BeforeAll {
        $script:policyName = 'pscdnpolicyremove'
        $script:policyIdentityName = 'pscdnpolicyremoveid'
        Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyIdentityName -ErrorAction SilentlyContinue
        New-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention | Out-Null
        New-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyIdentityName -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention | Out-Null
    }

    AfterAll {
        if ($script:policyName) {
            Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        }
        if ($script:policyIdentityName) {
            Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyIdentityName -ErrorAction SilentlyContinue
        }
    }

    It 'Delete' {
        $result = Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -PassThru
        $result | Should -BeTrue
        { Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $policy = Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyIdentityName
        $result = Remove-AzCdnPolicy -InputObject $policy -PassThru
        $result | Should -BeTrue
        { Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyIdentityName -ErrorAction Stop } | Should -Throw
    }
}
