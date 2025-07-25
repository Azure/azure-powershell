if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRedisEnterpriseCacheSku'))  
{  
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'  
if (-Not (Test-Path -Path $loadEnvPath)) {  
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'  
}  
. ($loadEnvPath)  
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRedisEnterpriseCacheSku.Recording.json'  
$currentPath = $PSScriptRoot  
while(-not $mockingPath) {  
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File  
    $currentPath = Split-Path -Path $currentPath -Parent  
}  
. ($mockingPath | Select-Object -First 1).FullName  
}  

Describe 'Get-AzRedisEnterpriseCacheSku' {  
  It 'List' {  
      $splat = @{  
          ClusterName = $env.ClusterName3  
          ResourceGroupName = $env.ResourceGroupName  
      }  
      $skus = Get-AzRedisEnterpriseCacheSku @splat  
      $skus | Should -Not -Be $null  
      # Check that the SKUs contain the expected names
      $skuNames = $skus | Select-Object -ExpandProperty Name
      $sizes = $skus | Select-Object -ExpandProperty SizeInGb
      $skuNames | Should -Contain 'Balanced_B250'
      $skuNames | Should -Contain 'Balanced_B50' 
      $sizes | Should -Contain 240.0
  }
}