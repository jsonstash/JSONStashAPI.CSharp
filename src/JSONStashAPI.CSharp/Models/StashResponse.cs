namespace JSONStashAPI.CSharp.Models
{
    public class StashResponse
    {
        /// <summary>
        /// Stored JSON for stash.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Message returned by the api if any.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Describes the stash returned.
        /// </summary>
        public StashMetadata Metadata { get; set; }
    }
}
