if(($null -eq $TestName) -or ($TestName -contains 'New-AzUserAssignedIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzUserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzUserAssignedIdentity' {
    It 'CreateExpanded' {
        $ide = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName02 -Location $env.location
        $ide.Name | Should -Be $env.userIdentityName02
    }
}
