# Strategies

## Design

## Resource Management

[Rm/](Rm/).

- [Rm/Meta/](Rm/Meta/) is meta information about Azure resources which is missed in Azure SDK.
- [Rm/Config/](Rm/Config/) is a resource configuration graph (DAG).
- [Rm/State/](Rm/State/) is a resource graph state, for example a state of resources in Azure. 

## Wish List

### AutoRest

1. An SDK serializer
   1. should be generic and belong to a runtime library
   1. should have a function to serialize to `JToken` instead of `string`.
1. API version
   1. should be discoverable from meta information, for example from a model, an operation, and/or
      a client.
1. Resource model should implement an `IResourceModel` interface, for example
   ```cs
   interface IResourceModel
   {
         [JsonProperty("name")]
         string Name { get; set; }

         [JsonProperty("location")]
         string? Location { get; set; }

         IDictionary<string, object> GetProperties();
   }
   ```
1. Resource operations classes should implement an `IResourceOperations<TModel>` interface, for example
   ```cs
   interface IResourceOperations<TModel>
       where TModel : IResourceModel
   {
         Task<TModel> BeginCreateOrUpdate(
            string name, string resourceGroupName, TModel model);
   }
   ```
1. `secureString` should be Swagger type/format.
1. Another type for Swagger `id[ResourceType]`.
