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
            $config = New-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Location $env.location -Description "testing powershell" -DefaultMode 'NONE'
            $config.Name | Should -Be $env.LocalRulestackName
        }
    }

    It 'ListLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack
            $config.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.LocalRulestackName
        }
    }

    It 'GetViaIdentityLocalRulestack'  {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } 
    }

    It 'UpdateLocalRulestack' {
        {
            $config = Update-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.LocalRulestackName
        } 
    }

    It 'UpdateViaIdentityLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config = Update-AzPaloAltoNetworksLocalRulestack -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.LocalRulestackName
        }
    }

    It 'CreatePrefixListLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksPrefixListLocalRulestack -Name $env.PrefixListLocalRulestackName -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -PrefixList "10.10.10.0/24" -Description "creating prefix list"
            $config.Name | Should -Be $env.PrefixListLocalRulestackName
        }
    }

    It 'ListPrefixListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetPrefixListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.PrefixListLocalRulestackName
            $config.Name | Should -Be $env.PrefixListLocalRulestackName
        }
    }

    It 'CreateFqdnListLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksFqdnListLocalRulestack -Name $env.FqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -FqdnList "www.google.com"
            $config.Name | Should -Be $env.FqdnListLocalRulestack
        }
    }

    It 'ListFqdnListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetFqdnListLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.FqdnListLocalRulestack
            $config.Name | Should -Be $env.FqdnListLocalRulestack
        }
    }

    It 'CreateLocalRule' {
        {
            $config = New-AzPaloAltoNetworksLocalRule -Priority 1 -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -RuleName $env.LocalRuleName -Description testing
            $config.RuleName | Should -Be $env.LocalRuleName
        }
    }

    It 'ListLocalRule' {
        {
            $config = Get-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetLocalRule' {
        {
            $config = Get-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Priority 1
            $config.RuleName | Should -Be $env.LocalRuleName
        }
    }

    It 'CreateCertificateObjectLocalRulestack' {
        {
            $config = New-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName -CertificateSelfSigned 'TRUE'
            $config.Name | Should -Be $env.CertificateObjectLocalRulestackName
        }
    }

    It 'ListCertificateObjectLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetCertificateObjectLocalRulestack' {
        {
            $config = Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName
            $config.Name | Should -Be $env.CertificateObjectLocalRulestackName
        }
    }

    It 'DeleteCertificateObjectLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.CertificateObjectLocalRulestackName
        }
    }

    It 'DeleteLocalRule' {
        {
            Remove-AzPaloAltoNetworksLocalRule -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Priority 1
        }
    }

    It 'DeleteFqdnListLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksFqdnListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.FqdnListLocalRulestack
        }
    }

    It 'DeletePrefixListLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName $env.LocalRulestackName -ResourceGroupName $env.resourceGroup -Name $env.PrefixListLocalRulestackName
        }
    }

    It 'DeleteLocalRulestack' {
        {
            Remove-AzPaloAltoNetworksLocalRulestack -Name $env.LocalRulestackName -ResourceGroupName $env.resourceGroup
        }
    }
}
