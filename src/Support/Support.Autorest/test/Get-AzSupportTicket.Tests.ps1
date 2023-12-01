if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSupportTicket'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSupportTicket.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSupportTicket' {
    It 'List' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot get support tickets with free support plan"
            
            Mock Get-AzSupportTicket{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.SupportTicketDetails"}
            
            Get-AzSupportTicket

            Assert-MockCalled Get-AzSupportTicket -Exactly 1
        }
        else{
            $supportTickets = Get-AzSupportTicket 
            $supportTickets.Count | Should -BeGreaterThan 0
        }
    }

    It 'Get' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot get support tickets with free support plan"
            
            Mock Get-AzSupportTicket{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.SupportTicketDetails"}
            
            Get-AzSupportTicket -SupportTicketName $env.Name

            Assert-MockCalled Get-AzSupportTicket -Exactly 2
        }
        else{
            $supportTicket = Get-AzSupportTicket -SupportTicketName $env.Name
            $supportTicket.Description | Should -Be "test ticket - please ignore and close"
        }
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
