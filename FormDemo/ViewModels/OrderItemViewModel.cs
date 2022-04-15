using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using FormDemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FormDemo.ViewModels
{

    public enum OrderTimingPriority
    {
        Medium,
        High
    }
    public class OrderItemViewModel : BaseViewModel
    {
        public OrderItemViewModel(Order order, int totalPage, int pageIndex)
        {
            Id = order.Id;
            QueueNumber = order.QueueNumber;
            TotalItems = order.TotalItems;
            CashierName = order.CashierName;
            Description = order.Description;
            CreatedAt = order.CreatedAt;
            TotalPage = totalPage;
            PageIndex = pageIndex;

            UpdateLineItemViewModel(order.LineItems);

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CountingTime = DateTime.Now.Subtract(order.CreatedAt);
                return true;
            }); 
        }

        private void UpdateLineItemViewModel(List<LineItem> lineItems)
        {
            LineItemViewModels.Clear();
            var startIndex = _pageIndex * AppConstants.MaxLineItemInOrder;
            var lineItemViewModelCount = (lineItems.Count - startIndex) >= AppConstants.MaxLineItemInOrder
                ? AppConstants.MaxLineItemInOrder
                : (lineItems.Count - startIndex);
            for (var i = 0; i < lineItemViewModelCount; i++)
            {
                LineItemViewModels.Add(new LineItemViewModel(lineItems[startIndex + i]));
            }
            
            HeightRequest = lineItemViewModelCount * AppConstants.LineItemHeight;
        }
        
        public string Id { get; set; }
        public string QueueNumber { get; set; }
        public int TotalItems { get; set; }
        public string CashierName { get; set; }
        public string Description { get; set; }
        public static DateTime CreatedAt { get; set; }
        
        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            set => SetProperty(ref _pageIndex, value);
        }
        
        private int _totalPage;
        public int TotalPage
        {
            get => _totalPage;
            set => SetProperty(ref _totalPage, value);
        }

        private double _heightRequest;
        public double HeightRequest
        {
            get => _heightRequest;
            set => SetProperty(ref _heightRequest, value);
        }


        private ObservableCollection<LineItemViewModel> _lineItemViewModels = new ObservableCollection<LineItemViewModel>();
        public ObservableCollection<LineItemViewModel> LineItemViewModels
        {
            get => _lineItemViewModels;
            set => SetProperty(ref _lineItemViewModels, value);
        }
        

        private TimeSpan _countingTime;
        public TimeSpan CountingTime
        {
            get => _countingTime;
            set
            {
                SetProperty(ref _countingTime, value);
                Priority = value.TotalSeconds > 60 ? OrderTimingPriority.High : OrderTimingPriority.Medium;
            }
        }

        private OrderTimingPriority _priority;

        public OrderTimingPriority Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }
    }
}
