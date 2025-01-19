if(($null -eq $TestName) -or ($TestName -contains 'Start-AzSpringAppDeploymentJfr'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzSpringAppDeploymentJfr.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzSpringAppDeploymentJfr' {
    It 'Start' {
        $deploy = Start-AzSpringAppDeploymentJfr -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.greenDeploymentName -AppInstance 'account-green-7-f667cc5bb-q74bh' -FilePath '/tmp'
        $deploy = Get-AzSpringAppDeployment -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appAccount -Name $env.greenDeploymentName  
        $deploy.ProvisioningState | Should -Be "Succeeded"
    }
}
