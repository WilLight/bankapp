using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApp.Server.Database;
using BankApp.Shared.Data;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private LiteDbCustomerRepo repo_;
        public CustomerController(ILogger<CustomerController> logger, LiteDbCustomerRepo repo)
        {
            _logger = logger;
            repo_ = repo;
        }

        [HttpPost]
        public ActionResult Add(Customer dto)
        {
            if (repo_.GetByUserName(dto.Credentials.UserName) == null)
                return BadRequest();
            repo_.Insert(dto);
            return Ok();
        }
    }
}