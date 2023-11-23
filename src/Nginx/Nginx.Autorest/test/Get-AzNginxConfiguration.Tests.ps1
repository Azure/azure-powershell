if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNginxConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNginxConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNginxConfiguration' {
    It 'List' {
        $confList = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $confList.Count | Should -Be 1
    }

    It 'Get' {
        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf.Name | Should -Be $env.nginxConf
    }

    It 'GetViaIdentity' {
        $conf = Get-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup
        $conf = Get-AzNginxConfiguration -InputObject  $conf
        $conf.Name | Should -Be $env.nginxConf
    }
}
