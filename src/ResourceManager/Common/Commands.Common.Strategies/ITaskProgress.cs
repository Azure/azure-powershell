namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Task progress.
    /// </summary>
    public interface ITaskProgress
    {
        /// <summary>
        /// Resource configuration related to the task.
        /// </summary>
        IResourceConfig Config { get; }

        /// <summary>
        /// Absolute progress [0..1].
        /// </summary>
        /// <returns></returns>
        double GetProgress();

        /// <summary>
        /// true if the task is done.
        /// </summary>
        bool IsDone { get; }
    }
}
