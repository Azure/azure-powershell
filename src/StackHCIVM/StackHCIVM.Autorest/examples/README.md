# Examples
This directory contains examples from the exported cmdlets of the module. When `build-module.ps1` is ran, example stub files will be generated here. If your module support Azure Profiles, the example stubs will be in individual profile folders. These example stubs should be updated to show how the cmdlet is used. The examples are imported into the documentation when `generate-help.ps1` is ran.

## Info
- Modifiable: yes
- Generated: partial
- Committed: yes
- Packaged: no

## Purpose
This separates the example documentation details from the generated documentation information provided directly from the generated cmdlets. Since the cmdlets don't have examples from the REST spec, this provides a means to add examples easily. The example stubs provide the markdown format that is required. The 3 core elements are: the name of the example, the code information of the example, and the description of the example. That information, if the markdown format is followed, will be available to documentation generation and be part of the documents in the `..\docs` folder.