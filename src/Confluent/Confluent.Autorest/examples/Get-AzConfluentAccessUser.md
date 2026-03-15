## DESCRIPTION
Organization users details

## EXAMPLES

### Example 1: Get Organization User Details
```powershell
Get-AzConfluentAccessUser -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/users/u-exampleuser01",
                        "resource_name": "crn://example.confluent.io/user=u-exampleuser01",
                        "created_at": "2023-05-02T14:34:49.388906+00:00",
                        "updated_at": "2025-12-18T11:54:28.13479+00:00"
                      },
                      "kind": "User",
                      "id": "u-exampleuser01",
                      "email": "user2@example.com",
                      "full_name": "Deepika N",
                      "auth_type": "AUTH_TYPE_SSO"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/users/u-exampleuser04",
                        "resource_name": "crn://example.confluent.io/user=u-exampleuser04",
                        "created_at": "2025-06-13T08:32:29.093404+00:00",
                        "updated_at": "2025-12-29T09:05:56.451147+00:00"
                      },
                      "kind": "User",
                      "id": "u-exampleuser04",
                      "email": "user3@example.com",
                      "full_name": "Shashank Gupta",
                      "auth_type": "AUTH_TYPE_SSO"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/users/u-exampleuser03",
                        "resource_name": "crn://example.confluent.io/user=u-exampleuser03",
                        "created_at": "2025-07-23T12:14:02.59428+00:00",
                        "updated_at": "2025-11-20T05:44:51.139779+00:00"
                      },
                      "kind": "User",
                      "id": "u-exampleuser03",
                      "email": "user4@example.com",
                      "full_name": "Pola Shekar",
                      "auth_type": "AUTH_TYPE_SSO"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/users/u-exampleuser02",
                        "resource_name": "crn://example.confluent.io/user=u-exampleuser02",
                        "created_at": "2025-09-25T09:15:10.758686+00:00",
                        "updated_at": "2025-11-17T07:20:35.154717+00:00"
                      },
                      "kind": "User",
                      "id": "u-exampleuser02",
                      "email": "user1@example.com",
                      "full_name": "Avish Porwal",
                      "auth_type": "AUTH_TYPE_SSO"
                    }…}
Kind              : UserList
MetadataFirst     :
MetadataLast      :
MetadataNext      : https://api.example.confluent.io/iam/v2/users?page_token=<TOKEN>
MetadataPrev      :
MetadataTotalSize : 0
```

This command list all Users under an organization in the resource group 
