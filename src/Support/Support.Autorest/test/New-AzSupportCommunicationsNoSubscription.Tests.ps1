if(($null -eq $TestName) -or ($TestName -contains 'New-AzSupportCommunicationsNoSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSupportCommunicationsNoSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSupportCommunicationsNoSubscription' {
    It 'CreateExpanded'  {
        if($env.SupportPlanTenant -eq "Basic support" || $env.SupportPlanTenant -eq "Free"){
            write-host "cannot create communication operations for tickets with free support plan"
            
            Mock New-AzSupportCommunicationsNoSubscription{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.CommunicationDetails"}
            
            New-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName1 -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
            
            Assert-MockCalled New-AzSupportCommunicationsNoSubscription -Exactly 1
        }
        else{

            $supportMessage = New-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName1 -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
        
            $supportMessage.Body.ToString() |  Should -Match $env.Body
        }
    }
}
