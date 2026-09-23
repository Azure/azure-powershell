if(($null -eq $TestName) -or ($TestName -contains 'AzGrafanaDashboard'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzGrafanaDashboard.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzGrafanaDashboard' {
    It 'CreateExpanded' {
        {
            $config = New-AzGrafanaManagedDashboard -DashboardName $env.dashboardName1 -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"Environment"="Dev"}
            $config.Name | Should -Be $env.dashboardName1
            
            $config = New-AzGrafanaManagedDashboard -DashboardName $env.dashboardName2 -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"Environment"="Dev"}
            $config.Name | Should -Be $env.dashboardName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzGrafanaDashboard
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzGrafanaDashboard -ResourceGroupName $env.resourceGroup -Name $env.dashboardName1
            $config.Name | Should -Be $env.dashboardName1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzGrafanaDashboard -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzGrafanaManagedDashboard -DashboardName $env.dashboardName2 -ResourceGroupName $env.resourceGroup -Tag @{"Environment"="Dev"; "Updated"="True"}
            $config.Name | Should -Be $env.dashboardName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzGrafanaDashboard -ResourceGroupName $env.resourceGroup -Name $env.dashboardName1
            $config = Update-AzGrafanaManagedDashboard -InputObject $config -Tag @{"Environment"="Dev"; "Updated"="True"}
            $config.Name | Should -Be $env.dashboardName1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzGrafanaManagedDashboard -DashboardName $env.dashboardName1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzGrafanaDashboard -ResourceGroupName $env.resourceGroup -Name $env.dashboardName2
            Remove-AzGrafanaManagedDashboard -InputObject $config
        } | Should -Not -Throw
    }
}
