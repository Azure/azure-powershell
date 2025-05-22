# About `lib` Directory

This directory contains common assemblies / libraries that Azure PowerShell modules depend on.

## How to use this directory

When making changes to the dependencies in this directory, please follow these steps:

1. Update `manifest.json` no matter if you are adding, removing or updating a dependency. This serves as the source of truth.
2. Run `Update-DevDependency` found in the AzDev module. Follow the instructions necessary to [build and import the module](../../tools/AzDev/README.md) first.
