using Microsoft.AspNetCore.Mvc;
using SecurityTesting.SAST;
using SecurityTesting.DAST;
using SecurityTesting.PenTest;
using SecurityTestingAPI.Models;

namespace SecurityTestingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityTestsController : ControllerBase
    {
        private readonly SASTService _sastService;
        private readonly DASTService _dastService;
        private readonly PenetrationTestingService _penTestService;

        public SecurityTestsController(SASTService sastService, DASTService dastService, PenetrationTestingService penTestService)
        {
            _sastService = sastService;
            _dastService = dastService;
            _penTestService = penTestService;
        }

        [HttpPost("start-sast")]
        public IActionResult StartSAST([FromBody] string codeBasePath)
        {
            _sastService.AnalyzeCode(codeBasePath);
            return Ok("SAST started");
        }

        [HttpPost("start-dast")]
        public async Task<IActionResult> StartDAST([FromBody] string targetUrl)
        {
            await _dastService.StartScan(targetUrl);
            return Ok("DAST started");
        }

        [HttpPost("start-pen-test")]
        public async Task<IActionResult> StartPenTest([FromBody] PenTestRequest request)
        {
            await _penTestService.RunExploit(request.ModuleName, request.Target);
            return Ok("Penetration Test started");
        }
        [HttpPost("generate-report")]
        public IActionResult GenerateReport([FromBody] List<Vulnerability> vulnerabilities, [FromQuery] string filePath)
        {
            // Implementation of report generation
            return Ok("Report generated");
        }

    }
}
