if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevProject' {
    It 'List' -skip {
        $listOfProjects = Get-AzDevCenterDevProject -Endpoint $env.endpoint
        $listOfProjects.Count | Should -Be 2

        $listOfProjects = Get-AzDevCenterDevProject -DevCenter $env.devCenterName
        $listOfProjects.Count | Should -Be 2

        }

    It 'Get' -skip {
        $project = Get-AzDevCenterDevProject -Endpoint $env.endpoint -ProjectName $env.projectName
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 10

        $project = Get-AzDevCenterDevProject -DevCenter $env.devCenterName -ProjectName $env.projectName
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 10
    }

    It 'GetViaIdentity' -skip {
        $poolInput = @{"ProjectName" = $env.projectName}
        $project = Get-AzDevCenterDevProject -Endpoint $env.endpoint -InputObject $poolInput
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 10

        $project = Get-AzDevCenterDevProject -DevCenter $env.devCenterName -InputObject $poolInput
        $project.Name | Should -Be $env.projectName
        $project.MaxDevBoxesPerUser | Should -Be 10
    }
}
