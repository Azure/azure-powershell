### Example 1: Invite a user to the Confluent organization
```powershell
Invoke-AzConfluentInviteAccessUser -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Email "newuser@contoso.com"
```

```output
Id          Email                Status    CreatedAt
--          -----                ------    ---------
inv-789     newuser@contoso.com  PENDING   2026-02-19 09:15:00
```

This command sends an invitation to a new user to join the Confluent organization.

### Example 2: Invite multiple users with authentication type
```powershell
Invoke-AzConfluentInviteAccessUser -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Email "user@contoso.com" -AuthType "SSO"
```

This command invites a user with specific authentication type configured.

