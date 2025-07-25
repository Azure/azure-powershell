if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminProject' {
    It 'UpdateExpanded' {
        $project = Update-AzDevCenterAdminProject -Name $env.projectUpdate -ResourceGroupName $env.resourceGroup -MaxDevBoxesPerUser 5
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectUpdate
        $project.MaxDevBoxesPerUser | Should -Be 5 
       }

    It 'UpdateViaIdentityExpanded' {
        $projectInput = Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectUpdate

        $project = Update-AzDevCenterAdminProject -InputObject $projectInput -MaxDevBoxesPerUser 5
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectUpdate
        $project.MaxDevBoxesPerUser | Should -Be 5     }

}
