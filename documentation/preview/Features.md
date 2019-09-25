# New Cmdlet Features for Az 4.0 Preview
- [Cmdlet Consistency](#cmdlet-consistency)
- [Asynchronous Operations](#asynchronous-operations)
- [Parameter Simplification](#parameter-simplification)
- [Subscription Parameters](#subscription-parameters)
- [ETag Support](#etag-support)

## Cmdlet Consistency
The Az 4.0 preview uses a cmdlet generator to create many of the cmdlets.  One of the benefits of this is that cmdlets have consistent names, consistent parameter types, and consistent functionality, both within a service and between services.  
Some of the new features consistently shared by cmdlets include the following.
- Piping from Get- cmdlets for a resource into other Action cmdlets for the same resource
- Piping from Get-AzResource to all other resource cmdlets
- Subscription parameters across all cmdlets that operate on resources
- Consistent support for interactive and piping parameter sets across all cmdlets
- Consistent simplification of parameters
- Consistent use of ShouldProcess
- Consistent output types for similar cmdlets - (e.g. Remove-* always returns nothing, and always has a PassThru parameter)
- [Future]: Consistent support for resource modification cmdlets across RPs - in a future release, cmdlets will all support both Replace and PATCH semantics for modifying resources - across all resource providers. 

Since existing Az cmdlets often inconsistently apply features and naming conventions, the added consistency in the preview cmdlets mean that there are significant breaking changes from existing cmdlets. In this case, breaking changes are necessary in order to achieve a consistent user experience between cmdlets, and between services.

## Asynchronous Operations
New cmdlets contain several new features related to asynchronous operations, including 
- Support for AsJob
- Support for NoWait
- Cancellation Support

### AsJob Support
All cmdlets that perform time-consuming operations in Azure have built-in support for running as a PowerShell Job using the `AsJob` parameter. Invoking a cmdlet with the `AsJob` parameter will return immediately and create a background job that executes the cmdlet.  You can use built-in PowerShell cmdlets (`Wait-Job`, `Receive-Job`, `Get-Job`) to check the progress of the background job, and return the results when the Job is complete.  In the new cmdlets, `AsJob` support creates lightweight background jobs that consume fewer system resources.

### NoWait Support
All cmdlets that perform time-consuming operations in Azure have built-in support for starting the operation without tracking results using the `NoWait` parameter.
In cases where the executing script is resource constrained, or it is not necessary to know the  outcome of the operation, you can use the NoWait parameter to simply start the given operation in Azure, and return immediately, withotu creating background jobs. 

### Cancellation Support
All cmdlets have built-in support for `Stop Processing`, which means that cmdlet execution can be halted at any time.  In a PowerShell or PowerShell Core session, simply 
press Command-. during cmdlet execution, and the cmdlet will stop processing and return control to the user.

## parameter Simplification
All cmdlets have simplified parameters as much as possible, and where simplification is not possible (such as when a cmdlet allows specifying a list or key-value paris of complex objects), the cmdlets support providing inline Hashtables rather than having to construct the underlying object.  This measn that every cmdlet has at least one parameter set where all parameters cna be specified from the command line without running any prior cmdlets, or creating any objects.

This is a radical departure from existing cmdlets, as rather than creating a set of objects to pass to a single Create or Update cmdlet, you can always simply provide parameters by typing on the command line.  This allows for much more natural interactive use of the cmdlets.

## Subscription Parameters
All cmdlets now have a SubscriptionId parameter, which cna be used to run operatiosn against any chosen subscription.  In addition, all Get-* cmdlets allow specifying multiple subscriptiosn with other parameters, allowing you to search across multiple subscriptiosn for resources that meet certain characteristics.  You can use `$PSDefaultParameterValues` settings to set a default set of subscriptiosn to use with your GEt-* cmdlets.

## ETag support
Across all creation and update cmdets, you cna use Etags to ensure consistency of updates.  Resources are returned with an ETag property, and you can specify and ETag value on update to require the server resource to update only if the resource on the server matches the given ETag.  This allows scripts to use Get-Update retry loops to ensure consistent update under simultaneous access to cloud scale.