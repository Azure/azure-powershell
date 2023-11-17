if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringBuildpackBinding'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringBuildpackBinding.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringBuildpackBinding' {
    It 'List' {
        { 
            Get-AzSpringBuildpackBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -BuilderName default
        } | Should -Not -Throw
    }

    It 'CRUD' {
        { 
            New-AzSpringBuildpackBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -BuilderName default -Name binging01 -BindingType 'AppDynamics'
            Get-AzSpringBuildpackBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -BuilderName default -Name binging01
            Remove-AzSpringBuildpackBinding -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -BuilderName default -Name binging01
        } | Should -Not -Throw
    }
}
