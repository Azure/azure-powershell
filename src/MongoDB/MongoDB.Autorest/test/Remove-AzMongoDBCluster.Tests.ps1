if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMongoDBCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMongoDBCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMongoDBCluster' {
    It 'Delete-WhatIf' {
        # Partner returns 405 (MethodNotAllowed) for cluster deletion.
        # Use -WhatIf to validate parameter binding without calling the API.
        Remove-AzMongoDBCluster -ResourceGroupName $env.ResourceGroupName `
            -OrganizationName $env.OrganizationName `
            -ProjectName $env.ClusterTestProjectName `
            -Name $env.ClusterName `
            -WhatIf
    }
}
