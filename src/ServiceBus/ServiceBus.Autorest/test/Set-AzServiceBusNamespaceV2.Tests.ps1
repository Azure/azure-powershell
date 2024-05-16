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
    param([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbNamespace]$expectedNamespace,[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbNamespace]$namespace)

    $expectedNamespace.SkuName | Should -Be $namespace.SkuName
    $expectedNamespace.SkuCapacity | Should -Be $namespace.SkuCapacity
    $expectedNamespace.Name | Should -Be $namespace.Name
    $expectedNamespace.MinimumTlsVersion | Should -Be $namespace.MinimumTlsVersion
    $expectedNamespace.Location | Should -Be $namespace.Location
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
Describe 'Set-AzServiceBusNamespaceV2' {
    It 'SetExpanded' {
        $ec5 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaulturi $env.keyVaulturi -UserAssignedIdentity $env.msi1

        $serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $serviceBusNamespace.KeyVaultProperty += $ec5

        $namespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 3
        assertNamespaceUpdates $serviceBusNamespace $namespace

        # Add KeyVaultProperty to a namespace with System Assigned
        $serviceBusNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName
        $ec1 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaulturi $env.keyVaulturi
        $ec2 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key2 -KeyVaulturi $env.KeyVaulturi

        $namespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $ec1,$ec2
        $namespace.KeyVaultProperty.Count | Should -Be 2
        $serviceBusNamespace.KeyVaultProperty = $namespace.KeyVaultProperty
        assertNamespaceUpdates $serviceBusNamespace $namespace

        $ec3 = New-AzServiceBusKeyVaultPropertiesObject -KeyName key3 -KeyVaulturi $env.keyVaulturi
        $serviceBusNamespace.KeyVaultProperty += $ec3

        $namespace = Set-AzServiceBUsNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 3
        assertNamespaceUpdates $serviceBusNamespace $namespace

        # Remove KeyVaultProperty from namespace with SystemAssigned identity.
        $serviceBusNamespace.KeyVaultProperty = $serviceBusNamespace.KeyVaultProperty[0,2]
        $namespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -KeyVaultProperty $serviceBusNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.Count | Should -Be 2
        assertNamespaceUpdates $serviceBusNamespace $namespace

        # Add UserAssigned Identity to above namespace to test for SystemAssigned and UserAssigned
        $namespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentityId $env.msi1
        $serviceBusNamespace.IdentityType = "SystemAssigned, UserAssigned"
        $serviceBusNamespace.UserAssignedIdentity = $namespace.UserAssignedIdentity
        assertNamespaceUpdates $serviceBusNamespace $namespace

        $identityId = $serviceBusNamespace.UserAssignedIdentity.Keys
        $identityId += $env.msi2
        $namespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.systemAssignedNamespaceName -UserAssignedIdentityId $identityId
        $namespace.UserAssignedIdentity.Count | Should -Be 2
        $serviceBusNamespace.UserAssignedIdentity = $namespace.UserAssignedIdentity
        assertNamespaceUpdates $serviceBusNamespace $namespace
        
        # Create a namespace with UserAssignedIdentity and use Set-Az cmdlet to set IdentityType to None
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -SkuName Premium -Location $env.location -IdentityType UserAssigned -UserAssignedIdentityId $env.msi1, $env.msi2
        $serviceBusNamespace.UserAssignedIdentity.Count | Should -Be 2

        $serviceBusNamespace = Set-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV6 -IdentityType None -UserAssignedIdentityId:$null
        $serviceBusNamespace.IdentityType | Should -Be $null
    }

    It 'SetExpandedNamespace' {
        $expectedNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace
        assertNamespaceUpdates $expectedNamespace $namespace

        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -MinimumTlsVersion 1.0
        $expectedNamespace.MinimumTlsVersion = '1.0'
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

        $expectedNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 
        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -SkuCapacity 16
        $expectedNamespace.SkuCapacity = 16
        assertNamespaceUpdates $expectedNamespace $namespace

        $expectedNamespace = Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3
        $namespace = Set-AzServiceBusNamespaceV2 -InputObject $expectedNamespace -PublicNetworkAccess Disabled
        $expectedNamespace.PublicNetworkAccess = "Disabled"
        assertNamespaceUpdates $expectedNamespace $namespace
    }
}
