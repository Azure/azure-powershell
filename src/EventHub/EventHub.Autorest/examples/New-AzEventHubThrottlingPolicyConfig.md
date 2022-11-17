### Example 1: Constructs an IThrottlingPolicy object 
```powershell
New-AzEventHubThrottlingPolicyConfig -Name t1 -RateLimitThreshold 10000 -MetricId IncomingBytes
```

```output
MetricId      Name RateLimitThreshold Type
--------      ---- ------------------ ----
IncomingBytes t1                10000 ThrottlingPolicy
```

Please refer examples for Set-AzEventHubApplicationGroup to know more.

