if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEmailService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEmailService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEmailService' {
    It 'Delete' {
        $name = "emailService-test" + $env.rstr1
        $res = New-AzEmailService -ResourceGroupName $env.resourceGroup -Name $name -DataLocation $env.dataLocation

        Remove-AzEmailService -Name $name -ResourceGroupName $env.resourceGroup

        $serviceList = Get-AzEmailService -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' {
        $name = "emailService-test" + $env.rstr2
        $res = New-AzEmailService -ResourceGroupName $env.resourceGroup -Name $name -DataLocation $env.dataLocation

        Remove-AzEmailService -InputObject $res.Id

        $serviceList = Get-AzEmailService -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
}
