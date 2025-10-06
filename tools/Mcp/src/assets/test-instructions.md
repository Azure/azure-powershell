## LLM Test Generation Directions

You have just called tool `create-test`.

Inputs:
- `{0}` = swagger example JSON source dir (read only)
- `{1}` = target test dir (write only)
- `{2}` = reference test dirs (style cues)
- helpDir = parentOf({1}) with `.Autorest` removed + `/help` (read only)

Goal: Create focused CRUD (+ negative) test scripts for each top-level resource using ONLY help-documented parameters.

File Strategy:
- Do NOT edit existing stub files.
- Create new `<ResourceName>.Crud.Tests.ps1` per resource group (skip if no allowed params after filtering).

Phases (include only those supported):
Create → Get → List → Update/Set → Delete/Remove → Negative.

Parameter Filtering (same as examples):
1. Allowed params = syntax line params + `### -ParamName` headings in help; exclude `CommonParameters`.
2. Drop swagger-only fields silently.

Implementation Pattern inside each file:
1. Dot-source common `utils.ps1` (if present) for shared env setup.
2. Create: capture returned object; store name/id for reuse.
3. Get: assert key props (Name, Id format, ProvisioningState). Use precise assertions, not whole-object dumps.
4. List: ensure resource present (filter by name/id).
5. Update/Set (if available): change minimal field; assert only that field changed.
6. Delete/Remove: remove resource; confirm absence or specific NotFound.
7. Negative: one meaningful invalid input; assert expected error pattern/text.

Rules:
* No invented params or renaming; casing must match help.
* Parameter value precedence (for Create / Update phases and any param reuse):
	1. Use the concrete value from the corresponding swagger example JSON (source `{0}`) if present for the mapped allowed parameter.
	2. If the swagger value is clearly a placeholder/dummy (`"string"`, `"<string>"`, `"XXXX"`, empty, null), fall back to a stable placeholder (`<ResourceGroupName>`, `<Location>`, `<Name>`, etc.).
	3. If no swagger value exists, use the stable placeholder directly.
* Do not overwrite a good concrete swagger value with a placeholder.
* Reuse variable names consistently across phases.
* Ensure cleanup for every created resource.
* Skip generating a file if nothing valid to test.
* Keep tests deterministic; avoid random sleeps or nondeterministic waits.

Quick Validation Checklist:
1. Params all in help.
2. Each phase present only if supported.
3. Assertions targeted & minimal.
4. Resource cleaned up.
5. Exactly one clear negative case (if meaningful).

Output: Write only to `{1}`. Do not modify examples or help files. Produce final test file contents now.
