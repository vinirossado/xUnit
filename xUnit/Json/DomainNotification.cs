using Game.Infra;

namespace Game.Json
{
    public class DomainNotification : Notification
    {
        #region Properties

        public string Key { get; private set; }
        public string Value { get; private set; }

        #endregion

        #region Constructors

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        #endregion
    }
}
