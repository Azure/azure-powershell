if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppNetwork' {
    It 'CreateExpanded' {
        {
            $appLink = New-AzAppNetwork -Name $env.appLinkNameForCreate -ResourceGroupName $env.resourceGroup -Location $env.location -EnableSystemAssignedIdentity
            $appLink.Name | Should -Be $env.appLinkNameForCreate
            $appLink.Location | Should -Be $env.location
            $appLink.IdentityType | Should -Be 'SystemAssigned'
            $appLink.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
