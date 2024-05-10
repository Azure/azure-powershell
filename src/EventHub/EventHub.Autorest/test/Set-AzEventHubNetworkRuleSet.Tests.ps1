if(($null -eq $TestName) -or ($TestName -contains 'Set-AzEventHubNetworkRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzEventHubNetworkRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzEventHubNetworkRuleSet' {
    It 'SetExpanded'  {
        $ipRule1 = New-AzEventHubIPRuleConfig -IPMask 1.1.1.1 -Action Allow
        $ipRule2 = New-AzEventHubIPRuleConfig -IPMask 2.2.2.2 -Action Allow

        $virtualNetworkRule1 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId $env.subnetId1
        $virtualNetworkRule2 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId $env.subnetId2
        $virtualNetworkRule3 = New-AzEventHubVirtualNetworkRuleConfig -SubnetId $env.subnetId3

        $networkRuleSet = Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -IPRule $ipRule1,$ipRule2 -VirtualNetworkRule $virtualNetworkRule1,$virtualNetworkRule2,$virtualNetworkRule3
        $networkRuleSet.DefaultAction | Should -Be "Allow"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Enabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -DefaultAction Deny
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Enabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -PublicNetworkAccess Disabled
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false

        $networkRuleSet = Set-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -TrustedServiceAccessEnabled
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $true

    }

    It 'SetViaIdentityExpanded'  {
        $networkRuleSet = Get-AzEventHubNetworkRuleSet -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
        
        { Set-AzEventHubNetworkRuleSet -InputObject $networkRuleSet -ErrorAction Stop } | Should -Throw 'Please specify the property you want to update on the -InputObject'
        
        $networkRuleSet = Set-AzEventHubNetworkRuleSet -InputObject $networkRuleSet -TrustedServiceAccessEnabled:$false
        $networkRuleSet.DefaultAction | Should -Be "Deny"
        $networkRuleSet.VirtualNetworkRule.Count | Should -Be 3
        $networkRuleSet.IPRule.Count | Should -Be 2
        $networkRuleSet.PublicNetworkAccess | Should -Be "Disabled"
        $networkRuleSet.TrustedServiceAccessEnabled | Should -Be $false
    }
}
