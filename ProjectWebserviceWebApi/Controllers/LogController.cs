using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectWebServiceWebApi.DAL;
using ProjectWebServiceWebApi.Models;

namespace ProjectWebServiceWebApi.Controllers
{
    public class LogController : ApiController
    {

        [HttpGet]
        public List<Log> GetLogByName(string name)
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;

            try
            {
                httpContext.Application.Lock();
                if (httpContext.Application["LogRepository"] == null)
                {
                    httpContext.Application["LogRepository"] = new LogRepository();
                }
                LogRepository logRepo = httpContext.Application["LogRepository"] as LogRepository;
                return logRepo.FindLogByName(name);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                httpContext.Application.UnLock();
            }

        }

        [HttpGet]
        [Route ("api/Log/{id:int}")]
        public List<Log> GetLogById(int id)
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;

            try
            {
                httpContext.Application.Lock();
                if (httpContext.Application["LogRepository"] == null)
                {
                    httpContext.Application["LogRepository"] = new LogRepository();
                }
                LogRepository logRepo = httpContext.Application["LogRepository"] as LogRepository;
                return logRepo.FindLogById(id.ToString());
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                httpContext.Application.UnLock();
            }
        }

        [HttpGet]
        [Route("api/Log/GetFullList")]
        public List<Log> GetFullList()
        {
            var httpContext = Request.Properties["MS_HttpContext"] as System.Web.HttpContextWrapper;

            try
            {
                httpContext.Application.Lock();
                if (httpContext.Application["LogRepository"] == null)
                {
                    httpContext.Application["LogRepository"] = new LogRepository();
                }
                LogRepository logRepo = httpContext.Application["LogRepository"] as LogRepository;
                return logRepo.GetFullList();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                httpContext.Application.UnLock();
            }
        }
    }
}
