if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryReplication' {
    It 'CreateExpanded' {
        {New-AzContainerRegistryReplication -name  $env.rstr2 -RegistryName  $env.rstr1 -ResourceGroupName $env.ResourceGroup -Location westus2 } | Should -Not -Throw
    }

    It 'CreateByRegistry' {
        $obj = Get-AzContainerRegistry -Name $env.rstr1 -ResourceGroupName $env.ResourceGroup 
        {New-AzContainerRegistryReplication -Name $env.rstr4 -Registry $obj -Location westus3  } | Should -Not -Throw
    }
}
