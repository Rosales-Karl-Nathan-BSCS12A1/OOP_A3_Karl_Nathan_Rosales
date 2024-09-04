interface IMenuService
{
    void AddMenuItem(string item, decimal price);
    void ViewMenu();
    void PlaceOrder();
    void ViewOrder();
    void CalculateTotal();
}