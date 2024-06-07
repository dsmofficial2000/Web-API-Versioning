using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.V2.Controllers
{
    [Route("api/V2/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countryDomainModel = CountriesData.Get();

            //Map Domain to DTO
            var response = new List<CountryDTOV2>();

            foreach(var countryDomain  in countryDomainModel)
            {
                response.Add(new CountryDTOV2
                {
                    Id = countryDomain.Id,
                    CountryName = countryDomain.Name,
                });
            }
            return Ok(response);
        }
    }
}
