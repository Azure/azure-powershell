if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMissionCommunity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMissionCommunity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMissionCommunity' {
    # NOTE: Skipped until a Recording.json is captured against a live Microsoft.Mission preview subscription.
    It 'Get' -skip {
        {
            $community = Get-AzMissionCommunity -Name $env.communityName -ResourceGroupName $env.resourceGroup
            $community.Name | Should -Be $env.communityName
        } | Should -Not -Throw
    }

    It 'List1' -skip {
        {
            $communities = Get-AzMissionCommunity -ResourceGroupName $env.resourceGroup
            $communities | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'List' -skip {
        {
            $communities = Get-AzMissionCommunity
            $communities | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
