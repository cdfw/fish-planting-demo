using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A geographic coordinate.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// The latitude
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// The longitude
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        public Coordinate([Range(-90, 90)] double latitude, [Range(-180, 180)] double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}