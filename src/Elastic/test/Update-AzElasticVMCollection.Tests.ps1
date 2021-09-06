if(($null -eq $TestName) -or ($TestName -contains 'Update-AzElasticVMCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzElasticVMCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzElasticVMCollection' {
    It 'UpdateExpanded' {
        { 
          Update-AzElasticVMCollection -ResourceGroupName $env.resourceGroup -Name $env.elasticName01 -OperationName Add -VMResourceId '/subscriptions/5a611eed-e33a-44e8-92b1-3f6bf835905e/resourceGroups/vidhi-rg/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS' 
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {          
            $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01 
            Update-AzElasticVMCollection -InputObject $elastic -OperationName Delete -VMResourceId '/subscriptions/5a611eed-e33a-44e8-92b1-3f6bf835905e/resourceGroups/vidhi-rg/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS' 
        } | Should -Not -Throw
    }
}
