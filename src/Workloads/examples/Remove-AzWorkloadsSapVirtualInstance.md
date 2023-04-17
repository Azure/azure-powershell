### Example 1: Remove a Virtual Instance for SAP solutions (VIS)
```powershell
Remove-AzWorkloadsSapVirtualInstance -Name X51 -ResourceGroupName X51Test
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           :
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/EASTUS/operationStatuses/1433bd12-7bb0-403d-a11c-31194d7bd4
                    f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Message           :
Name              : 1433bd12-7bb0-403d-a11c-31194d7bd4f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 14:50:32
Status            : Succeeded
Target            :
```

Remove-AzWorkloadsSapVirtualInstance cmdlet deletes the VIS, associated child instances (ASCS, Application Instance and Database Instance) and Managed Resource Group. This action doesnt delete the underlying physical Infrastructure resources such as Application resource group and underlying components such as Virtual Machines, Disks, etc. Its required that customer deletes physical resources themselves. Delete of a VIS  is permanent action and cannot be reverted. In this example, you can see that VIS can be deleted by passing the VIS name and Resource Group as inputs.

### Example 2: Remove a Virtual Instance for SAP solutions (VIS)
```powershell
Remove-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/X51Test/providers/Microsoft.Workloads/sapVirtualInstances/X51
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           :
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/EASTUS/operationStatuses/1433bd12-7bb0-403d-a11c-31194d7bd4
                    f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Message           :
Name              : 1433bd12-7bb0-403d-a11c-31194d7bd4f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 14:50:32
Status            : Succeeded
Target            :
```

Remove-AzWorkloadsSapVirtualInstance cmdlet deletes the VIS, associated child instances (ASCS, Application Instance and Database Instance) and Managed Resource Group. This action doesnt delete the underlying physical Infrastructure resources such as Application resource group and underlying components such as Virtual Machines, Disks, etc. Its required that customer deletes physical resources themselves. Delete of a VIS  is permanent action and cannot be reverted. In this example, you can see that VIS can be deleted by passing the Virtual Instance for SAP solutions (VIS) Azure resource ID as InputObject to the cmdlet.

