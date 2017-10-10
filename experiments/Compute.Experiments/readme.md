# AzureRM Compute Experiments

## Generic Resource Management Questions

1. Naming. Current PS naming is use the same name everywhere (a name of VM), except Domain Name Label which is `$Name$ResourceGroupName`. CLI adds suffixes.
   - Suffix pros:
     - easy to see a resource type in the Azure portal
   - Suffix cons:
     - adds noise to resource ids
1. Resource classification, for example shared vs unique resources.
1. Location inference. Current implementation (it's different compare to CLI)
   1. user's specified
   1. existing resource location
   1. resource group location
   1. [future] use current global/default user's/subscription location
