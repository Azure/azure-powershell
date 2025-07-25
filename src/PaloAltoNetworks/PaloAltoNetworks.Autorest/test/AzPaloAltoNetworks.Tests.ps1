if(($null -eq $TestName) -or ($TestName -contains 'AzPaloAltoNetworks'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzPaloAltoNetworks.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzPaloAltoNetworks' {
    It 'CreateLocalRulestack'  {
        {
            $config = New-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Location $env.location -Description "testing powershell" -DefaultMode 'NONE' -EnableSystemAssignedIdentity:$false
            $config.Name | Should -Be $env.LocalRulestackName
        } | Should -Not -Throw
    }

    It 'ListLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.LocalRulestackName
        } | Should -Not -Throw
    }

    It 'GetViaIdentityLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateLocalRulestack' {
        {
            $config = Update-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.LocalRulestackName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config = Update-AzPaloAltoNetworksLocalRulestack -InputObject $config -Tag @{"abc"="123"} -UserAssignedIdentity $env.managedIdentityId
            $config.Name | Should -Be $env.LocalRulestackName
        } | Should -Not -Throw
    }

    It 'CreatePrefixListLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksPrefixListLocalRulestack -Name $env.PrefixListLocalRulestackName -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -PrefixList "10.10.10.0/24" -Description "creating prefix list"
            $config.Name | Should -Be $env.PrefixListLocalRulestackName
        } | Should -Not -Throw
    }

    It 'ListPrefixListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetPrefixListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.PrefixListLocalRulestackName
            $config.Name | Should -Be $env.PrefixListLocalRulestackName
        } | Should -Not -Throw
    }

    It 'CreateFqdnListLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksFqdnListLocalRulestack -Name $env.FqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -FqdnList "www.google.com"
            $config.Name | Should -Be $env.FqdnListLocalRulestack
        } | Should -Not -Throw
    }

    It 'ListFqdnListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetFqdnListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.FqdnListLocalRulestack
            $config.Name | Should -Be $env.FqdnListLocalRulestack
        } | Should -Not -Throw
    }

    It 'CreateLocalRule' {
        {
            $config = New-AzPaloAltoNetworksLocalRule -Priority 1 -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -RuleName $env.LocalRuleName -Description testing
            $config.RuleName | Should -Be $env.LocalRuleName
        } | Should -Not -Throw
    }

    It 'ListLocalRule' {
        {
            $config = Get-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetLocalRule' {
        {
            $config = Get-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Priority 1
            $config.RuleName | Should -Be $env.LocalRuleName
        } | Should -Not -Throw
    }

    It 'CreateCertificateObjectLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName -CertificateSelfSigned 'TRUE'
            $config.Name | Should -Be $env.CertificateObjectLocalRulestackName
        } | Should -Not -Throw
    }

    It 'ListCertificateObjectLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetCertificateObjectLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName
            $config.Name | Should -Be $env.CertificateObjectLocalRulestackName
        } | Should -Not -Throw
    }

    It 'DeleteCertificateObjectLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName
        } | Should -Not -Throw
    }

    It 'DeleteLocalRule' {
        {
            Remove-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Priority 1
        } | Should -Not -Throw
    }

    It 'DeleteFqdnListLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.FqdnListLocalRulestack
        } | Should -Not -Throw
    }

    It 'DeletePrefixListLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.PrefixListLocalRulestackName
        } | Should -Not -Throw
    }

    It 'DeleteLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}