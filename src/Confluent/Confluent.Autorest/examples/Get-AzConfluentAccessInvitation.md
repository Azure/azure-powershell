### Example 1: List all Invitation under organization in the resource group
```powershell
Get-AzConfluentAccessInvitation -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Data              : {{
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv04",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv04",
                        "created_at": "2025-11-13T10:57:08.617671+00:00",
                        "updated_at": "2025-11-13T10:57:08.625073+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv04",
                      "email": "user5@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-13T13:28:01.219263+00:00",
                      "expires_at": "2025-11-16T10:57:08.625073+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv02",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv02",
                        "created_at": "2025-11-13T10:59:01.206099+00:00",
                        "updated_at": "2025-11-13T10:59:01.214239+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv02",
                      "email": "user6@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_EXPIRED",
                      "accepted_at": "0001-01-01T00:00:00+00:00",
                      "expires_at": "2025-11-16T10:59:01.214239+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv03",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv03",
                        "created_at": "2025-11-17T07:09:55.01892+00:00",
                        "updated_at": "2025-11-17T07:09:55.028684+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv03",
                      "email": "user7@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-17T07:13:01.863287+00:00",
                      "expires_at": "2025-11-20T07:09:55.028684+00:00"
                    }, {
                      "metadata": {
                        "self": "https://api.example.confluent.io/iam/v2/invitations/i-exampleinv01",
                        "resource_name": "crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv01",
                        "created_at": "2025-11-17T07:14:32.58968+00:00",
                        "updated_at": "2025-11-17T07:14:32.599239+00:00"
                      },
                      "kind": "Invitation",
                      "id": "i-exampleinv01",
                      "email": "user1@example.com",
                      "auth_type": "AUTH_TYPE_SSO",
                      "status": "INVITE_STATUS_ACCEPTED",
                      "accepted_at": "2025-11-17T07:14:56.660743+00:00",
                      "expires_at": "2025-11-20T07:14:32.599239+00:00"
                    }…}
Kind              : InvitationList
MetadataFirst     :
MetadataLast      :
MetadataNext      : https://api.example.confluent.io/iam/v2/invitations?page_token=<TOKEN>
MetadataPrev      :
MetadataTotalSize : 0
```

This command lists all Invitations under a organization and resource group