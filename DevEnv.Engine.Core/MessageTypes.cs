namespace DevEnv.Engine.Core
{
    public class ProgressMessage
    {
        public int Value { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public bool Intermediate { get; set; } = false;
    }
}