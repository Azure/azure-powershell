if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function assertNamespaceUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbNamespace]$expectedNamespace,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbNamespace]$namespace)

    $expectedNamespace.SkuName | Should -Be $namespace.SkuName
    $expectedNamespace.SkuCapacity | Should -Be $namespace.SkuCapacity
    $expectedNamespace.Name | Should -Be $namespace.Name
    $expectedNamespace.MinimumTlsVersion | Should -Be $namespace.MinimumTlsVersion
    $expectedNamespace.Location | Should -Be $namespace.Location
    $expectedNamespace.ZoneRedundant | Should -Be $namespace.ZoneRedundant
    $expectedNamespace.DisableLocalAuth | Should -Be $namespace.DisableLocalAuth
    $expectedNamespace.Tag.Count | Should -Be $namespace.Tag.Count
}
Describe 'Set-AzServiceBusNamespaceV2' {
    It 'SetExpanded' {
        $a = New-AzServiceBusUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec5 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaulturi $env.keyVaulturi -UserAssignedIdentity $env.msi1

        $serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $serviceBusNamespace.KeyVaultProperty += $ec5

        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
        $serviceBusNamespace.IdentityType | Should -Be "UserAssigned"
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 3
        $serviceBusNamespace.Name | Should -Be $env.namespaceV5

        # Add KeyVaultProperty to a namespace with System Assigned
        $ec1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaulturi
        $ec2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaulturi
        $ec3 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi

        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $ec1,$ec2,$ec3
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 3
        $serviceBusNamespace.IdentityType | Should -Be "SystemAssigned"

        # Remove KeyVaultProperty from namespace with SystemAssigned identity.
        $serviceBusNamespace.KeyVaultProperty = $serviceBusNamespace.KeyVaultProperty[0,2]
        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.IdentityType | Should -Be "SystemAssigned"

        # Add UserAssigned Identity to above namespace to test for SystemAssigned and UserAssigned
        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentity $a
        $serviceBusNamespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2
        
        # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2

        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -IdentityType None -UserAssignedIdentity:$null
        $serviceBusNamespace.IdentityType | Should -Be $null
    }

    It 'SetExpandedNamespace' {
        $expectedNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -SkuCapacity 12
        $expectedNamespace.SkuCapacity | Should -Be 12
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -MinimumTlsVersion 1.0
        $expectedNamespace.MinimumTlsVersion | Should -Be '1.0'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -MinimumTlsVersion 1.2
        $expectedNamespace.MinimumTlsVersion = '1.2'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -DisableLocalAuth:$false
        $expectedNamespace.DisableLocalAuth = $false
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -DisableLocalAuth
        $expectedNamespace.DisableLocalAuth = $true
        assertNamespaceUpdates $expectedNamespace $namespace
    }
}
