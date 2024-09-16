if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFabricCapacitySku'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFabricCapacitySku.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFabricCapacitySku' {
    It 'List' {
        $result = Get-AzFabricCapacitySku
        Validate_Skus $result
    }

    It 'List1' {
        $result = Get-AzFabricCapacitySku -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CapacityName
        Validate_Capacity_Skus $result
    }
}
