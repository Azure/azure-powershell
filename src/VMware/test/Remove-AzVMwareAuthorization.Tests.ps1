if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzVMwareAuthorization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareAuthorization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzVMwareAuthorization' {
    It 'Delete' {
        {
            Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $Id3 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup3)/providers/Microsoft.AVS/privateClouds/$($env.privateCloudName3)/authorizations/$($env.rstr4)"
            Remove-AzVMwareAuthorization -InputObject $Id3
        } | Should -Not -Throw
    }
}
