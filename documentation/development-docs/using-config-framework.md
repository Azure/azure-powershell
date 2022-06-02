# Using Config Framework

- [Overview](#overview)
- [Guide: How to Add a New Config](#guide-how-to-add-a-new-config)
- [Guide: How to Get the Value of a Config](#guide-how-to-get-the-value-of-a-config)
- [Special cases](#special-cases)
  - [Applies to](#applies-to)
  - [Validation](#validation)
  - [Environment variable](#environment-variable)

## Overview

The config framework was introduced in Az 8, May 2022 to set up a standard of how configs are used by both developers and end users of Azure PowerShell.

This document will go over 2 most common scenarios for developers. As for how to set configs please refer to [Update-AzConfig](https://docs.microsoft.com/powershell/module/az.accounts/update-azconfig).

## Guide: How to Add a New Config

### Step 1: Define the Config

#### Simple Config Definition

For most cases, creating an instance of [`SimpleTypedConfig<TValue>`](https://github.com/Azure/azure-powershell/blob/main/src/Accounts/Authentication/Config/Models/SimpleTypedConfig.cs) is the easist way to define a config. The syntax is:

```csharp
SimpleTypedConfig<TValue>.SimpleTypedConfig(string key, string helpMessage, TValue defaultValue, [string environmentVariable = null], [IReadOnlyCollection<AppliesTo> canApplyTo = null])
```
where
- `TValue` is the type of the value of the config, for example `int` or `bool`.
- `key` is the unique key of the config. It is used when user gets or sets the config.
  - It must be defined in [src/shared/ConfigKeys.cs](https://github.com/Azure/azure-powershell/blob/main/src/shared/ConfigKeys.cs) so that it can be referenced in any project.
  - It is reused as a parameter name of cmdlets that operate on configs, for example `Get-AzConfig`, so it must follow the naming conventions. See [Parameter Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md#parameter-best-practices).
- `helpMessage` is the help message or description of the config. 
  - It is reused as the help message of the corresponding PowerShell parameter in documents.
- `defaultValue` is the default value of the config. Used for basic type validation when setting the config.
- (Optional) `environmentVariable` sets to which environment variable the config is connected. Once set, the config framework will pick up the variable automatically.
  - Note: the config must correspond to **one single** environment variable and it must not require special logic to parse the value. Otherwise please check out [todo].
- (Optional) `canApplyTo` defines at which levels the config can apply to. There are three levels in total: `AppliesTo.Az`, `AppliesTo.Module`, `AppliesTo.Cmdlet`. By default all of them are included. For more details, see [todo].

Here is a sample definition:

```csharp
new SimpleTypedConfig<string>(
    ConfigKeys.DefaultSubscriptionForLogin,
    Resources.HelpMessageOfDefaultSubscriptionForLogin,
    string.Empty,
    "AZURE_ENV_VAR_FOR_SUBSCRIPTION",
    new[] { AppliesTo.Az });
```

#### Standard Config Definition

The more standard way to define a config is to create a class inheriting [`TypedConfig<TValue>`](https://github.com/Azure/azure-powershell/blob/main/src/Accounts/Authentication/Config/Models/TypedConfig.cs). It should be placed at [`src/Accounts/Authentication/Config/Definitions/`](https://github.com/Azure/azure-powershell/tree/main/src/Accounts/Authentication/Config/Definitions), where you can also find other examples of configs.

Like simple definition, you will need to override some key properties, which will not be repeated here.

Here is a sample definition:

```csharp
internal class DisplayBreakingChangeWarningsConfig : TypedConfig<bool>
{
    public override object DefaultValue => true;

    public override string Key => ConfigKeys.DisplayBreakingChangeWarning;

    public override string HelpMessage => Resources.HelpMessageOfDisplayBreakingChangeWarnings;
}
```

Definining configs in the standard way is more customizable than the simple way, for example when it comes to validating values and parsing enviroment variables. For more, see [todo].

### Step 2: Register the Config

Either way the config is defined, instanciate it and call [`IConfigManager.RegisterConfig(ConfigDefinition config)`](https://github.com/Azure/azure-powershell-common/blob/8d70507d41a3698b5b131df61f14e329d7a6eb41/src/Authentication.Abstractions/Interfaces/IConfigManager.cs#L30) in [`ConfigInitializer.RegisterConfigs(IConfigManager configManager)`](https://github.com/Azure/azure-powershell/blob/304e15c84071fee02622734c4e5f12c05baa77d2/src/Accounts/Authentication/Config/ConfigInitializer.cs#L192). For example:

```csharp
configManager.RegisterConfig(new DisplayBreakingChangeWarningsConfig());
```

Up until now, you are able to test this new config with `Get-AzConfig`, `Update-AzConfig` and `Clear-AzConfig`. For more, run `Get-Help Get-AzConfig`.

### Step 3: Regenerate Help Documents

As mentioned in Step 1, each config maps to a parameter of `Get-AzConfig`, `Update-AzConfig`, and `Clear-AzConfig`, so it is important to regenerate help documents after introducing new configs. Here are [the instructions](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/help-generation.md#updating-help-after-making-cmdlet-changes).

## Guide: How to Get the Value of a Config

Now that you have defined and registered the config, it is time to get its value. First you need to get the singleton of `IConfigManager`, then use `T GetConfigValue<T>(string key, object invocation = null);`. For example:

```csharp
AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager);
string subscriptionFromConfig = configManager.GetConfigValue<string>(ConfigKeys.DefaultSubscriptionForLogin, MyInvocation);
```

Note that although `invocation` is optional, if the config can apply to either `AppliesTo.Module` or `AppliesTo.Cmdlet` (see [todo]), it must be `MyInvocation`. 

## Special Cases

### Limit the Possibility of AppliesTo

### Validation of Config Value

### Environment Variables



- (optional) `string EnvironmentVariableName`
  - If the config can also be set by an environment variable, and the value of the environment variable can be parsed as the value type `TValue`, override this property.
  - For more complicated scenarios of using environment variables, such as you need to customize the logic of parsing it, do not use this property. See [todo] below.

### Use 
