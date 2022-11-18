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

    $expectedNamespace.SkuName | Should -Be $namespace.SkuName
    $expectedNamespace.SkuCapacity | Should -Be $namespace.SkuCapacity
    $expectedNamespace.Name | Should -Be $namespace.Name
    $expectedNamespace.MaximumThroughputUnits | Should -Be $namespace.MaximumThroughputUnits
    $expectedNamespace.MinimumTlsVersion | Should -Be $namespace.MinimumTlsVersion
    $expectedNamespace.Location | Should -Be $namespace.Location
    $expectedNamespace.EnableAutoInflate | Should -Be $namespace.EnableAutoInflate
    $expectedNamespace.KafkaEnabled | Should -Be $namespace.KafkaEnabled
    $expectedNamespace.ZoneRedundant | Should -Be $namespace.ZoneRedundant
    $expectedNamespace.DisableLocalAuth | Should -Be $namespace.DisableLocalAuth
    $expectedNamespace.Tag.Count | Should -Be $namespace.Tag.Count
}

Describe 'Set-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        # Add Encryption Config to NamespaceV5 which was created in New-AzEventHubNamespaceV2
        $a = New-AzEventHubUserAssignedIdentityObject -IdentityId $env.msi1, $env.msi2
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi -UserAssignedIdentity $env.msi1

        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace.KeyVaultProperty += $ec1

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $eventhubNamespace.IdentityType | Should -Be "UserAssigned"
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 3
        $eventhubNamespace.Name | Should -Be $env.namespaceV5

        # Add KeyVaultProperty to a namespace with System Assigned
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaulturi
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaulturi

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned"

        # Add KeyVaultProperty to a namespace with System Assigned identity
        $ec3 = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi
        $eventHubNamespace.KeyVaultProperty += $ec3
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $eventHubNamespace.KeyVaultProperty.Count | Should -Be 3

        # Remove KeyVaultProperty from namespace with SystemAssigned identity.
        $eventhubNamespace.KeyVaultProperty = $eventHubNamespace.KeyVaultProperty[0,2]
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned"

        # Add UserAssigned Identity to above namespace to test for SystemAssigned and UserAssigned

        $identityHashTable = New-AzEventHubUserAssignedIdentityObject -IdentityId $env.msi1
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentity $identityHashTable
        $eventhubNamespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be "SystemAssigned, UserAssigned"
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 1
        
        # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $identityHashTable
        $eventHubNamespace.UserAssignedIdentity.Count | Should -Be 2

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -IdentityType None -UserAssignedIdentity:$null
        $eventhubNamespace.IdentityType | Should -Be $null
    }
    It 'SetViaIdentityExpanded' {
        $expectedNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -EnableAutoInflate:$false -MaximumThroughputUnits 0
        $expectedNamespace.EnableAutoInflate = $false
        $expectedNamespace.MaximumThroughputUnits = 0
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -EnableAutoInflate:$true -MaximumThroughputUnits 18
        $expectedNamespace.EnableAutoInflate = $true
        $expectedNamespace.MaximumThroughputUnits = 18
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -SkuCapacity 12
        $expectedNamespace.SkuCapacity = 12
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -MaximumThroughputUnits 25
        $expectedNamespace.MaximumThroughputUnits = 25
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -MinimumTlsVersion 1.0
        $expectedNamespace.MinimumTlsVersion = '1.0'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -MinimumTlsVersion 1.2
        $expectedNamespace.MinimumTlsVersion = '1.2'
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -DisableLocalAuth:$false
        $expectedNamespace.DisableLocalAuth = $false
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -DisableLocalAuth
        $expectedNamespace.DisableLocalAuth = $true
        assertNamespaceUpdates $expectedNamespace $namespace
    }
}
