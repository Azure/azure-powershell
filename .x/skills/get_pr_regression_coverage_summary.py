"""Evaluate Azure PowerShell service regression coverage."""


def get_pr_regression_coverage_summary(pr_number):
    """Find modules without changed TestFx or AutoRest/Pester test artifacts."""
    changes = get_pr_file_changes(
        owner="Azure",
        repo="azure-powershell",
        pr_number=pr_number,
    )

    def test_layout(parts):
        if len(parts) < 4 or parts[0].casefold() != "src":
            return None
        project = parts[2].casefold()
        if project.endswith((".test", ".tests")) or project == "livetests":
            return "testfx"
        if (
            len(parts) >= 5
            and project.endswith(".autorest")
            and parts[3].casefold() in {"test", "tests"}
        ):
            return "pester"
        return None

    records = []
    for item in changes:
        if not isinstance(item, dict) or not isinstance(
            item.get("filename"), str,
        ) or not item["filename"]:
            raise ValueError("PR file changes must contain a filename.")
        path = item["filename"].replace("\\", "/")
        records.append((path, str(item.get("status") or "").casefold()))
        previous = item.get("previous_filename")
        if previous and previous.replace("\\", "/") != path:
            records.append((previous.replace("\\", "/"), "removed"))

    production_files = []
    modules = {}
    for path, status in records:
        parts = path.split("/")
        name = parts[-1].casefold()
        if (
            len(parts) >= 3
            and parts[0].casefold() == "src"
            and test_layout(parts) is None
            and not name.endswith((".md", ".rst", ".txt"))
            and not (
                len(parts) >= 5
                and parts[3].casefold() in {"help", "docs", "examples"}
            )
        ):
            if path not in production_files:
                production_files.append(path)
            module_key = parts[1].casefold()
            modules.setdefault(module_key, parts[1])

    test_files = []
    recording_files = []
    covered = set()
    for path, status in records:
        if status in {"removed", "deleted"}:
            continue
        lowered = path.casefold()
        parts = path.split("/")
        module_key = parts[1].casefold() if len(parts) > 1 else None
        if module_key not in modules:
            continue
        layout = test_layout(parts)
        if (
            (layout == "testfx" and lowered.endswith((".cs", ".ps1")))
            or (layout == "pester" and lowered.endswith(".tests.ps1"))
        ):
            test_files.append(path)
            covered.add(module_key)
        if (
            (
                layout == "testfx"
                and len(parts) >= 5
                and parts[3].casefold() == "sessionrecords"
                and lowered.endswith(".json")
            )
            or (layout == "pester" and lowered.endswith(".recording.json"))
        ):
            recording_files.append(path)
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
