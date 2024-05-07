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
    It 'CreateExpanded' {
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location $env.location
        $serviceBusNamespace.Name | Should -Be $env.namespaceV2
        $serviceBusNamespace.SkuName | Should -Be Standard
        $serviceBusNamespace.Location.Replace(" ", "").ToLower() | Should -Be $env.location

        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3 -SkuName Standard -Location $env.location -Tag @{k1='v1'; k2='v2'} -DisableLocalAuth -MinimumTlsVersion 1.1 
        $serviceBusNamespace.Name | Should -Be $env.namespaceV3
        $serviceBusNamespace.SkuName | Should -Be Standard
        $serviceBusNamespace.SkuTier | Should -Be Standard
        $serviceBusNamespace.MinimumTlsVersion | Should -Be '1.1'
        $serviceBusNamespace.Location.Replace(" ", "").ToLower() | Should -Be $env.location
        $serviceBusNamespace.DisableLocalAuth | Should -Be $true
        $serviceBusNamespace.Tag.Count | should -Be 2

        if ($env:usePartitionedNamespace) {
            $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location $env.location -IdentityType SystemAssigned -ZoneRedundant:$env.useZoneRedundancy -PremiumMessagingPartition 2 -SkuCapacity 2
            $serviceBusNamespace.PremiumMessagingPartition | Should -Be 2
        } else {
            $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location $env.location -IdentityType SystemAssigned -ZoneRedundant:$env.useZoneRedundancy -SkuCapacity 2
        }
        $serviceBusNamespace.Name | Should -Be $env.namespaceV4
        $serviceBusNamespace.IdentityType | Should -Be SystemAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.SkuTier | Should -Be Premium
        $serviceBusNamespace.SkuCapacity | Should -Be 2
        $serviceBusNamespace.Location.Replace(" ", "").ToLower() | Should -Be $env.location
        $serviceBusNamespace.ZoneRedundant | Should be $env.useZoneRedundancy

        # Create namespace with UserAssigned Encryption Enabled
        $ec1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -SkuName Premium -Location $env.location -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1,$env.msi2 -KeyVaultProperty $ec1,$ec2
        $serviceBusNamespace.IdentityType | Should -Be UserAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.SkuTier | Should -Be Premium
        $serviceBusNamespace.Location.Replace(" ", "").ToLower() | Should -Be $env.location
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2
        $serviceBusNamespace.RequireInfrastructureEncryption | Should -Be $false
        $serviceBusNamespace.ZoneRedundant | Should be $false

        # Create namespace with UserAssigned Encryption Enabled and RequireInfrastructureEncryption true
        $ec1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $ec2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaultUri -UserAssignedIdentity $env.msi1
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV9 -SkuName Premium -Location $env.location -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1,$env.msi2 -KeyVaultProperty $ec1,$ec2 -RequireInfrastructureEncryption
        $serviceBusNamespace.IdentityType | Should -Be UserAssigned
        $serviceBusNamespace.SkuName | Should -Be Premium
        $serviceBusNamespace.SkuTier | Should -Be Premium
        $serviceBusNamespace.Location.Replace(" ", "").ToLower() | Should -Be $env.location
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2
        $serviceBusNamespace.RequireInfrastructureEncryption | Should -Be $true

    }
}
