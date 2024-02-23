if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEmailService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEmailService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEmailService' {
    It 'List' {
        $services = Get-AzEmailService
        $services.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $service = Get-AzEmailService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $service.Name | Should -Be $env.persistentResourceName
    }

    It 'List1' {
        $services = Get-AzEmailService -ResourceGroupName $env.resourceGroup
    }

    It 'GetViaIdentity' {
        $EmailServiceInstance01 = Get-AzEmailService -ResourceGroupName $env.resourceGroup -Name $env.persistentResourceName
        $EmailServiceInstance = Get-AzEmailService -inputObject $EmailServiceInstance01
        $EmailServiceInstance.Name | Should -Be $env.persistentResourceName
    }
}
