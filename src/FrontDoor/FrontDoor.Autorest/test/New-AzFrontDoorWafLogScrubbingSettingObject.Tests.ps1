if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorWafLogScrubbingSettingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorWafLogScrubbingSettingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorWafLogScrubbingSettingObject' {
    It '__AllParameterSets' -skip {
        $LogScrubbingRule = New-AzFrontDoorWafLogScrubbingRuleObject -MatchVariable "RequestHeaderNames" -SelectorMatchOperator "EqualsAny" -State "Enabled"
        $logscrubbingSetting = New-AzFrontDoorWafLogScrubbingSettingObject -State "Enabled" -ScrubbingRule @($LogScrubbingRule)
        $logscrubbingSetting.State | Should -Be "Enabled"
        $logscrubbingSetting.ScrubbingRule[0].GetType() | Should -Be "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.WebApplicationFirewallScrubbingRules"
    }
}
