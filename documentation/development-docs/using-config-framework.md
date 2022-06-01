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

#### Standard Config Definition

To define a config, create a class inheriting [`TypedConfig<TValue>`](https://github.com/Azure/azure-powershell/blob/main/src/Accounts/Authentication/Config/Models/TypedConfig.cs) and place it at [`src/Accounts/Authentication/Config/Definitions/`](https://github.com/Azure/azure-powershell/tree/main/src/Accounts/Authentication/Config/Definitions), where you can also find other examples of configs.

You will need to override the following key properties when defining your own config class.

- `object DefaultValue`
  - The default value of the config.
- `string Key`
  - The unique key of the config.
  - The key is also used as a parameter name of cmdlets that operate on configs, for example `Get-AzConfig`, so it must follow the naming conventions. See [Parameter Best Practices](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/design-guidelines/parameter-best-practices.md#parameter-best-practices).
- `string HelpMessage`
  - The help message or description of the config.
  - It will also be used as the help message of the corresponding PowerShell parameter in documents.

public override string EnvironmentVariableName => "AZURE_PS_DISPLAY_BREAKING_CHANGE_WARNINGS";
```

#### Simple Config Definition

### Step 2: Register the Config

### Step 3: Regenerate Help Documents

## Guide: How to Get the Value of a Config

## Special Cases

### Limit the Possibility of AppliesTo

### Validation of Config Value

### Environment Variables



- (optional) `string EnvironmentVariableName`
  - If the config can also be set by an environment variable, and the value of the environment variable can be parsed as the value type `TValue`, override this property.
  - For more complicated scenarios of using environment variables, such as you need to customize the logic of parsing it, do not use this property. See [todo] below.

### Use 
