### Example 1: Create an instance of SAP monitor by string for HANA
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name ps-sapmonitorins-t01 -SapMonitorName yemingmonitor -ProviderType SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)
```

```output
Name                 Type
----                 ----
ps-sapmonitorins-t01 Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by string for HANA.

### Example 2: Create an instance of SAP monitor by key vault for HANA
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName sapMonitor-vayh7q-test -ProviderType SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId https://kv-9gosjc-test.vault.azure.net/secrets/hanaPassword/bf516d1dfcc144138e5cf55114f3344b -HanaDatabasePasswordKeyVaultResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/costmanagement-rg-8p50xe/providers/Microsoft.KeyVault/vaults/kv-9gosjc-test -Name sapins-kv-test
```

```output
Name           Type
----           ----
sapins-kv-test Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by key vault for HANA.

### Example 3: Create an instance of SAP monitor by dictionary for PrometheusHaCluster
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-promclt   -SapMonitorName dolauli-test04 -ProviderType PrometheusHaCluster -InstanceProperty @{prometheusUrl='http://10.4.1.10:9664/metrics'}
```

```output
Name                     Type
----                     ----
dolauli-instance-promclt Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by dictionary for PrometheusHaCluster.

### Example 4: Create an instance of SAP monitor by dictionary for PrometheusOS
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-prom   -SapMonitorName dolauli-test04 -ProviderType PrometheusOS -InstanceProperty @{prometheusUrl='http://10.3.1.6:9100/metrics'}
```

```output
Name                  Type
----                  ----
dolauli-instance-prom Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by dictionary for PrometheusOS.

### Example 5: Create an instance of SAP monitor by dictionary for MsSqlServer
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-ms   -SapMonitorName dolauli-test04 -ProviderType MsSqlServer -InstanceProperty @{sqlHostname="10.4.8.90";sqlPort=1433;sqlUsername="AMFSS";sqlPassword="fakepassword"}
```

```output
Name                Type
----                ----
dolauli-instance-ms Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by dictionary for MsSqlServer.

### Example 6: Create an instance of SAP monitor by dictionary for SapHana
```powershell
New-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-hana   -SapMonitorName dolauli-test04 -ProviderType SapHana -InstanceProperty @{hanaHostname="10.1.2.6";hanaDbName="SYSTEMDB";hanaDbSqlPort=30113;hanaDbUsername="SYSTEM"; hanaDbPassword="Manager1"}
```

```output
Name                  Type
----                  ----
dolauli-instance-hana Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command creates an instance of SAP monitor by dictionary for SapHana.