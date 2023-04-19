### Example 1:  Create an in-memory object for PrometheusRule.
```powershell
New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m" -Expression 'histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
```

```output
Alert Enabled Expression
----- ------- ----------
              histogram_quantile(0.99, sum(rate(jobs_duration_seconds_bucket{service="billing-processing"}[5m])) by (job_type))'
```

Create an in-memory object for PrometheusRule.
