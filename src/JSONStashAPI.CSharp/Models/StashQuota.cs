namespace JSONStashAPI.CSharp.Models
{
    public class StashQuota
    {
        /// <summary>
        /// Maximum amount of bytes the stash can use.
        /// </summary>
        public long MaxBytes { get; set; }

        /// <summary>
        /// The amount of bytes the stash data is using.
        /// </summary>
        public long UsedBytes { get; set; }
    }
}
