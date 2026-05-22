### Example 1: List all quotas in a subscription for a given location
```powershell
Get-AzPostgreSqlFlexibleServerQuotaUsage -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -LocationName example-location
```

```output
NameValue                                NameLocalizedValue                       Unit       Limit      CurrentValue
---------                                ------------------                       ----       -----      ------------
cores                                    cores                                    Count      196        118
standardBSFamily                         standardBSFamily                         Count      622        6
standardDDSv4Family                      standardDDSv4Family                      Count      260        4
standardDDSv5Family                      standardDDSv5Family                      Count      502        58
standardDSv3Family                       standardDSv3Family                       Count      424        0
standardEDSv4Family                      standardEDSv4Family                      Count      250        0
standardEDSv5Family                      standardEDSv5Family                      Count      271        0
standardESv3Family                       standardESv3Family                       Count      145        0
```

Lists all quotas defined, and their corresponding usage, for Azure Database for PostgreSQL flexible server, with location and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
