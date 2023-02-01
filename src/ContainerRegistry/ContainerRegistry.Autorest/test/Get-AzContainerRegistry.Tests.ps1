if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistry'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistry.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistry' {
    It 'List' {
        {Get-AzContainerRegistry -SubscriptionId $env.SubscriptionId} | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzContainerRegistry -Name $env.rstr1 -ResourceGroupName $env.ResourceGroup } | Should -Not -Throw
    }

    It 'List1'{
        { Get-AzContainerRegistry -ResourceGroupName $env.ResourceGroup  } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
