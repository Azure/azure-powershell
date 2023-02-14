### Example 1:Create an in-memory object for PrometheusRule.
```powershell
 new-AzPrometheusRuleObject -Alert "Billing_Processing_Very_Slow" -Expression "job_type:billing_jobs_duration_seconds:99p5m > 30" -Severity 2 -For PT5M
```

```output
Alert                        Enabled Expression                                        For  Record Severity
-----                        ------- ----------                                        ---  ------ --------
Billing_Processing_Very_Slow         job_type:billing_jobs_duration_seconds:99p5m > 30 PT5M        2
```

Create an in-memory object for PrometheusRule.

