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

To define a config, create a class inheriting [`TypedConfig<TValue>`](https://github.com/Azure/azure-powershell/blob/main/src/Accounts/Authentication/Config/Models/TypedConfig.cs) and place it at [`src/Accounts/Authentication/Config/Definitions/`](https://github.com/Azure/azure-powershell/tree/main/src/Accounts/Authentication/Config/Definitions), where you can also find examples of other configs.

You will find 

Simple config
Customized config

### Step 2: Register the Config

### Step 3: Regenerate Help Documents

## Guide: How to Get the Value of a Config

## Special Cases

### Applies to

### Validation

### Environment Variable
