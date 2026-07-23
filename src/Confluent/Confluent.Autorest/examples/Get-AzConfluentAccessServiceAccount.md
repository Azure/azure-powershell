### Example 1: List all Service accounts under an Organization in the resource group
```powershell
Get-AzConfluentAccessServiceAccount -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa02",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa02",
                        "created_at": "2025-11-24T04:19:14.474519+00:00",
                        "updated_at": "2025-11-24T04:19:14.474519+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa02",
                      "display_name": "serAccPGS",
                      "description": "Service account for connector snkConn24110948"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa04",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa04",
                        "created_at": "2025-12-22T13:46:18.382565+00:00",
                        "updated_at": "2025-12-22T13:46:18.382565+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa04",
                      "display_name": "serAccPGS19152212",
                      "description": "Service account for connector srcConnTestSA1915"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa01",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa01",
                        "created_at": "2025-12-22T13:47:06.072554+00:00",
                        "updated_at": "2025-12-22T13:47:06.072554+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa01",
                      "display_name": "serAccPGS19172212",
                      "description": "Service account for connector snkConnTestSA1917"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/service-accounts/sa-examplesa03",
                        "resource_name": "crn://example.confluent.io/service-account=sa-examplesa03",
                        "created_at": "2026-01-06T06:46:27.431436+00:00",
                        "updated_at": "2026-01-06T06:46:27.431436+00:00"
                      },
                      "kind": "ServiceAccount",
                      "id": "sa-examplesa03",
                      "display_name": "serAccPGS12160601",
                      "description": "Service account for connector snk1215"
                    }…}
Kind              : ServiceAccountList
MetadataFirst     :
MetadataLast      :
MetadataNext      :
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all Servie accounts under a organization and resource group