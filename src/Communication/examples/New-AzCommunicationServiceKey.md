### Example 1: Regenerates the Primary key using a IRegenerateKeyParameters hashtable

```powershell
PS > New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Parameter @{KeyType="Primary"}

PrimaryConnectionString                                                                                                                                     PrimaryKey
-----------------------                                                                                                                                     ----------
endpoint=https://contosoacsresource1.communication.azure.com/;accesskey=00bX0qrur6RrEx1tN8/4ibx6wITSET1XsRZgUCiOcGZNeL76TLhGJEEJbj69msOH1PZ/ZcQpyWQYIceHoFNfWw== 00bX0qrur6RrEx1tN8/4ibx6wITSET1XsRZgUCiOcGZNeL76TLhGJEEJbj69msOH1PZ/ZcQpyWQYIceHoFNfWw==
```

Invalidates the previous Primary key, regenerate a new one and return it.

### Example 2: Regenerates the Secondary key using a KeyType

```powershell
PS C:\> New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -KeyType Secondary

SecondaryConnectionString                                                                                                                                   SecondaryKey
-------------------------                                                                                                                                   ------------
endpoint=https://contosoacsresource1.communication.azure.com/;accesskey=md3tW8+ZaQpflaPLe0DMutXFqFtZIUI57lP3Fr29JR11BLdJoS8wlRCV4KQItNzdxu6RuCYMTGUy9kOPF5b1eA== md3tW8+ZaQpflaPLe0DMutXFqFtZIUI57lP3Fr29JR11BLdJoS8wlRCV4KQ
```

Invalidates the previous Secondary key, regenerate a new one and return it.
