if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelayAuthorizationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelayAuthorizationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelayAuthorizationRule' {
    It 'RelayNamespace' {
        {
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName01 -Name $env.authRuleName02

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }

    It 'HybridConnection' {
        {
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -HybridConnection $env.hybridConnectionName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -HybridConnection $env.hybridConnectionName01
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -HybridConnection $env.hybridConnectionName01 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -HybridConnection $env.hybridConnectionName01 -Name $env.authRuleName02

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -HybridConnection $env.hybridConnectionName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -HybridConnection $env.hybridConnectionName01 -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }

    It 'WcfRelay' {
        {
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -WcfRelay $env.wcfRelayName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -WcfRelay $env.wcfRelayName01
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.authRuleName02 -WcfRelay $env.wcfRelayName01 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -WcfRelay $env.wcfRelayName01 -Name $env.authRuleName02

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -WcfRelay $env.wcfRelayName01 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName01 -WcfRelay $env.wcfRelayName01 -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }
}
