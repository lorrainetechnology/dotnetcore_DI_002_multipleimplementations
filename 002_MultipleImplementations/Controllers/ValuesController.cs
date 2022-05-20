using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _002_MultipleImplementations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Func<MathOperationType, IMathOperation> _mathOperationDelegate;
        public ValuesController(Func<MathOperationType, IMathOperation> mathOperationDelegate)
        {
            _mathOperationDelegate = mathOperationDelegate;
        }
        [HttpPost]
        public ActionResult<int> Post([FromBody] OperationRequest opRequest)
        {
            opRequest.OperationType = (MathOperationType)opRequest.OperationEnumValue;
            IMathOperation mathOperation = _mathOperationDelegate(opRequest.OperationType);
            return mathOperation.PerformOperation(opRequest);            
        }
    }
}
