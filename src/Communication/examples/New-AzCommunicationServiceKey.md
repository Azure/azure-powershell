### Example 1: Regenerates the Primary key using a IRegenerateKeyParameters hashtable

```powershell
<<<<<<< HEAD
New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Parameter @{KeyType="Primary"}
```

```output
=======
PS > New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Parameter @{KeyType="Primary"}

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
PrimaryConnectionString              PrimaryKey
-----------------------              ----------
endpoint=<example-primary-endpoint>  <example-primarykey>
```

Invalidates the previous Primary key, regenerate a new one and return it.

### Example 2: Regenerates the Secondary key using a KeyType

```powershell
<<<<<<< HEAD
New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -KeyType Secondary
```

```output
=======
PS C:\> New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -KeyType Secondary

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
SecondaryConnectionString               SecondaryKey
-----------------------                 ----------
endpoint=<example-secondary-endpoint>   <example-secondarykey>
```

Invalidates the previous Secondary key, regenerate a new one and return it.
