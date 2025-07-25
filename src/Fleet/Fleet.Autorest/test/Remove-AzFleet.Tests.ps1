if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFleet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFleet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFleet' {
    It 'Delete' {
        {
            $result = Remove-AzFleet -Name $env.testFleet1 -ResourceGroupName $env.resourceGroup -PassThru
            $result | Should -Be $true
            Remove-AzFleet -Name $env.testFleet2 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $fleet3 = Get-AzFleet -Name $env.testFleet3 -ResourceGroupName $env.resourceGroup2
            $result = Remove-AzFleet -InputObject $fleet3 -PassThru
            $result | Should -Be $true
        } | Should -Not -Throw
    }
}
