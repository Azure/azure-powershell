if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDnsResolverPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDnsResolverPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDnsResolverPolicy' {
    It 'Get single DNS resolver policy by name, expect DNS resolver policy by name retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname662";
        
        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        $dnsResolver =  Get-AzDnsResolverPolicy -DnsResolverPolicyName $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolver | Should -BeSuccessfullyCreated

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'List DNS resolver policies in a resource group, expected least number of DNS resolver policies retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname663";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        $dnsResolvers =  Get-AzDnsResolverPolicy -ResourceGroupName $RESOURCE_GROUP_NAME

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
        
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'List DNS resolver policies in a subscription, expected least number of DNS resolver policies retrieved' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname664";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ACT
        $dnsResolvers =  Get-AzDnsResolverPolicy

        # ASSERT
        $dnsResolvers.Count | Should -BeGreaterThan 0
        
        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
