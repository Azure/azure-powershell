if(($null -eq $TestName) -or ($TestName -contains 'AzCustomLocationResourceSyncRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzCustomLocationResourceSyncRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzCustomLocationResourceSyncRule' {
    It 'CreateExpanded' {
        {
            $MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
            $config = New-AzCustomLocationResourceSyncRule -Name $env.resourceSyncRuleName1 -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Location $env.location -Priority 998 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)"
            $config.Name | Should -Be $env.resourceSyncRuleName1

            $config = New-AzCustomLocationResourceSyncRule -Name $env.resourceSyncRuleName2 -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Location $env.location -Priority 997 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)"
            $config.Name | Should -Be $env.resourceSyncRuleName2
        } | Should -Not -Throw
    }

    It 'CreateViaIdentityCustomLocationExpanded' {
        {
            $MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
            $obj = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            $config = New-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name $env.resourceSyncRuleName3 -Location $env.location -Priority 996 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)"
            $config.Name | Should -Be $env.resourceSyncRuleName3
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzCustomLocationResourceSyncRule -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzCustomLocationResourceSyncRule -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Name $env.resourceSyncRuleName2
            $config.Name | Should -Be $env.resourceSyncRuleName2
        } | Should -Not -Throw
    }

    It 'FindExpanded' {
        {
            $config = Find-AzCustomLocationTargetResourceGroup -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Label @{"Key1"="Value1"} -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'FindViaIdentityExpanded' {
        {
            $obj = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            $config = Find-AzCustomLocationTargetResourceGroup -InputObject $obj -Label @{"Key1"="Value1"} -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
            $config = Update-AzCustomLocationResourceSyncRule -Name $env.resourceSyncRuleName1 -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Priority 998 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)" -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.resourceSyncRuleName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityCustomLocationExpanded' {
        {
            $MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
            $obj = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            $config = Update-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name $env.resourceSyncRuleName2 -Priority 997 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)" -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.resourceSyncRuleName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
            $obj = Get-AzCustomLocationResourceSyncRule -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Name $env.resourceSyncRuleName3
            $config = Update-AzCustomLocationResourceSyncRule -InputObject $obj -Priority 996 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)" -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.resourceSyncRuleName3
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzCustomLocationResourceSyncRule -CustomLocationName $env.clusterLocationName -Name $env.resourceSyncRuleName1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityCustomLocation' {
        {
            $obj = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            Remove-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name $env.resourceSyncRuleName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $obj = Get-AzCustomLocationResourceSyncRule -ResourceGroupName $env.resourceGroup -CustomLocationName $env.clusterLocationName -Name $env.resourceSyncRuleName3
            Remove-AzCustomLocationResourceSyncRule -InputObject $obj
        } | Should -Not -Throw
    }
}
