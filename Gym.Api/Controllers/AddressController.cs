using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Address")]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(AddressEntity address)
        {
            var insert = await _addressService.Insert(address);

            if (insert)
                return Ok(new { message = "Endereço salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar o endereço." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(AddressEntity address)
        {
            var update = await _addressService.Update(address);

            if (update)
                return Ok(new { message = "Endereço atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar o endereço." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(AddressEntity address)
        {
            var delete = await _addressService.Delete(address);

            if (delete)
                return Ok(new { message = "Endereço deletado com sucesso." });

            return BadRequest(new { message = "Erro ao deletar o endereço." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var address = await _addressService.GetById(id);

            if (address != null)
                return Ok(address);

            return BadRequest(new { message = "Endereço não encontrado." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var adresses = await _addressService.GetAll();

            if (adresses != null)
                return Ok(adresses);

            return BadRequest(new { message = "Nenhum endereço encontrado." });
        }
    }
}