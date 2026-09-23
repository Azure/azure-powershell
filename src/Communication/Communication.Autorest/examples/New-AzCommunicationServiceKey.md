### Example 1: Regenerates the Secondary key using a KeyType

```powershell
New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -KeyType Secondary
```

```output
SecondaryConnectionString               SecondaryKey
-----------------------                 ----------
endpoint=<example-secondary-endpoint>   <example-secondarykey>
```

Invalidates the previous Secondary key, regenerate a new one and return it.