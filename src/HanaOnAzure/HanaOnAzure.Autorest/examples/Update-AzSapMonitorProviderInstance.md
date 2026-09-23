### Example 1: Update an instance of SAP monitor by string for HANA
```powershell
$jsonString = '{
  "HanaHostname": "hdb1-0",
  "HanaDatabaseUsername": "SYSTEM",
  "HanaDatabaseName": "SYSTEMDB",
  "HanaDatabaseSqlPort": "30015",
  "HanaDatabasePassword": "*****"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name ps-sapmonitorins-t01 -SapMonitorName yemingmonitor -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name                 Type
----                 ----
ps-sapmonitorins-t01 Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by string for HANA.

### Example 2: Update an instance of SAP monitor by key vault for HANA
```powershell
$jsonString = '{
  "HanaDatabaseName": "SYSTEMDB",
  "HanaDatabasePasswordSecretId": "https://kv-9gosjc-test.vault.azure.net/secrets/hanaPassword/************",
  "HanaHostname": "hdb1-0",
  "HanaDatabaseUsername": "SYSTEM",
  "HanaDatabaseSqlPort": "30015",
  "HanaDatabasePasswordKeyVaultResourceId": "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/costmanagement-rg-8p50xe/providers/Microsoft.KeyVault/vaults/kv-9gosjc-test"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name sapins-kv-test -SapMonitorName sapMonitor-vayh7q-test -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name           Type
----           ----
sapins-kv-test Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by key vault for HANA.

### Example 3: Update an instance of SAP monitor by dictionary for PrometheusHaCluster
```powershell
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-promclt -SapMonitorName dolauli-test04 -ProviderType PrometheusHaCluster -ProviderInstanceProperty '{"prometheusUrl"="http://10.4.1.10:9664/metrics"}'
```

```output
Name                     Type
----                     ----
dolauli-instance-promclt Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for PrometheusHaCluster.

### Example 4: Update an instance of SAP monitor by dictionary for PrometheusOS
```powershell
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-prom   -SapMonitorName dolauli-test04 -ProviderType PrometheusOS -ProviderInstanceProperty '{"prometheusUrl"="http://10.3.1.6:9100/metrics"}'
```

```output
Name                  Type
----                  ----
dolauli-instance-prom Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for PrometheusOS.

### Example 5: Update an instance of SAP monitor by dictionary for MsSqlServer
```powershell
$jsonString = '{
  "sqlPort": 1433,
  "sqlPassword": "fakepassword",
  "sqlUsername": "AMFSS",
  "sqlHostname": "10.4.8.90"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-ms -SapMonitorName dolauli-test04 -ProviderType MsSqlServer -ProviderInstanceProperty $jsonString
```

```output
Name                Type
----                ----
dolauli-instance-ms Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for MsSqlServer.

### Example 6: Update an instance of SAP monitor by dictionary for SapHana
```powershell
$jsonString = '{
  "hanaHostname": "10.1.2.6",
  "hanaDbPassword": "Manager1",
  "hanaDbUsername": "SYSTEM",
  "hanaDbSqlPort": 30113,
  "hanaDbName": "SYSTEMDB"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-hana -SapMonitorName dolauli-test04 -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name                  Type
----                  ----
dolauli-instance-hana Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for SapHana.