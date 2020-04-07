using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A fish planting species.
    /// </summary>
    /// <remarks>This is a generic type of fish rather than a specific species.</remarks>
    public class Species
    {
        /// <summary>
        /// The species name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The species name.</param>
        public Species([Required(AllowEmptyStrings = false)] string name)
        {
            Name = name;
        }
    }
}