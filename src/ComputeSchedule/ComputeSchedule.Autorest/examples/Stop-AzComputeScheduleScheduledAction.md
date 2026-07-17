### Example 1: Cancel a batch of operations scheduled on virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Stop-AzComputeScheduleScheduledAction -Location "eastus2euap" -Correlationid "9992a233-8f42-4e7c-8b5a-71eea1a0ead2" -OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:36:18 PM
OperationDeadline              : 12/25/2024 11:00:00 PM
OperationDeadlineType          : InitiateAt
OperationId                    : d099fda7-4fdb-4db0-98e5-53fab1821267
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85155
OperationState                 : Cancelled
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85155
ResourceOperationErrorCode     : OperationCancelledByUser
ResourceOperationErrorDetail   : Operation: d099fda7-4fdb-4db0-98e5-53fab1821267 was cancelled by the user.
RetryPolicyRetryCount          : 2
RetryPolicyRetryWindowInMinute : 30

ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:36:18 PM
OperationDeadline              : 12/25/2024 11:00:00 PM
OperationDeadlineType          : InitiateAt
OperationId                    : 333f8f97-32d0-4a88-9bf0-75e65da2052c
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85152
OperationState                 : Cancelled
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/pwshtest85152
ResourceOperationErrorCode     : OperationCancelledByUser
ResourceOperationErrorDetail   : Operation: 333f8f97-32d0-4a88-9bf0-75e65da2052c was cancelled by the user.
RetryPolicyRetryCount          : 2
RetryPolicyRetryWindowInMinute : 30
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls.

