# Docs
This directory contains the documentation of the cmdlets for the `Az.ComputeSchedule` module. To run documentation generation, use the `generate-help.ps1` script at the root module folder. Files in this folder will *always be overridden on regeneration*. To update documentation examples, please use the `..\examples` folder.

## Info
- Modifiable: no
- Generated: all
- Committed: yes
- Packaged: yes

## Details
The process of documentation generation loads `Az.ComputeSchedule` and analyzes the exported cmdlets from the module. It recognizes the [help comments](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/about/about_comment_based_help) that are generated into the scripts in the `..\exports` folder. Additionally, when writing custom cmdlets in the `..\custom` folder, you can use the help comments syntax, which decorate the exported scripts at build-time. The documentation examples are taken from the `..\examples` folder.