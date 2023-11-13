### Example 1: Get reservation price with 'Upfront' billing plan
```powershell
Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Upfront' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'yourRIName' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
```

```output
BillingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
GrandTotal              : 0
IsBillingPartnerManaged : 
IsTaxIncluded           : 
NetTotal                : 0
PaymentSchedule         : 
PricingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
ReservationOrderId      : 846655fa-d9e7-4fb8-9512-3ab7367352f1
SkuDescription          : Standard_b1ls
SkuTitle                : Reserved VM Instance, Standard_B1ls, US West, 1 Year
TaxTotal                : 0
```

Get reservation price with 'Upfront' billing plan

### Example 2: Get reservation price with 'Monthly' billing plan
```powershell
Get-AzReservationQuote -AppliedScopeType 'Shared' -BillingPlan 'Monthly' -billingScopeId '/subscriptions/b0f278e1-1f18-4378-84d7-b44dfa708665' -DisplayName 'yourRIName' -Location 'westus' -Quantity 1 -ReservedResourceType 'VirtualMachines' -Sku 'Standard_b1ls' -Term 'P1Y'
```

```output
BillingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
GrandTotal              : 0
IsBillingPartnerManaged : 
IsTaxIncluded           : 
NetTotal                : 0
PaymentSchedule         : {{
                            "dueDate": "2022-07-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "billingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-08-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-09-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }, {
                            "dueDate": "2022-10-07",
                            "pricingCurrencyTotal": {
                              "currencyCode": "GBP",
                              "amount": 2
                            },
                            "status": "Scheduled"
                          }…}
PricingCurrencyTotal    : {
                            "currencyCode": "GBP",
                            "amount": 24
                          }
ReservationOrderId      : 23d4106a-8ec0-4709-839f-0e8073459e83
SkuDescription          : Standard_b1ls
SkuTitle                : Reserved VM Instance, Standard_B1ls, US West, 1 Year
TaxTotal                : 0
```

Get reservation price with 'Monthly' billing plan
