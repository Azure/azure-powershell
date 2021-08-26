namespace Microsoft.Azure.Commands.Synapse.Common
{
    using System.Threading.Tasks;

    /// <summary>
    /// Async prompt confirm task completion source
    /// </summary>
    internal class ConfirmTaskCompletionSource : TaskCompletionSource<bool>
    {
        public string Message { get; private set; }

        /// <summary>
        /// Construct a ConfirmTaskCompletionSource object
        /// </summary>
        /// <param name="message">Confirmation message</param>
        public ConfirmTaskCompletionSource(string message) : base()
        {
            Message = message;
        }
    }
}
