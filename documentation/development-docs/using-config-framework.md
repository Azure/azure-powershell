# Using Config Framework

- [Overview](#overview)
- [Guide: How to Add a New Config](#guide-how-to-add-a-new-config)
- [Guide: How to Get the Value of a Config](#guide-how-to-get-the-value-of-a-config)
- [Special cases](#special-cases)
  - [Applies to](#applies-to)
  - [Validation](#validation)
  - [Environment variable](#environment-variable)

## Overview

The config framework was introduced in Az 8, May 2022 to set up a standard of how to define a config, get or update the value of a config, etc.

This document will go over 2 most common scenarios for developers.

## Guide: How to Add a New Config

### Step 1: Define the Config

To define a config, add a new class inheriting `TypedConfig` under src/Accounts/Authentication/Config/Definitions/

Simple config
Customized config

### Step 2: Register the Config

### Step 3: Regenerate Help Documents

## Guide: How to Get the Value of a Config

## Special Cases

### Applies to

### Validation

### Environment Variable
