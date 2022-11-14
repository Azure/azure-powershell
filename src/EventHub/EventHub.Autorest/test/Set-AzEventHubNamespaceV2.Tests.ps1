if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function assertNamespaceUpdates{
    param([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEhNamespace]$expectedNamespace,[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IEhNamespace]$namespace)

    Assert-AreEqual $expectedNamespace.SkuName $namespace.SkuName
    Assert-AreEqual $expectedNamespace.SkuCapacity $namespace.SkuCapacity
    Assert-AreEqual $expectedNamespace.Name $namespace.Name
    Assert-AreEqual $expectedNamespace.MaximumThroughputUnits $namespace.MaximumThroughputUnits
    Assert-AreEqual $expectedNamespace.MinimumTlsVersion $namespace.MinimumTlsVersion
    Assert-AreEqual $expectedNamespace.Location $namespace.Location
    Assert-AreEqual $expectedNamespace.EnableAutoInflate $namespace.EnableAutoInflate
    Assert-AreEqual $expectedNamespace.KafkaEnabled $namespace.KafkaEnabled
    Assert-AreEqual $expectedNamespace.ZoneRedundant $namespace.ZoneRedundant
    Assert-AreEqual $expectedNamespace.DisableLocalAuth $namespace.DisableLocalAuth
    Assert-AreEqual $expectedNamespace.Tags.Count $namespace.Tags.Count
}

Describe 'Set-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        # Add Encryption Config to NamespaceV5 which was created in New-AzEventHubNamespaceV2
        $a = New-AzEventHubUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi -UserAssignedIdentity $env.msi1

        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace += $ec1

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $eventhubNamespace.IdentityType | Should -Be "UserAssigned"
        $eventhubNamespace.IdentityId.Count | Should -Be 2
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 3
        $eventhubNamespace.Name | Should -Be $env.namespaceV5

        # Add KeyVaultProperty to a namespace with System Assigned
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaulturi
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaulturi

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned"

        # Remove KeyVaultProperty from namespace with SystemAssigned identity.
        $eventhubNamespace.KeyVaultProperty = $namespace.KeyVaultProperty | Where-Object { $_ –ne $namespace.KeyVaultProperty[0] }
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 1
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned"

        # Add UserAssigned Identity to above namespace to test for SystemAssigned and UserAssigned
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -IdentityType "SystemAssigned, UserAssigned"
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 1
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        
        # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $env.msi1, $env.msi2
        $eventHubNamespace.UserAssignedIdentity.Count | Should -Be 2

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -IdentityType None -UserAssignedIdentity:$null
        $eventhubNamespace.IdentityType | Should -Be $null
    }
    It 'SetViaIdentityExpanded' {
        $expectedNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -EnableAutoInflate:$false -MaximumThroughputUnits 0
        $expectedNamespace.IsAutoInflateEnabled = $false
        $expectedNamespace.MaximumThroughputUnits = 0
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -EnableAutoInflate:$true -MaximumThroughputUnits 18
        $expectedNamespace.IsAutoInflateEnabled = $true
        $expectedNamespace.MaximumThroughputUnits = 18
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -SkuCapacity 12
        $expectedNamespace.Sku.Capacity = 12
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -MaximumThroughputUnits 25
        $expectedNamespace.MaximumThroughputUnits = 25
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -MinimumTlsVersion 1.0
        $expectedNamespace.MinimumTlsVersion = '1.0'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -MinimumTlsVersion 1.2
        $expectedNamespace.MinimumTlsVersion = '1.2'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -DisableLocalAuth:$false
        $expectedNamespace.DisableLocalAuth = $false
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespace -InputObject $expectedNamespace -DisableLocalAuth
        $expectedNamespace.DisableLocalAuth = $true
        assertNamespaceUpdates $expectedNamespace $namespace
    }
}
