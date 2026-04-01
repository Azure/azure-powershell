if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorCdnRuleSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorCdnRuleSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorCdnRuleSet' {
    It 'Create' {
        $rulesetName = 'rsName070'

        # New
        Write-Host -ForegroundColor Green "New RuleSet: $($rulesetName)"
        $ruleSet = New-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
        $ruleSet.Name | Should -Be $rulesetName

        # Get - List / by name / ViaIdentity
        $rulesets = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName
        $rulesets.Count | Should -BeGreaterOrEqual 1
        $getRuleSet = Get-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
        $getRuleSet.Name | Should -Be $rulesetName
        $getRuleSet2 = Get-AzFrontDoorCdnRuleSet -InputObject $getRuleSet
        $getRuleSet2.Name | Should -Be $rulesetName

        # Get - ResourceUsage
        $rulesetUsage = Get-AzFrontDoorCdnRuleSetResourceUsage -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -RuleSetName $rulesetName
        $rulesetUsage | Should -Not -BeNullOrEmpty

        # Remove
        Write-Host -ForegroundColor Green "Remove RuleSet: $($rulesetName)"
        Remove-AzFrontDoorCdnRuleSet -ProfileName $env.FrontDoorCdnProfileName -ResourceGroupName $env.ResourceGroupName -Name $rulesetName
    }
}
