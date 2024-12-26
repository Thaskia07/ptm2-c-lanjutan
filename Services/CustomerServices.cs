using pertemuan_2.Models;
using pertemuan_2.Models.DB;

namespace pertemuan_2.Services
{
    public class CustomerServices
    {
        //
        private readonly ApplicationContext _context;

        public CustomerServices(ApplicationContext context)
        {
            _context = context;
        }

        //tabel customer dari kelas customer

        public List<Customer> GetListCustomers()
        {
            //mencari customer dengan list
            //di datas isinya list
            //getlistcustomer dipanggil di controller
            var datas = _context.Customers.ToList();
            return datas;
        }

        public Customer GetCustomerById(int id)
        {
            // Mencari customer berdasarkan ID
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }


        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //model customer
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
                //harus melihat dlu kondisinya dan butuh validasi
                if (customerOld != null)
                {
                    customerOld.Name = customer.Name;
                    customerOld.Address = customer.Address;
                    customerOld.City = customer.City;
                    customerOld.PhoneNumber = customer.PhoneNumber;

                    _context.SaveChanges();

                    return true;

                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteCustomer(int id) {
            try
            {
                var costomerData = _context.Customers.
                FirstOrDefault(x => x.Id == id);

                if (costomerData != null)
                {
                    _context.Customers.Remove(costomerData);
                    _context.SaveChanges();

                    return true;

                }
                return false;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
