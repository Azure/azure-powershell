if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNginxDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNginxDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNginxDeployment' {
    It 'List' {
        $nginxList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $nginxList.Count | Should -Be 1
    }

    It 'Get' {
        $nginx = Get-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $nginx.Name | Should -Be $env.nginxDeployment1
    }

    It 'GetViaIdentity' {
        $nginx = Get-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $nginx = Get-AzNginxDeployment -InputObject  $nginx
        $nginx.Name | Should -Be $env.nginxDeployment1
    }
}
