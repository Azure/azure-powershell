if(($null -eq $TestName) -or ($TestName -contains 'Start-AzPeeringInvokeLookingGlass'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzPeeringInvokeLookingGlass.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzPeeringInvokeLookingGlass' {
    It 'Invoke' {
        {
             $command = Start-AzPeeringInvokeLookingGlass -Command Ping -DestinationIp 1.1.1.1 -SourceLocation Seattle -SourceType EdgeSite
             $command.Command | Should -Be "Ping"
        } | Should -Not -Throw
    } 
}
