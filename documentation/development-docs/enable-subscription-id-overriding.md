# How to: Enable Overriding Subscription ID in Your Module

- [Background](#background)
- [Limitation](#limitation)
- [Steps](#steps)
  - [Add `SupportsSubscriptionId` Attribute](#add-supportssubscriptionid-attribute)
  - [Regenerate Help Documents](#regenerate-help-documents)
- [Notes / Troubleshooting](#notes--troubleshooting)
  - [Your Cmdlet Implements `IDynamicParameters`](#your-cmdlet-implements-idynamicparameters)
  - [Static Analysis Fails: Parameters are Removed](#static-analysis-fails-parameters-are-removed)

## Background

Working with **multiple Azure subscriptions** can be inconvenient in Azure PowerShell, because users has to keep switching the context, which is why we introduced a mechanism that can easily turn your module **multiple-subscription-friendly** in [Az v6.4.0](https://github.com/Azure/azure-powershell/blob/isra-fel-patch-1/ChangeLog.md#640---september-2021). For example

```powershell
# Legacy (switch subscription first)
Select-AzSubscription -SubscriptionId "00000000-0000-0000-0000-000000000000"
New-AzAksCluster ...

# New (just -SubscriptionId)
New-AzAksCluster ... -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

The new design does not only simplify scripts, but also runs more efficiently, as it saves 1 cmdlet execution per subscription switching.

## Limitation

The feature was designed to balance between "supporting more login scenarios" and "being easy to use". Here are the limitations:

- **One subscription, multiple accounts**: when you login Azure PowerShell with multiple user accounts, and there is one subscription owned by more than one of them, it is obvious that `-SubscriptionId` is not enough to tell which context you wish to use, but we do not want to introduce more parameters, so this is not supported.
  - Work-around is to log in with only 1 user account.
- **Management-plane only**: as subscription may not make as much sense in data-plane as in management-plane, this feature is suggested to be applied to management-plane cmdlets only.

## Steps

Here are the two simple steps to enable this for your module:

### Add `SupportsSubscriptionId` Attribute

You can either add it to the cmdlet base class, which applies to all the derived cmdlets; or to individual cmdlets.

```csharp
[SupportsSubscriptionId] // Adding to base class: all cmdlets that inherit `KubeCmdletBase` will benefit
public abstract class KubeCmdletBase : AzureRMCmdlet { /* ... */ }

[SupportsSubscriptionId] // Adding to cmdlet class: only this cmdlet will benefit
public class NewAzureRmAks : CreateOrUpdateKubeBase { /* ... */ }
```

### Regenerate Help Documents

By adding the attribute your cmdlet(s) get a `[-Subscription <String>]` parameter, so the help documents need to be regenerated.
Please refer to [Azure PowerShell Help Generation](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/help-generation.md) for more details.


## Notes / Troubleshooting

This design is compatible with most modules, however, there are some uncommon case you should be careful.

### Your Cmdlet Implements `IDynamicParameters`

The `-SubscriptionId` parameter is added via `IDynamicParameters` interface, so if your cmdlet has already implemented it, make sure:

1. `GetDynamicParameters()` is decorated with [`new` modifier](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-modifier).
1. Call `base.GetDynamicParameters()` and combine the results in your `GetDynamicParameters()`.

A sample implementation:

```csharp
public new object GetDynamicParameters()
{
    var parameters = base.GetDynamicParameters() as RuntimeDefinedParameterDictionary;
    // here should be customized logic to construct `RuntimeDefinedParameter` objects,
    // and call `parameters.Add()`
    return parameters;
}
```

### Static Analysis Fails: Parameters are Removed

This happens when the constructor of your cmdlet throws an exception -- normally constructors are not called during static analysis, but things are different if this feature is enabled.
Make sure you use `BeginProcessing()` for heavy work.

```csharp
// DO NOT
public StorageSyncClientCmdletBase()
{
    InitializeComponent(); // do stuff that throws exception in test environment, like an API call
}

// DO
public StorageSyncClientCmdletBase()
{
}

protected override void BeginProcessing()
{
    base.BeginProcessing();
    InitializeComponent();
}
```
