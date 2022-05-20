namespace _002_MultipleImplementations
{
    public class SubtractOperation : IMathOperation
    {
        public int PerformOperation(OperationRequest opRequest)
        {            
            return (opRequest.X - opRequest.Y);
        }
    }
}
