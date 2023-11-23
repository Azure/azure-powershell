### Example 1: Start Application server instance of the SAP system
```powershell
Start-AzWorkloadsSapApplicationInstance -Name app0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:21:31
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/58527855-a695-48a5-ac11-fbc
                    74b836859*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 58527855-a695-48a5-ac11-fbc74b836859*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:18:22
Status            : Succeeded
Target            :
```

Start-AzWorkloadsSapApplicationInstance cmdlet starts the App server instance of the SAP system represented by the VIS. Currently, start action is supported for ABAP stack. In this example, you can see that instance can be started by passing the App server instance resource name, Resource Group name and VIS name as inputs. 

### Example 2: Start Application server instance of the SAP system
```powershell
Start-AzWorkloadsSapApplicationInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/applicationInstances/app0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:11:00
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/651c6f1b-db7
                    b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 651c6f1b-db7b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:08:45
Status            : Succeeded
Target            :
```

Start-AzWorkloadsSapApplicationInstance cmdlet starts the App server instance of the SAP system represented by the VIS. Currently, start action is supported for ABAP stack. In this example, you can see that instance can be started by passing the App server instance Azure resource ID as InputObject to the cmdlet.

