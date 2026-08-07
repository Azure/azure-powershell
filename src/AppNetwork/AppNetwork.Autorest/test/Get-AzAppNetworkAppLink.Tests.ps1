if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppNetworkAppLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppNetworkAppLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppNetworkAppLink' {
    It 'List1' {
        # List by subscription
        { Get-AzAppNetworkAppLink } | Should -Not -Throw
    }

    It 'Get' {
        {
            $appLink = Get-AzAppNetworkAppLink -Name $env.appLinkName -ResourceGroupName $env.resourceGroup
            $appLink.Name | Should -Be $env.appLinkName
        } | Should -Not -Throw
    }

    It 'List' {
        # List by resource group
        {
            $appLinks = Get-AzAppNetworkAppLink -ResourceGroupName $env.resourceGroup
            $appLinks.Name | Should -Contain $env.appLinkName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
