using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql_core_test.Models;

namespace Npgsql_core_test.Controllers
{

    [Route("api/[controller]")]
    public class DataEventRecordsController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public DataEventRecordsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<DataEventRecord> Get()
        {
            return _dataAccessProvider.GetDataEventRecords();
        }

        [HttpGet]
        [Route("SourceInfos")]
        public IEnumerable<SourceInfo> GetSourceInfos(bool withChildren)
        {
            return _dataAccessProvider.GetSourceInfos(withChildren);
        }

        [HttpGet("{id}")]
        public DataEventRecord Get(long id)
        {
            return _dataAccessProvider.GetDataEventRecord(id);
        }

        [HttpPost]
        public void Post([FromBody]DataEventRecord value)
        {
            _dataAccessProvider.AddDataEventRecord(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]DataEventRecord value)
        {
            _dataAccessProvider.UpdateDataEventRecord(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dataAccessProvider.DeleteDataEventRecord(id);
        }
    }
}