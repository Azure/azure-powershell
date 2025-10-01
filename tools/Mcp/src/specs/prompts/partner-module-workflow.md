# Partner Module Workflow (Simplified)

Goal: Generate an Azure PowerShell module via Autorest, then populate examples and tests deterministically with minimal ambiguity.

Core Principle: Derive the working directory once and reuse it. Do not guess or fabricate paths.

## 1. Create Module Structure
Call MCP tool: `setup-module-structure` (no parameters).
It returns `{0}` = `ModuleName` (from user input inside the tool).
Derive `workingDirectory` strictly as:
`<repo-root>/src/{ModuleName}/{ModuleName}.Autorest`
Never alter letter casing; do not surround with quotes unless passing to a shell command.

## 2. Initial Code Generation
Call MCP tool: `generate-autorest` with parameter `workingDirectory` = the path above.
Do not call Autorest directly; always use the MCP tool.
If generation fails, STOP.

## 3. Populate Examples (Help-Driven Parameters)
Call MCP tool: `create-example` with the same `workingDirectory`.
Tool returns:
  `{0}` = specs example source dir (downloaded JSON)
  `{1}` = target examples dir in module
  `{2}` = reference ideal examples (semicolon separated; may be empty)

Parameter Source of Truth: Discard any swagger fields not documented in help.
Derive the help directory as: `helpDir = <repo-root>/src/{ModuleName}/help/`.
READ-ONLY: Do NOT copy, duplicate, or move help markdown files into the `.Autorest` or `examples` folder. They are only inspected to determine the allowed parameter set. Generating or pasting full help content into examples is prohibited.
For each cmdlet example you generate:
  1. Open the help markdown file: `helpDir/<CmdletName>.md`.
  2. Examine the allowed parameters from (a) syntax code fences ``` blocks containing the cmdlet invocation) and (b) `### -ParameterName` headings.
  3. Required ordering: parameters that appear in the first syntax signature first (in the order shown), followed by remaining optional parameters alphabetically.
  4. Ignore `CommonParameters` heading and any swagger example properties not in the allowed set.
  5. Use (or create if missing) only the example script files expected under `{1}`; never replicate help file text.

Example Construction Rules:
  - Minimal yet runnable. If swagger example provides values for disallowed params, omit them silently.
  - Provide enriched variants only if distinct meaningful optional parameters remain after filtering.
  - Use stable placeholders: `<ResourceGroupName>`, `<Location>`, etc.
  - Never invent parameters or reuse removed swagger names under new casing.
  - Leave the example file empty if no swagger fields map to documented parameters.

MANDATORY EXECUTION: Treat the tool's response (with placeholders) as an action plan—read from `{0}`, consult (but do not copy) help files in `helpDir`, then generate/update ONLY the example scripts under `{1}` (respecting any existing skeleton), mirroring stylistic patterns from `{2}`.

## 4. Populate Tests (Help-Driven Parameters)
Call MCP tool: `create-test` with the same `workingDirectory`.
Tool returns:
  `{0}` = specs example source dir
  `{1}` = target test dir
  `{2}` = reference ideal test dirs
Do NOT modify any pre-generated stub files. Instead CREATE NEW files: one per top-level resource (or logical resource group) named `<ResourceName>.Crud.Tests.ps1`.
Each file covers (omit phases not supported):
  1. Create (New-* or equivalent)
  2. Get (Get-*) with property assertions
  3. List (Get-* plural) asserting presence
  4. Update/Set (if supported) asserting only changed fields
  5. Delete/Remove (cleanup) asserting absence (or expected NotFound)
  6. Negative (invalid parameter or missing required) expecting specific error pattern
Parameter Filtering: Apply the SAME help-driven filtering used for examples. Do not call cmdlets with parameters absent from their help markdown.
Variable Reuse: Define all common names/IDs once in `utils.ps1` `setupEnv`; reference them in test files.
Assertions: Prefer targeted property checks (Name, Id pattern, ProvisioningState) over full object dumps.
Idempotency: Ensure cleanup for resources created; avoid deleting shared or pre-existing resources.
MANDATORY: After the tool call, treat response text as an execution plan: read from `{0}`, create new files under `{1}`, mirror style from `{2}`, and enforce help-based parameter filtering.

## 5. Regenerate Module
Call `generate-autorest` again with identical `workingDirectory` to ensure examples/tests are integrated. Do not modify the README.yaml block except via directives inserted earlier.

## 6. Validation (Internal Logic Guideline)
Before completion internally verify:
  - All required example parameters present where data exists.
  - No unknown parameters introduced.
  - Tests assert at least one key property per created resource.
If any check fails, refine the affected file(s) then proceed.

## Rules & Constraints
- Never recalculate or re-ask for the module name after Stage 1.
- Never invent alternative directory paths.
- Do not skip steps 1–5.
- Halt immediately if an MCP tool is unavailable or errors.

End of workflow.