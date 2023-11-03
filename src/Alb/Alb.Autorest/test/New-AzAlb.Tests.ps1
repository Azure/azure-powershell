if(($null -eq $TestName) -or ($TestName -contains 'New-AzAlb'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAlb.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAlb' {
    It 'CreateExpanded' {
        { 
            $albName = $env.albName+"new"
            $alb = New-AzAlb -Name $albName -ResourceGroupName $env.resourceGroup -Location $env.Region
            $alb.ProvisioningState | Should -Be 'Succeeded'
         } | Should -Not -Throw
    }
}
