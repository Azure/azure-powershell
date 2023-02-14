### Example 1: List existing CommunicationServices for a Subscription

```powershell
<<<<<<< HEAD
Get-AzCommunicationService -SubscriptionId 73fc3592-3cef-4300-5e19-8d18b65ce0e8
```

```output
=======
PS C:\> Get-AzCommunicationService -SubscriptionId 73fc3592-3cef-4300-5e19-8d18b65ce0e8

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name             Type                                          AzureAsyncOperation
-------- ----             ----                                          -------------------
global   ContosoResource1   Microsoft.Communication/communicationServices
global   ContosoResource4   Microsoft.Communication/communicationServices
global   ContosoResource3   Microsoft.Communication/communicationServices
global   ContosoResource5   Microsoft.Communication/communicationServices
```

Returns a list of all ACS resources under that subscription.

### Example 2: Get infomation on specified Azure Communication resource

```powershell
<<<<<<< HEAD
Get-AzCommunicationService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
=======
PS C:\> Get-AzCommunicationService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Type                                          AzureAsyncOperation
-------- ----           ----                                          -------------------
Global   ContosoAcsResource1 Microsoft.Communication/communicationServices
```

Returns the information on an ACS resource, if one matching provided parameters is found.
