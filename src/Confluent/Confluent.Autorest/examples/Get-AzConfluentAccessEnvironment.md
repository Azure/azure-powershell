### Example 1: List all Confluent Environments under organization and under resource group
```powershell
Get-AzConfluentAccessEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv002",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv002",
                        "created_at": "2025-11-03T14:15:40.878158+00:00",
                        "updated_at": "2025-11-03T14:15:40.878158+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv002",
                      "display_name": "default"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv003",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv003",
                        "created_at": "2025-11-17T10:14:45.640567+00:00",
                        "updated_at": "2025-11-17T10:14:45.640567+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv003",
                      "display_name": "test-env-0"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv004",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv004",
                        "created_at": "2025-11-28T09:41:04.588316+00:00",
                        "updated_at": "2025-11-28T09:41:04.588316+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv004",
                      "display_name": "test-env-1"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/org/v2/environments/env-exampleenv005",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv005",
                        "created_at": "2025-11-28T09:44:36.482039+00:00",
                        "updated_at": "2025-11-28T09:44:36.482039+00:00"
                      },
                      "kind": "Environment",
                      "id": "env-exampleenv005",
                      "display_name": "test-env-2"
                    }…}
Kind              : EnvironmentList
MetadataFirst     :
MetadataLast      :
MetadataNext      :
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all confluent environments under a organization and resource group
