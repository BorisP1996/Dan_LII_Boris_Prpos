using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class CreateOrderViewModel : ViewModelBase
    {
        CreateOrder createOrder;
        Entity context = new Entity();

        public CreateOrderViewModel(CreateOrder createOrderOpen,string username)
        {
            createOrder = createOrderOpen;
            InputName = username;
            CakeList = new tblCakeList();
            View = new vwOrder();
            ViewList = getOrders();
        }
        private List<vwOrder> viewList;

        public List<vwOrder> ViewList
        {
            get { return viewList; }
            set { viewList = value;
                OnPropertyChanged("ViewList");
            }
        }
        private vwOrder view;

        public vwOrder View
        {
            get { return view; }
            set { view = value;
                OnPropertyChanged("View");
            }
        }



        private bool update;

        public bool Update
        {
            get { return update; }
            set { update = value; }
        }


        private string inputName;

        public string InputName
        {
            get { return inputName; }
            set { inputName = value; }
        }

        private tblCakeList cakeList;

        public tblCakeList CakeList
        {
            get { return cakeList; }
            set { cakeList= value;
                OnPropertyChanged("CakeList");
            }
        }

        private List<vwOrder> orderList;

        public List<vwOrder> OrderList
        {
            get { return orderList; }
            set { orderList = value;
                OnPropertyChanged("OrderList");
            }
        }

        private vwOrder order;

        public vwOrder Order
        {
            get { return order; }
            set { order = value;
                OnPropertyChanged("Order");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            try
            {
                tblCakeList newList = new tblCakeList();
                newList.LjubavnoGnezdo = CakeList.LjubavnoGnezdo;
                newList.Dobos = CakeList.Dobos;
                newList.Kinder = CakeList.Kinder;
                newList.Bomba = CakeList.Bomba;
                newList.Lincer = CakeList.Lincer;
                newList.Cheese = CakeList.Cheese;
                context.tblCakeLists.Add(newList);

                tblOrder newOrder = new tblOrder();
                newOrder.CakeListID = newList.CakeListID;
                newOrder.OrderDate = DateTime.Now;
                tblUser userToFind = (from r in context.tblUsers where r.Username==InputName select r).FirstOrDefault();
                newOrder.UserID = userToFind.UserID;
                newOrder.TotalPrice= (newList.LjubavnoGnezdo * (1000 + (0.2 * 1000)) + newList.Lincer * (2000 + (0.2) * 2000) + newList.Cheese * (1200 + (0.2 * 1200)) +newList.Dobos * (2500 + (0.2 * 2500)) + newList.Bomba * (800 + (800 * 0.2)) + newList.Kinder * (1100 + (1100 * 0.2))).GetValueOrDefault();
                newOrder.NumberOfCakes = 0;
                context.tblOrders.Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("Order is saved");
                Update = true;
                ViewList = getOrders();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSaveExecute()
        {
            if (EverythingEmpty()==true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool EverythingEmpty()
        {
            if (String.IsNullOrEmpty(CakeList.LjubavnoGnezdo.ToString()) && String.IsNullOrEmpty(CakeList.Dobos.ToString()) && String.IsNullOrEmpty(CakeList.Lincer.ToString()) && String.IsNullOrEmpty(CakeList.Cheese.ToString()) && String.IsNullOrEmpty(CakeList.Bomba.ToString()) && String.IsNullOrEmpty(CakeList.Kinder.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            createOrder.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }


        private List<vwOrder> getOrders()
        {
            try
            {
                List<vwOrder> orderList = context.vwOrders.ToList();

                List<vwOrder> myOrders = new List<vwOrder>();
                tblUser userToFind = (from r in context.tblUsers where r.Username == InputName select r).FirstOrDefault();
                foreach (vwOrder item in orderList)
                {
                    if (item.UserID == userToFind.UserID) ;
                    {
                        myOrders.Add(item);
                    }
                }

                return myOrders;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return null;
            }
        }




    }
}
