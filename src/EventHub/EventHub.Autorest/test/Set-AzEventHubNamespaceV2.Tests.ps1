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

Describe 'Set-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -KafkaEnabled -DisableLocalAuth -SkuCapacity 2 -IdentityType SystemAssigned -PublicNetworkAccess Disabled
        $eventhubNamespace.KafkaEnabled | Should -Be $true
        $eventhubNamespace.DisableLocalAuth | Should -Be $true
        $eventhubNamespace.SkuCapacity | Should -Be 2
        $eventhubNamespace.IdentityType | Should -Be SystemAssigned
        $eventhubNamespace.PublicNetworkAccess | Should be Disabled

        New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -EnableAutoInflate:$true -MaximumThroughputUnits 18
        $eventhubNamespace.EnableAutoInflate | Should be $true
        $eventhubNamespace.MaximumThroughputUnits | Should be 18

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuCapacity 12
        $eventhubNamespace.SkuCapacity | Should be 12

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -MaximumThroughputUnits 13
        $eventhubNamespace.EnableAutoInflate | Should be $true
        $eventhubNamespace.MaximumThroughputUnits | Should be 13

        $eventHubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -MaximumThroughputUnits 25
        $eventhubNamespace.MaximumThroughputUnits | Should be 25

        $eventHubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -MinimumTlsVersion 1.0
        $eventhubNamespace.MinimumTlsVersion | Should be '1.0'

        $eventHubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -MinimumTlsVersion 1.2
        $eventhubNamespace.MinimumTlsVersion | Should be '1.2'

        $eventHubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -DisableLocalAuth:$false
        $eventhubNamespace.DisableLocalAuth | Should be $false

        $eventHubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -DisableLocalAuth
        $eventHubNamespace.DisableLocalAuth | Should be $true

        $a = @{}
        $a.Add('/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01',[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.UserAssignedIdentity]::new())
        $a.Add('/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg02',[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.UserAssignedIdentity]::new())
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key4 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key5 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -IdentityType UserAssigned -IdentityId $a -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.IdentityType | Should be UserAssigned
        $eventHubNamespace.IdenitityId.count | Should be 2
        $eventHubNamespace.KeyVaultProperty.count | Should be 2
        $eventHubNamespace.Name | Should be $env.namespaceV2

        $ec3 = New-AzEventHubKeyVaultPropertiesObject -KeyName key6 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg0
        $eventHubNamespace.KeyVaultProperty += $ec3
        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -KeyVaultProperty $eventhubNamespace.KeyVaultProperty
        $namespace.KeyVaultProperty.count | Should be 3

        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key4 -KeyVaultUri https://keyvault-rg1.vault.azure.net/
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key5 -KeyVaultUri https://keyvault-rg1.vault.azure.net/
        Set-AzKeyVaultAccessPolicy -VaultName $kv1 -ObjectId $namespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get -BypassObjectIdValidation

        $eventhubNamespace = Set-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -IdentityType SystemAssigned -KeyVaultProperty $ec1,$ec2
        $eventHubNamespace.Name | Should be env.namespaceV2
        $eventHubNamespace.IdentityType | Should be SystemAssigned
        $eventHubNamespace.KeyVaultProperty.Count | Should be 2


       

    }
}
