"""Select changed Azure PowerShell TestFx files."""


def changed_ps_test_files(pr_files):
    """Return changed .cs and .ps1 tests under a service Test project."""
    selected = []
    for path in pr_files or []:
        normalized = str(path).replace("\\", "/")
        lowered = normalized.casefold()
        parts = normalized.split("/")
        if (
            len(parts) >= 4
            and parts[0].casefold() == "src"
            and parts[2].casefold().endswith(".test")
            and (
                lowered.endswith(".cs")
                or lowered.endswith(".ps1")
            )
        ):
            selected.append(normalized)
    return selected
