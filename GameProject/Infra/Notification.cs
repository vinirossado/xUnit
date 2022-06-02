namespace GameProject.Infra
{
    public abstract class Notification
    {
        public string MessageType { get; protected set; }

        protected Notification()
        {
            MessageType = GetType().Name;
        }
    }
}
