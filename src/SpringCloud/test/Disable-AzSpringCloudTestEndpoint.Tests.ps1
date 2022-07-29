if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzSpringCloudTestEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzSpringCloudTestEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzSpringCloudTestEndpoint' {
    It 'Disable' {
        { 
            Enable-AzSpringCloudTestEndpoint -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Disable-AzSpringCloudTestEndpoint -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
        } | Should -Not -Throw
    }

    It 'DisableViaIdentity' {
        { 
            $spring = Get-AzSpringCloud -ResourceGroupName $env.resourceGroup -Name $env.standardSpringName01
            Enable-AzSpringCloudTestEndpoint -InputObject $spring.Id
            Disable-AzSpringCloudTestEndpoint -InputObject $spring.Id
        } | Should -Not -Throw
    }
}
