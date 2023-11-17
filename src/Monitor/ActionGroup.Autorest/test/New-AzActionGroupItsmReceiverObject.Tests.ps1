if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupItsmReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupItsmReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupItsmReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupItsmReceiverObject -ConnectionId a3b9076c-ce8e-434e-85b4-aff10cb3c8f1 -Name "sample itsm" -Region "westcentralus" -TicketConfiguration "{ 'PayloadRevision':0, 'WorkItemType':'Incident', 'UseTemplate':false,'WorkItemData':'{}','CreateOneWIPerCI':false}" -WorkspaceId "5def922a-3ed4-49c1-b9fd-05ec533819a3|55dfd1f8-7e59-4f89-bf56-4c82f5ace23c"
        } | Should -Not -Throw
    }
}
