### Example 1: Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier, that is App servers and ASCS instances of the system. In this example, you can see that system can be stopped by passing the VIS name and ResourceGroupName of the VIS as inputs. 

### Example 2: Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier, that is App servers and ASCS instances of the system. In this example, you can see that system can be stopped by providing the VIS Azure resource ID as InputObject to the cmdlet.

### Example 3: Stop an SAP system and its underlying Virtual Machine(s)
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg -DeallocateVM
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier and its underlying VIrtual Machine, that is App servers and ASCS instances of the system. In this example, you can see that SAP application and the VMs can be stopped by passing the VIS name, ResourceGroupName of the VIS, and DeallocateVM parameter as inputs. 

### Example 4: Soft Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg -SoftStopTimeoutSecond 300
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet soft stops the SAP application tier, that is App servers and ASCS instances of the system. In this example, you can see that system can be soft stopped by passing the VIS name, ResourceGroupName of the VIS and soft stop timeout seconds as inputs. 
