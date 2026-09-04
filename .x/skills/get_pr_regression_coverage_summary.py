"""Evaluate Azure PowerShell service regression coverage."""


def get_pr_regression_coverage_summary(pr_number):
    """Find changed service modules without focused TestFx changes."""
    changes = get_pr_file_changes(
        owner=None,
        repo=None,
        pr_number=pr_number,
    )
    files = [
        item.get("filename")
        for item in changes
        if isinstance(item, dict) and item.get("filename")
    ]
    production_files = []
    modules = set()
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
            modules.add(parts[1].casefold())

    test_files = []
    covered = set()
    for path in files:
        normalized = str(path).replace("\\", "/")
        parts = normalized.split("/")
        if (
            len(parts) >= 4
            and parts[0].casefold() == "src"
            and parts[1].casefold() in modules
            and parts[2].casefold().endswith(".test")
            and (
                normalized.casefold().endswith(".cs")
                or normalized.casefold().endswith(".ps1")
            )
        ):
            test_files.append(normalized)
            covered.add(parts[1].casefold())

    uncovered = sorted(modules - covered)
    return {
        "applicable": bool(production_files),
        "gap": bool(uncovered),
        "modules": sorted(modules),
        "uncovered_modules": uncovered,
        "production_files": production_files,
        "test_files": test_files,
        "recording_files": [],
    }
