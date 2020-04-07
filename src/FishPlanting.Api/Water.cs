using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A water that receives fish plants.
    /// </summary>
    public class Water
    {
        /// <summary>
        /// The water's ID for fish planting.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The water's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The counties that the water falls within.
        /// </summary>
        public IEnumerable<County> Counties { get; }

        /// <summary>
        /// A representative coordinate for the water.
        /// </summary>
        public Coordinate Coordinate { get; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The water's ID.</param>
        /// <param name="name">The water's name.</param>
        /// <param name="counties">The counties that the water falls in.</param>
        /// <param name="coordinate">A representative coordinate for the water.</param>
        public Water([Range(0, int.MaxValue)] int id
            , [Required(AllowEmptyStrings = false)] string name
            , [Required] IEnumerable<County> counties
            , [Required] Coordinate coordinate)
        {
            Id = id;
            Name = name;
            Counties = counties;
            Coordinate = coordinate;
        }
    }
}