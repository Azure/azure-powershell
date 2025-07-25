if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeidService' {
    It 'Delete' {
        { 
            Remove-AzDeidService -Name $env.deidServiceNameToDelete1 -ResourceGroupName $env.resourceGroupName
        } | Should -Not -Throw
    }

    It 'DeleteNonexistent' {
        { 
            Remove-AzDeidService -Name "nonexistent" -ResourceGroupName $env.resourceGroupName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $config = Get-AzDeidService -Name $env.deidServiceNameToDelete2 -ResourceGroupName $env.resourceGroupName
            Remove-AzDeidService -InputObject $config
        } | Should -Not -Throw
    }
}
