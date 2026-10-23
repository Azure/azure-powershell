if(($null -eq $TestName) -or ($TestName -contains 'New-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzCloudHsm' {
    It 'CreateExpanded' {
        $cloudHsm = New-AzCloudHsm -SubscriptionId $env.SubscriptionId -Name $env.cloudHsmName -ResourceGroupName $env.rgName -Location $env.location -Sku Standard_B1 -UserAssignedIdentity $env.userAssignedIdentityId
        $cloudHsm.name | Should -Be $env.cloudHsmName
        $cloudHsm.location | Should -Be $env.location
        $cloudHsm.ProvisioningState | Should -Be "Succeeded"
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
