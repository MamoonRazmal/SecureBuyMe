namespace BuyMe.State
{
    public class CartOberserver
    {
        public Action? Cart;
        public void AddStateActionListener(Action Listen)
        {
            Cart +=Listen;
        }
        public void RemoveStateActionListener(Action Listen) 
        {
            Cart -= Listen;
        }
        public void NotifyObservers()
        {
            Cart?.Invoke();
        }
    }
}