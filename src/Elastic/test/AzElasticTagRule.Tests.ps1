if(($null -eq $TestName) -or ($TestName -contains 'AzElasticTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzElasticTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzElasticTagRule' {
    It 'CreateExpanded' {
        $tagRule = New-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -LogRuleSendAadLog
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $true
        $tagRule.LogRuleSendActivityLog | Should -Be $false
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $false
        $tagRule.LogRuleFilteringTag.Count | Should -Be 0
    }

    It 'CreateViaJsonString' {
        $ruleProps = @{
            properties = @{
                logRules = @{
                    sendActivityLogs     = $true
                    sendSubscriptionLogs = $false
                    filteringTags        = @(
                        @{
                            action = "Include"
                            name   = "Tag1Name"
                            value  = "Tag1Val"
                        }, @{
                            action = "Exclude"
                            name   = "Tag2Name"
                            value  = "Tag2Val"
                        }
                    )
                }
            }
        }
        $rulePropsJson = ConvertTo-Json -InputObject $ruleProps -Depth 5
        $tagRule = New-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -JsonString $rulePropsJson
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $false
        $tagRule.LogRuleSendActivityLog | Should -Be $true
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $false
        $tagRule.LogRuleFilteringTag.Count | Should -Be 2
    }

    It 'CreateViaJsonFilePath' -Skip {

    }

    It 'CreateViaIdentityMonitorExpanded' {
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $tagRule = New-AzElasticTagRule -MonitorInputObject $monitor -LogRuleSendSubscriptionLog
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $false
        $tagRule.LogRuleSendActivityLog | Should -Be $false
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $true
        $tagRule.LogRuleFilteringTag.Count | Should -Be 0
    }

    It 'Get' {
        $tagRule = Get-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $true
        $tagRule.LogRuleSendActivityLog | Should -Be $false
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $false
        $tagRule.LogRuleFilteringTag.Count | Should -Be 0
    }

    It 'GetViaIdentityMonitor' {
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
        $tagRule = Get-AzElasticTagRule -MonitorInputObject $monitor
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $false
        $tagRule.LogRuleSendActivityLog | Should -Be $true
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $false
        $tagRule.LogRuleFilteringTag.Count | Should -Be 2
    }

    It 'UpdateExpanded' {
        Update-AzElasticTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -LogRuleSendActivityLog -LogRuleFilteringTag (New-AzElasticFilteringTagObject -Action Include -Name TagName -Value TagVal)
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $false
        $tagRule.LogRuleSendActivityLog | Should -Be $true
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $true
        $tagRule.LogRuleFilteringTag.Count | Should -Be 1
    }

    It 'UpdateViaIdentityExpanded' {
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
        Update-AzElasticTagRule -InputObject $monitor -LogRuleSendAadLog:$false -LogRuleSendSubscriptionLog -LogRuleFilteringTag (New-AzElasticFilteringTagObject -Action Include -Name TagName -Value TagVal)
        $tagRule.Name | Should -Be 'default'
        $tagRule.LogRuleSendAadLog | Should -Be $false
        $tagRule.LogRuleSendActivityLog | Should -Be $true
        $tagRule.LogRuleSendSubscriptionLog | Should -Be $true
        $tagRule.LogRuleFilteringTag.Count | Should -Be 1
    }
}
