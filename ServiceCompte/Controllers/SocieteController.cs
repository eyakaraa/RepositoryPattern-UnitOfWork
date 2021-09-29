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
    public class SocieteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SocieteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Societe>> GetAll()
        {
            var res = _unitOfWork.Societes.GetAll();
            _unitOfWork.Complete();
            return Ok(res);

        }

        [HttpPost("SocieteInRegion")]
        public IActionResult SocieteInRegion([FromQuery] string region)
        {
            var SocieteInRegion = _unitOfWork.Societes.GetAllSocieteInRegion(region);
            return Ok(SocieteInRegion);

        }
        [HttpPost("AddSociete")]
        public IActionResult AddSociete([FromQuery] Societe s)
        {
            _unitOfWork.Societes.Add(s);
            _unitOfWork.Complete();
            return Ok();

        }

        [HttpPut]
        public IActionResult updateSociete([FromQuery] Societe s)
        {
            _unitOfWork.Societes.Update(s);
            _unitOfWork.Complete();

            return Ok();

        }

      

    }

}
