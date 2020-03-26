### Example 1: Check the availability of a Kusto cluster name which is in use

```powershell
PS C:\> Test-AzKustoClusterNameAvailability -Location 'Central US' -Name mykustocluster

NameAvailable		Name      		   			Message
------------- 			----     		  				-------
False 					mykustocluster 	    Name 'mykustocluster' with type Engine is already taken. Please specify a different name
```

The above command returns whether or not a Kusto cluster named "mykustocluster" exists in the "Central US" region.

### Example 2: Check the availability of a Kusto cluster name which is not in use

```powershell
PS C:\> Test-AzKustoClusterNameAvailability -Location 'Central US' -Name mykustocluster

NameAvailable 		Name         			    Message
------------- 			----         				    -------
 True 					mykustocluster
```

The above command returns whether or not a Kusto cluster named "mykustocluster" exists in the "Central US" region.
