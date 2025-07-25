### Example 1: List network dependency endpoints for a Disk pool
```powershell
Get-AzDiskPoolOutboundNetworkDependencyEndpoint -DiskPoolName disk-pool-1 -ResourceGroupName storagepool-rg-test | Format-Table -Wrap
```

```output
Category              Endpoint
--------              --------
Microsoft Event Hub   {{
                        "domainName": "evhns-rp-prod-eus2euap.servicebus.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Service Bus {{
                        "domainName": "sb-rp-prod-eus2euap.servicebus.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Storage     {{
                        "domainName": "strpprodeus2euap.blob.core.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }, {
                        "domainName": "stbsprodeus2euap.blob.core.windows.net",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
Microsoft Apt Mirror  {{
                        "domainName": "azure.archive.ubuntu.com",
                        "endpointDetails": [
                          {
                            "port": 443
                          }
                        ]
                      }}
```

The command lists all outbound network dependency endpoints for a Disk pool.

