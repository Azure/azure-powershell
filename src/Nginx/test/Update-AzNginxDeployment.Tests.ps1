if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNginxDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNginxDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNginxDeployment' {
    It 'UpdateExpanded' {
        $nginx = Update-AzNginxDeployment -DeploymentName $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup -EnableDiagnosticsSupport
        $nginx.EnableDiagnosticsSupport | Should -Be True
    }

    It 'UpdateViaIdentityExpanded' {
        $nginx = Get-AzNginxDeployment -Name $env.nginxDeployment1 -ResourceGroupName $env.resourceGroup
        $res = Update-AzNginxDeployment -InputObject $nginx -EnableDiagnosticsSupport:$false
        $res.EnableDiagnosticsSupport | Should -Be False
    }
}
