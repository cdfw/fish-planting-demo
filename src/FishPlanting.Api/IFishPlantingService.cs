using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api
{
    /// <summary>
    /// A fish planting service.
    /// </summary>
    public interface IFishPlantingService
    {
        /// <summary>
        /// Get all counties
        /// </summary>
        /// <returns>All counties</returns>
        Task<IEnumerable<County>> GetCounties(CancellationToken cancellationToken = default);

        /// <summary>
        /// Find counties.
        /// </summary>
        /// <param name="filterByExpression">The filtering expression.</param>
        /// <param name="orderByExpression">The order by property selector expression.</param>
        /// <param name="orderDescending">Order by descending?</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="take">The number of records to return.</param>
        /// <param name="cancellationToken">The task cancellation token.</param>
        /// <returns>The search result</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filterByExpression"/>
        /// or <paramref name="orderByExpression"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="skip"/> or <paramref name="take"/> are less than zero
        /// or if <paramref name="take"/> is greater than 500.</exception>
        Task<SearchResult<County>> FindCounties(
              [Required] Expression<Func<County, bool>> filterByExpression
            , [Required] Expression<Func<County, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, 500)] int take = 20
            , CancellationToken cancellationToken = default);

        /// <summary>
        /// Find waters.
        /// </summary>
        /// <param name="filterByExpression">The filtering expression.</param>
        /// <param name="orderByExpression">The order by property selector expression.</param>
        /// <param name="orderDescending">Order by descending?</param>
        /// <param name="skip">The number of records to skip.</param>
        /// <param name="take">The number of records to return.</param>
        /// <param name="cancellationToken">The task cancellation token.</param>
        /// <returns>The search result</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filterByExpression"/>
        /// or <paramref name="orderByExpression"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="skip"/> or <paramref name="take"/> are less than zero
        /// or if <paramref name="take"/> is greater than 500.</exception>
        Task<SearchResult<Water>> FindWaters(
              [Required] Expression<Func<Water, bool>> filterByExpression
            , [Required] Expression<Func<Water, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, 500)] int take = 20
            , CancellationToken cancellationToken = default);

        /// <summary>
        /// Find fish plants.
        /// </summary>
        /// <param name="filterByExpression">The search expression</param>
        /// <param name="orderByExpression">The sorting property selector expression</param>
        /// <param name="orderDescending">Sort by descending order?</param>
        /// <param name="skip">The number of results to skip</param>
        /// <param name="take">The number of records to take</param>
        /// <param name="cancellationToken">Task cancellation</param>
        /// <returns>The search results</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="filterByExpression"/>
        /// or <paramref name="orderByExpression"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="skip"/> or <paramref name="take"/> are less than zero
        /// or if <paramref name="take"/> is greater than 500.</exception>
        Task<SearchResult<FishPlant>> FindFishPlants(
              [Required] Expression<Func<FishPlant, bool>> filterByExpression
            , [Required] Expression<Func<FishPlant, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, 500)] int take = 100
            , CancellationToken cancellationToken = default);
    }
}
