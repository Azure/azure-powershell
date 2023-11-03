if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringCloudAppCustomDomain'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringCloudAppCustomDomain.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringCloudAppCustomDomain' {
    It 'List' {
        { Get-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway} | Should -Not -Throw
    }

    It 'Get' {
        {   Test-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name "$($env.standardSpringName01).azuremicroservices.io"
            New-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name "$($env.standardSpringName01).azuremicroservices.io"
            Get-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name "$($env.standardSpringName01).azuremicroservices.io"
            Update-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name "$($env.standardSpringName01).azuremicroservices.io"
            Remove-AzSpringCloudAppCustomDomain -ResourceGroupName $env.resourceGroup -ServiceName $env.standardSpringName01 -AppName $env.appGateway -Name "$($env.standardSpringName01).azuremicroservices.io"
        } | Should -Not -Throw
    }
}
