if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminProject' {
    It 'Delete' {
        Remove-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectNameDelete
        { Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectNameDelete } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $project = Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectNameDelete2
        Remove-AzDevCenterAdminProject -InputObject $project
        { Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectNameDelete2 } | Should -Throw
    }
}
