if(($null -eq $TestName) -or ($TestName -contains 'AzElasticMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzElasticMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzElasticMonitor' {
    It 'CreateExpanded' {
        $monitor = New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        $monitor.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonString' {
        $monitorProps = @{
            location   = $env.location
            sku        = @{
                name = $env.sku
            }
            properties = @{
                userInfo = @{
                    emailAddress = $env.userEmail
                }
            }
        }
        $monitorPropsJson = ConvertTo-Json -InputObject $monitorProps -Depth 5
        $monitor = New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName04 -JsonString $monitorPropsJson
        $monitor.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'CreateViaJsonFilePath' -Skip {

    }

    It 'List' {
        $monitors = Get-AzElasticMonitor
        $monitors.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03
        $monitor.Name | Should -Be $env.elasticName03
    }

    It 'List1' {
        $monitors = Get-AzElasticMonitor -ResourceGroup $env.resourceGroup
        $monitors.Count | Should -BeGreaterOrEqual 2
    }

    It 'UpdateExpanded' {
        $monitor = Update-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 -Tag @{ "Tag31Name" = "Tag31Val"; "Tag32Name" = "Tag32Val" }
        $monitor.Tag.Count | Should -BeGreaterOrEqual 2
    }

    It 'UpdateViaJsonString' {
        $monitorTags = @{
            tags = @{
                "Tag41Name" = "Tag41Val"
                "Tag42Name" = "Tag42Val"
            }
        }
        $monitorTagsJson = ConvertTo-Json -InputObject $monitorTags
        Update-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName04 -JsonString $monitorTagsJson
    }

    It 'UpdateViaJsonFilePath' -Skip {

    }

    It 'UpdateViaIdentityExpanded' {
        $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName04
        $monitor = Update-AzElasticMonitor -InputObject $monitor -Tag @{ "TagName" = "TagVal" }
        $monitor.Tag.Count | Should -Be -BeGreaterOrEqual 1
    }

    It 'Delete' {
        New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        Remove-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName03
        $monitors = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup
        $monitors.Name | Should -Not -Contain $env.monitorName03
    }

    It 'DeleteViaIdentity' {
        $monitor = New-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName04 -Location $env.location -Sku $env.sku -UserInfoEmailAddress $env.userEmail
        Remove-AzElasticMonitor -InputObject $monitor
        $monitors = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup
        $monitors.Name | Should -Not -Contain $env.monitorName04
     }
}
