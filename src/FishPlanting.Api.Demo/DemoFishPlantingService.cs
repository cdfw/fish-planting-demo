using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace FishPlanting.Api.Demo
{
    /// <summary>
    /// A demo version of the <see cref="IFishPlantingService"/> using
    /// canned in-memory data.
    /// </summary>
    public class DemoFishPlantingService
        : IFishPlantingService
    {
        public async Task<SearchResult<County>> FindCounties(
              [Required] Expression<Func<County, bool>> filterByExpression
            , [Required] Expression<Func<County, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, 500)] int take = 20
            , CancellationToken cancellationToken = default)
        {
            try
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var q = Data.Counties.AsQueryable();
                    var total = q.Count();
                    q = q.Where(filterByExpression);
                    var filtered = q.Count();
                    if (!orderDescending)
                        q = q.OrderBy(orderByExpression);
                    else
                        q = q.OrderByDescending(orderByExpression);
                    var data = q.Skip(skip).Take(take);
                    var result = new SearchResult<County>(data, total, filtered);
                    return result;
                }, cancellationToken);
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new SearchResult<County>(error: ex.Message);
            }
        }

        public async Task<SearchResult<FishPlant>> FindFishPlants(
              [Required] Expression<Func<FishPlant, bool>> filterByExpression
            , [Required] Expression<Func<FishPlant, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, 500)] int take = 100
            , CancellationToken cancellationToken = default)
        {
            try
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var q = Data.FishPlants.AsQueryable();
                    var recordCount = q.Count();
                    q = q.Where(filterByExpression);
                    var filteredCount = q.Count();
                    if (!orderDescending)
                        q = q.OrderBy(orderByExpression);
                    else
                        q = q.OrderByDescending(orderByExpression);
                    var data = q.Skip(skip).Take(take);
                    return new SearchResult<FishPlant>(data, recordCount, filteredCount);
                }, cancellationToken);
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new SearchResult<FishPlant>(error: ex.Message);
            }
        }

        public async Task<SearchResult<Water>> FindWaters(
              [Required] Expression<Func<Water, bool>> filterByExpression
            , [Required] Expression<Func<Water, object>> orderByExpression
            , bool orderDescending = false
            , [Range(0, int.MaxValue)] int skip = 0
            , [Range(0, int.MaxValue)] int take = 20
            , CancellationToken cancellationToken = default)
        {
            try
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var q = Data.Waters.AsQueryable();
                    var recordCount = q.Count();
                    q = q.Where(filterByExpression);
                    var filteredCount = q.Count();
                    if (!orderDescending)
                        q = q.OrderBy(orderByExpression);
                    else
                        q = q.OrderByDescending(orderByExpression);
                    var data = q.Skip(skip).Take(take);
                    return new SearchResult<Water>(data, recordCount, filteredCount);
                }, cancellationToken);
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return new SearchResult<Water>(error: ex.Message);
            }
        }

        public async Task<IEnumerable<County>> GetCounties(CancellationToken cancellationToken = default)
        {
            var task = Task.Factory.StartNew(() =>
            {
                return Data.Counties.OrderBy(x => x.Id);
            }, cancellationToken);

            return await task.ConfigureAwait(false);
        }
    }
}
