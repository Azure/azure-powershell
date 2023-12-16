if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminProject' {
    It 'List' {
        $listOfProjects = Get-AzDevCenterAdminProject
        $listOfProjects.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $project = Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectName
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 3
    }

    It 'List1' {
        $listOfProjects = Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup
        $listOfProjects.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $project = Get-AzDevCenterAdminProject -ResourceGroupName $env.resourceGroup -Name $env.projectName
        $project = Get-AzDevCenterAdminProject -InputObject $project
        $project.DevCenterId | Should -Be $env.devCenterId
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 3
    }
}
