### Example 1: Stop Database instance of the SAP system
```powershell
Stop-AzWorkloadsSapDatabaseInstance -Name db0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:45:40
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/881d4ff9-1d38-4596-b215-28e
                    77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 881d4ff9-1d38-4596-b215-28e77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:43:32
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapDatabaseInstance cmdlet stops the Database instance of the SAP system represented by the VIS. Currently stop action is supported for SAP HANA Database only. In this example, you can see that database can be stopped by passing the DB instance resource name, ResourceGroupName and VIS name as inputs. 

### Example 2: Stop Database instance of the SAP system
```powershell
Stop-AzWorkloadsSapDatabaseInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/databaseInstances/db0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:45:40
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/881d4ff9-1d38-4596-b215-28e
                    77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 881d4ff9-1d38-4596-b215-28e77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:43:32
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapDatabaseInstance cmdlet stops the Database instance of the SAP system represented by the VIS. Currently stop action is supported for SAP HANA Database only. In this example, you can see that database can be stopped by providing the DB instance Azure resource ID as InputObject to the cmdlet. 