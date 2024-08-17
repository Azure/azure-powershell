# List all commands

```powershell

Get-Command -Module Az.Workloads

```

# Get help of the cmdlet.

```powershell

Get-Help Get-help New-AzWorkloadsMonitor -Full

```

# Request Payload

You can add `-Debug` parameter to each cmdlet to display the request payload. 

# Create workloads sap virtual instance

```powershell

# CreateWithDiscovery

New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -Location eastus2 -Environment 'Prod' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DHRUV-SVI-SCALE-TEST-AVSDISCOVERY8.2.202109120216FEB5738-INFRA/providers/Microsoft.Compute/virtualMachines/a12appvm0'

# CreateWithJsonTemplatePath

New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L02 -Location eastuseuap -Environment 'Prod' -SapProduct 'S4HANA' -Configuration .\test\configuration.json -Tag @{'k1'='v1'} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L02-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'='v1'}

```

+ Get-AzWorkloadsSapVirtualInstance: Get or list workloads monitor
+ Update-AzWorkloadsSapVirtualInstance: Update a workloads monitor
+ Remove-AzWorkloadsSapVirtualInstance: Remove a workloads monitor
+ Start-AzWorkloadsSapVirtualInstance: start a workloads monitor
+ Stop-AzWorkloadsSapVirtualInstance: stop a workloads monitor
```
