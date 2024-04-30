if(($null -eq $TestName) -or ($TestName -contains 'Set-AzServiceBusNetworkRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzServiceBusNetworkRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzServiceBusNetworkRuleSet' {
    It 'SetExpanded' {
        $ipRule1 = New-AzServiceBusIPRuleConfig -IPMask 1.1.1.1 -Action Allow
        $ipRule2 = New-AzServiceBusIPRuleConfig -IPMask 2.2.2.2 -Action Allow

        $virtualNetworkRule1 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId $env.subnetId1
        $virtualNetworkRule2 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId $env.subnetId2
        $virtualNetworkRule3 = New-AzServiceBusVirtualNetworkRuleConfig -SubnetId $env.subnetId3

        $networkRuleSet = Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -IPRule $ipRule1,$ipRule2 -VirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3
        $networkRuleSet.DefaultAction | Should -Be "Allow"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Enabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -DefaultAction Deny
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Enabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TrustedServiceAccessEnabled
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $true

    }

    It 'SetViaIdentityExpanded' {
        $networkRuleSet = Get-AzServiceBusNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        $networkRuleSet = Set-AzServiceBusNetworkRuleSet -InputObject $networkRuleSet -TrustedServiceAccessEnabled:$false
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        { Set-AzServiceBusNetworkRuleSet -InputObject $networkRuleSet -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'
    }
}
