### Example 1: Update an existing ACS resource to have tags

```powershell
<<<<<<< HEAD
Update-AzCommunicationService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1"}
```

```output
=======
PS C:\> Update-AzCommunicationService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Type                                          AzureAsyncOperation
-------- ----           ----                                          -------------------
Global   ContosoAcsResource1 Microsoft.Communication/communicationServices
```

Attaches the given tags to the specified ACS resource.
