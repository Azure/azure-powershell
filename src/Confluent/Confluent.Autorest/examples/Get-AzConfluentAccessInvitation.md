### Example 1: List all pending invitations in a Confluent organization
```powershell
Get-AzConfluentAccessInvitation -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          Email                Status    CreatedAt
--          -----                ------    ---------
inv-123     user1@contoso.com    PENDING   2026-02-01 10:30:00
inv-456     user2@contoso.com    ACCEPTED  2026-01-15 14:20:00
```

This command lists all user invitations for the specified Confluent organization.

### Example 2: List invitations with search filters
```powershell
$searchFilters = @{SearchFilters = @{Status = "PENDING"}}
Get-AzConfluentAccessInvitation -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists only pending invitations in the organization.

