if(($null -eq $TestName) -or ($TestName -contains 'New-AzEmailService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzEmailService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzEmailService' {
     It 'CreateExpanded' -skip {
        $NewAzEmailService = New-AzEmailService -ResourceGroupName $env.resourceGroup -Name $env.resourceName -DataLocation $env.dataLocation -Location $env.location
        $NewAzEmailService.Name | Should -Be $env.resourceName
    }

    It 'CreateViaJsonFilePath' -skip {
        $NewAzEmailService = New-AzEmailService -ResourceGroupName $env.resourceGroup -Name $env.resourceName -DataLocation $env.dataLocation -Location $env.location
        $NewAzEmailService.Name | Should -Be $env.resourceName
    }

    It 'CreateViaJsonString' -skip  {
        $NewAzEmailService = New-AzEmailService -ResourceGroupName $env.resourceGroup -Name $env.resourceName -DataLocation $env.dataLocation -Location $env.location
        $NewAzEmailService.Name | Should -Be $env.resourceName
    }
}
