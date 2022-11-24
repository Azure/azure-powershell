### Example 1: Remove Namespace
```powershell
#Creating a namespace by using New Command.
$serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace -SkuName Standard -Location eastus    
Remove-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace

#Using the Get command, we are determining whether our namespace has been deleted or not. If it is deleted Command will throw Exception.
Get-AzServiceBusNamespaceV2 -ResourceGroupName myResourceGroup -Name myNamespace
```

```output
Get-AzServiceBusNamespaceV2_Get: The Resource 'Microsoft.ServiceBus/namespaces/srgtc6' under resource group 'shubham-rg' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix
```

A Namespace was created and subsequently removed.


