if(($null -eq $TestName) -or ($TestName -contains 'Set-AzFrontDoorRulesEngine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzFrontDoorRulesEngine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzFrontDoorRulesEngine' {
    It 'UpdateExpanded' {
        $headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Overwrite" -HeaderName "Strict-Transport-Security" -Value "max-age=63072000; includeSubDomains; preload"
        $ruleEngine = Get-AzFrontDoorRulesEngine -ResourceGroupName $env.ResourceGroupName -FrontDoorName $env.FrontDoorName -Name $env.RuleEngineName
        $engineAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions
        $ruleEngine.Rule[0].Action= $engineAction
        Set-AzFrontDoorRulesEngine -ResourceGroupName $env.ResourceGroupName -FrontDoorName $env.FrontDoorName -Name $env.RuleEngineName -Rule $ruleEngine.Rule
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
