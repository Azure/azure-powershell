if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppNetwork' {
    It 'List1' {
        # List by subscription
        { Get-AzAppNetwork } | Should -Not -Throw
    }

    It 'Get' {
        {
            $appLink = Get-AzAppNetwork -Name $env.appLinkName -ResourceGroupName $env.resourceGroup
            $appLink.Name | Should -Be $env.appLinkName
        } | Should -Not -Throw
    }

    It 'List' {
        # List by resource group
        {
            $appLinks = Get-AzAppNetwork -ResourceGroupName $env.resourceGroup
            $appLinks.Name | Should -Contain $env.appLinkName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
