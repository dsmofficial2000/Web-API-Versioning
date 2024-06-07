using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countryDomainModel = CountriesData.Get();

            //Map Domain to DTO
            var response = new List<CountryDTO>();

            foreach(var countryDomain  in countryDomainModel)
            {
                response.Add(new CountryDTO
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                });
            }
            return Ok(response);
        }
    }
}
