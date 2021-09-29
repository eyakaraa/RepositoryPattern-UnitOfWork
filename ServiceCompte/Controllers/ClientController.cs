using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCompte.Domain.Entities;
using ServiceCompte.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCompte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            var res=_unitOfWork.Clients.GetAll();
            _unitOfWork.Complete();
            return Ok(res);

        }

        [HttpGet("GetParId")]
        public ActionResult<IEnumerable<Client>> GetParId([FromQuery] int c)
        {
            var res = _unitOfWork.Clients.GetById(c) ;
            _unitOfWork.Complete();
            return Ok(res);

        }

        [HttpPost]
        public IActionResult AddClient([FromQuery] Client c)
        {
            _unitOfWork.Clients.Add(c);
            _unitOfWork.Complete();
            return Ok();

        }

        [HttpPut]
        public IActionResult updateClient([FromQuery] Client c)
        {
            _unitOfWork.Clients.Update(c);
            _unitOfWork.Complete();

            return Ok();

        }
    }
}
