if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnPolicy' {
    BeforeAll {
        $script:policyName = 'pscdnpolicyget'
        Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        New-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention | Out-Null
    }

    AfterAll {
        if ($script:policyName) {
            Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        }
    }

    It 'List' {
        $policies = Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName
        $policies.Name | Should -Contain $script:policyName
    }

    It 'Get' {
        $policy = Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName
        $policy.Name | Should -Be $script:policyName
    }

    It 'GetViaIdentity' {
        $policy = Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName
        $policyByIdentity = Get-AzCdnPolicy -InputObject $policy
        $policyByIdentity.Name | Should -Be $script:policyName
    }
}
