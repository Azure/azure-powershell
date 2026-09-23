### Example 1: Poll the status of operations performed on a batch of virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Get-AzComputeScheduleOperationStatus -Location "eastus2euap" -Correlationid "bbb34b32-0ca1-473f-b53d-d06148d0d1fa" -OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:09:20 AM
OperationDeadline              : 12/18/2024 5:08:36 AM
OperationDeadlineType          : InitiateAt
OperationId                    : d099fda7-4fdb-4db0-98e5-53fab1821267
OperationOpType                : Start
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exesta83600
OperationState                 : Succeeded
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exesta83600
ResourceOperationErrorCode     :
ResourceOperationErrorDetail   :
RetryPolicyRetryCount          : 3
RetryPolicyRetryWindowInMinute : 30

ErrorCode                      :
ErrorDetail                    :
OperationCompletedAt           : 12/18/2024 5:04:18 AM
OperationDeadline              : 12/18/2024 5:03:15 AM
OperationDeadlineType          : InitiateAt
OperationId                    : 333f8f97-32d0-4a88-9bf0-75e65da2052c
OperationOpType                : Hibernate
OperationResourceId            : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exeHib80440
OperationState                 : Succeeded
OperationSubscriptionId        : ed5d2ee7-ede1-44bd-97a2-369489bbefe4
OperationTimezone              :
ResourceId                     : /subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/exeHib80440
ResourceOperationErrorCode     :
ResourceOperationErrorDetail   :
RetryPolicyRetryCount          : 3
RetryPolicyRetryWindowInMinute : 30
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls

