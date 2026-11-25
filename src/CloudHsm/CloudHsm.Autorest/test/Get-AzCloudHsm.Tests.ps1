if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCloudHsm' {
    It 'List1' {
        $cloudHsm = Get-AzCloudHsm -SubscriptionId $env.SubscriptionId
        $cloudHsm.name -contains $env.cloudHsmName | Should -Be $true
        $cloudHsm.location -contains $env.location | Should -Be $true
    }

    It 'Get2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $cloudHsm = Get-AzCloudHsm -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.rgName
        $cloudHsm.name -contains $env.cloudHsmName | Should -Be $true
        $cloudHsm.location -contains $env.location | Should -Be $true
    }

    It 'List' {
        $cloudHsm = Get-AzCloudHsm -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.rgName -Name $env.cloudHsmName
        $cloudHsm.name | Should -Be $env.cloudHsmName
        $cloudHsm.location | Should -Be $env.location
    }

    It 'GetViaIdentityCloudHsmCluster1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityCloudHsmCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity2' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
