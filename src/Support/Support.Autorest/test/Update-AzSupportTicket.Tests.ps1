if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSupportTicket'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSupportTicket.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSupportTicket' {

    It 'UpdateExpanded' {
        if($env.SupportPlanSubscription -eq "Basic support" || $env.SupportPlanSubscription -eq "Free"){
            write-host "cannot update support tickets with free support plan"
            
            Mock Update-AzSupportTicket{ New-MockObject -Type "Microsoft.Azure.PowerShell.Cmdlets.Support.Models.SupportTicketDetails"}
            
            Update-AzSupportTicket -SupportTicketName $env.Name -AdvancedDiagnosticConsent "Yes"

            Assert-MockCalled Update-AzSupportTicket -Exactly 1
        }
        else{
            $supportTicket = Update-AzSupportTicket -SupportTicketName $env.Name -AdvancedDiagnosticConsent "Yes"
            $supportTicket.AdvancedDiagnosticConsent | Should -Be "Yes"
        }
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
