if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCdnPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCdnPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCdnPolicy' {
    BeforeAll {
        $script:policyName = 'pscdnpolicyupdate'
        Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        New-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention | Out-Null
    }

    AfterAll {
        if ($script:policyName) {
            Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        }
    }

    It 'UpdateExpanded' {
        $policy = Update-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -Tag @{ purpose = 'update' }
        $policy.Name | Should -Be $script:policyName
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        $policy = Get-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName
        $updated = Update-AzCdnPolicy -InputObject $policy -Tag @{ purpose = 'identity' }
        $updated.Name | Should -Be $script:policyName
    }
}
