### Example 1: Regenerates the Primary key using a IRegenerateKeyParameters hashtable

```powershell
New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Parameter @{KeyType="Primary"}
```

```output
PrimaryConnectionString              PrimaryKey
-----------------------              ----------
endpoint=<example-primary-endpoint>  <example-primarykey>
```

Invalidates the previous Primary key, regenerate a new one and return it.

### Example 2: Regenerates the Secondary key using a KeyType

```powershell
New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -KeyType Secondary
```

```output
SecondaryConnectionString               SecondaryKey
-----------------------                 ----------
endpoint=<example-secondary-endpoint>   <example-secondarykey>
```

Invalidates the previous Secondary key, regenerate a new one and return it.
