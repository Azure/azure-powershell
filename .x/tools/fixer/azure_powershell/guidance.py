# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Repository-owned Codegen execution guidance."""


def _codegen_execution_guidance(safe_component):
    module_path = (
        f"`src/{safe_component}/`"
        if safe_component
        else "the affected `src/<Module>/` directory"
    )
    return (
        "### Mandatory Codegen execution protocol\n\n"
        "Before editing implementation files, inspect "
        f"{module_path} and determine whether the affected cmdlet belongs "
        "to a `*.Autorest` project. Classify the change before editing: "
        "REST schema and operation defects belong in the pinned "
        "`Azure/azure-rest-api-specs` input; PowerShell-specific public "
        "surface shaping belongs in the project `README.md` directives; "
        "non-modelable client behavior belongs in handwritten `custom/`; "
        "examples and tests remain handwritten. Do not directly synthesize "
        "or patch generated C#, proxy scripts, `docs/`, manifests, models, "
        "or the committed top-level `generated/` tree.\n\n"
        "Use the Azure PowerShell repository's "
        "[Codegen MCP documentation]"
        "(https://github.com/Azure/azure-powershell/blob/main/"
        "tools/Mcp/README.md). Invoke its `generate-autorest` tool with "
        "the absolute `*.Autorest` working directory when that MCP tool "
        "is available. Otherwise execute the same repository-owned "
        "non-interactive sequence documented by the tool implementation:\n\n"
        "```bash\n"
        "cd <absolute-path-to-Project.Autorest>\n"
        "autorest --reset\n"
        "autorest\n"
        "pwsh -File build-module.ps1\n"
        "```\n\n"
        "You MUST actually run Codegen after changing its durable inputs; "
        "do not merely describe these commands in the pull request. If "
        "the required tools cannot be installed or any generation step "
        "fails, stop and report the blocker instead of hand-authoring a "
        "substitute. Commit the complete generated diff, including a "
        "Codegen-created change to `generate-info.json` (the exact "
        "filename; never fabricate its `generate_Id`), then inspect the "
        "diff and run the focused module build, help, StaticAnalysis, and "
        "tests. A change confined to handwritten `custom/`, `examples/`, "
        "or completed tests does not become generated merely because it "
        "is inside a `*.Autorest` project."
    )
