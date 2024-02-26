if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSupportTicketsNoSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSupportTicketsNoSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSupportTicketsNoSubscription' {

    It 'UpdateExpanded' {
        if($env.SupportPlanTenant -eq "Basic support" || $env.SupportPlanTenant -eq "Free"){
            write-host "cannot update support tickets with free support plan"
            
            Mock Update-AzSupportTicketsNoSubscription{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.SupportTicketDetails"}
            
            Update-AzSupportTicketsNoSubscription -SupportTicketName $env.Name -AdvancedDiagnosticConsent "Yes"

            Assert-MockCalled Update-AzSupportTicketsNoSubscription -Exactly 1
        }
        else{
            $supportTicket = Update-AzSupportTicketsNoSubscription -SupportTicketName $env.Name -AdvancedDiagnosticConsent "Yes"
            $supportTicket.AdvancedDiagnosticConsent | Should -Be "Yes"
        }
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
