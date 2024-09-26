### Example 1: Update Azure Monitor Pipeline Group
```powershell
Update-AzPipelineGroup -Name testgroup -ResourceGroupName kubetest -SubscriptionId 00000000-0000-0000-0000-000000000000 -NetworkingConfiguration @() -Replica 1 -Exporter @{name="gigla1"; type="AzureMonitorWorkspaceLogs"; azureMonitorWorkspaceLog=@{api=@{dataCollectionEndpointUrl="https://myexporter.eastus-1.ingest.monitor.azure.com"; dataCollectionRule="dcr-00000000000000000000000000000000"; stream="Custom-MyTableRawData"; schema=@{recordMap=@(@{from="body"; to="Body"},@{from="severity_text"; to="SeverityText"},@{from="time_unix_nano"; to="TimeGenerated"})}}}} -Processor @{name="batchproc1"; type="Batch"; batch=@{batchSize=10}} -Receiver @(@{name="otlp1"; type="OTLP"; otlp=@{endpoint="0.0.0.0:7777"}}, @{name="myudpreceiveralittlelong26283032"; type="UDP"; udp=@{endpoint="0.0.0.0:5555"}}, @{name="mysyslog1"; type="Syslog"; syslog=@{endpoint="0.0.0.0:4444"}}) -ServicePipeline @{name="MyPipeline1"; type="logs"; receiver=@("otlp1", "myudpreceiveralittlelong26283032", "mysyslog1"); processor=@("batchproc1"); exporter=@("gigla1")}
```

Update Azure Monitor Pipeline Group

