using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Deepend_Test.Business;

namespace Deepend_Test.Web.Controllers
{
    [RoutePrefix("api/chequeApi")]
    public class ChequeApiController : ApiController
    {
        private readonly IChequeService _chequeService;
        public ChequeApiController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }

        /// <summary>
        /// Get Cheque List
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getChequeList")]
        public HttpResponseMessage GetChequeList()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var result = _chequeService.GetAllChequeList()
                                           .ChequeModel;

                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
                return response;
            }
            return response;
        }

        /// <summary>
        /// Get Cheque Detail
        /// </summary>
        /// <param name="chequeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getChequeDetailById/{chequeId}")]
        public HttpResponseMessage GetChequeDetailById(int chequeId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var result = _chequeService.GetAllChequeList()
                                           .ChequeModel
                                           .FirstOrDefault(x => x.Id == chequeId);

                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
                return response;
            }
            return response;
        }
    }
}
