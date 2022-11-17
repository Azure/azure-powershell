if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceBusNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceBusNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceBusNamespaceV2' {
    It 'CreateExpanded' -skip {
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        $serviceBusNamespace.Name | Should -Be $env.namespaceV2
        $serviceBusNamespace.SkuName | Should -Be Standard

        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3 -SkuCapacity 10 -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -DisableLocalAuth -MinimumTlsVersion 1.1
        $serviceBusNamespace.Name | Should -Be $env.namespaceV3
        $serviceBusNamespace.SkuCapacity | Should -Be 10
        $serviceBusNamespace.SkuName | Should -Be Standard
        $serviceBusNamespace.SkuTier | Should -Be Standard
        $serviceBusNamespace.MinimumTlsVersion | Should -Be '1.1'
        $serviceBusNamespace.Location | Should -Be "South Central Us"
        $serviceBusNamespace.DisableLocalAuth | Should -Be $true

        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned
        $serviceBusNamespace.Name | Should -Be $env.namespaceV4
        $serviceBusNamespace.IdentityType | Should -Be SystemAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.SkuTier | Should -Be Premium
        $serviceBusNamespace.Location | Should -Be "East Us"

        # Create namespace with UserAssigned Encryption Enabled
        $a = New-AzServiceBusUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a -KeyVaultProperty $ec1,$ec2
        $serviceBusNamespace.IdentityType | Should -Be UserAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.SkuTier | Should -Be Premium
        $serviceBusNamespace.Location | Should -Be "North Europe"
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2

        $ec3 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $serviceBusNamespace.KeyVaultProperty += $ec3
        $serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $serviceBusNamespace.Name | Should -Be $env.namespaceV5
        $serviceBusNamespace.IdentityType | Should -Be UserAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 3
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2

    }
}
