if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAutomanageConfigProfileAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAutomanageConfigProfileAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAutomanageConfigProfileAssignment' {
    It 'Delete' {
        { 
            New-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm -ConfigurationProfile "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction"
            Remove-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $obj = New-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm -ConfigurationProfile "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction" 
            Remove-AzAutomanageConfigProfileAssignment -InputObject $obj 
        } | Should -Not -Throw
    }
}
