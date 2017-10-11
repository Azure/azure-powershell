# AzureRM Compute Experiments

## Generic Resource Management Questions

1. Naming. Current PS naming is to use the same name everywhere (a name of VM), except Domain Name Label which is `$Name$ResourceGroupName`. CLI adds suffixes.
   - Suffix pros:
     - easy to see a resource type in the Azure portal
   - Suffix cons:
     - adds noise to resource ids
1. Resource classification, for example shared vs unique resources.
1. Location inference. Current implementation is (it's different compare to CLI)
   1. a user's specified location parameter
   1. a location of an existing resource
   1. a resource group location
   1. [future] to use current global/default user/subscription location
1. What should happen if a resource exists?
   1. should the behavior depends on a type/class of a resource?
   1. should it validate if it's compatable?
   1. should it modify the resource?
   1. should it delete the resource and create a new one?
   1. should we have two types of commands with different behavior, such as `New` and `Update`?
   1. should the cmdlet ask to modify/recreate an existing resource?
1. A Unique Domain Name Label. Should we add a subscription id as a prefix/suffix?
1. `New-Az*` cmdlets interfere a lot with `New-Azure*` cmdlets when using a tab completion.