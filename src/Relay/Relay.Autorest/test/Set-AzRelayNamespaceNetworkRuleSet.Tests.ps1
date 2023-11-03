if(($null -eq $TestName) -or ($TestName -contains 'Set-AzRelayNamespaceNetworkRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzRelayNamespaceNetworkRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzRelayNamespaceNetworkRuleSet' {
    It 'UpdateExpanded' {
        {
            $rules = @()
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
            Set-AzRelayNamespaceNetworkRuleSet -ResourceGroupName $env.resourceGroupName  -NamespaceName $env.namespaceName01  -DefaultAction 'Deny'  -IPRule $rules
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $rules = @()
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
            $rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
            $GetRuleSet = Get-AzRelayNamespaceNetworkRuleSet  -ResourceGroupName $env.resourceGroupName  -NamespaceName $env.namespaceName01
            Set-AzRelayNamespaceNetworkRuleSet -InputObject $GetRuleSet  -DefaultAction 'Deny'  -IPRule $rules -PublicNetworkAccess 'Enabled'
        } | Should -Not -Throw
    }
}
