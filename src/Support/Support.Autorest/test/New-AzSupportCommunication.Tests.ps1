if(($null -eq $TestName) -or ($TestName -contains 'New-AzSupportCommunication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSupportCommunication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSupportCommunication' {
    It 'CreateExpanded' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot create communication operations for tickets with free support plan"
            
            Mock New-AzSupportCommunication{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.CommunicationDetails"}
            
            New-AzSupportCommunication -Name "test-msg-$(New-Guid)" -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
            
            Assert-MockCalled New-AzSupportCommunication -Exactly 1
        }
        else{
            $supportMessage = New-AzSupportCommunication -Name "test-msg-$(New-Guid)" -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
        
            $supportMessage.Body.ToString() |  Should -Match $env.Body
        }
    }
}
