if(($null -eq $TestName) -or ($TestName -contains 'Resume-AzFabricCapacity'))
{
  $fabricCommonPath = Join-Path $PSScriptRoot 'common.ps1'
    . ($fabricCommonPath)
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzFabricCapacity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Resume-AzFabricCapacity' {
    It 'Resume' {
        Suspend-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CapacityName
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CapacityName
        Validate_Capacity $result $env.CapacityName $env.CapacityId $env.Location "Paused" "Succeeded" $env.SkuName

        Resume-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CapacityName
        $result = Get-AzFabricCapacity -ResourceGroupName $env.ResourceGroupName -CapacityName $env.CapacityName
        Validate_Capacity $result $env.CapacityName $env.CapacityId $env.Location "Active" "Succeeded" $env.SkuName
    }
}
