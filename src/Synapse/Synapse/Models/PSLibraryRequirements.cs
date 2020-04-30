using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLibraryRequirements
    {
        public PSLibraryRequirements(LibraryRequirements libraryRequirements)
        {
            this.Time = libraryRequirements?.Time;
            this.Content = libraryRequirements?.Content;
            this.Filename = libraryRequirements?.Filename;
        }

        /// <summary>
        /// Gets the last update time of the library requirements file.
        /// </summary>
        public System.DateTime? Time { get; set; }

        /// <summary>
        /// Gets the library requirements.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets the filename of the library requirements file.
        /// </summary>
        public string Filename { get; set; }
    }
}