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

## 3. Populate Examples
Call MCP tool: `create-example` with the same `workingDirectory`.
Tool returns:
  `{0}` = specs example source dir (downloaded JSON)
  `{1}` = target examples dir in module
  `{2}` = reference ideal examples (semicolon separated; may be empty)
Use reference examples (if any) for style: parameter ordering (required first), consistent variable placeholder patterns, and advanced options inclusion.
Leave an example file empty only if no relevant swagger example data exists.
Quality guidance (concise):
  - Provide both minimal (required params only) and enriched (common optional params) variants if the skeleton expects multiple examples.
  - Use stable placeholder naming: `<ResourceGroupName>`, `<Location>`, `<WorkspaceName>` etc., unless a deterministic value is required by an existing test.
  - Do not invent unsupported parameters; omit deprecated or preview-only params unless the swagger version explicitly requires them.
  - Maintain consistent casing and ordering: required first, then alphabetized optional.
  - Prefer realistic value shapes (GUID formats, URIs) over lorem ipsum.
MANDATORY: After the tool call, TREAT the returned response text itself (instructions referencing {0} {1} {2}) AS AN ACTION PLAN. Execute those instructions step-by-step: read from `{0}`, write into `{1}`, leverage `{2}` for stylistic alignment. Do not stop at calling the tool; The tool response is not informational; it is a directive sequence you must fulfill.

## 4. Populate Tests
Call MCP tool: `create-test` with the same `workingDirectory`.
Tool returns:
  `{0}` = specs example source dir
  `{1}` = target test dir
  `{2}` = reference ideal test dirs
Fill test stubs using variables defined in `utils.ps1` `setupEnv` function. 
IMPORTANT: You can completely ignore the generated Test files as they only have the skeleton. Instead, you can group these test files into groups of 1 particular resource & then write 1 new file combining these 3-4 test file in the CRUD format.
Add: create -> get -> assert -> (optional cleanup). Add a negative test when feasible.
Leave a test empty only if genuinely no meaningful data can be inferred.
Quality guidance (concise):
  - CRUD Pattern: Create (or Update) => Get => Assert essential fields => (List => Assert presence) => (Delete => Confirm absence) when resource lifecycle is supported.
  - Assertions: Prefer specific property checks (Name, Id segment patterns, ProvisioningState) over broad object dumps.
  - Negative Case: Intentionally supply one invalid parameter or missing required field; assert error category/message pattern.
  - Reuse Variables: All names & IDs defined once in `setupEnv` to avoid duplication and enable future parameterization.
  - Idempotency: Avoid destructive operations unless they clean up what this test created.
MANDATORY: After the tool call, EXECUTE the returned test instructions: interpret response text referencing `{0}`, `{1}`, `{2}`, open each stub under `{1}`, populate bodies using data from `{0}`, and mirror style from `{2}`. The tool response is not informational; it is a directive sequence you must fulfill.

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