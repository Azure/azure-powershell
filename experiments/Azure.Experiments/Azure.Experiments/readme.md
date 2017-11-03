## Stages

1. Get a current Azure state. Each resource has a function to get information from Azure.
   The function is an asynchronous operation.
2. Analyze the state. For example, extract a location from the state.
   The analysis is a syncronous operation. On this stage, a user interaction may be required.
   All decisions has to be made on this stage.
3. Create a graph of create/update operations. This operation is synchronous.
4. Execute the graph. This operation is asynchronous and may require a progress bar, AsJob etc.
   It can also create several resources simultaneously.

## Policies

```cs
interface IInfoMap
{
    Info Get<Info>(IResourcePolicy<Info> info)
        where Info : class;
}
interface IResourcePolicy
{
}
interface IResourcePolicy<Info> : IResourcePolicy
    where Info : class
{
    IEnumerable<IResourcePolicy> Dependencies { get; }
    string GetLocation(Info info);
    Task<Info> CreateAsync(Context context, Info info);
}
interface IResourcePolicy<Info, Id> : IResourcePolicy<Info>
    where Info : class
{
    Task<Info> GetAsync(Context context, Id id);
}
sealed class ManagedResourceId
{
    string ResourceGroupName { get; }
    string Name { get; }
}
interface IManagedResourcePolicy<Info> : IResource<Info, ManagedResourceId>
{
	ResourceGroupPolicy
    void UpdateInfo(Info info, IInfoMap infoMap);
}
interface IResourceGroupPolicy : IResourcePolicy<ResourceGroup, string>
{
}
interface ISubresource<Info, ParentInfo> : IResource
{
    IResource<ParentInfo> Parent { get; }
    Info Get(ParentInfo parentInfo);
    void Set(ParentInfo info, Info info);
}
```