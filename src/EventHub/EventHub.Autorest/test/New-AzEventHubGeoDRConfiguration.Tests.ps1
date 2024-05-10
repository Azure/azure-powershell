if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubGeoDRConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubGeoDRConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubGeoDRConfiguration' {
    It 'CreateExpanded' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = New-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.Name | Should -Be $env.alias
        $drConfig.PartnerNamespace | Should -Be $env.secondaryNamespaceResourceId
        $drConfig.Role | Should -Be "Primary"

        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }

        $drConfig = Get-AzEventHubGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.Name | Should -Be $env.alias
        $drConfig.PartnerNamespace | Should -Be $env.primaryNamespaceResourceId
        $drConfig.Role | Should -Be "Secondary"

        $namespaceAuthRules = Get-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace

        $drAuthRules = Get-AzEventHubAuthorizationRule -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $drAuthRules.Count | Should -Be $namespaceAuthRules.Count

        $authRule = Get-AzEventHubAuthorizationRule -Name RootManageSharedAccessKey -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $authRule.Name | Should -Be "RootManageSharedAccessKey"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $drKeys = Get-AzEventHubKey -Name RootManageSharedAccessKey -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $namespaceKeys = Get-AzEventHubKey -Name RootManageSharedAccessKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $drKeys.PrimaryKey | Should -Be $namespaceKeys.PrimaryKey
        $drKeys.SecondaryKey | Should -Be $namespaceKeys.SecondaryKey
    }
}
