using System.Threading.Tasks;

namespace Microsoft.CLU
{
    /// <summary>
    /// The contract that needs to be implemented by an entity representing
    /// entry point of a command in a specific "Programming Model".
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Tells whether the command is synchronous or asynchronous.
        /// </summary>
        bool IsAsync { get; }

        /// <summary>
        /// Invokes a synchronous command.
        /// </summary>
        void Invoke();

        /// <summary>
        /// Invokes an asynchronous command.
        /// </summary>
        Task InvokeAsync();
    }
}
