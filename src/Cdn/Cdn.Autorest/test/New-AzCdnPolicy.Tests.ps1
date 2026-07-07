if(($null -eq $TestName) -or ($TestName -contains 'New-AzCdnPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCdnPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCdnPolicy' {
    BeforeAll {
        $script:policyName = 'pscdnpolicynew'
        Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
    }

    AfterAll {
        if ($script:policyName) {
            Remove-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -ErrorAction SilentlyContinue
        }
    }

    It 'CreateExpanded' {
        $policy = New-AzCdnPolicy -ResourceGroupName $env.ResourceGroupName -Name $script:policyName -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention
        $policy.Name | Should -Be $script:policyName
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
