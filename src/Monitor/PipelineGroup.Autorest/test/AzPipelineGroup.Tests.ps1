if(($null -eq $TestName) -or ($TestName -contains 'AzPipelineGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzPipelineGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzPipelineGroup' {
    It 'CreateExpanded' {
        {
            $config = New-AzPipelineGroup -Name $env.pipelineGroupName `
                -ResourceGroupName $env.resourceGroup `
                -Location $env.location `
                -SubscriptionId $env.subscriptionId `
                -ExtendedLocationName $env.extLocName `
                -ExtendedLocationType CustomLocation `
                -NetworkingConfiguration @() `
                -Replica 1 `
                -Exporter @{name="gigla1"; type="AzureMonitorWorkspaceLogs"; azureMonitorWorkspaceLog=@{api=@{dataCollectionEndpointUrl="https://myexporter.eastus-1.ingest.monitor.azure.com"; dataCollectionRule="dcr-00000000000000000000000000000000"; stream="Custom-MyTableRawData"; schema=@{recordMap=@(@{from="body"; to="Body"},@{from="severity_text"; to="SeverityText"},@{from="time_unix_nano"; to="TimeGenerated"})}}}} `
                -Processor @{name="batchproc1"; type="Batch"; batch=@{batchSize=10}} `
                -Receiver @(@{name="otlp1"; type="OTLP"; otlp=@{endpoint="0.0.0.0:7777"}}, @{name="myudpreceiveralittlelong26283032"; type="UDP"; udp=@{endpoint="0.0.0.0:5555"}}, @{name="mysyslog1"; type="Syslog"; syslog=@{endpoint="0.0.0.0:4444"}}) `
                -ServicePipeline @{name="MyPipeline1"; type="Logs"; receiver=@("otlp1", "myudpreceiveralittlelong26283032", "mysyslog1"); processor=@("batchproc1"); exporter=@("gigla1")}

            $config.Name | Should -Be $env.pipelineGroupName
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzPipelineGroup -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroup -Name $env.pipelineGroupName
            $config.Name | Should -Be $env.pipelineGroupName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzPipelineGroup -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzPipelineGroup -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroup -Name $env.pipelineGroupName
        } | Should -Not -Throw
    }
}
