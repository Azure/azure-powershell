### Example 1: Get deployment manifest for a DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
Cloud                                      : AzureCloud
ConnectionIntent                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
Location                                   : eastus2euap
ResourceId                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
ResourceName                               : winfield-ps-test
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command gets the deployment manifest for the DisconnectedOperation `winfield-ps-test` in resource group `winfield-demo-rg-2`.