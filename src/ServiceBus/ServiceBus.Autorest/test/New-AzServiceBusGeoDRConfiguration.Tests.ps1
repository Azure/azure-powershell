if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusGeoDRConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusGeoDRConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusGeoDRConfiguration' {
    It 'CreateExpanded' -skip:$($env.secondaryLocation -eq '') {
        $drConfig = New-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace -PartnerNamespace $env.secondaryNamespaceResourceId
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.Name | Should -Be $env.alias
        $drConfig.PartnerNamespace | Should -Be $env.secondaryNamespaceResourceId
        $drConfig.Role | Should -Be "Primary"

        while($drConfig.ProvisioningState -ne "Succeeded"){
            $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
            Start-Sleep 10
        }

        $drConfig = Get-AzServiceBusGeoDRConfiguration -Name $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.secondaryNamespace
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.Name | Should -Be $env.alias
        $drConfig.PartnerNamespace | Should -Be $env.primaryNamespaceResourceId
        $drConfig.Role | Should -Be "Secondary"

        $namespaceAuthRules = Get-AzServiceBusAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace

        $drAuthRules = Get-AzServiceBusAuthorizationRule -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $drAuthRules.Count | Should -Be $namespaceAuthRules.Count

        $authRule = Get-AzServiceBusAuthorizationRule -Name RootManageSharedAccessKey -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $authRule.Name | Should -Be "RootManageSharedAccessKey"
        $authRule.ResourceGroupName | Should -Be $env.resourceGroup
        $authRule.Rights.Count | Should -Be 3

        $drKeys = Get-AzServiceBusKey -Name RootManageSharedAccessKey -AliasName $env.alias -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $namespaceKeys = Get-AzServiceBusKey -Name RootManageSharedAccessKey -ResourceGroupName $env.resourceGroup -NamespaceName $env.primaryNamespace
        $drKeys.PrimaryKey | Should -Be $namespaceKeys.PrimaryKey
        $drKeys.SecondaryKey | Should -Be $namespaceKeys.SecondaryKey
    }
}
