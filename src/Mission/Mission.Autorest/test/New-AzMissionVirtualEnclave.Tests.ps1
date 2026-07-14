if(($null -eq $TestName) -or ($TestName -contains 'New-AzMissionVirtualEnclave'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMissionVirtualEnclave.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMissionVirtualEnclave' {
    # NOTE: Skipped until a Recording.json is captured against a live Microsoft.Mission preview subscription.
    It 'CreateExpanded' -skip {
        {
            $enclave = New-AzMissionVirtualEnclave -Name $env.enclaveName -ResourceGroupName $env.resourceGroup -Location $env.location -CommunityResourceId $env.communityResourceId -EnclaveVirtualNetworkName 'enclave-vnet' -EnclaveVirtualNetworkCustomCidrRange '10.0.1.0/24'
            $enclave.Name | Should -Be $env.enclaveName
            $enclave.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
