if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesReplicationPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesReplicationPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesReplicationPolicy' {
    It 'List' {
        $policies = Get-AzRecoveryServicesReplicationPolicy -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName
        $value = 0
        $policies.Count | Should Not BeNullOrEmpty
    }

    It 'Get'  {
        $policy = Get-AzRecoveryServicesReplicationPolicy -PolicyName $env.asrPolicyName -ResourceGroupName $env.asrResourceGroup -ResourceName $env.asrResourceName
        $policy.Name | Should -Be $env.asrPolicyName
    }
}
