## `Get-*` cmdlet example

_Note_: for the below examples, the string "TopLevelResource" would be replaced with the name of your top-level resource (_e.g._, "VirtualMachine", "VirtualNetwork", "SqlServer"), and the string "ChildResource" would be replaced with the name of your child resource (_e.g._, "VirtualMachineExtension", "VirtualNetworkPeering", "SqlDatabase")

### Top-level resource

All top-level resources should have a `Get-*` cmdlet that allows users to list the resources in their subscription or a resource group, as well as get a specific resource. In addition, users should be able to provide the resource id of the resource they want to get, and the cmdlet will parse the string to get the necessary identity information.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Get-AzTopLevelResource [-ResourceGroupName <String>]

Get-AzTopLevelResource -ResourceGroupName <String> -Name <String>

Get-AzTopLevelResource -ResourceId <String>
```

The first parameter set has an optional `-ResourceGroupName` parameter, which allows the user to list all resources in a subscription or in a resource group. The second parameter set has required `-ResourceGroupName` and `-Name` parameters, which allows the user to get a specific resource. The third parameter set has a required `-ResourceId` parameter, which allows the user to get a specific resource by resource id.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Get, "AzTopLevelResource", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSTopLevelResource))]
    public class GetTopLevelResourceCommand : ServiceBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";"
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet )]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = new PSTopLevelResource(this.MySDKClient.TopLevelResource.Get(this.ResourceGroupName, this.Name));
                WriteObject(result);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var result = this.MySDKClient.TopLevelResource.ListByResourceGroup(this.ResourceGroupName).Select(r => new PSTopLevelResource(r));
                WriteObject(result, true);
            }
            else
            {
                var result = this.MySDKClient.TopLevelResource.List().Select(r => new PSTopLevelResource(r));
                WriteObject(result, true);
            }
        }
    }
}
```

### Child resource

All child resources should have a `Get-*` cmdlet that allows users to list the child resources under a parent resource, as well as get a specific resource. In addition, users should be able to provide the resource id of the resource they want to get, and the cmdlet will parse the string to get the necessary identity information.

#### Parameter sets

To enable the scenarios mentioned previously, the cmdlet will need three parameter sets:

```
Get-AzChildResource -ResourceGroupName <String> -TopLevelResourceName <String> [-Name <String>]

Get-AzChildResource -TopLevelResourceObject <PSTopLevelResource> [-Name <String>]

Get-AzChildResource -ResourceId <String>
```

The first parameter set has mandatory `-ResourceGroupName` and `-TopLevelResourceName` parameters to get the identity information about the parent resource, and then an optional `-Name` parameter to allow the user to either list all child resources contained in the given parent or get the specific child resource. The second parameter set has required `-TopLevelResourceObject` parameter, which can be piped from the parent `Get-*` or `Set/Update-*` cmdlet, and an optional `-Name` parameter. The third parameter set has a required `-ResourceId` parameter, which allows the user to get a specific child resource by resource id.

#### C# example

```cs
namespace Microsoft.Azure.Commands.Service
{
    [Cmdlet(VerbsCommon.Get, "AzChildResource", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSChildResource))]
    public class GetChildResourceCommand : ServiceBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopLevelResourceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSTopLevelResource TopLevelResourceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.TopLevelResourceName = resourceIdentifier.ParentResource
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.TopLevelResourceObject))
            {
                this.ResourceGroupName = this.TopLevelResourceObject.ResourceGroupName;
                this.TopLevelResourceName = this.TopLevelResourceObject.Name;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = new PSChildResource(this.MySDKClient.ChildResource.Get(this.ResourceGroupName, this.TopLevelResourceName, this.Name));
                WriteObject(result);
            }
            else
            {
                var result = this.MySDKClient.ChildResource.List(this.ResourceGroupName, this.TopLevelResourceName).Select(r => new PSChildResource(r));
                WriteObject(result, true);
            }
        }
    }
}
```