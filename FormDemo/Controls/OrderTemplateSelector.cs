using FormDemo.ViewModels;
using Xamarin.Forms;

namespace FormDemo.Controls
{
    public class OrderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate StartTemplate { get; set; }
        public DataTemplate MiddleTemplate { get; set; }
        public DataTemplate EndTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var order = (OrderItemViewModel) item;
            var pageIndex = order.PageIndex;
            var totalPage = order.TotalPage;
            switch (pageIndex)
            {
                case 0 when totalPage == 1:
                    return DefaultTemplate;
                case 0 when totalPage > 1:
                    return StartTemplate;
            }

            return pageIndex + 1 == totalPage ? EndTemplate : MiddleTemplate;
        }
    }
}