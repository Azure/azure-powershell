### Example 1: {{ Add title here }}
```powershell
$a = New-AzPrometheusRuleObject -Record "job_type:billing_jobs_duration_seconds:99p5m"
$scope = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lnxtest/providers/microsoft.monitor/accounts/lnxmonitorworkspace"
New-AzPrometheusRuleGroup -ResourceGroupName lnxtest -RuleGroupName newrule -Location eastus -Rule $a -Scope $scope
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

