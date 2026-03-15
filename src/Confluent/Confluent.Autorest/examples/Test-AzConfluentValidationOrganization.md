### Example 1: Organization Validate proxy resource
```powershell
Test-AzConfluentValidationOrganization `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Location "centralus" `
    -OfferDetailId "confluent-cloud-azure-prod" `
    -OfferDetailPlanId "confluent-cloud-azure-payg-prod" `
    -OfferDetailPlanName "Confluent Cloud - Pay as you Go" `
    -OfferDetailPublisherId "confluentinc" `
    -OfferDetailTermUnit "P1M" `
    -UserDetailEmailAddress "user4@example.com" `
    -UserDetailFirstName "Prem" `
    -UserDetailLastName "Gnanashekar" `
    -UserDetailUserPrincipalName "user4@example.com"
```

```output
Test-AzConfluentValidationOrganization_ValidateExpanded: SaaS Purchase Payment Check Failed as validationResponse was {"isEligible":false,"errorMessage":"Test header retention date cannot be in the past. {\"contact\":\"testaccounts@example.com\",\"scenarios\":\"BAMI,CSZ,Inv-v7,crs-vnext\",\"retention\":\"2099-01-01T00:00:00.000Z\"}"} Organization resource already exists with resource id: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org. Cannot complete signup. Reason: Email already exists. For more details: https://docs.confluent.io/cloud/current/billing/ccloud-azure-payg.html#prerequisites.ErrorCode:40025CorrelationID:00000000-0000-0000-0000-000000000002
```

This command Validates Organization proxy resource