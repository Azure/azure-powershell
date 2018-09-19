workflow fastJob
{
    param([int[]] $nums)
    $sum=($nums | Measure-Object -Sum).Sum
    echo $sum
}