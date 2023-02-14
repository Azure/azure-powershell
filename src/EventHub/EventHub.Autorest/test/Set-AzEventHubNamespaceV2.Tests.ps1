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
    param([Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEhNamespace]$expectedNamespace,[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IEhNamespace]$namespace)

    $expectedNamespace.SkuName | Should -Be $namespace.SkuName
    $expectedNamespace.SkuCapacity | Should -Be $namespace.SkuCapacity
    $expectedNamespace.Name | Should -Be $namespace.Name
    $expectedNamespace.MaximumThroughputUnit | Should -Be $namespace.MaximumThroughputUnit
    $expectedNamespace.MinimumTlsVersion | Should -Be $namespace.MinimumTlsVersion
    $expectedNamespace.Location | Should -Be $namespace.Location
    $expectedNamespace.EnableAutoInflate | Should -Be $namespace.EnableAutoInflate
    $expectedNamespace.KafkaEnabled | Should -Be $namespace.KafkaEnabled
    $expectedNamespace.ZoneRedundant | Should -Be $namespace.ZoneRedundant
    $expectedNamespace.DisableLocalAuth | Should -Be $namespace.DisableLocalAuth
    $expectedNamespace.Tag.Count | Should -Be $namespace.Tag.Count
    $expectedNamespace.PublicNetworkAccess | Should -Be $namespace.PublicNetworkAccess
    $expectedNamespace.AlternateName | Should -Be $namespace.AlternateName
    $expectedNamespace.IdentityType | Should -Be $namespace.IdentityType
    
    if ($expectedNamespace.RequireInfrastructureEncryption -ne $true){
        $namespace.RequireInfrastructureEncryption | Should -Not -Be $true
    }
    else{
        $namespace.RequireInfrastructureEncryption | Should -Be $true
    }

    if ($expectedNamespace.UserAssignedIdentity -ne $null){
        $expectedNamespace.UserAssignedIdentity.Count | Should -Be $namespace.UserAssignedIdentity.Count
    }
    else{
        $expectedNamespace.UserAssignedIdentity | Should -Be $null
    }

    if ($expectedNamespace.KeyVaultProperty -ne $null){
        $expectedNamespace.KeyVaultProperty.Count | Should -Be $namespace.KeyVaultProperty.Count
    }
    else{
        $expectedNamespace.KeyVaultProperty | Should -Be $null
    }
}

Describe 'Set-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        # Add Encryption Config to NamespaceV5 which was created in New-AzEventHubNamespaceV2
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi -UserAssignedIdentity $env.msi1
        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace.KeyVaultProperty += $ec1
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 3
        assertNamespaceUpdates $eventhubNamespace $namespace

        # Add KeyVaultProperty to a namespace with System Assigned
        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaulturi
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.keyVaulturi
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $ec1,$ec2
        $namespace.KeyVaultProperty.Count | Should -Be 2
        $eventhubNamespace.KeyVaultProperty = $namespace.KeyVaultProperty
        assertNamespaceUpdates $eventhubNamespace $namespace

        # Add KeyVaultProperty to a namespace with System Assigned identity
        $ec3 = New-AzEventHubKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi
        $eventHubNamespace.KeyVaultProperty += $ec3
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 3
        assertNamespaceUpdates $eventHubNamespace $namespace

        # Remove KeyVaultProperty from namespace with SystemAssigned identity.
        $eventhubNamespace.KeyVaultProperty = $eventHubNamespace.KeyVaultProperty[0,2]
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 2
        assertNamespaceUpdates $eventHubNamespace $namespace

        # Add UserAssigned Identity to above namespace to test for SystemAssigned and UserAssigned
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentityId $env.msi1
        $eventHubNamespace.IdentityType = "SystemAssigned, UserAssigned"
        $eventhubNamespace.UserAssignedIdentity = $namespace.UserAssignedIdentity
        assertNamespaceUpdates $eventHubNamespace $namespace

        # Add another UserAssignedIdentity to the above namespace
        $identityId = $eventHubNamespace.UserAssignedIdentity.Keys
        $identityId += $env.msi2
        $namespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -UserAssignedIdentityId $identityId
        $namespace.UserAssignedIdentity.Count | Should -Be 2
        $eventHubNamespace.UserAssignedIdentity = $namespace.UserAssignedIdentity
        assertNamespaceUpdates $eventHubNamespace $namespace
        
        # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1
        $eventHubNamespace.UserAssignedIdentity.Count | Should -Be 1

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -IdentityType None -UserAssignedIdentity:$null
        $eventhubNamespace.IdentityType | Should -Be $null
    }
    It 'SetViaIdentityExpanded' {
        $expectedNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -EnableAutoInflate:$false -MaximumThroughputUnit 0
        $expectedNamespace.EnableAutoInflate = $false
        $expectedNamespace.MaximumThroughputUnit = 0
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -EnableAutoInflate:$true -MaximumThroughputUnit 18
        $expectedNamespace.EnableAutoInflate = $true
        $expectedNamespace.MaximumThroughputUnit = 18
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -SkuCapacity 12
        $expectedNamespace.SkuCapacity = 12
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -MaximumThroughputUnit 25
        $expectedNamespace.MaximumThroughputUnit = 25
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

        $namespace = Set-AzEventHubNamespaceV2 -InputObject $expectedNamespace -PublicNetworkAccess "Disabled"
        $expectedNamespace.PublicNetworkAccess = "Disabled"
        assertNamespaceUpdates $expectedNamespace $namespace
    }
}
