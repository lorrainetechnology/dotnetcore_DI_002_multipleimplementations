namespace _002_MultipleImplementations
{
    public class AddOperation : IMathOperation
    {
        public int PerformOperation(OperationRequest opRequest)
        {            
            return (opRequest.X + opRequest.Y);            
        }
    }
}
