### Example 1: Calculate price for returning reservations
```powershell
$orderId = "50000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"

Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
```

```output
BillingInformationBillingCurrencyProratedAmount            : {
                                                               "currencyCode": "USD",
                                                               "amount": 25.05       
                                                             }
BillingInformationBillingCurrencyRemainingCommitmentAmount : {
                                                               "currencyCode": "USD",
                                                               "amount": 18.06       
                                                             }
BillingInformationBillingCurrencyTotalPaidAmount           : {
                                                               "currencyCode": "USD",
                                                               "amount": 25.8        
                                                             }
BillingInformationBillingPlan                              : Monthly
BillingInformationCompletedTransaction                     : 5
BillingInformationTotalTransaction                         : 12
BillingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 0.75
                                                             }
ConsumedRefundsTotal                                       : {
                                                               "currencyCode": "USD",
                                                               "amount": 365.43
                                                             }
Id                                                         : /providers/Microsoft.Capacity/reservationOrders/4336d060-da34-4228-91b0-feab5b2a1e1d/reservations/5e012942-5692-41c0-bc71-86303e11104d
MaxRefundLimit                                             : {
                                                               "currencyCode": "USD",
                                                               "amount": 50000
                                                             }
PolicyError                                                : {}
PricingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 0.75
                                                             }
Quantity                                                   : 1
ResourceGroupName                                          :
SessionId                                                  : b0a96155-5f75-4138-b01f-443130f5516e
```

Calculate reservations refund amount.
The SessionId in the response is a required input parameter for cmdlet Invoke-AzReservationReturn
