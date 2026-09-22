namespace Task_4.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            float total = CalculateOrderTotal(selected_order);
            Console.WriteLine(total);
        }
    }
}