using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishPlanting.Api
{
    /// <summary>
    /// A county of the state.
    /// </summary>
    public class County
    {
        /// <summary>
        /// The sequential county ID (1..58) by alphabetic sort.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The name of the county.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public County([Range(1, 58)] int id, [Required(AllowEmptyStrings = false)] string name)
        {
            Id = id;
            Name = name;
        }
    }
}
