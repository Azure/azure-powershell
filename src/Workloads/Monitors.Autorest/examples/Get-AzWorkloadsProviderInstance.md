### Example 1: List all providers in an AMS Instance
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams
```

```output
Name              ResourceGroupName ProvisioningState IdentityType
----              ----------------- ----------------- ------------
Hana-1-test       ad-ams-rg         Failed            
hana-test-2       ad-ams-rg         Succeeded         
prov-1            ad-ams-rg         Failed            
hana-test         ad-ams-rg         Failed            
SAP-NETWEAVER     ad-ams-rg         Failed            
HA3-HANA-HighAvl  ad-ams-rg         Succeeded         
lh-28022023-host  ad-ams-rg         Failed            
as1-sysdb         ad-ams-rg         Succeeded         
h2-test           ad-ams-rg         Failed            
```

 List all the providers created for an AMS Instance

### Example 2: Get information about an AMS Provider
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams -Name hana-test-2
```

```output
Name        ResourceGroupName ProvisioningState IdentityType
----        ----------------- -----------------  ------------
hana-test-2 ad-ams-rg         Succeeded         
```

Gets information about a specific AMS Provider

### Example 3: Get information about an AMS Provider by Id
```powershell
Get-AzWorkloadsProviderInstance -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/ams_mon/providerInstances/suha-db2-1"
```

```output

Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
suha-db2-1 suha-0802-rg1     Succeeded
```

Get information about an AMS Provider by ArmId