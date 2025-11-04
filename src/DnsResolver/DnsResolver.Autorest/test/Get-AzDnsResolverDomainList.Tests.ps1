if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverDomainList'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverDomainList.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverDomainList' {
    It 'Get single DNS resolver domain list by name, expect DNS resolver domain list by name retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname662";
        
        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolver =  Get-AzDnsResolverDomainList -DnsResolverDomainListName $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolver | Should -BeSuccessfullyCreated
    }

    It 'List DNS resolver domain lists in a resource group, expected least number of DNS resolver domain lists retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname663";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolverDomainLists =  Get-AzDnsResolverDomainList -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolverDomainLists.Count | Should -BeGreaterThan 0

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'List DNS resolver domain lists in a subscription, expected least number of DNS resolver domain lists retrieved' {
        # ARRANGE
        $dnsResolverDomainListName = "psdnsresolverdomainlistname664";

        New-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Domain @("contoso.com.", "example.com.")

        # ACT
        $dnsResolverDomainLists =  Get-AzDnsResolverDomainList

        # ASSERT
        $dnsResolverDomainLists.Count | Should -BeGreaterThan 0

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverDomainList -Name $dnsResolverDomainListName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
