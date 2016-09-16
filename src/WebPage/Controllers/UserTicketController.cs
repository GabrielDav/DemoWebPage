using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPage.Models;

namespace WebPage.Controllers
{
    [Route("api/tickets")]
    public class UserTicketController : BaseController
    {
        private readonly IUserTicketService _service;

        private readonly ILogger<UserTicketController> _logger;

        public UserTicketController(ILogger<UserTicketController> logger, IMapper mapper, IUserTicketService service) : base(mapper)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            _service = service;
            
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }
        
        /// <summary>
        /// Returns all user tickets
        /// </summary>
        /// <returns>UserTickets[]</returns>
        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            _logger.LogDebug("Executing GET api/tickets");
            var response = await _service.GetAllTicketsAsync();
            _logger.LogDebug($"GetTickets returned {response.Result}");
            return ServiceResult<UserTicket[], UserTicketModel[]>(response);
        }
        
        /// <summary>
        /// Saves new user ticket into database
        /// </summary>
        /// <param name="model">UserTicket model</param>
        /// <returns>200 on Success</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserTicketModel model)
        {
            _logger.LogDebug("Executing POST api/tickets");
            if (!ModelState.IsValid)
            {
                _logger.LogDebug("Model is not valid");
                return BadRequest(ModelState);
            }
            var response = await _service.RegisterUserTicketAsync(_mapper.Map<UserTicket>(model));
            _logger.LogDebug($"RegisterUserTicketAsync returned {response.Result}");
            return ServiceResult(response);
        }

    }
}
