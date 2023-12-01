if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportCommunicationsNoSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportCommunicationsNoSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportCommunicationsNoSubscription' {

    It 'Get' {
        if($env.SupportPlanTenant -eq "Basic support" || $env.SupportPlanTenant -eq "Free"){
            write-host "cannot get communication operations for tickets with free support plan"
            
            Mock Get-AzSupportCommunicationsNoSubscription{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.CommunicationDetails"}
            
            Get-AzSupportCommunicationsNoSubscription -SupportTicketName $env.Name -CommunicationName $env.CommunicationName
            
            Assert-MockCalled Get-AzSupportCommunicationsNoSubscription -Exactly 1
        }
        else{
            $supportMessage = Get-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName -SupportTicketName $env.Name
        
            $supportMessage.Body.ToString() |  Should -Match $env.Body
        }
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
