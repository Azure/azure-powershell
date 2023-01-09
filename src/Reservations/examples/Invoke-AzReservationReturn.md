### Example 1: Return a reservation using the session ID obtained from calculateRefund command.
```powershell
$orderId = "50000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003"
$fullyQualifiedOrderId = "/providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003"

Invoke-AzReservationCalculateRefund -ReservationOrderId $orderId -ReservationToReturnQuantity 1 -ReservationToReturnReservationId $fullyQualifiedId  -Id $fullyQualifiedOrderId -Scope "Reservation"
```

```output
BillingInformationBillingCurrencyProratedAmount            : {
                                                               "currencyCode": "USD",
                                                               "amount": 12.9        
                                                             }
BillingInformationBillingCurrencyRemainingCommitmentAmount : {
                                                               "currencyCode": "USD",
                                                               "amount": 18.06       
                                                             }
BillingInformationBillingCurrencyTotalPaidAmount           : {
                                                               "currencyCode": "USD",
                                                               "amount": 15.48       
                                                             }
BillingInformationBillingPlan                              : Monthly
BillingInformationCompletedTransaction                     : 5
BillingInformationTotalTransaction                         : 12
BillingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 2.58
                                                             }
ConsumedRefundsTotal                                       : {
                                                               "currencyCode": "USD",
                                                               "amount": 368.23
                                                             }
Id                                                         : /providers/microsoft.capacity/reservationOrders/50000000-aaaa-bbbb-cccc-100000000003/reservations/30000000-aaaa-bbbb-cccc-100000000003
Location                                                   :
MaxRefundLimit                                             : {
                                                               "currencyCode": "USD",
                                                               "amount": 50000
                                                             }
PolicyError                                                : {}
PricingRefundAmount                                        : {
                                                               "currencyCode": "USD",
                                                               "amount": 2.58
                                                             }
Quantity                                                   : 1
ResourceGroupName                                          :
SessionId                                                  : 93fe5df2-d888-47c5-b00c-cd0ccb1f29b9
```
Proceed reservations return with session ID obtained from Invoke-AzReservationCalculateRefund.
