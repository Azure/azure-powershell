if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCommvaultRoleMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCommvaultRoleMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCommvaultRoleMapping' {
    It 'Get' {
        $roleMapping = Get-AzCommvaultRoleMapping -SubscriptionId $env.SubscriptionId -CloudAccountName $env.CloudAccountName -ResourceGroupName $env.ResourceGroupName
        $roleMapping.Name | Should -Be 'default'
        $roleMapping.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'GetViaIdentity' {
        $roleMapping = Get-AzCommvaultRoleMapping -SubscriptionId $env.SubscriptionId -CloudAccountName $env.CloudAccountName -ResourceGroupName $env.ResourceGroupName
        $byIdentity = Get-AzCommvaultRoleMapping -InputObject @{ Id = $roleMapping.Id }
        $byIdentity.Name | Should -Be 'default'
        $byIdentity.Id | Should -Be $roleMapping.Id
    }
}
