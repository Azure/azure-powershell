if(($null -eq $TestName) -or ($TestName -contains 'New-AzNginxConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNginxConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNginxConfiguration' {
    It 'CreateExpanded' {
        $confFile = New-AzNginxConfigurationFileObject -VirtualPath $env.nginxFilePath -Content $env.nginxFileContent
        $conf = New-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name default -ResourceGroupName $env.resourceGroup -File $confFile -RootFile $env.nginxFilePath
        $conf.ProvisioningState | Should -Be 'Succeeded'
    }
}
