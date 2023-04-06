### Example 1: Create High Availability Pacemaker cluster provider
```powershell
New-AzWorkloadsProviderPrometheusHaClusterInstanceObject -ClusterName hacluster -Hostname h20dbvm0 -PrometheusUrl "http://10.0.92.5:964/metrics" -Sid X00 -SslPreference Disabled
```

```output
ProviderType        ClusterName Hostname PrometheusUrl                Sid SslCertificateUri SslPreference
------------        ----------- -------- -------------                --- ----------------- -------------
PrometheusHaCluster hacluster   h20dbvm0 http://10.0.92.5:964/metrics X00                   Disabled
```

Create High Availability Pacemaker cluster for an AMS instance
