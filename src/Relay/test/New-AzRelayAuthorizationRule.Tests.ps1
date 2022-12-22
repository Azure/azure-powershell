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
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }

    It 'CreateExpanded1' {
        {
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -HybridConnection $env.hybridConnectionName02 -Name $env.authRuleName01 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -HybridConnection $env.hybridConnectionName02
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -HybridConnection $env.hybridConnectionName02 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -HybridConnection $env.hybridConnectionName02 -Name $env.authRuleName01

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -HybridConnection $env.hybridConnectionName02 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -HybridConnection $env.hybridConnectionName02 -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }

    It 'CreateExpanded2' {
        {
            New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -WcfRelay $env.wcfRelayName02 -Name $env.authRuleName01 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -WcfRelay $env.wcfRelayName02
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -Name $env.authRuleName01 -WcfRelay $env.wcfRelayName02 -Rights 'Listen','Send'
            Remove-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -WcfRelay $env.wcfRelayName02 -Name $env.authRuleName01

            $authRule = New-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -WcfRelay $env.wcfRelayName02 -Name $env.authRuleName02 -Rights 'Listen'
            Get-AzRelayAuthorizationRule -InputObject $authRule
            $authRule.Rights += 'Send'
            Set-AzRelayAuthorizationRule -ResourceGroupName $env.resourceGroupName-Namespace $env.namespaceName -WcfRelay $env.wcfRelayName02 -Name $env.authRuleName02 -InputObject $authRule
            Remove-AzRelayAuthorizationRule -InputObject $authRule
        } | Should -Not -Throw
    }
}
