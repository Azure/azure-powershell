# Src

## Dependencies
All dependencies for all projects are managed within the `src` folder for this repository.

### DO NOT:
- Use Visual Studio [`Right click project -> Add Reference...`] to add/update/remove dependencies for any project
- Use NuGet package manager within Visual Studio [`Right click project -> Manage NuGet Packages...`] to add/update/remove dependencies for any project

### How to add/update dependencies
- TODO: Add this information

## Acquiring Symbols in Visual Studio
We publish the symbols for this repository to our MyGet feed. The URL for our symbols MyGet feed is: https://www.myget.org/F/azure-powershell/symbols/

To add this feed to your Visual Studio, please follow the steps here: https://docs.myget.org/docs/reference/symbols#Consuming_symbol_packages_in_Visual_Studio