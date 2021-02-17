namespace MoqExampleBackEnd
{
    public interface ISaleCreator
    {
        string CalculateTotal(string selectedItem, string currency, int quantity);
    }
}