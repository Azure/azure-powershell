if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDnsResolverPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDnsResolverPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDnsResolverPolicy' {
    It 'Update DNS Resolver Policy by adding tag, expect DNS resolver policy updated' {
        # ARRANGE
        $dnsResolverPolicyName = "psdnsresolverpolicyname47";
        $resourceGroupName = "powershell-test-rg-debug-update";
        $location = "westus2";

        $originalDnsResolverPolicy = New-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Location $location

        $tag  = GetRandomHashtable -size 5

        # ACT
        $updatedDnsResolverPolicy = Update-AzDnsResolverPolicy -Name $dnsResolverPolicyName -ResourceGroupName $resourceGroupName -Tag $tag

        # ASSERT
        $updatedDnsResolverPolicy | Should -BeSuccessfullyCreated
        $updatedDnsResolverPolicy | Should -BeSameAsExpected -ExpectedValue $originalDnsResolverPolicy
        $updatedDnsResolverPolicy.Tag.Count | Should -Be $tag.Count
    }
}
