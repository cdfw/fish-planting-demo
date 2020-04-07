using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A size class for the fish.
    /// </summary>
    public class SizeClass
    {
        /// <summary>
        /// The name of the size class
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The size class name</param>
        public SizeClass([Required(AllowEmptyStrings = false)] string name)
        {
            Name = name;
        }
    }
}