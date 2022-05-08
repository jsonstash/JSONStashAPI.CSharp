namespace JSONStashAPI.CSharp.Models
{
    public class StashMetadata
    {
        /// <summary>
        /// Stored JSON for stash.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date and time when the stash was created.
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Date and time when the stash was updated.
        /// </summary>
        public DateTimeOffset? Modified { get; set; }

        /// <summary>
        /// The identifier of the stash.
        /// </summary>
        public Guid StashId { get; set; }

        /// <summary>
        /// The identifier of the collection.
        /// </summary>
        public Guid CollectionId { get; set; }

        /// <summary>
        /// The current quota the stash is using.
        /// </summary>
        public StashQuota Quota { get; set; }
    }
}
