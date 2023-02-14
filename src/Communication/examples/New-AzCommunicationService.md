### Example 1: Create a ACS resource

```powershell
<<<<<<< HEAD
New-AzCommunicationService -ResourceGroupName ContosoResourceProvider1 -Name ContosoAcsResource1 -DataLocation UnitedStates -Location Global
```

```output
=======
PS C:\> New-AzCommunicationService -ResourceGroupName ContosoResourceProvider1 -Name ContosoAcsResource1 -DataLocation UnitedStates -Location Global

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name           Type                                          AzureAsyncOperation
-------- ----           ----                                          -------------------
Global   ContosoAcsResource1 Microsoft.Communication/communicationServices
```

Creates a ACS resource using the specified parameters.
