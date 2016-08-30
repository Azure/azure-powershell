## Cleaning up commits

### Best practices for keeping commits clean

During development, to make sure that your commit history stays clean while the branch you're based off of is changing, follow some of these rules:

1. **Rebase instead of merging**
    - When you need to update your branch with the changes made to the base branch, [rebasing](#rebasing) will change the commit that your branch is based off of, allowing you to add the changes from the base branch and not gain an extra commit that you would with merging
2. **Large number of changes**
    - If you create a pull request that contains a large number of changes (*e.g.,* re-recording tests) that won't be able to be displayed on GitHub, separate your changes into multiple pull requests that reference each other.

### Number of commits

It can be difficult to follow the changes in a pull request when the number of commits that come with it become too large:
- If a bug fix is being addressed, a single commit should be submitted
- If a new feature is being introduced, then the pull request can have multiple logical commits with each commit clearly describing what it does

### Rebasing

Sometimes a pull request can be based on a much earlier commit in the branch that you are trying to merge into it, causing a large amount of commits and file changes to litter the pull request. In this case, it would be better to **rebase** (move branches around by changing the commit that they are based on). After rebasing, you will want to close the pull request and open a new one, which will now have fewer commits.

For example, if you're working from the branch **feature** and are trying to rebase with **master**, you may run one of the following commands:
> `git rebase master`
> `git rebase master feature`

You can also rebase with the following command:
> `git pull --rebase`

A normal `git pull` is equivalent to `git fetch` followed by `git merge FETCH_HEAD`, but when you run `git pull --rebase`, it runs `git rebase` instead of `git merge`.

For more information on rebasing, click [here](https://git-scm.com/docs/git-rebase).

### Squashing

When your pull request has a group of commits that can be condensed into one, logical commit, use **squashing**. This will clean up the number of commits your pull request has while also grouping together common commits. 

For example, if you wanted to squash the last three commits into one, you may run the following command:
> `git rebase -i HEAD~3`

This will bring up an editor showing your last three commits. Pick a commit to keep (as the message), and squash the other two into it.

For more information on squashing, click [here](https://git-scm.com/book/en/v2/Git-Tools-Rewriting-History#Squashing-Commits).

### Cherry-picking

If you want to merge specific commits from another branch into the current one you are working from, use **cherry-picking**. 

For example, if you're working on the **master** branch and want to pull commit X (the commit-hash) from the **feature** branch, you may run the following commands:
> `git checkout master`
> `git cherry-pick X -n`

The `-n`, or `--no-commit`, is recommended for cherry-picking because it won't automatically create a commit for the cherry-picked change; this will allow you to view the changes first and make sure that you want to add all everything from the cherry-picked commit.

Now, if you want to cherry-pick a range of commits, say X through Y, from the **feature** branch, you may run the following commands:
> `git checkout -b temp-branch X`
> `git rebase --onto master Y^`

For more information on cherry-picking, click [here](https://git-scm.com/docs/git-cherry-pick).