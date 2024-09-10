namespace Application.Extentions.LogicException
{
    /// <summary>
    /// this method used for returning business Logic Massages to Client 
    /// </summary>
    public class LogicException : Exception
    {


        public LogicException(string Massage) : base(Massage)
        {

        }
    }


}
