### Example 1: List all AMS Instances
```powershell
Get-AzWorkloadsMonitor
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
suha-1606-ams2 suha-0802-rg1     mrg-15061                          eastus2euap Failed
```

Lists all AMS Instances in the subscription

### Example 2: List all AMS instances in a Resource Group
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
```

List all AMS instances in a Resource Group


### Example 3: Get Information about an AMS Instance
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg -Name ad-ams
```

```output
Name   ResourceGroupName ManagedResourceGroupConfigurationName Location ProvisioningState
----   ----------------- ------------------------------------- -------- -----------------
ad-ams ad-ams-rg         sapmonrg-u2mtiw                       eastus   Succeeded
```

Gets information about a specific AMS instance in a resource group

### Example 4: Get Information about an AMS Instance by Id
```powershell
 Get-AzWorkloadsMonitor -InputObject '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-1606-ams2'
```

```output
Name           ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----           ----------------- ------------------------------------- --------    -----------------
suha-1606-ams2 suha-0802-rg1     mrg-15061                             eastus2euap Failed


```

Get Information about an AMS Instance by ArmId