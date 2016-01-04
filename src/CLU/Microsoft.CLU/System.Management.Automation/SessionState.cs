using Microsoft.CLU;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace System.Management.Automation
{
    public sealed class SessionState
    {
        /// <summary>
        /// Represents the session variables.
        /// </summary>
        public PSVariableIntrinsics PSVariable { get; private set; }

        /// <summary>
        /// Creates an instance of SessionState.
        /// </summary>
        public SessionState()
        {
            PSVariable = new PSVariableIntrinsics();
            _stateFileFullPath = CLUEnvironment.Session.SessionPath;
        }

        /// <summary>
        /// Save the session.
        /// </summary>
        internal void Save()
        {
            System.IO.File.WriteAllText(_stateFileFullPath, ToJsonString());
        }

        /// <summary>
        /// Load the session.
        /// </summary>
        internal void Load()
        {
            if (System.IO.File.Exists(_stateFileFullPath))
            {
                var stateString = System.IO.File.ReadAllText(_stateFileFullPath);
                var json = JsonConvert.DeserializeObject(stateString) as JObject;

                PSVariable.Load(json);
            }
        }

        /// <summary>
        /// Gets Json string representing the session variables.
        /// </summary>
        /// <returns>The json string</returns>
        internal string ToJsonString()
        {
            return $"{{{PSVariable.ToJsonString()}}}";
        }

        #region Private fields

        /// <summary>
        /// The full path to the file holding session state.
        /// </summary>
        private string _stateFileFullPath;

        #endregion
    }
}