namespace _002_MultipleImplementations
{
    public class MultiplyOperation : IMathOperation
    {
        public int PerformOperation(OperationRequest opRequest)
        {            
            return (opRequest.X * opRequest.Y);            
        }
    }
}
