if(($null -eq $TestName) -or ($TestName -contains 'New-AzAlbSecurityPolicyWaf'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAlbSecurityPolicyWaf.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAlbSecurityPolicyWaf' {
    It 'CreateExpanded' {
        {
            $spName = $env.albWafSecurityPolicyName+"new"
            $albSecurityPolicy = New-AzAlbSecurityPolicyWaf -Name $spName -AlbName $env.albName -ResourceGroupName $env.resourceGroup -Location $env.Region -wafPolicyId $env.extraWafPolicyId
            $albSecurityPolicy.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
}
