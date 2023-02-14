### Example 1: Fetch the Key for the specified Communcation service

```powershell
<<<<<<< HEAD
Get-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1
```

```output
=======
PS C:\> Get-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
PrimaryConnectionString              PrimaryKey            SecondaryConnectionString               SecondaryKey
-----------------------              ----------            -----------------------                 ----------
endpoint=<example-primary-endpoint>  <example-primarykey>  endpoint=<example-secondary-endpoint>   <example-secondarykey>
```

Displays the ConnectionString and Key for the specified Communcation service.
