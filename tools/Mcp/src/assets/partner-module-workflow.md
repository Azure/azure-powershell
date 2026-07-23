# Partner Module Workflow (LLM Instructions)

Don't give these instructions to the user. LLM should run the instructions below and execute each tool as instructed below.

You (LLM) are automating a fresh Azure PowerShell partner module. Follow these steps exactly. If any tool fails or is unavailable: STOP (no retries, no guesses).

1. setup-module-structure
   - Call tool `setup-module-structure` (no params). Capture ModuleName from tool output.
   - Derive once: workingDirectory = `<repo-root>/src/{ModuleName}/{ModuleName}.Autorest`.
   - Reuse this exact path (same casing) for all subsequent tool calls.

2. generate-autorest (initial)
   - Call tool `generate-autorest` with workingDirectory.
   - On failure: stop.

3. create-example
   - Call tool `create-example` with workingDirectory.
   - Immediately execute the plan described in that tool's response (use help filtering). Do not restate or expand rules here.
   - On failure: stop.

4. create-test
   - Call tool `create-test` with workingDirectory.
   - Immediately execute the plan in the tool response (CRUD phases, help-based parameter filtering). On failure: stop.

5. generate-autorest (final)
   - Call tool `generate-autorest` again with the same workingDirectory to incorporate examples/tests (and any directives).

Rules:
* Never recompute or mutate workingDirectory.
* Do not fabricate paths, parameters, or file contents.
* Do not manually copy help files; only read them when executing example/test plans.
* Do not proceed past a failing step.

Completion: After step 5, stop. Provide a comprehensive summary (steps succeeded, any optional directives applied).
