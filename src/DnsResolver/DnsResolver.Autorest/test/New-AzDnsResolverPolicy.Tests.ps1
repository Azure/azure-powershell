if(($null -eq $TestName) -or ($TestName -contains 'New-AzDnsResolverPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDnsResolverPolicy' {
    It 'Create DNS resolver policy' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname0j0cdzg";

        # ACT
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location

        # ASSERT
        $resolverPolicy | Should -BeSuccessfullyCreated

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }

    It 'Update DNS Resolver Policy with new tags.' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname4c7glpm";

        New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location
        $tag = GetRandomHashtable -size 2

        # ACT
        $resolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME -Location $location -Tag $tag

        # ASSERT
        $resolverPolicy.ProvisioningState  | Should -Be "Succeeded"
        $resolverPolicy.Tag.Count | Should -Be $tag.Count

        # UNDO
        Start-Sleep -Seconds 5
        Remove-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $RESOURCE_GROUP_NAME
    }
}
