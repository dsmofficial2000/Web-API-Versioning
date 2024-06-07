using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.V1.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countryDomainModel = CountriesData.Get();

            //Map Domain to DTO
            var response = new List<CountryDTOV1>();

            foreach(var countryDomain  in countryDomainModel)
            {
                response.Add(new CountryDTOV1
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                });
            }
            return Ok(response);
        }
    }
}
