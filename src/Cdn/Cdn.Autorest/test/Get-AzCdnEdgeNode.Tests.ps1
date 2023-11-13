if(($null -eq $TestName) -or ($TestName -contains 'Get-AzCdnEdgeNode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCdnEdgeNode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzCdnEdgeNode'  {
    It 'List' {
        {
            $minPrefixLength = 0;
            $maxIpv4PrefixLength = 32;
            $maxIpv6PrefixLength = 128;
            $expectedEdgeNodeNames = @("Standard_Verizon", "Premium_Verizon", "Custom_Verizon") 
            $edgeNodes = Get-AzCdnEdgeNode

            $edgeNodes.Count | Should -Be 3
            foreach ($edgeNode in $edgeNodes) {
                $edgeNode.Name | Should -BeIn $expectedEdgeNodeNames
                $edgeNode.IpAddressGroup.Count | Should -BeGreaterThan 0
                foreach ($ipAddressGroup in $edgeNode.IpAddressGroup) {
                    $ipAddressGroup.DeliveryRegion | Should -Not -BeNullOrEmpty
                    $ipAddressGroup.Ipv4Address.Count | Should -BeGreaterThan 0
                    foreach ($ipAddress in $ipAddressGroup.Ipv4Address) {
                        $ipAddress.BaseIpAddress | Should -Not -BeNullOrEmpty
                        $ipAddress.PrefixLength | Should -BeGreaterOrEqual $minPrefixLength
                        $ipAddress.PrefixLength | Should -BeLessOrEqual $maxIpv4PrefixLength
                    }
                    $ipAddressGroup.Ipv6Address.Count | Should -BeGreaterThan 0
                    foreach ($ipAddress in $ipAddressGroup.Ipv6Address) {
                        $ipAddress.BaseIpAddress | Should -Not -BeNullOrEmpty
                        $ipAddress.PrefixLength | Should -BeGreaterOrEqual $minPrefixLength
                        $ipAddress.PrefixLength | Should -BeLessOrEqual $maxIpv6PrefixLength
                    }
                }
            } 
        }
    }
}
