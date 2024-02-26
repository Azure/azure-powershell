if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportCommunication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportCommunication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportCommunication' {

    It 'List' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot get communication operations for tickets with free support plan"
            
            Mock Get-AzSupportCommunication{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.CommunicationDetails"}
            
            Get-AzSupportCommunication -SupportTicketName $env.Name
            
            Assert-MockCalled Get-AzSupportCommunication -Exactly 1 
        }
        else{
            $supportMessage = Get-AzSupportCommunication -SupportTicketName $env.Name
        
            $supportMessage.Count | Should -BeGreaterThan 0
        }
    }

    It 'GetViaIdentitySupportTicket' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot get communication operations for tickets with free support plan"
            
            Mock Get-AzSupportCommunication{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.CommunicationDetails"}
            
            Get-AzSupportCommunication -SupportTicketName $env.Name -CommunicationName $env.CommunicationName
            
            Assert-MockCalled Get-AzSupportCommunication -Exactly 2 
        }
        else{
            $supportMessage = Get-AzSupportCommunication -CommunicationName $env.CommunicationName -SupportTicketName $env.Name
        
            $supportMessage.Body.ToString() | Should -Match $env.Body
        }
    } 

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
