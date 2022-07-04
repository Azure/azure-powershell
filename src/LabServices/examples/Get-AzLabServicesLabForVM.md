### Example 1: Get the lab for a Virtual machine.
```powershell
Get-AzLabServicesLabForVm -ResourceId '/subscriptions/<SubscriptionID>/resourceGroups/<GroupName>/providers/Microsoft.LabServices/labs/<labName>/virtualMachines/<VMName>'
```

```output
Location Name                Type
-------- ----                ----
westus2  labName             Microsoft.LabServices/labs
```

Gets the lab based on the VM Id.
