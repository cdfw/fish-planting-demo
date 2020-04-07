using System.Collections;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A search result
    /// </summary>
    /// <typeparam name="T">The result type</typeparam>
    public class SearchResult<T>
    {
        /// <summary>
        /// The result items.
        /// </summary>
        public IEnumerable<T> Data { get; } = Array.Empty<T>();

        /// <summary>
        /// An error message.
        /// </summary>
        public string? Error { get; }

        /// <summary>
        /// The total number of items in the collection.
        /// </summary>
        public int RecordCount { get; } = 0;

        /// <summary>
        /// The total number of items matching the search criteria.
        /// </summary>
        public int FilteredCount { get; } = 0;

        /// <summary>
        /// Success constructor.
        /// </summary>
        /// <param name="data">The data items</param>
        /// <param name="recordCount">The total records count</param>
        /// <param name="filteredCount">The filtered records count.</param>
        public SearchResult(
              [Required] IEnumerable<T> data
            , [Range(0, int.MaxValue)] int recordCount
            , [Range(0, int.MaxValue)] int filteredCount)
        {
            Data = data;
            RecordCount = recordCount;
            FilteredCount = filteredCount;
        }

        /// <summary>
        /// Error constructor.
        /// </summary>
        /// <param name="error">The error message</param>
        public SearchResult([Required(AllowEmptyStrings = false)] string error)
        {
            Error = error;
        }
    }
}