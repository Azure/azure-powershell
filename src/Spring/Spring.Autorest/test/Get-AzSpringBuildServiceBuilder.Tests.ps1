if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringBuildServiceBuilder'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringBuildServiceBuilder.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringBuildServiceBuilder' {
    It 'List' {
        { Get-AzSpringBuildServiceBuilder -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01} | Should -Not -Throw
    }
    It 'CRUD' { 
        { 
            New-AzSpringBuildServiceBuilder -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name builder01 -StackId 'io.buildpacks.stacks.bionic' -StackVersion 'base' 
            Get-AzSpringBuildServiceBuilder -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name builder01
            Remove-AzSpringBuildServiceBuilder -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -Name builder01
        } | Should -Not -Throw
    }
}
