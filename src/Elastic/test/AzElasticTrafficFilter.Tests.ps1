if(($null -eq $TestName) -or ($TestName -contains 'AzElasticTrafficFilter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzElasticTrafficFilter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzElasticTrafficFilter' {
    It 'CreateIPFilter' {
        {
            New-AzElasticIPFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.ipFilterName01 -IP 10.10.1.0/24
        } | Should -Not -Throw
    }

    It 'CreateIPFilterViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            New-AzElasticIPFilter -InputObject $monitor -Name $env.ipFilterName02 -IP 10.10.2.0/24
        } | Should -Not -Throw
    }

    It 'CreatePLFilter' {
        {
            New-AzElasticPrivateLinkFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.plFilterName01 -PrivateEndpointName $env.peName
        } | Should -Not -Throw
    }

    It 'CreatePLFilterViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            New-AzElasticPrivateLinkFilter -InputObject $monitor -Name $env.plFilterName02 -PrivateEndpointName $env.peName
        } | Should -Not -Throw
    }

    It 'ListAll' {
        {
            $filters = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            $filters.Count | Should -Be 4
        }
    }

    It 'ListAllViaIdentityMonitor' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            $filters = Get-AzElasticAllTrafficFilter -MonitorInputObject $monitor
            $filters.Count | Should -Be 4
        }
    }

    It 'Dismount' {
        {
            $ruleSet = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 | Where-Object Name -eq $env.ipFilterName01
            Dismount-AzElasticTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -RulesetId $ruleSet.Id

            $filters = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            $filters.Name | Should -Not -Contain $env.ipFilterName01
            $filters.Name | Should -Contain $env.plFilterName01
        }
    }

    It 'DismountViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            $ruleSet = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 | Where-Object Name -eq $env.plFilterName02
            Dismount-AzElasticTrafficFilter -InputObject $monitor -RulesetId $ruleSet.Id

            $filters = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            $filters.Name | Should -Not -Contain $env.plFilterName02
            $filters.Name | Should -Contain $env.ipFilterName02
        }
    }

    It 'ListAssociated' {
        {
            $filters = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            $filters.Count | Should -Be 1
        }
    }

    It 'ListAssociatedViaIdentityMonitor' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            $filters = Get-AzElasticAssociatedTrafficFilter -MonitorInputObject $monitor
            $filters.Count | Should -Be 1
        }
    }

    It 'DeleteUnassociated' {
        {
            $ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 | Where-Object Name -eq $env.ipFilterName01
            Remove-AzElasticUnassociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -RulesetId $ruleSet.Id

            $allFilters = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            $allFilters.Count | Should -Be 3
        }
    }

    It 'DeleteUnassociatedViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            $ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 | Where-Object Name -eq $env.plFilterName02
            Remove-AzElasticUnassociatedTrafficFilter -InputObject $monitor -RulesetId $ruleSet.Id

            $allFilters = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            $allFilters.Count | Should -Be 2
        }
    }

    It 'Associate' {
        $ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 | Where-Object Name -eq $env.ipFilterName02
        Mount-AzElasticTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -RulesetId $ruleSet.Id

        $associatedFilters = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        $associatedFilters.Count | Should -Be 2
    }

    It 'AssociateViaIdentity' {
        $ruleSet = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 | Where-Object Name -eq $env.plFilterName01
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
        Mount-AzElasticTrafficFilter -InputObject $monitor -RulesetId $ruleSet.Id

        $associatedFilters = Get-AzElasticAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
        $associatedFilters.Count | Should -Be 2
    }

    It 'Delete' {
        {
            $ruleSet = Get-AzElasticListAssociatedTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 | Where-Object Name -eq $env.ipFilterName02
            Remove-AzElasticTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -RulesetId $ruleSet.Id

            $allFilters = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
            $allFilters.Count | Should -Be 1
        }
    }

    It 'DeleteViaIdentity' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName02
            $ruleSet = Get-AzElasticListAssociatedTrafficFilter -MonitorInputObject $monitor | Where-Object Name -eq $env.plFilterName01
            Remove-AzElasticTrafficFilter -MonitorInputObject $monitor -RulesetId $ruleSet.Id

            $allFilters = Get-AzElasticAllTrafficFilter -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
            $allFilters.Count | Should -Be 0
        }
    }
}
