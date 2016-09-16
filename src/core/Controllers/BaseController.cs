using System;
using System.Net;
using AutoMapper;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebPage.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected BaseController(IMapper mapper)
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper;
        }

        private ActionResult ErrorResponse(ServiceResponse response)
        {
            switch (response.Result)
            {
                case Result.NotFound:
                    return StatusCode((int)HttpStatusCode.NotFound, response.Error);
                case Result.BadRequest:
                    return StatusCode((int)HttpStatusCode.BadRequest, response.Error);
                case Result.InternalError:
                    return StatusCode((int)HttpStatusCode.InternalServerError, response.Error);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected ActionResult ServiceResult<T, TModel>(ServiceResponse<T> response)
        {
            if (response.Result == Result.Success)
                return Ok(_mapper.Map<TModel>(response.Model));
            return ErrorResponse(response);
        }

        protected ActionResult ServiceResult(ServiceResponse response)
        {
            if (response.Result == Result.Success)
                return Ok();
            return ErrorResponse(response);
        }
    }
}
