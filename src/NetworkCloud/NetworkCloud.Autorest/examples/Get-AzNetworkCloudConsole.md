### Example 1: List virtual machine's consoles
```powershell
Get-AzNetworkCloudConsole -SubscriptionId subscriptionId -VirtualMachineName virtualMachineName -ResourceGroupName resourceGroupName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy      SystemDataLastModifiedByType AzureAsyncOperation
-------- ----    ------------------- -------------------  ------------------------ ------------------------  ----------------------------  ----------------------------
eastus   default 06/27/2023 21:32:03  <user>              User                     06/27/2023 21:32:41       <identity>                    Application
```

This command gets all consoles for the provided virtual machine.

### Example 2: Get virtual machine's console
```powershell
Get-AzNetworkCloudConsole -Name consoleName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -VirtualMachineName virtualMachineName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy      SystemDataLastModifiedByType AzureAsyncOperation
-------- ----    ------------------- -------------------  ------------------------ ------------------------  ----------------------------  ----------------------------
eastus   default 06/27/2023 21:32:03  <user>              User                     06/27/2023 21:32:41       <identity>                    Application
```

This command gets a specific console of the provided virtual machine.
