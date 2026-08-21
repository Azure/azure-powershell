if(($null -eq $TestName) -or ($TestName -contains 'New-AzMissionCommunity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMissionCommunity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMissionCommunity' {
    # NOTE: Skipped until a Recording.json is captured against a live Microsoft.Mission preview subscription.
    It 'CreateExpanded' -skip {
        {
            $community = New-AzMissionCommunity -Name $env.communityName -ResourceGroupName $env.resourceGroup -Location $env.location -AddressSpace '10.0.0.0/16'
            $community.Name | Should -Be $env.communityName
            $community.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
