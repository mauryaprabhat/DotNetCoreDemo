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
                    Description ="FilmCity of India"
                },
                new CityDto
                {
                    ID= 2,
                    Name="Delhi",
                    Description="Capital of India"
                }
            };
        }
    }
}
