using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public interface IMenuItem
    {
        List<string> DetailNameList();
        List<int> DetailValueList();
    }
}
