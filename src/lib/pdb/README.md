## What is this directory for

In the [security tools pipeline](../../../.azure-pipelines/security-tools.yml), one step called BinSkim would scan all of the assemblies and executables in the artifacts. When scanning assemblies, it requires the corresponding Program Database (PDB) files. Most cases BinSkim is smart enough to find them, for example by downloading the symbol package from nuget.org. However if it fails to do so, you could get an [`E_PDB_NOT_FOUND`](https://github.com/microsoft/binskim/blob/7b64cf4ff69d2c6d8c4945be821d361b24e2169f/docs/RulesAndErrorsTroubleshootingGuide.md#resolving-e_pdb_not_found) error.

The solution is to grab the PDB file elsewhere (maybe by asking the developers), and then put them next to the assemblies. But keep in mind that we don't want to ship them to the end user because they are useless at runtime and they are big.

This directory serves as an E2E solution. You put the PDB files here, tell the script where their corresponding assemblies are, and the script will copy them to the right place before the BinSkim scan.

## How to add a new PDB file

1. Put the PDB file in `src/lib/pdb`.
2. Update [`CopyPdbToArtifacts.ps1`](./CopyPdbToArtifacts.ps1), in the hashtable `$PathMappings`, add a new entry of the PDB's name and its destination, i.e. where the corresponding .dll file lies in artifacts.
3. Check in and push your code. Note that PDB files are ignored by `.gitignore`. You need to explicitly add them by `git add -f path/to/*.pdb`.## What is lib/pdb for
