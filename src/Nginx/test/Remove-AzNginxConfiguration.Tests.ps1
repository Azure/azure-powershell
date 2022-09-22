if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNginxConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNginxConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNginxConfiguration' {
    It 'Delete' {
        { Remove-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name $env.nginxConf -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
          $confFile = New-AzNginxConfigurationFileObject -VirtualPath $env.nginxFilePath -Content $env.nginxFileContent
          $conf = New-AzNginxConfiguration -DeploymentName $env.nginxDeployment1 -Name default -ResourceGroupName $env.resourceGroup -File $confFile -RootFile $env.nginxFilePath
          Remove-AzNginxConfiguration -InputObject $conf
        } | Should -Not -Throw
    }
}
