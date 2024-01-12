### Example 1: Create the Spring Cloud Gateway custom domain.
```powershell
New-AzSpringCloudGatewayCustomDomain -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -GatewayName default -DomainName myDomainName.com -Thumbprint "*"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Create the Spring Cloud Gateway custom domain.
https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates?pivots=azure-portal