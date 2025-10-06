## LLM Example Generation Directions

You have just called tool `create-example` for a freshly generated module.

Inputs:
- `{0}` = source swagger example JSON directory (read only)
- `{1}` = target examples directory (write here only)
- `{2}` = reference example dirs (style cues; may be empty)
- helpDir = parentOf({1}) with `.Autorest` removed + `/help` (read only)

Goal: Produce minimal, runnable PowerShell example scripts for each relevant cmdlet using ONLY parameters documented in help.

Algorithm (repeat per cmdlet needed):
1. Open `helpDir/<CmdletName>.md`.
2. Collect allowed params = (a) params in first syntax line(s) in code fences + (b) every `### -ParamName` heading. Exclude `CommonParameters`.
3. For each swagger JSON in `{0}` referencing this cmdlet, map its fields to allowed params; drop non‑allowed silently.
4. Order parameters: required (in the order of the first syntax signature) then optional alphabetical.
5. Build one minimal example. Add a second variant ONLY if it demonstrates distinct optional parameters.

Rules:
* Never invent or rename parameters; casing must match help.
* Value selection precedence (per allowed parameter):
	1. If the swagger example JSON (source `{0}`) contains a concrete value for that parameter (after mapping), use that value directly.
	2. If the swagger value is obviously redacted (e.g. `"string"`, `"<string>"`, `"XXXX"`, empty, or null) then fall back to a stable placeholder instead of using the dummy.
	3. Otherwise (no concrete usable value) use a stable placeholder: `<ResourceGroupName>`, `<Location>`, `<SubscriptionId>`, `<Name>`, etc.
* Do not substitute placeholders where a good swagger value exists.
* If no allowed params remain after filtering, create/leave an empty file or a single comment line.
* Do not copy help prose; output only script lines (and brief inline comments if helpful).
* Mirror formatting style hints (indentation, spacing) from reference dirs `{2}` without copying their literal values.

Output Handling:
- Modify/create files ONLY under `{1}`; no other directories.
- Preserve existing example files, updating parameter sets/order as needed.

Quick Validation Checklist (stop if any fail):
1. All parameters exist in help.
2. Required parameters present & ordered first.
3. No swagger‑only or duplicate parameters.
4. Placeholders consistent.
5. No redundant variant scripts.

Produce the final example script contents now; do not restate these instructions.

