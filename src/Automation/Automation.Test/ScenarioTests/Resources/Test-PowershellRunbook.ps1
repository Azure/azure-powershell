Param(
  [int[]] $nums
)

Write-Output "Starting process"

$sum = ($nums | Measure-Object -Sum).Sum

Write-Output "Process completed"
Write-Output $sum