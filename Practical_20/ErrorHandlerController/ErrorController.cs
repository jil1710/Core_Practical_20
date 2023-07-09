using Microsoft.AspNetCore.Mvc;

namespace Practical_20.ErrorHandlerController
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this._logger = logger;
        }

        public IActionResult NotFoundEx()
        {
            _logger.LogError("Accessing Not Found Page 404 Error");
            return View();
        }

        public IActionResult Ambiguous()
        {
            _logger.LogError($"{nameof(Ambiguous)} Page Request Occure!");
            return View();
        }
        public IActionResult BadRequestEx()
        {
            _logger.LogError($"{nameof( BadRequest)} Occure!");
            return View();
        }
        public IActionResult InternalServerError()
        {
            _logger.LogError("Internal Server Error Occure!");
            return View();
        }
        public IActionResult LoopDetected()
        {
            _logger.LogError($"{nameof(LoopDetected)} Error Occure!");
            return View();
        }
        public IActionResult UnAuthorized()
        {
            _logger.LogError("Unauthorized access occure!");
            return View();
        }
    }
}
