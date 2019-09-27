---
RFC: RFC0006
Author: Mark Cowlishaw
Status: InReview
SupercededBy:
Version: 1.0
---

# Consistent Create and Modify Cmdlets Across Services

The cmdlets for each RP should provide the same capability for creating and updating resources, but the underlying APIs provide a mix of PUT and PATCH semantics that make cmdlet consistency difficult.  In the face of this inconsistency, cmdlets should implement a consistent cmdlets for resource creation and modificationa s follows:

- All RPs should have a `New` cmdlet, which by default creates a new resource only if no current resource exists.
- The `New` cmdlet should have a `-Overwrite` option which overrides this behavior to destructively create or replace a new resource as specified in the parameters.
- All RPS should implement an `Update` cmdlet which allows the user to set one or mroe properties of the resource to update - only the specified properties will be changed on the resource in Azure

## Motivation

Users will get the same capabilities for all creation and modification cmdlets across Azure services, allowing them to:

- Create resources destructively or non-destructively
- Update resources by modifying only the parts of the resource they want to change, leaving other properties untouched (PATCH semantics)

### Creation scenarios
```code
As a user creating resources in Azure
I can create a new resource and specify whether the creation should replace any existing resource (or not)
so that I can have a consistent creation experience across all Azure resources
```

## User Experience

Destructive creation of resources

```PowerShell
New-AzKeyVault <parameters> -Overwrite
```

Non-destructive creation of resources

```PowerShell
New-AzKeyVault <parameters> 
```

### Modification scenarios
```code
As a user modifying resources in Azure
I can modify ay property of a resource without having to specify properties of the resource unrelated to my change
so that I can easily modify only the properties I want to change, for any resource iN Azure
```

## User Experience


```PowerShell
Update-AzKeyVault -SkuName "NewSku"
```


## Comments and Questions

- Are the cmdlet verbs `New` and `Update` appropriate for the creation and modification scenarios, or would you prefer other verbs in addition (or instead of these), for example `Set`

- Are there any creation or modifications cenarios that would not be covered by the proposed cmdlet changes?
