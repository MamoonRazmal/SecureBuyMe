namespace BuyMe.State
{
    public class PriceObserver
    {
        protected Action<decimal>? _listeners;
        public void AddStateActionListener(Action<decimal> listner)
        {
            if (listner is not null)
            {
                _listeners += listner;
            }

        }
        public void RemoveStateActionListener(Action<decimal> listner)

        {
            if (listner is not null)
            {
                _listeners -= listner;
            }
        }
        public void Notify(decimal price)
        {
            if (_listeners is not null)
            {
                _listeners?.Invoke(price);
            }
        }

    }
}