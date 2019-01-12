namespace LibBusinessLayer.BIL.Infrastructure
{
    /// <summary>
    /// This class will store information about the success of the operation.The Succedeed property indicates
    /// whether the operation is successful, and the Message and Property properties will store the error message and the property, respectively
    /// An error has occurred.
    /// </summary>
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
