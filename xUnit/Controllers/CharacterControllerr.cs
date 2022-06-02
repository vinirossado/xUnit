using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterControllerr : ControllerBase
    {
        #region Properties
        #endregion Properties

        #region Constructors
        public CharacterControllerr() : base()
        {
            
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Busca Atrações por id da atração
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AttractionViewModel</returns>
        [HttpGet, Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> GetById([FromRoute] int id)
        {
            //var attractionDb = await _attractionApp.FindByIdAsync((int)id);
            //var response = _mapper.Map<AttractionViewModel>(attractionDb);

            //return ResolveReturn(response);
            return Ok();
        }

           

        /// <summary>
        /// Busca lista com todas as Atrações
        /// </summary>
        /// <returns>Lista de object</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            //var attraction = await _attractionApp.GetAllAsync();
            //var response = _mapper.Map<IEnumerable<object>>(attraction);
            //return ResolveReturn(response);
            return Ok();

        }

        /// <summary>
        /// Insere nova Atração
        /// </summary>
        /// <param name="model"></param>
        /// <returns>object</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Post([FromBody] object model)
        {
            //if (!ModelState.IsValid) return BadRequestModelState();

            //var attraction = _mapper.Map<Attraction>(model);
            //await _attractionApp.AddAsync(attraction);

            //return ResolveReturn(model);
            return Ok();

        }

        /// <summary>
        /// Atualiza Atração pelo id da atração
        /// </summary>
        /// <param name="model"></param>
        /// <returns>object</returns>
        [HttpPut]
        public ActionResult<object> Put([FromBody] object model)
        {
            //if (!ModelState.IsValid) return BadRequestModelState();

            //var attraction = _mapper.Map<Attraction>(model);

            //_attractionApp.UpdateAsync(attraction);

            //return ResolveReturn(_mapper.Map<AttractionViewModel>(attraction));
            return Ok();

        }
        #endregion Methods
    }
}
