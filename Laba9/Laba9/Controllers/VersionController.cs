using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laba9.Services;
using Asp.Versioning;

namespace Laba9.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}")]
    public class VersionController : ControllerBase
    {
        private readonly IVersionService _versionService;

        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [Obsolete("This version is obsolete.", true)]
        public IActionResult GetV1()
        {
            var result = _versionService.GetIntValue();
            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion("2")]
        public IActionResult GetV2()
        {
            var result = _versionService.GetStringValue();
            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion("3")]
        public IActionResult GetV3()
        {
            var result = _versionService.GetExcelFile();
            return File(result.Content, result.ContentType, result.FileName);
        }
    }
}