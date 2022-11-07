if(($null -eq $TestName) -or ($TestName -contains 'New-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEventHubNamespaceV2' {
    It 'SetExpanded' {
        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        $eventHubNamespace.Name | Should -Be $env.namespaceV2
        $eventHubNamespace.SkuName | Should be Standard

        $eventHubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV3 -SkuCapacity 10 -MaximumThroughputUnits 18 -SkuName Standard -Location southcentralus -Tag @{k1='v1'; k2='v2'} -EnableAutoInflate -DisableLocalAuth -KafkaEnabled -MinimumTlsVersion 1.1
        $eventHubNamespace.Name | Should be $env.namespaceV3
        $eventHubNamespace.SkuCapacity | Should be 10
        $eventHubNamespace.SkuName | Should be Standard
        $eventHubNamespace.MaximumThroughputUnits | Should be 18
        $eventHubNamespace.MinimumTlsVersion | Should be '1.1'
        $eventHubNamespace.Location | Should be "South Central Us"
        $eventHubNamespace.EnableAutoInflate | Should be $true
        $eventHubNamespace.DisableLocalAuth | Should be $true
        $eventHubNamespace.KafkaEnabled | Should be $true
        

        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV4 -SkuName Premium -Location eastus -IdentityType SystemAssigned        
        $eventhubNamespace.MaximumThroughputUnits | Should -Be 0
        $eventhubNamespace.Name | Should -Be $env.namespaceV4
        $eventhubNamespace.IdentityType | Should -Be SystemAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should be Premium
        $eventhubNamespace.Location | Should -Be "East Us"


        $a = @{}
        $a.Add('/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01',[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.UserAssignedIdentity]::new())
        $a.Add('/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg02',[Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.UserAssignedIdentity]::new())
        $ec1 = New-AzEventHubKeyVaultPropertiesObject -KeyName key4 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01
        $ec2 = New-AzEventHubKeyVaultPropertiesObject -KeyName key5 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg01
        $eventhubNamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5 -SkuName Premium -Location northeurope -IdentityType UserAssigned -UserAssignedIdentity $a -KeyVaultProperty $ec1,$ec2
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.SkuTier | Should be Premium
        $eventhubNamespace.Location | Should -Be "North Europe"
        $eventhubNamespace.KeyVaultProperty.Count | Should be 2
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2


        $ec3 = New-AzEventHubKeyVaultPropertiesObject -KeyName key6 -KeyVaulturi https://keyvault-rg1.vault.azure.net/ -IdentityUserAssignedIdentity /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourcegroups/shubham-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSI-rg0
        $eventhubNamespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV5
        $eventhubNamespace.KeyVaultProperty += $ec3
        $eventhubNamespace.Name | Should -Be $env.namespaceV5
        $eventhubNamespace.IdentityType | Should -Be UserAssigned
        $eventhubNamespace.SkuName | Should -Be Premium
        $eventhubNamespace.KeyVaultProperty.Count | Should be 3
        $eventhubNamespace.UserAssignedIdentity.Count | Should -Be 2


 
    }
}
