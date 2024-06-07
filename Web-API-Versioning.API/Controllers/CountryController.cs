using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.V1.Controllers
{
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountryController : ControllerBase
    {
        //https://localhost:7092/api/Country?api-version=1.0
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetV1()
        {
            var countryDomainModel = CountriesData.Get();

            //Map Domain to DTO
            var response = new List<CountryDtoV1>();

            foreach(var countryDomain  in countryDomainModel)
            {
                response.Add(new CountryDtoV1
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                });
            }
            return Ok(response);
        }


        //https://localhost:7092/api/Country?api-version=2.0
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetV2()
        {
            var countryDomainModel = CountriesData.Get();

            //Map Domain to DTO
            var response = new List<CountryDtoV2>();

            foreach (var countryDomain in countryDomainModel)
            {
                response.Add(new CountryDtoV2
                {
                    Id = countryDomain.Id,
                    CountryName = countryDomain.Name,
                });
            }
            return Ok(response);
        }
    }
}
