if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppNetworkAppLink'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppNetworkAppLink.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppNetworkAppLink' {
    It 'CreateExpanded' {
        {
            $appLink = New-AzAppNetworkAppLink -Name $env.appLinkName -ResourceGroupName $env.resourceGroup -Location $env.location -EnableSystemAssignedIdentity
            $appLink.Name | Should -Be $env.appLinkName
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
