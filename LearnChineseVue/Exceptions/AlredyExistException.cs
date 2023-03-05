namespace LearnChineseVue.Exceptions
{
    public class AlredyExistException : Exception
    {
        public AlredyExistException(string message) : base(message)
        {
        }

        public AlredyExistException()
        {
        }
    }
}
