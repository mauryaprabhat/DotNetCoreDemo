using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    ID= 1,
                    Name ="Mumbai",
                    Description ="FilmCity of India",
                    PointsOfInterests= new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Mumabi PointofInterest1",
                            Description = " Mumbai Descripton for Point of interest1"
                        },
                        new PointsOfInterestDto()
                        {
                            Id =2,
                            Name = "Mumabi PointofInterest2",
                            Description = " Mumabi Description for point of interest2"
                        }
                    }
                },
                new CityDto
                {
                    ID= 2,
                    Name="Delhi",
                    Description="Capital of India",
                    PointsOfInterests = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id= 1,
                             Name= "Delhi point of interest1",
                             Description = " Delhi Description for point of interest1 "
                        },
                        new PointsOfInterestDto()
                        {
                            Id= 2,
                             Name= "Delhi point of interest2",
                             Description = " Delhi Description for point of interest2 "
                        }
                    }
                }
            };
        }
    }
}
