workflow Use-WorkflowCheckpointSample
{
    Write-Output "Before Checkpoint."
    start-sleep -s 20
	
    # A checkpoint is created.
    Checkpoint-Workflow

    # This line occurs after the checkpoint. The runbook will start here on resume.
    Write-Output "After Checkpoint."
}