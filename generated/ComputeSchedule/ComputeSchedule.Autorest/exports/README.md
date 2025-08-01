# Exports
This directory contains the cmdlets *exported by* `Az.ComputeSchedule`. No other cmdlets in this repository are directly exported. What that means is the `Az.ComputeSchedule` module will run [Export-ModuleMember](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/export-modulemember) on the cmldets in this directory. The cmdlets in this directory are generated at **build-time**. Do not put any custom code, files, cmdlets, etc. into this directory. Please use `..\custom` for all custom implementation.

## Info
- Modifiable: no
- Generated: all
- Committed: no
- Packaged: yes

## Details
The cmdlets generated here are created every time you run `build-module.ps1`. These cmdlets are a merge of all (excluding `InternalExport`) cmdlets from the private binary (`..\bin\Az.ComputeSchedule.private.dll`) and from the `..\custom\Az.ComputeSchedule.custom.psm1` module. Cmdlets that are *not merged* from those directories are decorated with the `InternalExport` attribute. This happens when you set the cmdlet to **hide** from configuration. For more information on hiding, see [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression) or the [README.md](..\internal/README.md) in the `..\internal` folder.

## Purpose
We generate script cmdlets out of the binary cmdlets and custom cmdlets. The format of script cmdlets are simplistic; thus, easier to generate at build time. Generating the cmdlets is required as to allow merging of generated binary, hand-written binary, and hand-written custom cmdlets. For Azure cmdlets, having script cmdlets simplifies the mechanism for exporting Azure profiles.

## Structure
The cmdlets generated here will flat in the directory (no sub-folders) as long as there are no Azure profiles specified for any cmdlets. Azure profiles (the `Profiles` attribute) is only applied when generating with the `--azure` attribute (or `azure: true` in the configuration). When Azure profiles are applied, the folder structure has a folder per profile. Each profile folder has only those cmdlets that apply to that profile. 

## Usage
When `./Az.ComputeSchedule.psm1` is loaded, it dynamically exports cmdlets here based on the folder structure and on the selected profile. If there are no sub-folders, it exports all cmdlets at the root of this folder. If there are sub-folders, it checks to see the selected profile. If no profile is selected, it exports the cmdlets in the last sub-folder (alphabetically). If a profile is selected, it exports the cmdlets in the sub-folder that matches the profile name. If there is no sub-folder that matches the profile name, it exports no cmdlets and writes a warning message.