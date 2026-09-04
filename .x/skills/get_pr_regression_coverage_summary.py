"""Evaluate Azure PowerShell service regression coverage."""


def get_pr_regression_coverage_summary(pr_number):
    """Find changed service modules without focused TestFx changes."""
    changes = get_pr_file_changes(
        owner="Azure",
        repo="azure-powershell",
        pr_number=pr_number,
    )
    files = [
        item.get("filename")
        for item in changes
        if isinstance(item, dict) and item.get("filename")
    ]
    production_files = []
    modules = {}
    for path in files:
        normalized = str(path).replace("\\", "/")
        parts = normalized.split("/")
        name = parts[-1]
        if (
            len(parts) >= 3
            and parts[0].casefold() == "src"
            and not parts[2].casefold().endswith(".test")
            and not name.casefold().endswith(".md")
        ):
            production_files.append(normalized)
            module_key = parts[1].casefold()
            if module_key not in modules:
                modules[module_key] = parts[1]

    test_files = []
    recording_files = []
    covered = set()
    for path in files:
        normalized = str(path).replace("\\", "/")
        lowered = normalized.casefold()
        parts = normalized.split("/")
        module_key = parts[1].casefold() if len(parts) > 1 else None
        if (
            len(parts) >= 4
            and parts[0].casefold() == "src"
            and module_key in modules
            and parts[2].casefold().endswith(".test")
            and (
                lowered.endswith(".cs")
                or lowered.endswith(".ps1")
            )
        ):
            test_files.append(normalized)
            covered.add(module_key)
        if (
            len(parts) >= 5
            and parts[0].casefold() == "src"
            and module_key in modules
            and parts[2].casefold().endswith(".test")
            and parts[3].casefold() == "sessionrecords"
            and lowered.endswith(".json")
        ):
            recording_files.append(normalized)
            covered.add(module_key)

    uncovered = sorted(set(modules) - covered)
    return {
        "applicable": bool(production_files),
        "gap": bool(uncovered),
        "modules": [modules[key] for key in sorted(modules)],
        "uncovered_modules": [modules[key] for key in uncovered],
        "production_files": production_files,
        "test_files": test_files,
        "recording_files": recording_files,
    }
