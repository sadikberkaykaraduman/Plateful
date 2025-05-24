using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet("GetAllFeatures")]
        public IActionResult GetAllFeatures()
        {
            var features = _featureService.TGetListAll();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(features));
        }

        [HttpGet("GetFeatureById/{id}")]
        public IActionResult GetFeatureById(int id)
        {
            var feature = _featureService.TGetById(id);
            return Ok(_mapper.Map<GetFeatureDto>(feature));
        }

        [HttpPost("AddFeature")]
        public IActionResult AddFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);
            return Ok("Feature was added");
        }

        [HttpPut("UpdateFeature")]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);
            return Ok("Feature was updated");
        }

        [HttpDelete("DeleteFeature/{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            _featureService.TDelete(feature);
            return Ok("Feature was deleted");
        }
    }
}
