# Using Config Framework

- [Overview](#overview)
- [Guide: How to Add a New Config](#guide-how-to-add-a-new-config)
  - [Step 1: Define the Config](#step-1-define-the-config)
    - [Simple Config Definition](#simple-config-definition)
    - [Standard Config Definition](#standard-config-definition)
  - [Step 2: Register the Config](#step-2-register-the-config)
  - [Step 3: Regenerate Help Documents](#step-3-regenerate-help-documents)
- [Guide: How to Get the Value of a Config](#guide-how-to-get-the-value-of-a-config)
- [Customizing Config Definitions](#customizing-config-definitions)
  - [About AppliesTo](#about-appliesto)
  - [Validation of Config Value](#validation-of-config-value)
  - [Parsing Environment Variables](#parsing-environment-variables)

## Overview

The config framework was introduced in Az 8, May 2022 to set up a standard of how configs are used by both developers and end users of Azure PowerShell.

This document will go over two most common scenarios for developers. As for how to use the config framework in PowerShell please refer to [Update-AzConfig](https://docs.microsoft.com/powershell/module/az.accounts/update-azconfig).

## Guide: How to Add a New Config

### Step 1: Define the Config

#### Simple Config Definition

For most cases, creating an instance of [`SimpleTypedConfig<TValue>`](https://github.com/Azure/azure-powershell/blob/main/src/Accounts/Authentication/Config/Models/SimpleTypedConfig.cs) is the easiest way to define a config. The syntax is:

```csharp
SimpleTypedConfig<TValue>.SimpleTypedConfig(string key, string helpMessage, TValue defaultValue, [string environmentVariable = null], [IReadOnlyCollection<AppliesTo> canApplyTo = null])
```
where
- `TValue` is the type of the value of the config, for example `int` or `bool`.
- `key` is the unique key of the config. It is used when user gets or sets the config.
  - It must be defined in [src/shared/ConfigKeys.cs](https://github.com/Azure/azure-powershell/blob/main/src/shared/ConfigKeys.cs) so that it can be referenced in any project.
    - If the config will be used in the [azure-powershell-common] solution, it must also be defined in [src/Authentication.Abstractions/Models/ConfigKeysForCommon.cs](https://github.com/Azure/azure-powershell-common/blob/main/src/Authentication.Abstractions/Models/ConfigKeysForCommon.cs).
  - It is reused as a parameter name of cmdlets that operate on configs, for example `Get-AzConfig`, so it must **follow the PowerShell naming conventions**. See [Parameter Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md#parameter-best-practices).
- `helpMessage` is the help message or description of the config. 
  - It is reused as the help message of the corresponding PowerShell parameter in documents.
- `defaultValue` is the default value of the config. Used for basic type validation when setting the config.
- _(Optional)_ `environmentVariable` sets to which environment variable the config is connected. Once set, the config framework will pick up the variable automatically.
  - Note: the config must correspond to **one single** environment variable and it must not require special logic to parse the value. Otherwise please check out [Parsing Environment Variables](#parsing-environment-variables).
- _(Optional)_ `canApplyTo` defines at which levels the config can apply to. There are three levels in total: `AppliesTo.Az`, `AppliesTo.Module`, `AppliesTo.Cmdlet`. By default all of them are included. For more details, see [About AppliesTo](#about-appliesto).

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

Defining configs in the standard way is more _flexible_ than the simple way, for example when it comes to validating values and parsing environment variables. For more, see [Customizing Config Definitions](#customizing-config-definitions).

### Step 2: Register the Config

Either way the config is defined, instantiate it and call [`IConfigManager.RegisterConfig(ConfigDefinition config)`](https://github.com/Azure/azure-powershell-common/blob/8d70507d41a3698b5b131df61f14e329d7a6eb41/src/Authentication.Abstractions/Interfaces/IConfigManager.cs#L30) in [`ConfigInitializer.RegisterConfigs(IConfigManager configManager)`](https://github.com/Azure/azure-powershell/blob/304e15c84071fee02622734c4e5f12c05baa77d2/src/Accounts/Authentication/Config/ConfigInitializer.cs#L192). For example:

```csharp
configManager.RegisterConfig(new DisplayBreakingChangeWarningsConfig());
```

Up until now, you are able to test this new config with PowerShell cmdlets `Get-AzConfig`, `Update-AzConfig` and `Clear-AzConfig`. For more, run `Get-Help Get-AzConfig`.

### Step 3: Regenerate Help Documents

As mentioned in Step 1, each config maps to a parameter of `Get-AzConfig`, `Update-AzConfig`, and `Clear-AzConfig`, so it is important to regenerate help documents after introducing new configs. Here are [the instructions](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/help-generation.md#updating-help-after-making-cmdlet-changes).

## Guide: How to Get the Value of a Config

Now that you have defined and registered the config, it is time to get its value. First you need to get the singleton of `IConfigManager`, then use `T GetConfigValue<T>(string key, object invocation = null);`. For example:

```csharp
AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var configManager);
string subscriptionFromConfig = configManager.GetConfigValue<string>(ConfigKeys.DefaultSubscriptionForLogin, MyInvocation);
```

Note that although `invocation` is optional, if the config can apply to either `AppliesTo.Module` or `AppliesTo.Cmdlet` (see [About AppliesTo](#about-appliesto)), it must be `MyInvocation`. Alternatively, **it is best practice to always pass in `MyInvocation`**.

## Customizing Config Definitions

### About AppliesTo

Configs cannot only be set globally, but also be set for a certain cmdlet or module. For example, the following script disables breaking change warning messages for `Az.KeyVault` module, while other modules are not affected by it.

```powershell
Update-AzConfig -DisplayBreakingChangeWarning $false -AppliesTo Az.KeyVault
```

The `IReadOnlyCollection<AppliesTo> ConfigDefinition.CanApplyTo { get; }` property controls to which levels a config can be applied. For example, if it does not make sense for your config to apply to a module or cmdlet, you should set the property to `new AppliesTo[] { AppliesTo.Az }`.

### Validation of Config Value

By default, when user sets a config, the type of the value is validated. If you want to implement your own validation, override `void TypedConfig<TValue>.Validate(object value)`, throw an exception when the value is invalid.

```csharp
public override void Validate(object value)
{
    // do not forget to call `base` so type is still checked
    base.Validate(value);
    int valueInt = (int)value;
    if (value < 0 || value > 100))
    {
        throw new ArgumentException($"Unexpected value [{value}]. The value of config [{Key}] should be between 0 and 100.", nameof(value));
    }
}
```

### Parsing Environment Variables 

Some configs can also be set via environment variables. The config framework will try to parse the variable by the key you set for `string EnvironmentVariableName` property.

However, if for any of the following situations, you need to implement your onw parsing logic:
- Multiple environment variables control one config.
- The value cannot be parsed directly. For example string "Y" to boolean "true".

In this case, instead of setting `EnvironmentVariableName`, override `string ParseFromEnvironmentVariables(IReadOnlyDictionary<string, string> environmentVariables)`. For example:

```csharp
// `environmentVariables` contains all the environment variables
public override string ParseFromEnvironmentVariables(IReadOnlyDictionary<string, string> environmentVariables)
{
    if (environmentVariables.TryGetValue("Azure_PS_Intercept_Survey", out string configString))
    {
        if ("Disabled".Equals(configString, StringComparison.OrdinalIgnoreCase)
            || "False".Equals(configString, StringComparison.OrdinalIgnoreCase))
        {
            // note the return type is string
            return false.ToString();
        }
    }
    // returning null means the variable is not set 
    return null;
}
```
