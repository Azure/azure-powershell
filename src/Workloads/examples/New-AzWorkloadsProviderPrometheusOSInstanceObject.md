### Example 1: Create Linux OS Provider
```powershell
New-AzWorkloadsProviderPrometheusOSInstanceObject -PrometheusUrl "http://10.1.0.4:9100/metrics" -SapSid X00 -SslPreference Disabled
```

```output
ProviderType PrometheusUrl                SapSid SslCertificateUri SslPreference
------------ -------------                ------ ----------------- -------------
PrometheusOS http://10.1.0.4:9100/metrics X00                      Disabled
```

Create Linux Operating System provider for an AMS instance
