using System;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A fish planting record.
    /// </summary>
    public class FishPlant
    {
        /// <summary>
        /// The water receiving the plant.
        /// </summary>
        public Water Water { get; }
        
        /// <summary>
        /// The week of the plant as indicated by a <see cref="DayOfWeek.Sunday"/> date.
        /// </summary>
        public DateTime Week { get; }

        /// <summary>
        /// The species of the plant.
        /// </summary>
        public Species Species { get; }

        /// <summary>
        /// The size class of the plant.
        /// </summary>
        public SizeClass Size { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="water">The water.</param>
        /// <param name="week">The week.</param>
        /// <param name="species">The species.</param>
        /// <param name="size">The size class of the fish.</param>
        public FishPlant([Required] Water water, DateTime week, [Required] Species species, [Required] SizeClass size)
        {
            Water = water;
            Week = week;
            Species = species;
            Size = size;
        }
    }
}