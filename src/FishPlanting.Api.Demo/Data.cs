using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FishPlanting.Api.Demo
{
    internal static class Data
    {
        static readonly County Anacapa = new County(1, nameof(Anacapa));
        static readonly County Bolinas = new County(2, nameof(Bolinas));
        static readonly County Cucamonga = new County(3, nameof(Cucamonga));
        static readonly County Euclid = new County(4, nameof(Euclid));
        static readonly County Zappa = new County(5, nameof(Zappa));

       internal static IReadOnlyCollection<County> Counties = new List<County>
        {
            Anacapa, Bolinas, Cucamonga, Euclid, Zappa,
        };


        static readonly Species Catfish = new Species(nameof(Catfish));
        static readonly Species Trout = new Species(nameof(Trout));

        internal static IReadOnlyCollection<Species> Species = new List<Species>
        {
            Catfish, Trout,
        };

        static readonly SizeClass Fingerling = new SizeClass(nameof(Fingerling));
        static readonly SizeClass Catchable = new SizeClass(nameof(Catchable));
        static readonly SizeClass SubCatchable = new SizeClass(nameof(SubCatchable));
        static readonly SizeClass Trophy = new SizeClass(nameof(Trophy));

        internal static IReadOnlyCollection<SizeClass> SizeClasses = new List<SizeClass>
        {
            Fingerling, Catchable, SubCatchable, Trophy,
        };

        static readonly Water AguaFriaReservoir = new Water(1, "Agua Fria Reservoir"
            , new County[] { Cucamonga }, new Coordinate(34.12345, -114.54321));
        static readonly Water DearCreek = new Water(2, "Dear Creek"
            , new County[] { Anacapa, Bolinas }, new Coordinate(35.678, -117.34567));
        static readonly Water ParallelLake = new Water(3, "Parallel Lake"
            , new County[] { Euclid }, new Coordinate(38.8765, -121.019283));
        static readonly Water SanBernardinoRiver = new Water(4, "San Bernardino River"
            , new County[] { Zappa }, new Coordinate(33.3333333, -115.19191919));

        internal static IReadOnlyCollection<Water> Waters = new List<Water>
        {
            AguaFriaReservoir, DearCreek, ParallelLake, SanBernardinoRiver,
        };


        internal static IReadOnlyCollection<FishPlant> FishPlants = new List<FishPlant>
        {
            new FishPlant(AguaFriaReservoir, DateTime.Now.AddMonths(-1).AddDays(1).ToSunday(), Trout, SubCatchable),
            new FishPlant(AguaFriaReservoir, DateTime.Now.AddDays(-14).AddDays(2).ToSunday(), Trout, Catchable),
            new FishPlant(AguaFriaReservoir, DateTime.Now.AddDays(5).ToSunday(), Trout, Trophy),

            new FishPlant(DearCreek, DateTime.Now.AddMonths(1).AddDays(3).ToSunday(), Trout, Fingerling),
            new FishPlant(DearCreek, DateTime.Now.AddMonths(2).AddDays(-1).ToSunday(), Trout, Fingerling),
            new FishPlant(DearCreek, DateTime.Now.AddMonths(3).ToSunday(), Trout, Fingerling),

            new FishPlant(SanBernardinoRiver, DateTime.Now.ToSunday(), Catfish, Catchable)
        };

        static DateTime ToSunday(this DateTime date)
        {
            return date.AddDays(-(int)date.DayOfWeek).Date;
        }
    }
}
