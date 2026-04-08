### Example 1: Invite user to the organization
```powershell
Invoke-AzConfluentInviteAccessUser `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -JsonString '{
        "email": "caller@contoso.com",
        "upn": "caller@contoso.com",
        "organizationId": "<confluent-org-id>",
        "invitedUserDetails": {
            "invitedEmail": "newuser@contoso.com",
            "auth_type": "AUTH_TYPE_SSO"
        }
    }'
```

```output
AcceptedAt           : 2026-03-07T13:59:56.6238+00:00
AuthType             : AUTH_TYPE_SSO
Email                : newuser@contoso.com
ExpiresAt            : 2026-03-10T13:59:56.602737+00:00
Id                   : i-exampleinv05
Kind                 : Invitation
MetadataCreatedAt    : 2026-03-07T13:59:56.602737+00:00
MetadataDeletedAt    :
MetadataResourceName : crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/invitation=i-exampleinv05
MetadataSelf         : https://api.example.confluent.io/iam/v2/invitations/i-exampleinv05
MetadataUpdatedAt    :
ResourceGroupName    :
Status               : INVITE_STATUS_ACCEPTED
```

This command Invite User to organization