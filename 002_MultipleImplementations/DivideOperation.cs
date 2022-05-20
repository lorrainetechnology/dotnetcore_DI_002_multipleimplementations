namespace _002_MultipleImplementations
{
    public class DivideOperation : IMathOperation
    {
        public int PerformOperation(OperationRequest opRequest)
        {            
            return (opRequest.X / opRequest.Y);            
        }
    }
}
